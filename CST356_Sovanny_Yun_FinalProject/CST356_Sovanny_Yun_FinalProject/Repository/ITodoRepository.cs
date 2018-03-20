using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db = CST356_Sovanny_Yun_FinalProject.Data;
using CST356_Sovanny_Yun_FinalProject.Models;


namespace CST356_Sovanny_Yun_FinalProject.Repository
{
    public interface ITodoRepository
    {
        void SaveTodo(Db.Todo todo);
        void UpdateTodo(Db.Todo todo);
        void DeleteTodo(int id);

        List<Db.Todo> GetTodoForUser(string userId);

        Db.Todo GetTodo(int id);
    }
}
