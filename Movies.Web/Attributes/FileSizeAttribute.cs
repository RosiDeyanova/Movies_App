using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Movies.Web.Attributes
{
    public class FileSizeAttribute : ValidationAttribute, IClientModelValidator
    {
        private long _maxSize { get; set; }

        public FileSizeAttribute(long maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file?.Length > _maxSize)
            {
                return new ValidationResult(string.Format(ErrorMessage, _maxSize));
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-filesize", string.Format(ErrorMessage, _maxSize));
            MergeAttribute(context.Attributes, "data-val-filesize-maxsize", _maxSize.ToString()); //"['.jpg', '.png']"
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);

            return true;
        }
    }
}
