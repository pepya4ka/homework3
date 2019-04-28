using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModulSchool.BusinessLogic;
using ModulSchool.Models;

namespace homework3.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly GetUsersInfoRequestHandler _getUsersInfoRequestHandler;

        public UserController(GetUsersInfoRequestHandler getUsersInfoRequestHandler)
        {
            _getUsersInfoRequestHandler = getUsersInfoRequestHandler;
        }

        [HttpGet("{id}")]
        public Task<User> GetUserInfo(Guid id)
        {
            return _getUsersInfoRequestHandler.Handle(id);
        }

        [HttpPost("append")]
        public Task<User> AppendUser(User user)//[FromBody]
        {
            Guid guid = Guid.NewGuid();
            user.Id = guid;

            return Task.FromResult<User>(user);
        }
    }
}