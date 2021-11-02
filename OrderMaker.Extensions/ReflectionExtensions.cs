using System;
using System.ComponentModel;
using System.Linq;

namespace OrderMaker.Extensions
{
    public static class ReflectionExtensions
    {
        public static string GetDisplayName<T>(this T obj)
        {
            var displayName = obj
                .GetType() 
                .GetCustomAttributes(typeof(DisplayNameAttribute), true)
                .FirstOrDefault() as DisplayNameAttribute;

            return displayName?.DisplayName ?? "";
        }
    }
}