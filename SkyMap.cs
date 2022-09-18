using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkyMapCSharp
{
    
    /**
     * @brief com.example.skymap.SkyMap a class that contains all essential
     *        functions to perform astronomic calculations
     *
     */
    public class SkyMap
    {
        public SkyMap() { }

        /**
         * @brief Construct a new com.example.skymap.SkyMap object
         *        when constructor is called without any input arguments you must
         *        provide all this information later in program
         * @param observer        Observer position
         * @param datetime        Date and time values
         * @param celestialobject Celestial object
         */
        public SkyMap(ObserverPosition observer, CelestialObject celestialobject, DateTimeValues datetime)
        {
            _lattitude = observer.lattitude;
            _longitude = observer.longitude;
            _declination = celestialobject.GetDec();
            _right_ascension = celestialobject.GetRA();
            _time = datetime.time;
            _year = datetime.year;
            _month = datetime.month;
            _day = datetime.day;

            if (_lattitude != 0 && _longitude != 0)
            {
                Calculate_all();
            }
        }

        /**
         * @brief Construct a new com.example.skymap.SkyMap object
         *        when constructor is called without any input arguments you must
         *        provide all this information later in program
         *
         * @param lattitude       - default value:0, type: double, details: geographic
         *                        coordinates
         * @param longitude       - default value:0, type: double, details: geographic
         *                        coordinates
         * @param declination     - default value:0, type: double, details:
         *                        com.example.skymap.Star coordinates
         * @param right_ascension - default value:0, type: double, details:
         *                        com.example.skymap.Star coordinates
         * @param year            - default value:0, type: double, details: datetime,
         *                        current year
         * @param month           - default value:0, type: double, details: datetime,
         *                        current month
         * @param day             - default value:0, type: double, details: datetime,
         *                        current day
         * @param time            - default value:0, type: double, details: datetime,
         *                        current time utc.
         */
        public SkyMap(double lattitude, double longitude, double declination, double right_ascension, double year,
                double month, double day, double time)
        {
            _lattitude = lattitude;
            _longitude = longitude;
            _declination = declination;
            _right_ascension = right_ascension;
            _time = time;
            _year = year;
            _month = month;
            _day = day;

            if (_lattitude != 0 && _longitude != 0)
            {
                Calculate_all();
            }
        }
        // leave empty if you want to use real_time calculations or provide all data to
        // calculate once and then you can also use update to calculate things in
        // real_time

        /**
         * @param lattitude - type: double, details: geographic coordinates
         * @param longitude - type: double, details: geographic coordinates
         * @return com.example.skymap.ObserverPosition return your lattitude and
         *         longitude
         * @brief function transfers your location deeper to program,
         *        so your location is taken for further calculations
         *        if your location is not constant you may want to provide it as an
         *        input for this function
         */
        public ObserverPosition my_location(double lattitude, double longitude) // returns pointer to array where your
                                                                                // location is stored or when provided data
                                                                                // it can update your position
        {
            _lattitude = lattitude;
            _longitude = longitude;
            _observer_position.lattitude = _lattitude;
            _observer_position.longitude = _longitude;
            return new ObserverPosition(_lattitude, _longitude);
        }

        /**
         * @return com.example.skymap.ObserverPosition return your lattitude and
         *         longitude
         * @brief function transfers your location deeper to program,
         *        so your location is taken for further calculations
         *        if your location is not constant you may want to provide it as an
         *        input for this function
         */
        public ObserverPosition my_location() // returns pointer to array where your location is stored or when provided
                                              // data it can update your position
        {
            return new ObserverPosition(_lattitude, _longitude);
        }

        /**
         * @param right_ascension - default value:0, type: double, details:
         *                        com.example.skymap.Star coordinates
         * @param declination     - default value:0, type: double, details:
         *                        com.example.skymap.Star coordinates
         * @return returns com.example.skymap.Star coordinates
         * @brief function:star_ra_dec
         *        this is another way to feed data for calculations input star
         *        coordinates
         */
        public Star star_ra_dec(double right_ascension, double declination)
        {
            _right_ascension = right_ascension;
            _declination = declination;
            _star.SetRA(_right_ascension);
            _star.SetDec(_declination);

            return _star;
        }

        /**
         * @return returns com.example.skymap.Star coordinates
         * @brief function:star_ra_dec
         */
        public Star star_ra_dec()
        {
            return _star;
        }

        /**
         * @param celestial_object - default value:nullptr, type:
         *                         com.example.skymap.CelestialObject(double,double),
         *                         details: com.example.skymap.Star coordinates
         * @return returns com.example.skymap.Star coordinates in form of
         *         com.example.skymap.CelestialObject*
         * @brief function:CelebralObject_ra_dec
         *        this is another way to feed data for calculations input star
         *        coordinates
         */
        public CelestialObject celestial_object_ra_dec(CelestialObject celestial_object)
        {
            _right_ascension = celestial_object.GetRA();
            _declination = celestial_object.GetDec();
            _star.SetRA(_right_ascension);
            _star.SetDec(_declination);
            return _star;
        }

        /**
         * @return returns com.example.skymap.Star coordinates in form of
         *         com.example.skymap.CelestialObject*
         * @brief function:CelebralObject_ra_dec
         */
        public CelestialObject celestial_object_ra_dec()
        {
            return _star;
        }

        /**
         * @brief function transforms current local time to UTC
         *
         * @param hhh                  - hour type:double
         * @param mmm                  - minute type:double
         * @param sss                  - second type:double
         * @param your_timezone_offset type:double
         * @return double returns UTC type: double
         */
        public double Hh_mm_ss2UTC(double hhh, double mmm, double sss, double your_timezone_offset)
        {
            double converted_to_utc = hhh + mmm / 60 + sss * 0.000277777778;
            converted_to_utc -= your_timezone_offset;
            if (converted_to_utc >= 24)
            {
                converted_to_utc -= 24;

                newday = 1;
            }
            else if (converted_to_utc < 0)
            {
                converted_to_utc += 24;
                newday = -1;
            }
            else if (converted_to_utc == 24)
            {

                converted_to_utc = 0;
                newday = 1;
            }
            else
            {
                newday = 0;
            }

            return converted_to_utc;
        }

        /**
         * @param year  - type: double, details: datetime, current year
         * @param month - type: double, details: datetime, current month
         * @param day   - type: double, details: datetime, current day
         * @param UTC   - type: double, details: datetime, current time utc.
         * @return com.example.skymap.DateTimeValues
         * @brief if you want to perform realtime calculations you update time and date
         *        for calculations calling this function
         */
        public DateTimeValues DateTime(double year, double month, double day, double UTC)
        {
            _year = year;
            _month = month;
            _day = day;
            _time = UTC;
            _day += newday;

            return new DateTimeValues(_year, _month, _day, _time);
        }

        /**
         * @return com.example.skymap.DateTimeValues
         * @brief Datetimevalues getter
         */
        public DateTimeValues DateTime()
        {
            return new DateTimeValues(_year, _month, _day, _time);
        }

        /**
         * @param Y-   year - type: double, details: datetime, current year
         * @param M    month - type: double, details: datetime, current month
         * @param D    day - type: double, details: datetime, current day
         * @param TIME - type: double, details: datetime, current time utc.
         * @return double returns number of double since J2000 type:double
         * @brief Calculating the double from J2000 the reference date is J2000, which
         *        corresponds to 1200 double UT on Jan 1st 2000 AD
         */
        public double J2000(double Y, double M, double D, double TIME)
        {
            
            double JD = (367 * Y - Math.Floor(7 * (Y + Math.Floor((M + 9) / 12)) / 4)
                    - Math.Floor(3 * (Math.Floor((Y + (M - 9) / 7) / 100) + 1) / 4) + Math.Floor(275 * M / 9) + D + 1721028.5 + TIME / 24);
            double j2000 = JD - (double)2451545;

            return j2000;
        }

        /**
         * @return double returns number of double since J2000 type:double
         * @brief J2000 Getter
         */
        public double J2000()
        {
            _JD = (367 * _year - Math.Floor(7 * (_year + Math.Floor((_month + 9) / 12)) / 4)
                    - Math.Floor(3 * (Math.Floor((_year + (_month - 9) / 7) / 100) + 1) / 4) + Math.Floor(275 * _month / 9) + _day
                    + 1721028.5 + _time / 24);
            _j2000 = _JD - (double)2451545;

            return _j2000;
        }

        /**
         * @param j2000     - to calculate LST we need to know how many double passed
         *                  since J2000
         * @param time      - default value:0, type: double, details: datetime, current
         *                  time utc.
         * @param longitude - default value:0, type: double, details: geographic
         *                  coordinates
         * @return double return local sidereal time
         * @brief calculates Local_Sidereal_Time and stores it.:
         *        is a timekeeping system that astronomers use to locate celestial
         *        objects. Using sidereal time, it is possible to easily point a
         *        telescope to the proper coordinates in the night sky. In short,
         *        sidereal time is a "time scale that is based on Earth's rate of
         *        rotation measured relative to the fixed stars"
         */
        public double Local_Sidereal_Time(double j2000, double time, double longitude)
        {
            double LST = 100.46 + 0.985647 * j2000 + longitude + 15 * time;
            if (LST < 0)
            {
                LST += 360;
            }
            else if (LST > 360)
            {
                LST -= 360;
            }
            return LST;
        }

        /**
         * @return double return local sidereal time
         * @brief LST getter
         */
        public double Local_Sidereal_Time()
        {
            _LST = 100.46 + 0.985647 * _j2000 + _longitude + 15 * _time;
            if (_LST < 0)
            {
                _LST += 360;
            }
            else if (_LST > 360)
            {
                _LST -= 360;
            }
            _local_sidereal_time = _LST;
            return _LST;
        }

        /**
         * @param LST             -local sidereal time
         * @param right_ascension
         * @return double
         * @brief the hour angle is the angle between two planes: one containing Earth's
         *        axis and the zenith (the meridian plane), and the other containing
         *        Earth's axis and a given point of interest (the hour circle)
         */
        public double Hour_Angle(double LST, double right_ascension) // calculates hour_angle and stores it
        {
            double HA = LST - right_ascension;
            if (HA < 0)
            {
                HA += 360;
            }
            else if (HA > 360)
            {
                HA -= 360;
            }
            return HA;
        }

        /**
         * @return Hour angle in double
         * @brief the hour angle is the angle between two planes: one containing Earth's
         *        axis and the zenith (the meridian plane), and the other containing
         *        Earth's axis and a given point of interest (the hour circle)
         */
        public double Hour_Angle()
        {
            _HA = _local_sidereal_time - _right_ascension;
            if (_HA < 0)
            {
                _HA += 360;
            }
            else if (_HA > 360)
            {
                _HA -= 360;
            }
            _hourangle = _HA;
            return _hourangle;
        }

        /**
         * @param hour_angle
         * @param declination
         * @param lattitude
         * @return com.example.skymap.SearchResult
         * @brief calculate az and alt , returns pointer to array where the az and alt
         *        is stored
         */
        public SearchResult calculate_AZ_alt(double hour_angle, double declination, double lattitude)
        {
            /*
             * math behind calculations -- conversion from HA and DEC to ALT and AZ
             * Math.Sin(ALT) = Math.Sin(DEC) * Math.Sin(LAT) + Math.Cos(DEC) * Math.Cos(LAT) * Math.Cos(HA)
             * ALT = Math.Asin(ALT)
             * Math.Sin(DEC) - Math.Sin(ALT) * Math.Sin(LAT)
             * Math.Cos(A) = ---------------------------------
             * Math.Cos(ALT) * Math.Cos(LAT)
             * A = Math.Acos(A)
             * If Math.Sin(HA) is negative,then AZ = A, otherwise AZ = 360 - A
             */

            double sinDEC = Math.Sin(deg2rad(declination));
            double sinHA = Math.Sin(deg2rad(hour_angle));
            double sinLAT = Math.Sin(deg2rad(lattitude));
            double cosDEC = Math.Cos(deg2rad(declination));
            double cosHA = Math.Cos(deg2rad(hour_angle));
            double cosLAT = Math.Cos(deg2rad(lattitude));
            double sinALT = (sinDEC * sinLAT) + (cosDEC * cosLAT * cosHA);
            double ALT = Math.Asin(sinALT);
            double cosALT = Math.Cos((ALT));
            double cosA = (sinDEC - sinALT * sinLAT) / (cosALT * cosLAT);
            double A = Math.Acos(cosA);
            A = rad2deg(A);
            ALT = rad2deg(ALT);

            double AZ;
            if (sinHA > 0)

            {
                AZ = 360 - A;
            }
            else
            {
                AZ = A;
            }
            _search_result.SetAzimuth(AZ);
            _search_result.SetAltitude(ALT);
            return _search_result;
        }

        /**
         * @brief perform all necessary calculations and after this function is called
         *        you can use get_star_azimuth and get_star_altitude
         *        it is called automatically when using update() or when all data is
         *        provided in constuctor
         */
        public void Calculate_all()
        {
            J2000();
            Local_Sidereal_Time();
            Hour_Angle();
            calculate_AZ_alt(_hourangle, _declination, _lattitude);
        }

        /**
         * @return * double
         * @brief Get the star azimuth object works only if you provide all data at
         *        constructor or in update() function and if you previously used
         *        calculate_AZ_alt()
         */
        public double get_star_Azimuth()
        {
            return _search_result.GetAzimuth();
        }

        /**
         * @return double
         * @brief Get the star Altitude object works only if you provide all data at
         *        constructor or in update() function and if you previously used
         *        calculate_AZ_alt()
         */
        public double get_star_Altitude()
        {
            return _search_result.GetAltitude();
        }

        /**
         * @param lattitude
         * @param longitude
         * @param declination
         * @param right_ascension
         * @param year
         * @param month
         * @param day
         * @param time
         * @brief this function let you
         */
        public void update(double lattitude, double longitude, double declination, double right_ascension, double year,
                double month, double day, double time) // if you created empty constructor you can provide all data here
                                                       // then use get..() functions
        {
            _lattitude = lattitude;
            _longitude = longitude;
            _declination = declination;
            _right_ascension = right_ascension;
            _time = time;
            _year = year;
            _month = month;
            _day = day;
            _day += newday;
            Calculate_all();
        }

        /**
         * @param Deg
         * @return double
         * @brief convert degrees to radians
         */
        public double deg2rad(double Deg)
        {
            return Deg * 3.14159265358979 / 180.00;
        }

        /**
         * @param Rad
         * @return double
         * @brief convert radians to degrees
         */
        public double rad2deg(double Rad)
        {
            return Rad * 180.0 / 3.14159265358979;
        }
        // check for star visibility sometimes user wants to know only if it will be
        // visible or not , function returns true if is visible false if it is not
        // returns value when previously provided data to update function on in
        // constructor what star you want to look at

        /**
         * @return true if star is visible
         * @return false if star is not visible
         * @brief check star visibility at your location
         */
        public bool IsVisible()
        {
            if (_search_result.GetAltitude() >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * @return com.example.skymap.SearchResult
         * @brief get star azimuth and altitude
         */
        public SearchResult get_star_search_result()
        {
            return _search_result;
        }

        /**
         * @return com.example.skymap.CelestialObject*
         * @brief function returns pointer to the celestial object
         */
        public CelestialObject get_celestial_object()
        {
            return _star;
        }

        private bool isvisible = false;
        private ObserverPosition _observer_position = new ObserverPosition();
        private SearchResult _search_result = new SearchResult();
        private Star _star = new Star();

        private double h2deg(double h)
        {
            return h * 15;
        }

        private double deg2h(double Deg)
        {
            return Deg / 15;
        }

        private double asind(double rad)
        {
            return Math.Asin(rad2deg(rad));
        }

        private double acosd(double rad)
        {
            return Math.Acos(rad2deg(rad));
        }

        /*
         * angle from the vernal
         * equinox measured along the equator. This angle
         * is the right ascension
         */
        private double _right_ascension;
        private double _time;
        // geographic coordinates
        private double _lattitude, _longitude;
        /*
         * The angular separation of a star from the equa-
         * torial plane is not affected by the rotation of the
         * Earth.This angle is called the declination
         */
        private double _declination;
        private double _year;
        private double _month;
        /*
         * the hour angle is the angle between two planes: one containing Earth's axis
         * and the zenith (the meridian plane), and the other containing Earth's axis
         * and a given point of interest (the hour circle)
         */
        private double _hourangle;
        /*
         * is a timekeeping system that astronomers use to locate celestial objects.
         * Using sidereal time, it is possible to easily point a telescope to the proper
         * coordinates in the night sky. In short, sidereal time is a
         * "time scale that is based on Earth's rate of rotation measured relative to the fixed stars"
         */
        private double _local_sidereal_time;
        /*
         * is a timekeeping system that astronomers use to locate celestial objects.
         * Using sidereal time, it is possible to easily point a telescope to the proper
         * coordinates in the night sky. In short, sidereal time is a
         * "time scale that is based on Earth's rate of rotation measured relative to the fixed stars"
         */
        private double _LST;
        private double _day;
        private double _j2000;
        private double _HA;
        private double _JD;
        private double newday = 0;
    };

}
