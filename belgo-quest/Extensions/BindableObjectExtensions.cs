using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;



namespace belgoquest
{
    public static class BindableObjectExtensions
    {
        public static T GetValue<T>(this BindableObject bindableObject, BindableProperty property)
        {
            return (T)bindableObject.GetValue(property);
        }

        public static Type GetPropType(object src, string propName)
        {
            if (src == null)
                return null;

            PropertyInfo info = src.GetType().GetRuntimeProperty(propName);

            if (info == null)
                return null;

            return info.GetType();
        }

        public static T GetPropValue<T>(this Object obj, String name) {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T) retval;
        }

        private static Object GetPropValue(this Object obj, String name) {
            foreach (String part in name.Split('.')) {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetRuntimeProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }
    }

}

