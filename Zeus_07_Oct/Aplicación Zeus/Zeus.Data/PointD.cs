using System;

namespace Zeus.Data
{
    [Serializable()]
    public struct PointD
    {
        public PointD(string x, string y)
        {
            X = double.Parse(x.Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator));
            Y = double.Parse(y.Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator));
        }
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return X.ToString().Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".")
                + " " + Y.ToString().Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
        }
        

        public static PointD FromSQLPoint(string Point)
        {
            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(@"POINT\(([0-9]*\.?[0-9]*)\s([0-9]*\.?[0-9]*)\)");
            return new PointD(re.Match(Point).Groups[1].ToString(), re.Match(Point).Groups[2].ToString());
        }

        public static string ToPgString(double number)
        {
            return number.ToString().Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".");
        }

        public bool IsEmpty()
        {
            if (X == 0 && Y == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double X, Y;
    }
}
