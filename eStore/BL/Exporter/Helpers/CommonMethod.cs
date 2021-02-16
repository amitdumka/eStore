using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace eStore.BL.Exporter.Database
{
    public static class CommonMethod
    {
        public static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {

                            pro.SetValue(objT, CO.To( row[pro.Name].ToString(), pro.PropertyType));
                        }
                        catch (Exception ex) {
                            Console.WriteLine("PN:" + pro.Name);
                            Console.WriteLine("err: "+ex.Message);
                            if(pro.PropertyType== typeof(DateTime) && row[pro.Name].ToString().Length>0)
                            {
                                double vv = double.Parse(row[pro.Name].ToString());
                                DateTime d = DateTime.FromOADate(vv);
                                pro.SetValue(objT, d);
                            }
                        }
                    }
                }
                return objT;
            }).ToList();
        }
    }


    public class  CO
    {
        public static object To(string val, Type ty)
        {
            if(ty== typeof(DateTime))
            {
                //DateTime d= new DateTime()
            }
            else if(ty== typeof(EmpType))
            {
                return EnumExt.ToEnum<EmpType>(val);
            }
            object value = Convert.ChangeType(val, ty);
            
            return value;
        }
        public static object To(object val, Type ty)
        {
            if (ty == typeof(DateTime))
            {
                DateTime d = new DateTime((long)val);
            }
            
            object value = Convert.ChangeType(val, ty);

            return value;
        }
        /// <summary>
        /// Extension method to return an enum value of type T for the given string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>

    }
    public static class EnumExt
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        ///// <summary>
        ///// Extension method to return an enum value of type T for the given int.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static T ToEnum<T>(this int value)
        //{
        //    var name = Enum.GetName(typeof(T), value);
        //    return name.ToEnum<T>();
        //}
    }
    public static class EnumHelper
    {
        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val;
            return Enum.TryParse<T>(str, true, out val) ? val : default(T);
        }

        public static T GetEnumValue<T>(int intValue) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }

            return (T)Enum.ToObject(enumType, intValue);
        }
    }
}
