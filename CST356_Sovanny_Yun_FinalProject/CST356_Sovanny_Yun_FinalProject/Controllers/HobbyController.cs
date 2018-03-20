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
    public class HobbyController : Controller
    {
        private readonly IHobbyService _hobbyService;
        public HobbyController(IHobbyService hobbyserv)
        {
            _hobbyService = hobbyserv;
        }

        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();

            var hobbyModel = _hobbyService.GetHobbyForUser(userId);

            return View(hobbyModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HobbyModel hobbyModel)
        {

            if (!ModelState.IsValid) return View();

            try
            {
                var userId = User.Identity.GetUserId();
                _hobbyService.SaveHobby(hobbyModel, userId);
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
            var hobby = _hobbyService.GetHobby(id);

            return View(hobby);
        }

        [HttpPost]
        public ActionResult Edit(HobbyModel hobbyModel)
        {
            if (ModelState.IsValid)
            {
                _hobbyService.UpdateHobby(hobbyModel);

                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var hobby = _hobbyService.GetHobby(id);

            return View(hobby);
        }

        public ActionResult Delete(int id)
        {
            _hobbyService.DeleteHobby(id);

            return RedirectToAction("List");
        }
    }
}