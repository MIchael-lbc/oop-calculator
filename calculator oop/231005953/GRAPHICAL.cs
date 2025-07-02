
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NCalc;

namespace WindowsFormsApp1
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
            SetupChart();
        }

        private void SetupChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea area = new ChartArea("MainArea");
            chart1.ChartAreas.Add(area);
            chart1.Series.Add("Function");
            chart1.Series["Function"].ChartType = SeriesChartType.Line;
            chart1.Series["Function"].Color = System.Drawing.Color.Blue;
        }

        private void btnPlot_Click_1(object sender, EventArgs e)
        {
            chart1.Series["Function"].Points.Clear();

            string expressionText = txtFunction.Text.Trim();

            if (!double.TryParse(txtXMin.Text, out double xMin) ||
                !double.TryParse(txtXMax.Text, out double xMax) ||
                string.IsNullOrWhiteSpace(expressionText))
            {
                MessageBox.Show("Please enter valid X range and function.");
                return;
            }

            if (xMax <= xMin)
            {
                MessageBox.Show("Xmax must be greater than Xmin.");
                return;
            }

            for (double x = xMin; x <= xMax; x += 0.1)
            {
                try
                {
                    Expression expr = new Expression(expressionText);
                    expr.Parameters["x"] = x;

                    var result = expr.Evaluate();
                    if (result != null && double.TryParse(result.ToString(), out double y))
                    {
                        chart1.Series["Function"].Points.AddXY(x, y);
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid function expression (e.g. use sin(x), x^2, etc.)");
                    return;
                }
            }

            chart1.ChartAreas[0].RecalculateAxesScale();
        }
    }
}
