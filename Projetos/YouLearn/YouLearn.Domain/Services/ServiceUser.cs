using System;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Services
{
    public class ServiceUser : IServiceUser
    {

        public AddUserResponse AddUser(AddUserRequest request)
        {
            if (request == null)
            {
                throw new Exception("Objeto AddUserRequest é obrigatório."); 
            }

            User user = new User();
            user.Name.FirstName = "Wallison";
            user.Name.LastName = "Chico";
            user.Email.Address = "franciscowallison@gmail.com";
            user.Password = "teste";

            if(user.Name.FirstName.Length < 3 || user.Name.FirstName.Length > 50)
            {
                throw new Exception("Primeiro nome é obrigatório e deve conter entre 3 à 50 caracteres");
            }

            if(user.Name.LastName.Length < 3 || user.Name.LastName.Length > 50)
            {
                throw new Exception("Primeiro nome é obrigatório e deve conter entre 3 à 50 caracteres");
            }

            if(user.Email.Address.IndexOf('@')  < 1 )
            {
                throw new Exception("Email invalido");
            }

            if(user.Password.Length >= 3 )
            {
                throw new Exception("Senha deve ter no minimo 3 caracteres");
            }

            //Persiste no banco de dados
            AddUserResponse response = new RepositoryUser().ToSave(user);

            return response;
        }

        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            throw new System.NotImplementedException();
        }
        
    }
}