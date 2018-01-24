using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace tradetool.Utilities
{
    public static class ConvertHelper
    {
        public static decimal ToDecimal(string value)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch
            {
                return 0;
            }
        }
        public static long ToUnixTime(this DateTime dateTime)
        {
            DateTime UnixEpoch = new DateTime(1970, 1, 1);
            return (dateTime - UnixEpoch).Ticks / TimeSpan.TicksPerMillisecond;
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            DataTable table = new DataTable();
            if (typeof(T) == typeof(int))
            {
                table.Columns.Add("IntValue", typeof(int));
                if (data == null)
                    return table;
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    row["IntValue"] = item;
                    table.Rows.Add(row);
                }
                return table;
            }
            else if (typeof(T) == typeof(string))
            {
                if (data == null)
                    return table;
                table.Columns.Add("StringValue", typeof(string));
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    row["StringValue"] = item;
                    table.Rows.Add(row);
                }
                return table;
            }
            else
            {

                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Defining type of data column gives proper data table 
                    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name, type);
                }
                if (data != null)
                    foreach (T item in data)
                    {
                        var values = new object[Props.Length];
                        for (int i = 0; i < Props.Length; i++)
                        {
                            //inserting property values to datatable rows
                            values[i] = Props[i].GetValue(item, null);
                        }
                        dataTable.Rows.Add(values);
                    }
                //put a breakpoint here and check datatable
                return dataTable;
            }
        }
    }
}
