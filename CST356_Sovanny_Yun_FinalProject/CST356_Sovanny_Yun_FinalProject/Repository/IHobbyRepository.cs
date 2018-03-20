using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST356_Sovanny_Yun_FinalProject.Models;
using Db = CST356_Sovanny_Yun_FinalProject.Data;

namespace CST356_Sovanny_Yun_FinalProject.Repository
{
    public interface IHobbyRepository
    {
        void SaveHobby(Db.Hobby todo);
        void UpdateHobby(Db.Hobby todo);
        void DeleteHobby(int id);

        List<Db.Hobby> GetHobbyForUser(string userId);

        Db.Hobby GetHobby(int id);
    }
}
