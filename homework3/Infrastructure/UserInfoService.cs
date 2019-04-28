using System;
using System.Threading.Tasks;
using ModulSchool.Models;
using ModulSchool.Services.Interfaces;
using Npgsql;
//using Dapper;

namespace ModulSchool.Services
{
    public class UserInfoService : IUserInfoService
    {
        private const string ConnectionString =
            "host=localhost;port=5432;database=postgres;username=postgres;password=1";

        public async Task<User> GetById(Guid id)
        {
            User user = new User
            {
                Email = "test@test.ru",
                Id = id,
                Nickname = "test",
                Phone = "+7 987 654 32 10"
            };

            return await Task.FromResult<User>(user);
        }
    }
}
