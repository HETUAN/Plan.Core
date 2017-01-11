using Bruce.Paln.Entity;
using Bruce.Paln.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bruce.Paln.Web.Controllers
{
    public class HomeController : BaseController
    {
        readonly UserPlanService _upService = new UserPlanService();
        readonly PlanResultService _prService = new PlanResultService();
        //
        // GET: /Home/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Test()
        {
            return View();
        }

        [Authorize]
        public ActionResult Home()
        {
            return View();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public JsonResult GetData(int type, DateTime? startTime, DateTime? endTime)
        {
            startTime = startTime == null ? DateTime.Now.Date : startTime.Value.Date;
            endTime = endTime == null ? DateTime.Now.Date.AddDays(1) : endTime.Value.Date.AddDays(1);
            //var ll = upService.GetVmList().Where(item => item.HappenTime >= startTime.Value.Date && item.HappenTime.Date <= endTime.Value.Date);
            var ll = _upService.GetVmList(GetUserId(), (DateTime)startTime, (DateTime)endTime);
            return Json(ll);
        }

        /// <summary>
        /// 获取计划实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public JsonResult GetModel(int id)
        {
            if (id > 0)
            {
                return Json(_upService.GetModel(id));
            }
            else
            {
                return Json(new { });
            }
        }

        /// <summary>
        /// 添加计划
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public JsonResult Add(UserPlanEntity entity)
        {
            entity.UserId = GetUserId();
            int id = _upService.Insert(entity);
            var result = new { result = (id > 0) };
            return Json(result);
        }

        /// <summary>
        /// 编辑计划
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public JsonResult Edit(UserPlanEntity entity)
        {
            //entity.UserId = Account.UserId;
            var id = _upService.Update(entity);
            var result = new { result = id };
            return Json(result);
        }

        /// <summary>
        /// 删除计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public JsonResult Delete(int id)
        {
            if (id > 0)
            {
                int row = _upService.Delete(id);
                return Json(new { result = row > 0 });
            }
            else
            {
                return Json(new { });
            }
        }

        /// <summary>
        /// 添加结果
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public JsonResult AddResult(PlanResultEntity entity)
        {
            var id = _prService.ExistResult(entity.PlanId) ? _prService.Update(entity) : _prService.Insert(entity);
            var result = new { result = (id > 0) };
            return Json(result);
        }

        /// <summary>
        /// 编辑结果
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public JsonResult EditResult(PlanResultEntity entity)
        {
            int id = _prService.Update(entity);
            var result = new { result = (id > 0) };
            return Json(result);
        }

        /// <summary>
        /// 获取结果实体
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        [Authorize]
        public JsonResult GetResultModel(int planId)
        {
            return Json(_prService.GetModel(planId));
        }

        /// <summary>
        /// 时间是否有冲突
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="useTime"></param>
        /// <returns></returns>
        [Authorize]
        public JsonResult CheckConflict(DateTime startTime, int useTime)
        {
            //
            DateTime endTime = startTime.AddMinutes(useTime);
            int result = _upService.CheckConflict(GetUserId(), startTime, endTime);
            return Json(new { result = (result > 0) });
        }
    }
}