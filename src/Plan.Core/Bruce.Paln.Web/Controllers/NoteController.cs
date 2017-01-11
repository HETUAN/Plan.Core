using Bruce.Paln.Entity;
using Bruce.Paln.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bruce.Paln.Web.Controllers
{
    public class NoteController : BaseController
    {
        readonly NoteService _service;

        public NoteController()
        {
            _service = new NoteService();
        }

        public JsonResult GetLastModel()
        {
            return Json(_service.GetLastMode());
        }

        public JsonResult GetModel(int id)
        {
            if (id == 0)
                return Json(new { });
            return Json(_service.GetMode(id));
        }

        public ActionResult GetListPager(int pageindex, int pageSize, string title)
        {
            int rows;
            var list = _service.GetList(GetUserId(), pageindex, pageSize, title, out rows);
            return Json(new { rowCount = rows, curIndex = pageindex, List = list });
        }

        [HttpPost]
        public ActionResult Add(NoteEntity node)
        {
            //
            node.UserId = GetUserId();
            node.CreateTime = DateTime.Now;
            node.UpdateTime = DateTime.Now;
            return Json(new { result = (_service.Insert(node) > 0) });
        }

        [HttpPost]
        public ActionResult Edit(NoteEntity node)
        {
            return Json(new { result = (_service.Update(node) > 0) });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return Json(_service.Delete(id));
        }
    }
}