namespace SkyMapCSharp
{


    /**
     * @brief Structure to represent a star
     */
    public class Star : ICelestialObject
    {
        public double _right_ascension;
        public double _declination;

        public Star(double RA, double Dec)
        {
            _right_ascension = (RA);
            _declination = (Dec);
        }

        public Star()
        {
        }

        public double GetRA()
        {
            return _right_ascension;
        }

        public double GetDec()
        {
            return _declination;
        }

        public void SetRA(double RA)
        {
            _right_ascension = RA;
        }

        public void SetDec(double Dec)
        {
            _declination = Dec;
        }

    }

}