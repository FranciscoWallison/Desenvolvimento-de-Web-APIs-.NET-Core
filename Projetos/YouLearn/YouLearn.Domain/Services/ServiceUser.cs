using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ObjectValue;

namespace YouLearn.Domain.Services
{
    public class ServiceUser : Notifiable, IServiceUser
    {
        //Dependencias
        private readonly IRepositoryUser _repositoryUser;

        //Construtor
        public ServiceUser(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public AddUserResponse AddUser(AddUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AddUserRequest",
                 MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AddUserRequest"));
                
                return null;
            }

            //Create values objects
            Name name = new Name(request.FirstName, request.LastName); 
            Email email = new Email(request.Email);

            //Create entity
            User user = new User(name , email, request.Password);

            AddNotifications(user);

            if(this.IsInvalid()) return null;

             //There is no database
            _repositoryUser.ToSave(user);

            return new AddUserResponse(user.Id);
        }

        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AuthenticateUserRequest", 
                    MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AuthenticateUserRequest"));
                return null;
            }

            var email = new Email(request.Email);
            var user = new User(email, request.Password);

            AddNotifications(user);

            if(this.IsInvalid()) return null;

            user = _repositoryUser.Get(user.Email.Address, user.Password);

            if(user == null){
                AddNotification("User", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var response = new AuthenticateUserResponse(){
                Id = user.Id,
                FirstName = user.Name.FirstName
            };

            return response;
        }
        
    }
}