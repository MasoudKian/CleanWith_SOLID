using FluentValidation.Results;  // ✅ مهم: اینو اضافه کن

namespace Clean.Application.Exceptions
{
    public class ValidationExceptions : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationExceptions(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors) // ✅ حالا دیگه Errors شناخته میشه
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
