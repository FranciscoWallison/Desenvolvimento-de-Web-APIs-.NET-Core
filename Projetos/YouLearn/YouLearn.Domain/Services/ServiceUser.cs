using System;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ObjectValue;


namespace YouLearn.Domain.Services
{
    public class ServiceUser : Notifiable, IServiceUser
    {

        public AddUserResponse AddUser(AddUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AddUserRequest",
                 MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AddUserRequest"));
                
                return null;
            }

            //Cria entidade
            Name name = new Name(request.FirstName, request.LastName); 
            Email email = new Email(request.Email);

            User user = new User();
            user.Name = name;
            user.Email = email;
            user.Password = request.Password;

            AddNotifications(name, email, user);

            if(user.Password.Length <= 3 )
            {
                throw new Exception("Senha deve ter no minimo 3 caracteres");
            }

            //Persiste no banco de dados
            //AddUserResponse response = new RepositoryUser().ToSave(user);

            //return response;

            if(IsInvalid())
                return null;

            return new AddUserResponse(Guid.NewGuid());
        }

        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            throw new System.NotImplementedException();
        }
        
    }
}