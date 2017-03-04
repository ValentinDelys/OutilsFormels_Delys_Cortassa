using System.Text.RegularExpressions;
using System;


namespace OutilsFormels
{
    public static class RegexFunction
    {
        public static bool isValidstring(string str, int sizeMin, int sizeMax)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            if (str.Length < sizeMin || str.Length > sizeMax) { return false; }
            return rg.IsMatch(str);
        }

        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public static bool isValidPassword(string inputPassword)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,30}");
            var hasNoCharacterSpeacial = new Regex(@"^[a-zA-Z0-9]*$");
            hasNoCharacterSpeacial.IsMatch(inputPassword);
            return hasNoCharacterSpeacial.IsMatch(inputPassword) && hasNumber.IsMatch(inputPassword) && hasUpperChar.IsMatch(inputPassword) && hasMinimum8Chars.IsMatch(inputPassword);
        }
        public static bool isNumber(string inputString)
        {
            var isANumber = new Regex(@"[0-9]");
            return isANumber.IsMatch(inputString);
        }
    }
}