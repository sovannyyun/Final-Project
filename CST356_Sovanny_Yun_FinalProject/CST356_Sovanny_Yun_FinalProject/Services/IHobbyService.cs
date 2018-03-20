using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST356_Sovanny_Yun_FinalProject.Models;

namespace CST356_Sovanny_Yun_FinalProject.Services
{
    public interface IHobbyService
    {
        void SaveHobby(HobbyModel todo, string userId);
        void UpdateHobby(HobbyModel todo);
        void DeleteHobby(int id);

        List<HobbyModel> GetHobbyForUser(string userId);

        HobbyModel GetHobby(int id);
    }
}
