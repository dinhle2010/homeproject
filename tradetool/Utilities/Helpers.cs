using Core.MVC.APIWrapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace tradetool
{
    public static class Helpers
    {
        internal static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;
        private static BigInteger CurrentHttpPostNonce { get; set; }
        internal static readonly DateTime DateTimeUnixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        internal static string ToHttpPostString(this Dictionary<string, object> dictionary)
        {
            var output = string.Empty;
            foreach (var entry in dictionary)
            {
                var valueString = entry.Value as string;
                if (valueString == null)
                {
                    output += "&" + entry.Key + "=" + entry.Value;
                }
                else
                {
                    output += "&" + entry.Key + "=" + valueString.Replace(' ', '+');
                }
            }

            return output.Substring(1);
        }
        public static string ToStringHex(this byte[] value)
        {
            var output = string.Empty;
            for (var i = 0; i < value.Length; i++)
            {
                output += value[i].ToString("x2", InvariantCulture);
            }

            return (output);
        }
        internal static string GetCurrentHttpPostNonce()
        {
            var newHttpPostNonce = new BigInteger(Math.Round(DateTime.UtcNow.Subtract(DateTimeUnixEpochStart).TotalMilliseconds * 1000, MidpointRounding.AwayFromZero));
            if (newHttpPostNonce > CurrentHttpPostNonce)
            {
                CurrentHttpPostNonce = newHttpPostNonce;
            }
            else
            {
                CurrentHttpPostNonce += 1;
            }

            return CurrentHttpPostNonce.ToString(InvariantCulture);
        }
        public static string GetdataViaproxy(string url)
        {
            string fullURL = string.Format("http://207.148.66.48/api/values?" + "endpoint={0}", url.Replace("&", "[and]"));
            try
            {
                using (var objAPI = new APIClient(new HttpClient()))
                {
                    using (var response = objAPI.GetWithParam(fullURL, null))
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                }

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
