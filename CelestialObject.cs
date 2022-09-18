namespace SkyMapCSharp
{
    public interface CelestialObject
    {

        double GetRA();

        double GetDec();

        void SetRA(double ra);

        void SetDec(double dec);
    }
}