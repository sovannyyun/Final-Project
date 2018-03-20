using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CST356_Sovanny_Yun_FinalProject.Models;

namespace CST356_Sovanny_Yun_FinalProject.Services
{
    public interface ITodoService
    {
        void SaveTodo(ToDoModel todo,string userId);
        void UpdateTodo(ToDoModel todo);
        void DeleteTodo(int id);

        List<ToDoModel> GetTodoForUser(string userId);

        ToDoModel GetTodo(int id);
    }
}
