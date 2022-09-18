namespace SkyMapCSharp
{
    public class ObserverPosition
    {
        public double lattitude = 0;
        public double longitude = 0;
        public ObserverPosition() { }
        public ObserverPosition(double lattitude, double longitude)
        {
            this.lattitude = lattitude;
            this.longitude = longitude;
        }
        public double GetLattitude()
        {
            return lattitude;
        }
        public double GetLongitude()
        {
            return longitude;
        }
    }
}