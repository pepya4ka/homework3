using Dapper;
using ModulSchool.Models;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace ModulSchool.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<User> GetById(Guid id);
        Task AppendUser(object user);
    }

    public async void AppendUser(User user)
    {
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            string query = "INSERT INTO users (id, email, nickname, phone) VALUES (@id, @email, @nickname, @phone)";

            await connection.QuerySingleAsync<User>(query, user);
        }
    }
}
