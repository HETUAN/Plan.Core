using System;
using Bruce.Paln.Service;
using Microsoft.AspNetCore.Mvc;

namespace Bruce.Paln.Web.Controllers
{
    public class KeyCountController : BaseController
    {
        readonly KeyCountService _service;

        public KeyCountController()
        {
            _service = new KeyCountService();
        }

        public ActionResult Index()
        {
            return View();
        }

        //获取最近七天数据
        public JsonResult GetLastSevenDaysData()
        {
            return Json(_service.GetLast7DayViewModels(GetUserId()));
        }

        public JsonResult GetData(DateTime sday, DateTime eday)
        {
            return Json(_service.GetViewModels(GetUserId(), sday, eday));
        }

    }
}