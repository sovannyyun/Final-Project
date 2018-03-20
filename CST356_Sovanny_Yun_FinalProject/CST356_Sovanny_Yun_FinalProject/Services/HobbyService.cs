using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CST356_Sovanny_Yun_FinalProject.Models;
using CST356_Sovanny_Yun_FinalProject.Data;
using CST356_Sovanny_Yun_FinalProject.Repository;
using Microsoft.AspNet.Identity;

namespace CST356_Sovanny_Yun_FinalProject.Services
{
    public class HobbyService : IHobbyService
    {
        private readonly IHobbyRepository _repo;

        public HobbyService(IHobbyRepository hobbyRepo)
        {
            _repo = hobbyRepo;
        }

        public void DeleteHobby(int id)
        {
            _repo.DeleteHobby(id);
        }

        public HobbyModel GetHobby(int id)
        {
            return MapToHobbyModel(_repo.GetHobby(id));
        }

        public List<HobbyModel> GetHobbyForUser(string userId)
        {
            var newHobbyModelList = new List<HobbyModel>();
            foreach (var item in _repo.GetHobbyForUser(userId))
            {
                newHobbyModelList.Add(MapToHobbyModel(item));
            }
            return newHobbyModelList;
        }

        public void SaveHobby(HobbyModel hobby, string userId)
        {
            _repo.SaveHobby(MapToHobby(hobby, userId));
        }

        public void UpdateHobby(HobbyModel hobby)
        {
            _repo.UpdateHobby(MapToHobby(hobby));
        }

        private HobbyModel MapToHobbyModel(Hobby dbHobby)
        {
            var newHobbyModel = new HobbyModel()
            {
                Id = dbHobby.Id,
                Name = dbHobby.HobbyName
            };
            return newHobbyModel;
        }

        private Hobby MapToHobby(HobbyModel hobby, string userId = null)
        {
            if (userId == null)
            {
                var newHobbyDb = new Hobby()
                {
                    Id = hobby.Id,
                    HobbyName = hobby.Name

                };
                return newHobbyDb;

            }
            else
            {
                var newHobbyDb = new Hobby()
                {
                    Id = hobby.Id,
                    HobbyName = hobby.Name,
                    UserId = userId

                };
                return newHobbyDb;

            }

        }
    }
}