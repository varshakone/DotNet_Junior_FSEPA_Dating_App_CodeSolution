using Dating.DataLayer;
using Dating.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dating.BusinessLayer.Service.Repository
{
   public class UserRepository : IUserRepository
    {
        private readonly IUserConnection _userConnection;
        /// <summary>
        /// Inject UserContext object
        /// </summary>
        public UserRepository(UserContext userContext)
        {
            _userConnection = new UserConnection(userContext);
        }

        /// <summary>
        /// In-Memory DB logic to add user profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public async Task<Profile> AddProfile(Profile profile)
        {
            try
            {
                String message = string.Empty;
                var userContext = _userConnection.GetUserContext;
                var LstProfiles = userContext.Profiles;
                var result = await LstProfiles.AddAsync(profile);
                userContext.SaveChanges();
                
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// In-Memory DB logic to create new user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> CreateNewUser(User user)
        {
            try
            {
                String message = string.Empty;
                var userContext = _userConnection.GetUserContext;
                var LstUsers = userContext.Users;
                var result = await LstUsers.AddAsync(user);

                if(result !=null)
                {
                    userContext.SaveChanges();
                    message = "New User Registered";
                }
                return message; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// In-Memory DB logic to return list of users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> ListOfMembers()
        {
            try
            {
                var userContext = _userConnection.GetUserContext;
                var result = userContext.Users;
                               
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// In-Memory DB logic to verify user exist or not
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public async Task<User> VerifyUser(string UserName, string Password)
        {
            try
            {
                var userContext = _userConnection.GetUserContext;
                var LstUsers = userContext.Users;

                var result =await LstUsers.SingleOrDefaultAsync(usr =>usr.UserName == UserName && usr.Password==Password);
                return result;
            }            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
