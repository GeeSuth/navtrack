using System;
using System.Text.RegularExpressions;

// ReSharper disable IdentifierTypo
namespace Navtrack.Listener.Helpers.New
{
    public abstract class NewDateTimeUtil
    {
        public static DateTime Convert(DateFormat dateFormat, params string[] input)
        {
            return dateFormat switch
            {
                DateFormat.HHMMSS_SS_DDMMYY => Parse_HHMMSS_SS_DDMMYY(input),
                _ => Parse_YYMMDDHHMMSS(input)
            };
        }
 
        private static DateTime Parse_HHMMSS_SS_DDMMYY(string[] input)
        {
            Match timeMatch = new Regex("(\\d{2})(\\d{2})(\\d{2}).(\\d+)").Match(input[0]); // hh mm ss . sss
            Match dateMatch = new Regex("(\\d{2})(\\d{2})(\\d{2})").Match(input[1]); // dd mm yy

            return DateTimeUtil.New(
                dateMatch.Groups[3].Value,
                dateMatch.Groups[2].Value,
                dateMatch.Groups[1].Value,
                timeMatch.Groups[1].Value,
                timeMatch.Groups[2].Value,
                timeMatch.Groups[3].Value,
                timeMatch.Groups[4].Value);
        }
        
        private static DateTime Parse_YYMMDDHHMMSS(string[] input)
        {
            Match match = new Regex("(\\d{2})(\\d{2})(\\d{2})(\\d{2})(\\d{2})(\\d{2})").Match(input[0]);

            return DateTimeUtil.New(
                match.Groups[1].Value,
                match.Groups[2].Value,
                match.Groups[3].Value,
                match.Groups[4].Value,
                match.Groups[5].Value,
                match.Groups[6].Value);
        }
    }
}