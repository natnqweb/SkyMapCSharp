namespace SkyMapCSharp
{
    public class DateTimeValues
    {
        public double year = 0;
        public double month = 0;
        public double day = 0;
        public double time = 0;

        public DateTimeValues(double y, double m, double d, double t)
        {
            year = y;
            month = m;
            day = d;
            time = t;
        }

        public DateTimeValues()
        {
        }
    }
}