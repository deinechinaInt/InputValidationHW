using System;

namespace InputValidationHW
{
    public class IncorrectInputFormatException : Exception
    {

        public IncorrectInputFormatException(Input input) : base(string.Format("Incorrect input format for field {0}. Try to enter in format: {1}", input.FieldName, input.ExpectedFormat))
        {

        }
    }
}
