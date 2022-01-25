using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace sage
{
    public class Plot
    {
        #region Properties
        public DotNet.Highcharts.Highcharts Chart = new DotNet.Highcharts.Highcharts("chart");
        public DotNet.Highcharts.Options.Title Title = new DotNet.Highcharts.Options.Title();
        public DotNet.Highcharts.Options.XAxisTitle XTitle = new DotNet.Highcharts.Options.XAxisTitle();
        public DotNet.Highcharts.Options.YAxisTitle YTitle = new DotNet.Highcharts.Options.YAxisTitle();

        public DotNet.Highcharts.Options.XAxis XAxis = new DotNet.Highcharts.Options.XAxis();        
        public DotNet.Highcharts.Options.YAxis YAxis = new DotNet.Highcharts.Options.YAxis();        
 
        //        public DotNet.Highcharts.Options.PlotOptions Options = new DotNet.Highcharts.Options.PlotOptions();

        #endregion

        #region 
        public Plot(){
            Chart.SetTitle(Title);
            XAxis.Title = XTitle;
            YAxis.Title = YTitle;
            //YAxis.Min = 0;
            Chart.SetXAxis(XAxis);
            Chart.SetYAxis(YAxis);
       }

        public Plot(string[] titles){
            Title.Text = titles[0];
            Chart.SetTitle(Title);
            XTitle.Text = titles[1];
            XAxis.Title = XTitle;
            YTitle.Text = titles[2];
            YAxis.Title = YTitle;
            //YAxis.Min = 0;
            Chart.SetXAxis(XAxis);
            Chart.SetYAxis(YAxis);
       }


        #endregion 

        #region Set Values


        #endregion


        public string ToHtmlString()
        {
            return Chart.ToHtmlString();
        }

        #region Samples
        public void SetAsSample()
        {
            Chart.SetXAxis(new DotNet.Highcharts.Options.XAxis
            {
                Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
                   
            });
            Chart.SetSeries(new DotNet.Highcharts.Options.Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(new object[] { 29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 })
            });
        }
        #endregion
    }

    public class ScatterPlot : Plot
    {
        public DotNet.Highcharts.Options.Series[] series = new DotNet.Highcharts.Options.Series[10];
        public int nSeries;

        public ScatterPlot(string[] titles):base(titles)
        {
        }

        public ScatterPlot():base()
        {
        }

        public void setSeries( int n, int increment, string title, double[] v)
        {
            object[] values = new object[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = new DotNet.Highcharts.Options.Point { X = i * increment, Y = v[i] };
            }
 
            Chart.SetSeries(new DotNet.Highcharts.Options.Series{
                Type = DotNet.Highcharts.Enums.ChartTypes.Scatter,
                Data = new DotNet.Highcharts.Helpers.Data(values), 
                Name = title
            });
        }

        public string plotGrid( int xcol, GridView g)
        {
            // titles is an array
            // titles[0] - Header title
            // titles[1] - X Axis
            // titles[2] = Y Axis
            // xcol is the column with the x data
            int n = g.Rows[0].Cells.Count;
            DotNet.Highcharts.Options.Series[] series = new DotNet.Highcharts.Options.Series[n-1]; // n-1 excludes x column
            
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
                    j++;
                }
            }

            this.Chart.SetSeries(series);

            return ToHtmlString();
        }

        public string plotGrid(string title, int xcol, int[] cols, GridView g)
        {
            // Same as plotGrid, however only plots columns specified in cols
            int n = cols.Length;
            int n2 = g.Rows[0].Cells.Count;
            DotNet.Highcharts.Options.Series[] series = new DotNet.Highcharts.Options.Series[n];

            int j = 0; // Alternate counter - you do not set the xcol as a series
            for (int i = 0; i < n2; i++)
            {
                if (i != xcol && cols.Contains(i))
                {
                    series[j] = new DotNet.Highcharts.Options.Series
                    {
                        Type = DotNet.Highcharts.Enums.ChartTypes.Scatter,
                        Data = new DotNet.Highcharts.Helpers.Data(getDataFromGridColumn(xcol, i, g)),
                        Name = g.HeaderRow.Cells[i].Text
                    };
                    j++;
                }
            }

            this.Title.Text = title;
            this.Chart.SetSeries(series);

            return ToHtmlString();

        }

        public string plotScatterFromArray(string plotTitle, string XTitle, string YTitle, double[,] points)
        {
            // Set the points
            
            int n = points.Length/2;

            object[] values = new object[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = new DotNet.Highcharts.Options.Point { X = points[0,i], Y = points[1,i] };
            }

            DotNet.Highcharts.Options.Series[] series = new DotNet.Highcharts.Options.Series[1];

            series[0] = new DotNet.Highcharts.Options.Series
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Scatter,
                Data = new DotNet.Highcharts.Helpers.Data(values),
                Name = YTitle
            };

            Title.Text = plotTitle;
            XAxis.Title.Text = XTitle;
            YAxis.Title.Text = YTitle;

            Chart.SetSeries(series);
            return Chart.ToHtmlString();
        }

        public string plotScatterFromArray(double[,] points)
        {
            // Set the points

            int n = points.Length / 2;

            object[] values = new object[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = new DotNet.Highcharts.Options.Point { X = points[0, i], Y = points[1, i] };
            }

            DotNet.Highcharts.Options.Series[] series = new DotNet.Highcharts.Options.Series[1];

            series[0] = new DotNet.Highcharts.Options.Series
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Scatter,
                Data = new DotNet.Highcharts.Helpers.Data(values)
            };

            Chart.SetSeries(series);
            return Chart.ToHtmlString();
        }
        public object[] getDataFromGridColumn(int xcol, int ycol, GridView g)
         {
            // Answers a Point Array that can be used as Data in a series
            // xcol is the column with the x data

            int n = g.Rows.Count;
            object[] v = new object[n];
             for (int i = 0; i < n; i++)
             {
                 v[i] = new DotNet.Highcharts.Options.Point
                 {
                     X = Convert.ToDouble(g.Rows[i].Cells[xcol].Text),
                     Y = Convert.ToDouble(g.Rows[i].Cells[ycol].Text)
                 };
             }
            return v;
         }
    }
}