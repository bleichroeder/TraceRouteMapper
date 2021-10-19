using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraceRouteMapper.DataAccess;

namespace TraceRouteMapper
{
    public partial class MainWindow : Form
    {
        CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        bool Running = false;

        readonly GMapOverlay Markers = new GMapOverlay("markers");
        readonly GMapOverlay Routes = new GMapOverlay("routes");
        readonly List<PointLatLng> Points = new List<PointLatLng>();

        private string pubIP = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            InitializeMap();
            AcceptButton = StartTraceButton;
            CancelButton = StartTraceButton;
            Text += " v" + Assembly.GetEntryAssembly().GetName().Version;
        }

        private void InitializeMap()
        {
            Task.Run(() =>
            {
                MapControl.Invoke(new MethodInvoker(() =>
                {
                    MapControl.ShowCenter = false;
                    MapControl.MapProvider = GoogleMapProvider.Instance;
                    MapControl.Overlays.Add(Markers);
                    MapControl.Overlays.Add(Routes);
                }));

                try
                {
                    using (WebClient c = new WebClient())
                    {
                        pubIP = c.DownloadString("https://api.ipify.org");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                if (pubIP != null)
                {
                    GeoLocation response = new LocationAccess()
                .ReturnGeoLocationFromIP(pubIP);

                    if (response.HasLocationData())
                    {
                        double.TryParse(response.Latitude, out double lat);
                        double.TryParse(response.Longitude, out double longt);

                        MapControl.Invoke(new MethodInvoker(() =>
                        {
                            MapControl.Position = new PointLatLng()
                            {
                                Lat = lat,
                                Lng = longt
                            };
                        }));
                    }
                }

                LoadingLabel.Invoke(new MethodInvoker(() =>
                {
                    LoadingLabel.Visible = false;
                }));
                MapControl.Invoke(new MethodInvoker(() =>
                {
                    MapControl.Zoom = 5;
                    MapControl.Visible = true;
                }));
            });
        }

        public void StartTrace(string destination)
        {
            CancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => { TraceProcess(destination); }, CancellationTokenSource.Token);
        }

        private void TraceProcess(string destination)
        {
            bool error = false;

            try
            {
                int hopCount = 0;

                IPAddress destinationIP = new Ping()
                .Send(destination).Address;

                GeoLocation response = null;
                double lat = 0;
                double longt = 0;

                if (pubIP != null)
                {
                    response = new LocationAccess()
                        .ReturnGeoLocationFromIP(pubIP);

                    double.TryParse(response.Latitude, out lat);
                    double.TryParse(response.Longitude, out longt);

                    if (lat != 0 && longt != 0)
                    {
                        var point = new PointLatLng()
                        {
                            Lat = lat,
                            Lng = longt
                        };

                        Points.Add(point);

                        AddMarker(
                            point,
                            GMarkerGoogleType.yellow_dot,
                            string.Format(
                                "\nIP: {0}\nHop: {1}\n",
                                response.IP,
                                0
                                ));

                        RefreshRoute();

                        SetMapPosition(point);

                        AddTableRow(new string[] {
                            hopCount.ToString(),
                            response.IP,
                            "0",
                            "null",
                            response.Country_Name,
                            response.Region_Name,
                            response.City,
                            response.Zip,
                            response.Latitude,
                            response.Longitude
                        }, Color.Yellow);

                        SetStatus(string.Format("Running trace: {0} @{1}", destination, destinationIP));
                    }
                }

                hopCount++;

                using (var pinger = new Ping())
                {
                    for (int ttl = 1; ttl <= 30; ttl++)
                    {
                        if (CancellationTokenSource.IsCancellationRequested)
                        {
                            break;
                        }

                        DateTime pStart = DateTime.UtcNow;

                        PingReply reply = pinger.Send(
                            destination,
                            4000,
                            new byte[32],
                            new PingOptions(ttl, true)
                            );

                        DateTime pEnd = DateTime.UtcNow;

                        if (reply.Status == IPStatus.Success || reply.Status == IPStatus.TtlExpired)
                        {
                            response = null;

                            response = new LocationAccess()
                            .ReturnGeoLocationFromIP(reply.Address.ToString());

                            double.TryParse(response.Latitude, out lat);
                            double.TryParse(response.Longitude, out longt);

                            AddTableRow(new string[] {
                                        hopCount.ToString(),
                                        reply.Address.ToString(),
                                        response.Hostname,
                                        (pEnd - pStart).TotalMilliseconds + "ms",
                                        response.Country_Name,
                                        response.Region_Name,
                                        response.City,
                                        response.Zip,
                                        response.Latitude,
                                        response.Longitude
                                    }, Color.White);

                            if (lat != 0 && longt != 0)
                            {
                                var point = new PointLatLng()
                                {
                                    Lat = lat,
                                    Lng = longt
                                };

                                AddMarker(
                                    point,
                                    GMarkerGoogleType.blue_dot,
                                    string.Format(
                                        "\nIP: {0}\nHop: {1}\n",
                                        reply.Address,
                                        hopCount
                                        ));

                                Points.Add(point);

                                SetMapPosition(point);

                                RefreshRoute();
                            }
                        }

                        if (reply.Status == IPStatus.TimedOut)
                        {
                            AddTableRow(new string[] {
                                        hopCount.ToString(),
                                        "RTO",
                                        "-",
                                        "-",
                                        "-",
                                        "-",
                                        "-",
                                        "-",
                                        "-",
                                        "-"
                                    }, Color.Salmon);

                            hopCount++;
                            continue;
                        }

                        if (reply.Status != IPStatus.TtlExpired && reply.Status != IPStatus.TimedOut || reply.Address == destinationIP)
                        {
                            if (Markers.Markers.Count > 0)
                            {
                                var lMark = Markers.Markers.Last();

                                if (lMark != null)
                                {
                                    Markers.Markers.Remove(lMark);

                                    AddMarker(
                                        new PointLatLng(lMark.Position.Lat, lMark.Position.Lng),
                                        GMarkerGoogleType.green_dot,
                                        string.Format("\nIP: {0}\nHop: {1}",
                                            reply.Address,
                                            hopCount)
                                        );

                                    OutputGrid.Invoke(new MethodInvoker(() =>
                                    {
                                        OutputGrid.Rows[OutputGrid.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                                    }));
                                }
                            }

                            break;
                        }
                        hopCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                if (ex.InnerException != null)
                {
                    error = true;

                    if (ex.InnerException.Message.ToLower().Contains("no such host is known"))
                    {
                        SetStatus(ex.InnerException.Message);
                    }
                }
            }

            if (!error)
            {
                SetStatus("Ready...");
            }

            StartTraceButton.Invoke(new MethodInvoker(() =>
            {
                StartTraceButton.Text = "TraceRoute";
            }));

            Running = false;
        }

        private async void StartTraceButton_Click(object sender, EventArgs e)
        {
            if (Running)
            {
                await Cancellation();
            }
            else
            {
                if (!string.IsNullOrEmpty(InputTextBox.Text))
                {
                    await Startup();
                }
            }
        }

        private async Task<bool> Cancellation()
        {
            CancellationTokenSource.Cancel();
            StartTraceButton.Text = "Aborting...";
            ControlPanel.Enabled = false;

            while (Running)
                await Task.Delay(100);

            ClearMapData();
            OutputGrid.Rows.Clear();
            ControlPanel.Enabled = true;
            return true;
        }

        private async Task<bool> Startup()
        {
            ClearMapData();
            OutputGrid.Rows.Clear();
            StartTrace(InputTextBox.Text);
            StartTraceButton.Text = "Abort";
            Running = true;
            await Task.Delay(10);
            return true;
        }

        private void ClearMapData()
        {
            Points.Clear();
            Markers.Clear();
            Routes.Clear();
        }

        private void AddMarker(PointLatLng point, GMarkerGoogleType markerType, string toolTipText)
        {
            GMarkerGoogle marker = new GMarkerGoogle(point, markerType)
            {
                ToolTipText = toolTipText
            };
            Markers.Markers.Add(marker);
        }

        private void RefreshRoute()
        {
            Routes.Routes.Add(new GMapRoute(Points, "Route")
            {
                Stroke = new Pen(Color.Red, 2)
            });
        }

        private void SetStatus(string status)
        {
            StatusOutput.Invoke(new MethodInvoker(() =>
            {
                StatusOutput.Text = status;
            }));
        }

        private void AddTableRow(string[] dataArray, Color rowColor)
        {
            OutputGrid.Invoke(new MethodInvoker(() =>
            {
                OutputGrid.Rows.Add(dataArray);

                for (int i = 0; i < OutputGrid.Rows[OutputGrid.Rows.Count - 1].Cells.Count; i++)
                    OutputGrid.Rows[OutputGrid.Rows.Count - 1].Cells[i].ToolTipText = dataArray[i];

                OutputGrid.Rows[OutputGrid.Rows.Count - 1].DefaultCellStyle.BackColor = rowColor;
            }));
        }

        private void SetMapPosition(PointLatLng point)
        {
            MapControl.Invoke(new MethodInvoker(() =>
            {
                MapControl.Position = point;
            }));
        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            MapControl.Zoom += 1;
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            MapControl.Zoom -= 1;
        }
    }
}
