using SkyMapCSharp;

var skymap = new SkyMap();
var losAngeles = new ObserverPosition()
{
    lattitude = 34.05,
    longitude = -118.24358
};

var sirius = new Star()
{
    _right_ascension = 101.52,
    _declination = -16.7424
};

var dt = new DateTimeValues()
{
    year = 2021.00,
    month = 9.00,
    day = 4.00,
    time = 20.2 // UTC
};

skymap.SetCelestialObject(sirius);
skymap.DateTime(dt);
skymap.SetMyLocation(losAngeles);

skymap.CalculateAll();

double az = skymap.GetAzimuth();
double alt = skymap.GetAltitude();
System.Console.WriteLine("Azimuth = " + az + " Altitude = " + alt);
