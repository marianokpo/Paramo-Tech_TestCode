using Application.Commmon.Interfaces;
using Application.Commmon.Validations;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserCase.V1.UserOperation.Commonds
{
    public record struct PostCreateUser : IRequest<Result>
    {
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string userType { get; set; }
        public string money { get; set; }
    }

    public class PostCreateUserHandler : IRequestHandler<PostCreateUser, Result>
    {
        private readonly IFilesServices _filesServices;
        private readonly IUsersServices _usersServices;

        public PostCreateUserHandler(IFilesServices filesServices, IUsersServices usersServices)
        {
            _filesServices = filesServices;
            _usersServices = usersServices;
        }

        public async Task<Result> Handle(PostCreateUser request, CancellationToken cancellationToken)
        {
            var errors = "";

            ValidateUser.ValidateErrors(request.name, request.email, request.address, request.phone, ref errors);

            if (errors != null && errors != "")
                return new Result()
                {
                    IsSuccess = false,
                    Errors = errors
                };

            User newUser = await _usersServices.NewUser(request.name,
                request.email, request.address, request.phone,
                request.userType, request.money);

            List<User> _users = await _filesServices.GetUsersFromFile();

            //Normalize email
            newUser.Email = await _usersServices.NormalizeEmail(newUser.Email);

            if (await _usersServices.isDuplicate(newUser, _users))
            {
                Debug.WriteLine("The user is duplicated");

                return new Result()

                {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                };
            }
            else
            {
                Debug.WriteLine("User Created");

                return new Result()
                {
                    IsSuccess = true,
                    Errors = "User Created"
                };
            }
        }
    }
}