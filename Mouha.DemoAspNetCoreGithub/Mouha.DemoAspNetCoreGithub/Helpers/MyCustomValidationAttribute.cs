﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mouha.DemoAspNetCoreGithub.Helpers
{
    public class MyCustomValidationAttribute: ValidationAttribute
    {
        public MyCustomValidationAttribute(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string nomLivre = value.ToString();
                if (nomLivre.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Le nom du livre  ne contient pas la valeur désirée");
        }
    }
}