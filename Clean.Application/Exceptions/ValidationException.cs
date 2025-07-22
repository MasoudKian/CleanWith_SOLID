using FluentValidation.Results;  // ✅ مهم: اینو اضافه کن

namespace Clean.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors) // ✅ حالا دیگه Errors شناخته میشه
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
