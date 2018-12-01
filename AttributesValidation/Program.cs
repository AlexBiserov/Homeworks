using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesValidation
{
    class AccountModel
    {
        [StringLength(50, ErrorMessage = "Длина логина должна быть 4 - 50 символов", MinimumLength = 4)]
        public string Login { get; set; }

        [StringLength(50, ErrorMessage = "Длина пароля должна быть 4-8 символов", MinimumLength = 4)]
        public string Password { get; set; }

        [RegularExpression("@", ErrorMessage = "Проверьте правильность ввода email")]
        public string Email { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        
        public string ConfirmPassword { get; set; }

        [Range(18, 100, ErrorMessage = "Возраст должен быть больше 1 и меньше 100")]
        public int Age { get; set; }

        [MyCustom(ErrorMessage = "Empty or null")]
        public string Text { get; set; }
    }
    class MyCustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return !string.IsNullOrWhiteSpace(value as string);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AccountModel am = new AccountModel
            {
                ConfirmPassword = "admin",
                Email = "admin@gmail.com",
                Password = "admin",
                Age = 0,
                Login = "1",
                Text = "s"
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(am);

            //Если валидация не прошла
            if (!Validator.TryValidateObject(am, context, validationResults, true))
            {
                //Перебор ошибок
                foreach (var error in validationResults)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Valid");
            }

            Console.Read();
        }
    }
}
