namespace SkyMapCSharp
{


    /**
     * @brief Structure to represent a star
     */
    public class Star : CelestialObject
    {
        public double right_ascension;
        public double declination;

        public Star(double RA, double Dec)
        {
            right_ascension = (RA);
            declination = (Dec);
        }

        public Star()
        {
        }

        public double GetRA()
        {
            return right_ascension;
        }

        public double GetDec()
        {
            return declination;
        }

        public void SetRA(double RA)
        {
            right_ascension = RA;
        }

        public void SetDec(double Dec)
        {
            declination = Dec;
        }

    }

}