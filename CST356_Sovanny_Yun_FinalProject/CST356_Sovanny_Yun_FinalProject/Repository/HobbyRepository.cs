using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CST356_Sovanny_Yun_FinalProject.Models;
using System.Data.Entity;
using Db = CST356_Sovanny_Yun_FinalProject.Data;

namespace CST356_Sovanny_Yun_FinalProject.Repository
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly Data.Entities1 _dbcontext;
        private DbSet<Db.Hobby> HobbyDbSet { get; set; }
        public HobbyRepository(Db.Entities1 dbcontext)
        {
            this._dbcontext = dbcontext;
            HobbyDbSet = dbcontext.Hobbies;
        }

        public void DeleteHobby(int id)
        {
            var hobby = _dbcontext.Hobbies.Find(id);
            if (hobby == null) return;

            HobbyDbSet.Remove(hobby);
            _dbcontext.SaveChanges();
        }

        public Db.Hobby GetHobby(int id)
        {
            return _dbcontext.Hobbies.Find(id);
        }

        public List<Db.Hobby> GetHobbyForUser(string userId)
        {
            var todoList = HobbyDbSet.Where(x => x.UserId == userId).ToList();

            return todoList;
        }

        public void SaveHobby(Db.Hobby hobby)
        {
            HobbyDbSet.Add(hobby);
            _dbcontext.SaveChanges();
        }

        public void UpdateHobby(Db.Hobby hobby)
        {
            var HobbyToChange = HobbyDbSet.FirstOrDefault(x => x.Id == hobby.Id);
            HobbyToChange.HobbyName = hobby.HobbyName;
            _dbcontext.SaveChanges();
        }
    }
}