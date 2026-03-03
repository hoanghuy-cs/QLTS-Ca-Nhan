using System.Globalization;

namespace QLTS.GUI.Helpers
{
    public static class DecimalHelper
    {
        public static string FormatVND(decimal number)
        {
            var vietnamCulture = CultureInfo.GetCultureInfo("vi-VN");
            return number.ToString("C0", vietnamCulture);
        }
    }
}
