using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ProjectBase.Utils.Helper
{
    public static class EnumHelper
    {
        public static IDictionary<int, string> ToDictionary<T>()
        {
            try
            {
                IDictionary<int, string> dict = new Dictionary<int, string>();
                var names = Enum.GetNames(typeof(T));

                if (null != names && 0 < names.Length)
                {
                    foreach (var name in names)
                    {
                        var value = Convert.ToInt32(((T)Enum.Parse(typeof(T), name)));
                        dict.Add(value, name);
                    }
                }

                return dict;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetDescription<T>(Enum value)
        {
            try
            {
                if (!Enum.IsDefined(typeof(T), value)) return null;

                var fieldInfo = value.GetType().GetField(value.ToString());
                var attributes = (DescriptionAttribute[])
                    fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                return (attributes.Length > 0) ? attributes[0].Description : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static KeyValuePair<int, string>[] GetDescriptions<T>()
        {
            try
            {
                IList<KeyValuePair<int, string>> keyValuePairs = new List<KeyValuePair<int, string>>();
                var values = Enum.GetValues(typeof(T));

                if (null != values && 0 < values.Length)
                {
                    foreach (Enum value in values)
                    {
                        var id = Convert.ToInt32(value);
                        var desc = GetDescription<T>(value);
                        keyValuePairs.Add(new KeyValuePair<int, string>(id, desc));
                    }
                }

                return keyValuePairs.ToArray<KeyValuePair<int, string>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T ConvertToEnum<T>(this string value)
        {
            try
            {
                if (typeof(T).BaseType != typeof(Enum))
                {
                    throw new InvalidCastException();
                }

                if (Enum.IsDefined(typeof(T), value) == false)
                {
                    throw new InvalidCastException();
                }

                return (T)Enum.Parse(typeof(T), value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetDescription<T>(this T currentEnum)
        {
            try
            {
                string description = currentEnum.ToString();

                if (!string.IsNullOrEmpty(description))
                {
                    DescriptionAttribute da = null;
                    var type = typeof(T);

                    var element = type.GetField(description);

                    if (element != null)
                    {
                        da = Attribute.GetCustomAttribute(element, typeof(DescriptionAttribute)) as DescriptionAttribute;

                        if (da != null)
                        {
                            description = da.Description;
                        }
                    }
                }

                return description;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
