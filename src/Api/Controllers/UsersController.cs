using Application.UserCase.V1.UserOperation.Commonds;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name,
            string email, string address, string phone, string userType, string money)
        {
            return await _mediator.Send(new PostCreateUser()
            {
                name = name,
                email = email,
                address = address,
                phone = phone,
                userType = userType,
                money = money
            });
        }
    }
}