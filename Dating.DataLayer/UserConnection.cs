using System;
using System.Collections.Generic;
using System.Text;

namespace Dating.DataLayer
{
    public class UserConnection : IUserConnection
    {
        private readonly UserContext _userContext;
        public UserConnection(UserContext userContext)
        {
            _userContext = userContext;
        }
        public UserContext GetUserContext => _userContext;
    }
}
