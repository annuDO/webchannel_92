using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trelleborg.Foundation.SitecoreExtensions
{
    public static class StringExtensions
    {
        public static string ToDelimitedString(this IEnumerable<string> values, string delimiter)
        {
            if (values == null)
                return string.Empty;
            var str1 = string.Empty;
            var flag = true;
            foreach (string str2 in values)
            {
                if (String.IsNullOrWhiteSpace(str2)) continue;
                if (!flag)
                    str1 = str1 + delimiter;
                str1 = str1 + str2;
                flag = false;
            }
            return str1;
        }
    public static String GetExcerpt(this string data, Int32 length = 100)
    {
      if (!string.IsNullOrEmpty(data))
      {
        data = Regex.Replace(data, @"<img\s[^>]*>(?:\s*?</img>)?", String.Empty, RegexOptions.IgnoreCase);
        data = new Regex("<(?!sup|/sup).*?>", RegexOptions.Compiled).Replace(data, String.Empty);

        //data = new Regex("(?i)<(?!sup|/sup).*?>", RegexOptions.Compiled).Replace(data, String.Empty);



        if (data!=null && data.Length > length)
        {
          data = data.Substring(0, length - 4) + "...";
        }
        return data;
      }

      return string.Empty;
    }

    public static string ToFileSize(this double value)
    {
      string[] suffixes = { "bytes", "KB", "MB", "GB", String.Empty, "TB", "PB", "EB", "ZB", "YB" };
      for (int i = 0; i < suffixes.Length; i++)
      {
        if (value <= (Math.Pow(1024, i + 1)))
        {
          return ThreeNonZeroDigits(value /
              Math.Pow(1024, i)) +
              " " + suffixes[i];
        }
      }

      return ThreeNonZeroDigits(value /
          Math.Pow(1024, suffixes.Length - 1)) +
          " " + suffixes[suffixes.Length - 1];
    }

    private static string ThreeNonZeroDigits(double value)
    {
      if (value >= 100)
      {
        // No digits after the decimal.
        return value.ToString("0,0", CultureInfo.InvariantCulture);
      }
      else if (value >= 10)
      {
        // One digit after the decimal.
        return value.ToString("0.0", CultureInfo.InvariantCulture);
      }
      else
      {
        // Two digits after the decimal.
        return value.ToString("0.00", CultureInfo.InvariantCulture);
      }
    }

    public static string GetYouTubeId(this Uri url)
    {
      if (url ==null || string.IsNullOrWhiteSpace(url.AbsoluteUri))
      {
        return string.Empty;
      }
      var youtubeMatch = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)").Match(url.AbsoluteUri);
      return youtubeMatch.Success ? youtubeMatch.Groups[1].Value : url.AbsoluteUri;
    }

    public static string GetYoukuId(this Uri url)
    {
      if (url == null || string.IsNullOrWhiteSpace(url.AbsoluteUri))
      {
        return string.Empty;
      }
      var youkuMatch = new Regex(@"youku(?:\.com)/(?:.*embed(?:/|/)|(?:.*/)?)([a-zA-Z0-9-_=]+)").Match(url.AbsoluteUri);
      return youkuMatch.Success ? youkuMatch.Groups[1].Value : url.AbsoluteUri;
    }

    public static string LowercaseFirst(this string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        return string.Empty;
      }
      return char.ToUpperInvariant(s[0]) + s.Substring(1);
    }
    public static string FormatFileSize(double size)
    {
      string str = string.Empty;
      string[] strArray = new string[5]
          {
                "B",
                "KB",
                "MB",
                "GB",
                "TB"
          };
      int index = 0;
      while (size >= 1024.0 && index + 1 < strArray.Length)
      {
        ++index;
        size /= 1024.0;
      }
      str = string.Format( CultureInfo.InvariantCulture,"{0:0.##}&nbsp;{1}", size, strArray[index]);
      return str;
    }
  }
}

