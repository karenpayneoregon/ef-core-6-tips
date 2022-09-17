namespace TaxpayerMocking.LanguageExtensions
{
    internal static class GeneralExtensions
    {
        public static string ToYesNo(this bool value) => value ? "Yes" : "No";
    }
}
