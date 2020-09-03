using System.ComponentModel.DataAnnotations;

namespace CarServiceApp.ValidationAttributes
{
    public class NullOrLimitLengthStringAttribute : ValidationAttribute
    {
        private int minLength { get; set; }

        private int? maxLength { get; set; }

        public NullOrLimitLengthStringAttribute(int minLength)
        {
            this.minLength = minLength;
        }

        public NullOrLimitLengthStringAttribute(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            if (maxLength == null && value.ToString().Length >= minLength)
                return true;

            if (value.ToString().Length >= minLength && value.ToString().Length <= maxLength)
                return true;

            return false;
        }
    }
}
