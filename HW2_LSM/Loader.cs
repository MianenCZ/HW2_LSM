using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Mianen.Matematics.Geometry2D;

namespace HW2_LSM
{
	public class Loader
	{
		
		public Series[] Data;

		public string FileName { get; private set; }

		public Loader(string Path)
		{
			this.FileName = Path;
			StreamReader streamReader = new StreamReader((Stream)new FileStream(Path, FileMode.Open, FileAccess.Read));
			this.Data = new Series[2];
			Data[0] = new Series
			{
				Name = "Measurements",
				ChartType = SeriesChartType.Point,
				BorderWidth = 2,
				Color = Color.Blue
			};
			Data[1] = new Series
			{
				Name = "Trend",
				ChartType = SeriesChartType.Spline,
				BorderWidth = 1,
				Color = Color.Green
			};
			List<Point2D<double>> point2DList = new List<Point2D<double>>();
			string line;
			while ((line = streamReader.ReadLine()) != null)
			{
				string[] array = line.Split(new char[1]{';'}, StringSplitOptions.RemoveEmptyEntries);
				array = array.Select(q => q.Trim()).ToArray<string>();
				double num1 = double.Parse(array[0], (IFormatProvider)CultureInfo.InvariantCulture);
				double num2 = double.Parse(array[1], (IFormatProvider)CultureInfo.InvariantCulture);
				this.Data[0].Points.Add(new DataPoint(num1, num2));
				point2DList.Add(new Point2D<double>(num1, num2));
			}
			Polynom<double> polynom = Polynom<double>.Aproximate(point2DList.ToArray(), 2);
			for (double xValue = 50.0; xValue <= 250; ++xValue)
			{
				double yValue = polynom.DefVector[0, true] + xValue * polynom.DefVector[1, true] + xValue * xValue * polynom.DefVector[2, true];
				this.Data[1].Points.Add(new DataPoint(xValue, yValue));
			}
		}
	}
}

