using System;

namespace SNREnumExtend
{
    public static class EnumExtend
    {
        //higher efficiency than toString?
        public static string ToStr<T>(this Enum value)
        {
            string enumString = Enum.GetName(typeof(T), value);
            return enumString;
        }


    }

}

