using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST356_Sovanny_Yun_FinalProject.Models
{
    public enum Status
    {
        Done,
        InProgress
    }

    public class UserModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public HobbyModel Hobby { get; set; }

        public List<ToDoModel> ToDoList { get; set; }

    }

    public class HobbyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ToDoModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
        public Status Status { get; set; }
    }


}