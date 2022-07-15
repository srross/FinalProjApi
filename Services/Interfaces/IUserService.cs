using FinalProjApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjApi.Services.Interfaces
{
    public interface IUserService
    {
        void AddNewUser(User user);

        User GetUserById(int id);
    }
}