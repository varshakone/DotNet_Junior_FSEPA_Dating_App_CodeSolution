using Dating.DataLayer;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Dating.Tests.Utility
{
   public class InMemoryDBUtility
    {

        private DatingContext _dateContext;
        private UserContext _userContext;
        private IUserConnection _userConnection;
        private IDateConnection _dateConnection;
        public InMemoryDBUtility()
        {
            DbContextOptions<DatingContext> contextOptions = new DbContextOptions<DatingContext>();
            DbContextOptionsBuilder optionsBuilderSkill = new DbContextOptionsBuilder(contextOptions);
            var dboption = optionsBuilderSkill.UseInMemoryDatabase().Options as DbContextOptions<DatingContext>;
            _dateContext = new DatingContext(dboption);

            DbContextOptions<UserContext> contextOptionsUser = new DbContextOptions<UserContext>();
            DbContextOptionsBuilder optionsBuilderUser = new DbContextOptionsBuilder(contextOptionsUser);
            var userdboption = optionsBuilderUser.UseInMemoryDatabase().Options as DbContextOptions<UserContext>;
            _userContext = new UserContext(userdboption);

            //Skill Connection
            _dateConnection = new DateConnection(_dateContext);

            //User Connnection;
            _userConnection = new UserConnection(_userContext);

        }

        public DatingContext GetDateContext()
        {
            return _dateConnection.GetDatingContext;
        }

        public UserContext GetUserContext()
        {
            return _userConnection.GetUserContext;
        }
    }
}
