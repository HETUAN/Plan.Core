using Bruce.Paln.Web.Helper;
using Bruce.Paln.Entity;
using Bruce.Paln.Service;
using Microsoft.AspNetCore.Mvc;

namespace Bruce.Paln.Web.Controllers
{
    public class LeetCodeController : BaseController
    {
        readonly LeetCodeHelper _leetCode;

        public LeetCodeController()
        {
            _leetCode = new LeetCodeHelper();
        }

        //
        // GET: /LeetCode/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllQuestion()
        {
            //
            return Json(_leetCode.GetAllQuestion());
        }

        public JsonResult GetNextQuestion()
        {
            LeetQuestionService _service = new LeetQuestionService();
            return Json(_service.GetNextLeetQuestion(GetUserId()));
        }

        public JsonResult GetList()
        {
            LeetQuestionService _service = new LeetQuestionService();
            return Json(_service.GetList(GetUserId()));
        }

        public JsonResult AddAnswer(int questionId, string answer)
        {
            LeetAnswerEntity entity = new LeetAnswerEntity();
            entity.UserId = GetUserId();
            entity.Answer = answer;
            entity.Status = 1;
            entity.LeetCodeId = questionId;
            LeetAnswerService _service = new LeetAnswerService();
            return Json(new { result = (_service.Insert(entity) > 0) });
        }

    }
}