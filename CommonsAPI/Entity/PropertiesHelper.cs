using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CommonsAPI.Entity
{
    public class PropertiesHelper
    {
        public static void CopyProperties(object fromObj, object toObj)
        {
            if (fromObj != null && toObj != null)
            {
                Type toObjType = toObj.GetType();
                foreach (PropertyInfo piFrom in getEntityProperties(fromObj))
                {
                    PropertyInfo piTo = toObjType.GetProperties().FirstOrDefault(pi => piFrom.Name == pi.Name);
                    if (piTo != null)
                    {
                        piTo.SetValue(toObj, piFrom.GetValue(fromObj, null), null);
                    }
                }
            }
        }

        private static List<PropertyInfo> getEntityProperties(object entity)
        {
            return entity.GetType().GetProperties()
                .Where(pi => pi.PropertyType.IsPrimitive ||
                             pi.PropertyType == typeof(string) ||
                             pi.PropertyType == typeof(DateTime) ||
                             pi.PropertyType == typeof(decimal) ||
                             pi.PropertyType == typeof(Nullable<decimal>) ||
                             pi.PropertyType == typeof(Nullable<DateTime>)).ToList();
        }
    }
}
