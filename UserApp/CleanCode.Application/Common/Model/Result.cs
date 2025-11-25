

using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;


namespace UserApp.Application.Common.Model
{
    public class Result<TValue> where TValue : class
    {
        private List<ValidationResult> _infos = new List<ValidationResult>();
        private List<ValidationResult> _warnings = new List<ValidationResult>();
        private List<ValidationResult> _errors = new List<ValidationResult>();

        public TValue? Value { get; set; }
        public Guid RequestId { get; set; }
        public bool IsAuthorized { get; set; } = true;
        public IReadOnlyList<ValidationResult> Infos
        {
            get => _infos.AsReadOnly();
            init => _infos.AddRange(value);
        }
        public IReadOnlyList<ValidationResult> Errors
        {
            get => _errors.AsReadOnly();
            init => _errors.AddRange(value);
        }
        public IReadOnlyList<ValidationResult> Warnings
        {
            get => _warnings.AsReadOnly();
            init => _warnings.AddRange(value);
        }

        public bool HasErrors => Errors.Any(r => r.HasErrors);

        public void SetResult(TValue value)
        {
            Value = value;
        }

        public void SetValidationResult(ValidationResult validationResult)
        {
            _warnings?.AddRange(validationResult.ValidationItems.Where(x => x.ValidationSeverity == ValidationSeverity.Warning).Select(x => ValidationResult.FromValidationItem(x)));
        }
        public void SetUnauthorizedResult()
        {
            Value = null;
            IsAuthorized = false;
        }

        
    }
}
