using System;
using System.Threading.Tasks;

using MassTransit;

// тут была зависимость от homework3.Services
//using homework3.Models;
using homework3.Commands;
using ModulSchool.Models;

namespace homework3.Application
{
    public class AppendUsersRequestHandler
    {
        private readonly IBus _bus;

        public AppendUsersRequestHandler(IBus bus)
        {
            _bus = bus;
        }

        public Task<User> Handle(User user)
        {
            Guid guid = Guid.NewGuid();
            user.Id = guid;

            // было так: _userInfoService.AppendUser(user);
            _bus.Send(new AppendUserCommand()
            {
                User = user
            });

            return Task.FromResult<User>(user);
        }
    }
}