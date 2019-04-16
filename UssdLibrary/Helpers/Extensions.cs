using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UssdLibrary.Helpers
{
    static class Extensions
    {
        public static string UnixTimeNow(this DateTime dateTime)
        {
            int unixTime = (int)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
            return Convert.ToString(unixTime, 16);
        }

        public static DateTime DateTimeFromUnixTime(this double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public static string CreateDirectory(string directoryMain, string directorySub)
        {
            string path = directoryMain;
            string subpath = directorySub;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            return dirInfo.CreateSubdirectory(subpath).FullName;
        }

        //TODO: Regex regex = new Regex("([-]?[Минус]?[0-9]+)[,.]?");
        //public static string RegexResponse(this string usssAnswer)
        //{
        //    
        //    return regex.Match(usssAnswer).Groups[1].ToString();
        //}
    }
}
