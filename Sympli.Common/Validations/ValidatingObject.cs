using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sympli.Common.Validations
{
    public abstract class ValidatingObject
    {
        private List<ValidationResult> _validationResults;

        public ValidatingObject()
        {
            _validationResults = new List<ValidationResult>();
        }

        public virtual bool IsValid()
        {
            object entity = this;
            _validationResults = new List<ValidationResult>();
            var context = new ValidationContext(entity);
            return Validator.TryValidateObject(entity, context, _validationResults, true);
        }

        public IList<ValidationResult> Validate(object entity)
        {
            _validationResults = new List<ValidationResult>();
            var context = new ValidationContext(entity);
            Validator.TryValidateObject(entity, context, _validationResults, true);
            return _validationResults;
        }

        public bool HasErrors()
        {
            return _validationResults.Any();
        }

        public string[] GetValidationMessages()
        {
            return _validationResults == null ? new string[] { } : _validationResults.Select(v => v.ErrorMessage).ToArray();
        }
    }
}
