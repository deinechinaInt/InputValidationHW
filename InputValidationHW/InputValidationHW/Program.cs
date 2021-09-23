using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace InputValidationHW
{
    class Program
    {
        static void Main(string[] args)
        {          
            var inputs = new List<Input>()
            {
                new Input
                {
                    FieldName ="Email", 
                    RegularEx= @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z", 
                    ExpectedFormat="myemail@address.com" 
                },
                new Input
                { 
                    FieldName = "Mobile Phone", 
                    RegularEx = @"^\+[1-9]\d{1,14}$", 
                    ExpectedFormat ="+37300000000" 
                },
                 new Input
                {
                    FieldName = "Birth Date",
                    RegularEx = @"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$",
                    ExpectedFormat ="01.01.2021"  
                },
                 new Input
                {
                    FieldName = "Zip Code",
                    RegularEx = @"^[0-9]{4}$",
                    ExpectedFormat ="4 digits"
                },
                  new Input
                {
                    FieldName = "Website",
                    RegularEx = @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|"
                               +@"www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|"
                               +@"https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})",
                    ExpectedFormat ="www.____.com"
                }
            };

            foreach(var input in inputs)
            {
                var success = false;
                while (!success)
                {
                    try
                    {
                        Console.WriteLine($"Enter {input.FieldName}: ");
                        var userInput = Console.ReadLine();
                        ValidateInput(userInput, input);
                        success = true;

                    }
                    catch (IncorrectInputFormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    
                }
                
            }
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();            
        }

        private static void ValidateInput(string userInput, Input input)
        {
            var regexToCheck = new Regex(input.RegularEx);
            if (string.IsNullOrEmpty(userInput) || !regexToCheck.IsMatch(userInput))
            {
                throw new IncorrectInputFormatException(input);
            }
        }
    }
}
