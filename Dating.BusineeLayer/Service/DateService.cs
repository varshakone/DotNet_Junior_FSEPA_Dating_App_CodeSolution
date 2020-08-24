using Dating.BusinessLayer.Interface;
using Dating.BusinessLayer.Service.Repository;
using Dating.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dating.BusinessLayer.Service
{
   public class DateService:IDateService
    {

        private readonly IDateRepository _dateRepository;
        /// <summary>
        /// 
        /// </summary>
        public DateService(IDateRepository dateRepository)
        {
            _dateRepository = dateRepository;
        }

        /// <summary>
        /// Call user repository method to send request
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> SendRequest(DateDetails user)
        {
            try
            {
                var result = await _dateRepository.SendRequest(user);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
