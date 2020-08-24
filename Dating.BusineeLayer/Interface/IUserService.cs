using Dating.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dating.BusinessLayer.Interface
{
   public interface IUserService
    {
        Task<String> CreateNewUser(User user);
      
        Task<User> VerifyUser(String UserName, String Password);

        Task<Profile> AddProfile(Profile profile);
       
        Task<IEnumerable<User>> ListOfMembers();
    }
}