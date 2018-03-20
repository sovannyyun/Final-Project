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
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repo;

        public TodoService(ITodoRepository todoRepository)
        {
            _repo = todoRepository;
        }

        public void DeleteTodo(int id)
        {
            _repo.DeleteTodo(id);
        }

        public ToDoModel GetTodo(int id)
        {
            return MapToToDoModel(_repo.GetTodo(id));
        }

        public List<ToDoModel> GetTodoForUser(string userId)
        {
            try
            {
                var newToDoModelList = new List<ToDoModel>();
                foreach (var item in _repo.GetTodoForUser(userId))
                {
                    newToDoModelList.Add(MapToToDoModel(item));
                }
                return newToDoModelList;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public void SaveTodo(ToDoModel todo, string userId)
        {
            _repo.SaveTodo(MapToToDoDb(todo, userId));
        }

        public void UpdateTodo(ToDoModel todo)
        {
            _repo.UpdateTodo(MapToToDoDb(todo));
        }

        private ToDoModel MapToToDoModel(Todo dbToDo)
        {
            var newTodoModel = new ToDoModel()
            {
                Id = dbToDo.Id,
                CreatedOn = dbToDo.CreatedOn,
                Description = dbToDo.Description,
                Status = dbToDo.Status == Status.Done.ToString()
                         ? Status.Done
                         : Status.InProgress
            };
            return newTodoModel;
        }

        private Todo MapToToDoDb(ToDoModel dbToDo, string userId = null)
        {
            if (userId == null)
            {
                var newTodoDb = new Todo()
                {
                    Id = dbToDo.Id,
                    CreatedOn = dbToDo.CreatedOn,
                    Description = dbToDo.Description,
                    Status = dbToDo.ToString()
                };
                return newTodoDb;
            }
            else
            {
                var newTodoDb = new Todo()
                {
                    Id = dbToDo.Id,
                    CreatedOn = dbToDo.CreatedOn,
                    Description = dbToDo.Description,
                    Status = dbToDo.ToString(),
                    UserId = userId
                };
                return newTodoDb;
            }

        }
    }
}