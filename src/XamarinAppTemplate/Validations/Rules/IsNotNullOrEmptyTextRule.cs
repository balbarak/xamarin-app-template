using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppTemplate.Validations
{
    public class IsNotNullOrEmptyTextRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
