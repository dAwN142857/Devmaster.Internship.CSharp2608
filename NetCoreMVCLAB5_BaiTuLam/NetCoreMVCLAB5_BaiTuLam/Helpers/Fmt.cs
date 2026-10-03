using System.Globalization;

namespace NetCoreMVCLAB5_BaiTuLam.Helpers
{
    public static class Fmt
    {
        private static readonly CultureInfo Vn = new("vi-VN");
        public static string Vnd(float value) => value.ToString("#,##0", Vn) + " ₫";
    }
}
