using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CST356_Sovanny_Yun_FinalProject.Services;
using CST356_Sovanny_Yun_FinalProject.Models;
using Microsoft.AspNet.Identity;

namespace CST356_Sovanny_Yun_FinalProject.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoserv)
        {
            _todoService = todoserv;
        }

        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();

            var todoModel = _todoService.GetTodoForUser(userId);

            return View(todoModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ToDoModel todoModel)
        {

            if (!ModelState.IsValid) return View();

            try
            {
                var userId = User.Identity.GetUserId();
                _todoService.SaveTodo(todoModel, userId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var todo = _todoService.GetTodo(id);

            return View(todo);
        }

        [HttpPost]
        public ActionResult Edit(ToDoModel todoModel)
        {
            if (ModelState.IsValid)
            {
                _todoService.UpdateTodo(todoModel);

                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var todo = _todoService.GetTodo(id);

            return View(todo);
        }

        public ActionResult Delete(int id)
        {
            _todoService.DeleteTodo(id);

            return RedirectToAction("List");
        }
    }
}