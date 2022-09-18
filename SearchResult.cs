namespace SkyMapCSharp
{


    /**
     * @brief data structure for storing search result Azimuth and Altitude
     */
    public class SearchResult
    {
        public double Azimuth;
        public double Altitude;

        // constructor
        public SearchResult(double Az, double Alt)
        {
            Azimuth = (Az);
            Altitude = (Alt);
        }

        public SearchResult()
        {
        }

        // setters and getters
        public void SetAzimuth(double _Azimuth)
        {
            Azimuth = _Azimuth;
        }

        public void SetAltitude(double _Altitude)
        {
            Altitude = _Altitude;
        }

        public double GetAzimuth()
        {
            return Azimuth;
        }

        public double GetAltitude()
        {
            return Altitude;
        }
    }

}