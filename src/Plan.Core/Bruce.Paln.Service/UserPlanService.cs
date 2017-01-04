using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;
using Bruce.Paln.Repository;
using System;
using System.Collections.Generic;

namespace Bruce.Paln.Service
{
    public class UserPlanService
    {
        private readonly UserPlanRepository _repository;

        public UserPlanService()
        {
            _repository = new UserPlanRepository();
        }

        public int Insert(UserPlanEntity entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(UserPlanEntity entity)
        {
            return _repository.Update(entity);
        }
        /// <summary>
        /// 物理删除数据
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public int Delete(int entityId)
        {
            return _repository.Delete(entityId);
        }

        public UserPlanEntity GetModel(int id)
        {
            return _repository.GetModel(id);
        }
        public List<UserPlanEntity> GetList()
        {
            return _repository.GetList();
        }

        public List<UserPlanViewModel> GetVmList()
        {
            return _repository.GetVmList();
        }

        /// <summary>
        /// 获取业务实体列表
        /// </summary>
        /// <returns></returns>
        public List<UserPlanViewModel> GetVmList(int userId, DateTime startTime, DateTime endTime)
        {
            return _repository.GetVmList(userId, startTime, endTime);
        }

        /// <summary>
        /// 检查时间是否冲突
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int CheckConflict(int userId, DateTime startTime, DateTime endTime)
        {
            return _repository.CheckConflict(userId, startTime, endTime);
        }
    }
}
