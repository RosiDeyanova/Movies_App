using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Web.Attributes
{
    public class YearValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int year = (int)value;

            if (year <= DateTime.Now.Year && year >= 1900)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}