using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF_Project
{
   public static class ValidationClass
    {
      public static Tuple<bool,string> validateStringTextbox(string text)
        {
            if(String.IsNullOrEmpty(text))
            {
                return Tuple.Create(false, "Nie wpisano żadnego tekstu");
            }
            if(text.Length < 2)
            {
                return Tuple.Create(false, "Podany tekst jest zbyt krótki");
            }

            return Tuple.Create(true, "1");
        }

      public static Tuple<bool,string> validateDateTextbox(string text)
        {
            Regex regex = new Regex("^([0]?[0-9]|[12][0-9]|[3][01])[..-]([0]?[1-9]|[1][0-2])[..-]([0-9]{4}|[0-9]{2})$");
            MatchCollection matches = regex.Matches(text);

            if(matches.Count < 1)
            {
                return Tuple.Create(false, "Błędny format daty (dd.mm.yyyy)");
            }
            return Tuple.Create(true, "1");
        }
    }
}
