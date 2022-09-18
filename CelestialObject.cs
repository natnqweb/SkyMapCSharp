namespace SkyMapCSharp
{
    public interface ICelestialObject
    {

        double GetRA();

        double GetDec();

        void SetRA(double ra);

        void SetDec(double dec);
    }
}