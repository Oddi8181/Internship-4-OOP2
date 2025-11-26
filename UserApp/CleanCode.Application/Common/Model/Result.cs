

using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;


namespace UserApp.Application.Common.Model
{
    public class Result<T> where T : class
    {
        public bool Success { get; private set; }
        public T? Value { get; private set; }
        public ValidationResult? ValidationResult { get; private set; }


        private Result(bool success, T? value, ValidationResult? validationResult)
        {
            Success = success;
            Value = value;
            ValidationResult = validationResult;
        }
        public static Result<T> Ok(T value) => new Result<T>(true, value, null);
        public static Result<T> Fail(ValidationResult validation) => new Result<T>(false, default, validation);

    }
}
