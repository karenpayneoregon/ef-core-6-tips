using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaxpayerMocking.Classes
{
    internal class Helpers
    {
        public static bool IsValidSocialSecurityNumber(string value) =>
            Regex.IsMatch(value.Replace("-", ""),
                @"^(?!\b(\d)\1+\b)(?!123456789|219099999|078051120)(?!666|000|9\d{2})\d{3}(?!00)\d{2}(?!0{4})\d{4}$");
    }
}
