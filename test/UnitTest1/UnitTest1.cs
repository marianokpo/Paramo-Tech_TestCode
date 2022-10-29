using System.Threading;
using Application.Commmon.Interfaces;
using Application.UserCase.V1.UserOperation.Commonds;
using Infrastructure.Services;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private readonly IFilesServices _filesServices;
        private readonly IUsersServices _usersServices;
        private PostCreateUserHandler _handler;
        private CancellationToken _cancellationToken;

        public UnitTest1()
        {
            _filesServices = new FilesServices();
            _usersServices = new UsersServices();
            _cancellationToken = CancellationToken.None;
            _handler = new PostCreateUserHandler(_filesServices, _usersServices);
        }

        [Fact]
        public async void CreateUser()
        {
            PostCreateUser postCreateUser = new PostCreateUser()
            {
                name = "Mike",
                email = "mike@gmail.com",
                address = "Av. Juan G",
                phone = "+349 1122354215",
                userType = "Normal",
                money = "124"
            };

            var result = await _handler.Handle(postCreateUser, _cancellationToken);

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public async void DuplicateUser()
        {
            PostCreateUser postCreateUser = new PostCreateUser()
            {
                name = "Agustina",
                email = "Agustina@gmail.com",
                address = "Av. Juan G",
                phone = "+349 1122354215",
                userType = "Normal",
                money = "124"
            };

            var result = await _handler.Handle(postCreateUser, _cancellationToken);

            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public async void DataErrorUser()
        {
            PostCreateUser postCreateUser = new PostCreateUser()
            {
                name = "",
                email = null,
                address = "Av. Juan G",
                phone = "+349 1122354215",
                userType = "Normal",
                money = "124"
            };

            var result = await _handler.Handle(postCreateUser, _cancellationToken);

            Assert.False(result.IsSuccess);
            Assert.Equal("The name is required The email is required", result.Errors);
        }
    }
}