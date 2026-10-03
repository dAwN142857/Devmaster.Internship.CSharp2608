using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace NetCoreMVCLAB5_BaiTuLam.Validation
{
    /// <summary>Mô tả không được chứa các từ nhạy cảm.</summary>
    public class NoBadWordsAttribute : ValidationAttribute
    {
        // Thêm/bớt từ nhạy cảm tại đây
        private static readonly string[] BadWords =
            { "die", "admin", "fack", "fuck", "shit" };

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var text = value as string;
            if (string.IsNullOrWhiteSpace(text)) return ValidationResult.Success;

            var found = BadWords
                .Where(w => Regex.IsMatch(text, $@"\b{Regex.Escape(w)}\b", RegexOptions.IgnoreCase))
                .ToList();

            if (found.Count > 0)
            {
                return new ValidationResult(
                    $"Mô tả chứa từ nhạy cảm không được phép: {string.Join(", ", found)}.",
                    new[] { context.MemberName });
            }
            return ValidationResult.Success;
        }
    }
}
