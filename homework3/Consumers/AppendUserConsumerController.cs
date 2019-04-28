using System.Threading.Tasks;
using homework3.Commands;
using MassTransit;
using ModulSchool.Services.Interfaces;

namespace homework3.Consumers
{
    public class AppendUserConsumer : IConsumer<AppendUserCommand>
    {
        private readonly IUserInfoService _userInfoService;

        public AppendUserConsumer(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task Consume(ConsumeContext<AppendUserCommand> context)
        {
            await _userInfoService.AppendUser(context.Message.User);
        }
    }
}