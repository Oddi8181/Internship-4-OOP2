

namespace UserApp.Application.Common.Validation.ValidationItems
{
    public class ValidationResult
    {
        private List<ValidationItem> _validationItems = new List<ValidationItem>();
        public IReadOnlyList<ValidationItem> ValidationItems => _validationItems;

        public bool HasErrors => _validationItems.Any(validationResult => validationResult.ValidationSeverity == ValidationSeverity.Error);
      
        public void AddValidationItem(ValidationItem item)
        {
            _validationItems.Add(item);
        }
        public ValidationResult()
        {
            
        }
    }
}
