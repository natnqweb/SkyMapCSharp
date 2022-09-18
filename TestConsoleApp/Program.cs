using SkyMapCSharp;
ObserverPosition myPosition = new ObserverPosition(0, 0);
Star sirius = new Star();
SkyMap skymap = new SkyMap();
DateTimeValues dt = new DateTimeValues();

dt.year = 2021.00;
dt.month = 9.00;
dt.day = 4.00;
dt.time = 20.2; // UTC


sirius.SetRA(101.52);
sirius.SetDec(-16.7424);

myPosition.lattitude = 34.05;
myPosition.longitude = -118.24358;
skymap.celestial_object_ra_dec(sirius);
skymap.DateTime(dt.year, dt.month, dt.day, dt.time);
skymap.my_location(myPosition.GetLattitude(), myPosition.GetLongitude());
skymap.Calculate_all();

double az = skymap.get_star_Azimuth();
double alt = skymap.get_star_Altitude();
System.Console.WriteLine("Azimuth = " + az + " Altitude = " + alt);
