using System.Text.RegularExpressions;

namespace schedule_mvc.Data
{
    public class Helpers
    {
        public static bool ValidateName(string name)
        {
            //can only begin with a letter
            //can contain dots and spaces
            //can only end in a letter
            string pattern = @"^[a-zA-Z]+(?:[\s.]+[a-zA-Z]+)*$";

            return Regex.Match(name, pattern).Success;
        }
    }
}
