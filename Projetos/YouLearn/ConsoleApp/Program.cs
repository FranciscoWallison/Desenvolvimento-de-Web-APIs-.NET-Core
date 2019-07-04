using System;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AddUserRequest request = new AddUserRequest()
            {
                Email = "franciscowallison@gmail.com",
                FirstName = "Wallison",
                LastName = "Chico",
                Password = "12345"
            };

            var response = new ServiceUser().AddUser(request);
Console.WriteLine("Hello World!"+  response);
            Console.ReadKey();
        }
    }
}
