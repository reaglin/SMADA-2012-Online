using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using sage;

namespace SMADA_2012.App_Code.SMADA
{
    public class SMADAPlot : ScatterPlot
    {
        public SMADAPlot() : base()
        {
            // Nothing done here
        }

        public SMADAPlot(string[] titles): base(titles)
        {
            // Nothing to do here
        }

        public string HydrographPlot(Hydrograph h)
        {
            int n = h.numberOfSteps;
            int ts = Convert.ToInt32(h.timeStep);

            Title.Text = h.Title.toString();
            XAxis.Title.Text = "Values (cfs)";
            YAxis.Title.Text = "Time (minutes)";
            YAxis.Min = 0;

            object[] runoff = new object[n];
            object[] excess = new object[n];
            for (int i = 0; i < n; i++)
            {
                runoff[i] = new DotNet.Highcharts.Options.Point { X = i * ts, Y = h.outflow[i] };
                excess[i] = new DotNet.Highcharts.Options.Point { X = i * ts, Y = h.excess[i] };
            }

            Chart.SetSeries(
            new DotNet.Highcharts.Options.Series[] {
                new DotNet.Highcharts.Options.Series {
                Type = DotNet.Highcharts.Enums.ChartTypes.Scatter,
                Data = new DotNet.Highcharts.Helpers.Data(runoff),
                 Name = "Runoff (cfs)"
            },
                new DotNet.Highcharts.Options.Series {
                Type = DotNet.Highcharts.Enums.ChartTypes.Scatter,
                Data = new DotNet.Highcharts.Helpers.Data(excess),
                 Name = "Excess (cfs)"
            }

            });

            return this.ToHtmlString();
        }

        public string RainfallPlot(Rainfall r)
        {
            int n = r.numberOfSteps();
            double ts = r.TimeStep.asDouble();

            Title.Text = r.Title.toString();
            YAxis.Title.Text = "Depth (in)";
            XAxis.Title.Text = "Time (minutes)";
            YAxis.Min = 0;

            object[] rainfall = new object[n];
            for (int i = 0; i < n; i++)
            {
                rainfall[i] = new DotNet.Highcharts.Options.Point { X = i * ts, Y = r.depth(i) };
            }


            Chart.SetSeries(
            new DotNet.Highcharts.Options.Series[] {
                new DotNet.Highcharts.Options.Series {
                Type = DotNet.Highcharts.Enums.ChartTypes.Scatter,
                Data = new DotNet.Highcharts.Helpers.Data(rainfall),
                Name = "Rainfall Depth (in)"}});

            return this.ToHtmlString();
        }

        public string plotRegression(int xcol, GridView g)
        {
            // titles is an array
            // titles[0] - Header title
            // titles[1] - X Axis
            // titles[2] = Y Axis
            // xcol is the column with the x data
            int n = g.Rows[0].Cells.Count;
            DotNet.Highcharts.Options.Series[] series = new DotNet.Highcharts.Options.Series[n - 1]; // n-1 excludes x column

            int j = 0; // Alternate counter - you do not set the xcol as a series
            for (int i = 0; i < n; i++)
            {
                if (i != xcol)
                {
                    series[j] = new DotNet.Highcharts.Options.Series
                    {
                        Type = DotNet.Highcharts.Enums.ChartTypes.Scatter,
                        Data = new DotNet.Highcharts.Helpers.Data(getDataFromGridColumn(xcol, i, g)),
                        Name = g.HeaderRow.Cells[i].Text
                    };

                    if (g.HeaderRow.Cells[i].Text == "Y Actual")
                        series[j].PlotOptionsScatter = new DotNet.Highcharts.Options.PlotOptionsScatter { LineWidth = 1 };

                    j++;
                }
            }

            this.Chart.SetSeries(series);

            return ToHtmlString();
        }
    }
}