using Autofac;
using DriverClientLib.BLL.Infrastructure;
using NewronTestOWM.BLL.Interface;
using NewronTestOWM.DAL.Entitys.Weather;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Nevron;
using Nevron.Chart;
using Nevron.Chart.Windows;
using Nevron.Chart.WinForm;
using Nevron.Editors;
using Nevron.GraphicsCore;
using System.Drawing;

namespace NewronTestOWM
{
    public partial class Form1 : Form
    {
        private ILifetimeScope ioc;
        public Form1()
        {
            ioc = ConfigureContainer.Configure().BeginLifetimeScope();
            InitializeComponent();
            
        }

        private async void nButton1_Click(object sender, EventArgs e)
        {
           var locGeter =  ioc.Resolve<ILocationGetter>();
           var t = await locGeter.GetMyLocationAsync();
            if (t != null)
            {
                nRichTextLabel1.Text = t.Country_code+ ", " + t.Country_Name +  ", " + t.City;
                var weather = ioc.Resolve<IWeatherGeter>();
                var weather_data = await weather.GetWeathersAsync(t,10);
                if (weather_data != null)
                    SetDataToChart(weather_data);
            }
        }

        private void SetDataToChart(IEnumerable<WeatherData> data)
        {
            
            IntitChart();
            NChart chart = nChartControl1.Charts[0];
            NStockSeries stock = (NStockSeries)chart.Series[chart.Series.Count - 1];
            foreach(var d in data)
            {
                stock.OpenValues.Add(d.LowTemp);
                stock.HighValues.Add(d.MaxTemp);
                stock.LowValues.Add(d.LowTemp);
                stock.CloseValues.Add(d.Temp);
                stock.XValues.Add(d.DateTime.ToOADate());
            }
            nChartControl1.Refresh();
        }

        private void IntitChart()
        {
            nChartControl1.Clear();
            // setup chart
            NChart chart = nChartControl1.Charts[0];
            chart.Projection.SetPredefinedProjection(PredefinedProjection.Orthogonal);
            chart.LightModel.EnableLighting = false;
            chart.Axis(StandardAxis.Depth).Visible = false;
            chart.Wall(ChartWallType.Floor).Visible = false;
            chart.Wall(ChartWallType.Left).Visible = false;
            chart.BoundsMode = BoundsMode.Stretch;
            chart.Height = 40;
            chart.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(15, NRelativeUnit.ParentPercentage));
            chart.Size = new NSizeL(new NLength(80, NRelativeUnit.ParentPercentage), new NLength(75, NRelativeUnit.ParentPercentage));
            // setup X axis
            NAxis axis = chart.Axis(StandardAxis.PrimaryX);
            NDateTimeScaleConfigurator dateTimeScale = new NDateTimeScaleConfigurator();
            axis.ScaleConfigurator = dateTimeScale;

            dateTimeScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Back, true);
            dateTimeScale.MajorGridStyle.SetShowAtWall(ChartWallType.Floor, false);
            dateTimeScale.InnerMajorTickStyle.Length = new NLength(0);
            dateTimeScale.RoundToTickMin = true;
            dateTimeScale.RoundToTickMax = true;
            dateTimeScale.LabelGenerationMode = LabelGenerationMode.Stagger2;
            dateTimeScale.LabelFitModes = new LabelFitMode[] { LabelFitMode.AutoScale };

            // setup primary Y axis
            axis = chart.Axis(StandardAxis.PrimaryY);
            NStandardScaleConfigurator standardScale = (NStandardScaleConfigurator)axis.ScaleConfigurator;
            standardScale.MajorGridStyle.LineStyle.Pattern = LinePattern.Dot;
            standardScale.MajorGridStyle.SetShowAtWall(ChartWallType.Left, false);

            NScaleStripStyle stripStyle = new NScaleStripStyle(new NColorFillStyle(Color.Beige), null, true, 0, 0, 1, 1);
            stripStyle.Interlaced = true;
            stripStyle.SetShowAtWall(ChartWallType.Back, true);
            standardScale.StripStyles.Add(stripStyle);
            standardScale.InnerMajorTickStyle.Length = new NLength(0);

            Color customColor = Color.FromArgb(150, 150, 200);

            // setup the stock series
            NStockSeries stock = (NStockSeries)chart.Series.Add(SeriesType.Stock);
            stock.DataLabelStyle.Visible = false;
            stock.CandleStyle = CandleStyle.Bar;
            stock.CandleWidth = new NLength(0.5f, NRelativeUnit.ParentPercentage);
            stock.HighLowStrokeStyle.Color = customColor;
            stock.UpStrokeStyle.Width = new NLength(0);
            stock.DownStrokeStyle.Width = new NLength(0);
            stock.UpFillStyle = new NColorFillStyle(Color.LightGreen);
            stock.DownFillStyle = new NColorFillStyle(customColor);
            stock.Legend.Mode = SeriesLegendMode.SeriesLogic;
            stock.UseXValues = true;
            stock.InflateMargins = true;
        }

        private void nChartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
