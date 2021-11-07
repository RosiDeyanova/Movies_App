using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Web.Attributes
{
    public class YearRangeAttribute : RangeAttribute
    {
        public YearRangeAttribute(int year) : base(year, DateTime.Now.Year) 
        {

        }
        //public override bool IsValid(object value)
        //{
        //    int year = (int)value;

        //    if (year <= DateTime.Now.Year && year >= 1900)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}