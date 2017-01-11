using Bruce.Paln.Entity;
using Bruce.Paln.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bruce.Paln.Web.Controllers
{
    public class DailyController : BaseController
    {
        private readonly DailyService _service;

        /// <summary>
        /// 需求分析：
        /// 1. 列表页，分页每页五个可以查找。
        /// 2. 添加，在添加的时候根据当天的日期判断当天的日记是否已经存在，如果已经存在那么就直接跳到编辑页面。
        /// 3. 编辑就是编辑。
        /// 4. 暂时没有删除。
        /// </summary>
        public DailyController()
        {
            _service = new DailyService();
        }

        public ActionResult GetModel(int id)
        {
            return Json(_service.GetModel(id));
        }

        public ActionResult GetModelByDate(DateTime date)
        {
            var result = _service.GetModel(GetUserId(), date);
            if (result == null)
            {
                return Json(new { });
            }
            else
            {
                return Json(result);
            }
        }

        public ActionResult GetList()
        {
            return Json(_service.GetList(GetUserId()));
        }

        public ActionResult GetListPager(int pageindex, int pageSize, string title, string date)
        {
            DateTime? dt = null;
            int rows;
            if (date != "")
                dt = Convert.ToDateTime(date);
            var list = _service.GetList(GetUserId(), pageindex, pageSize, title, dt, out rows);
            return Json(new { rowCount = rows, curIndex = pageindex, List = list });
        }

        [HttpPost]
        public ActionResult Add(DailyEntity model)
        {
            model.UserId = GetUserId();
            //model.DailyDate = model.DailyDate.Date;
            model.DailyDate = DateTime.Now.Date;
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            return Json(new { result = (_service.Count(DateTime.Now) <= 0 ? _service.Insert(model) : _service.Update(model)) > 0 });
        }

        [HttpPost]
        public ActionResult Edit(DailyEntity model)
        {
            model.UserId = GetUserId();
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            return Json(new { result = _service.Update(model) > 0 });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return Json(_service.Delete(id));
        }
         
    }
}