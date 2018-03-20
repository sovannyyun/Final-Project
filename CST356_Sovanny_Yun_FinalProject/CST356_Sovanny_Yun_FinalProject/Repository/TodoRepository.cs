using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CST356_Sovanny_Yun_FinalProject.Data;
using CST356_Sovanny_Yun_FinalProject.Models;
using System.Data.Entity;
using Db = CST356_Sovanny_Yun_FinalProject.Data;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace CST356_Sovanny_Yun_FinalProject.Repository
{
    public class TodoRepository : ITodoRepository
    {

        private readonly Data.Entities1 _dbcontext;
        private DbSet<Db.Todo> TodoDbSet { get; set; }

        public TodoRepository(Entities1 dbcontext)
        {
            _dbcontext = dbcontext;
            TodoDbSet = _dbcontext.Todoes;
        }

        public void DeleteTodo(int id)
        {
            var todo = _dbcontext.Todoes.Find(id);
            if (todo == null) return;

            TodoDbSet.Remove(todo);
            _dbcontext.SaveChanges();
        }

        public Todo GetTodo(int id)
        {
            return _dbcontext.Todoes.Find(id);
        }

        public List<Todo> GetTodoForUser(string userId)
        {

            try
            {
                var todoList = TodoDbSet.Where(x => x.UserId == userId).ToList();

                return todoList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void SaveTodo(Todo todo)
        {
            try
            {
                TodoDbSet.Add(todo);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateTodo(Todo todo)
        {
            var todoToChange = TodoDbSet.FirstOrDefault(x => x.Id == todo.Id);

            todoToChange.Description = todo.Description;
            todoToChange.Status = todo.Status;
            _dbcontext.SaveChanges();
        }
    }
}
