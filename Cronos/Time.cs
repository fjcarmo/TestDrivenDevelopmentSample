using System;

namespace Cronos
{
    public class Time
    {
        public int _hour;
        public int _minute;

        public Time()
        {
        }

        public Time(int hour, int minute)
        {
            int totalMinutes = (hour * 60) + minute;
            _hour = Math.Abs(totalMinutes / 60);
            _minute = Math.Abs(totalMinutes % 60);                    
        }        

        public static Time operator +(Time firstTime, Time secondTime)
        {               
            return new Time(firstTime._hour + secondTime._hour, firstTime._minute + secondTime._minute);
        }

        public static Time operator -(Time firstTime, Time secondTime)
        {
            return new Time(firstTime._hour - secondTime._hour, firstTime._minute - secondTime._minute);
        }

        public static bool operator ==(Time firstTime, Time secondTime)
        {
            if ((object)firstTime == null) return (object)secondTime == null;

            return firstTime.Equals(secondTime);            
        }

        public static bool operator !=(Time firstTime, Time secondTime)
        {
            return !(firstTime == secondTime);
        }

        public override bool Equals(object time)
        {
            if (time == null || GetType() != time.GetType()) return false;

            Time time2 = (Time)time;
            return (_hour == time2._hour && _minute == time2._minute);
        }

        public override int GetHashCode()
        {
            return (_hour, _minute).GetHashCode();
        }

        public static bool operator >(Time firstTime, Time secondTime)
        {
            return (firstTime._hour * 60 + firstTime._minute > secondTime._hour * 60 + secondTime._minute);
        }

        public static bool operator <(Time firstTime, Time secondTime)
        {
            return !(firstTime > secondTime);
        }

        public static explicit operator float(Time time)
        {
            float result = time._hour + (float)(time._minute / 60.0);

            return result;
        }

        public static explicit operator Time(float floatTime)
        {
            Time time = new Time();

            time._hour = (int)floatTime;
            time._minute = (int)((floatTime - Math.Truncate(floatTime)) * 60);

            return time;
        }
    }
}
