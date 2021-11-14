using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace OrderMaker.Extensions
{
    public static class ReflectionExtensions
    {
        public static string GetDisplayNameAttribute(this Enum enumValue)
        {
            var displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()?
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();

            return string.IsNullOrEmpty(displayName) ? enumValue.ToString() : displayName;
        }
    }
}