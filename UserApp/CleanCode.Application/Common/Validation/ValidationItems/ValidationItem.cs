
namespace UserApp.Application.Common.Validation.ValidationItems
{
    public class ValidationItem
    {
        public ValidationSeverity ValidationSeverity { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }

        public ValidationItem()
        {
            
        }
    }
}
