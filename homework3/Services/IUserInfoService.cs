using ModulSchool.Models;
using System;
using System.Threading.Tasks;

namespace ModulSchool.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<User> GetById(Guid id);
    }
}
