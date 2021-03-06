﻿using System.ComponentModel.DataAnnotations;

namespace PeopleSearch.Attributes
{
    public class PersonImageUrlAttribute : ValidationAttribute
    {
        private const string ERROR_MESSAGE = "Url is not a same-origin url that starts with \"user-images\\\"";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var imageUrl = (string)value;
            return !imageUrl.StartsWith("user-images\\") ? new ValidationResult(ERROR_MESSAGE) : ValidationResult.Success;
        }
    }
}
