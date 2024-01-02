using System;

namespace SNRStringExtend
{
    public static class StringExtend
    {
        // 字符串转枚举 
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        // 字符串转枚举值  
        public static int ToEnumValue<T>(this string value)
        {
            int enumInt = (int)Enum.Parse(typeof(T), value);
            return enumInt;
        }


    }



}
