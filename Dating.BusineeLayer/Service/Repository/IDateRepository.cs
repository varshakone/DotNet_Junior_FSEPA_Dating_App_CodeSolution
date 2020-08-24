using Dating.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dating.BusinessLayer.Service.Repository
{
   public interface IDateRepository
    {
        Task<String> SendRequest(DateDetails user);
    }
}
