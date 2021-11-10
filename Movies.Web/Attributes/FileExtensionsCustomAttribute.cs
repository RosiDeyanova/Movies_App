using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Movies.Web.Attributes
{
    public class FileExtensionsCustomAttribute : ValidationAttribute, IClientModelValidator
    {
        private static string[] _extensions;
        private readonly string _extensionsString;

        public FileExtensionsCustomAttribute(string[] extensions)
        {
            _extensions = extensions;
            _extensionsString = string.Join(",", _extensions);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            var extension = Path.GetExtension(file?.FileName);

            if (extension == null || _extensions.Any(e => e == extension))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(string.Format(ErrorMessage, _extensionsString));
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-fileextensioncustom", string.Format(ErrorMessage, _extensionsString));
            MergeAttribute(context.Attributes, "data-val-fileextensioncustom-extensionsstring", _extensionsString); //"['.jpg', '.png']"
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


