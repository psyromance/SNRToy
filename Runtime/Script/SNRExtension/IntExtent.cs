using System;


namespace SNRIntExtend
{
    public static class IntExtend
    {
        public static string ToEnumStr<T>(this int value)
        {
            string enumString = Enum.GetName(typeof(T), value);
            return enumString;
        }
    }

}