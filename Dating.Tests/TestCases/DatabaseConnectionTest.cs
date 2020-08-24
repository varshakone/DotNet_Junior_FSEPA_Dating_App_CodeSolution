
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Dating.Tests.Utility;
using Dating.DataLayer;

namespace Dating.Tests.TestCases
{
 public class DatabaseConnectionTest
    {
        // private references
        static FileUtility fileUtility;
        private DatingContext _dateContext;
        private UserContext _userContext;
        private IUserConnection _userConnection;
        private IDateConnection _dateConnection;
        static DatabaseConnectionTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_database_revised.txt";
            fileUtility.CreateTextFile();
        }
        public DatabaseConnectionTest()
        {
            DbContextOptions<DatingContext> contextOptions = new DbContextOptions<DatingContext>();
            DbContextOptionsBuilder optionsBuilderSkill = new DbContextOptionsBuilder(contextOptions);
            var dboption = optionsBuilderSkill.UseInMemoryDatabase().Options as DbContextOptions<DatingContext>;
            _dateContext = new DatingContext(dboption);

            DbContextOptions<UserContext> contextOptionsUser = new DbContextOptions<UserContext>();
            DbContextOptionsBuilder optionsBuilderUser = new DbContextOptionsBuilder(contextOptionsUser);
            var userdboption = optionsBuilderUser.UseInMemoryDatabase().Options as DbContextOptions<UserContext>;
            _userContext = new UserContext(userdboption);


            //date Connection
            _dateConnection = new DateConnection(_dateContext);

            //User Connnection;
            _userConnection = new UserConnection(_userContext);
        }
        [Fact]
        public async Task TestFor_InMemoryDBConnection_User()
        {
            try
            {
                var result = _userConnection.GetUserContext;
              
                if(result !=null)
                {
                     string testResult = "TestFor_InMemoryDBConnection_User=" + "True";

                    // Write test case result in text file
                     fileUtility.WriteTestCaseResuItInText(testResult);
                }
                Assert.NotNull(result);
            }
            catch(Exception ex)
            {
                var error = ex;
                string testResult = "TestFor_InMemoryDBConnection_User=" + "False";

                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);
            }
        }

        [Fact]
        public async Task TestFor_InMemoryDBConnection_Dating()
        {
            try
            {
                var result = _dateConnection.GetDatingContext;

                if (result != null)
                {
                    string testResult = "TestFor_InMemoryDBConnection_Dating=" + "True";

                    // Write test case result in text file
                  fileUtility.WriteTestCaseResuItInText(testResult);
                }
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                var error = ex;
                string testResult = "TestFor_InMemoryDBConnection_Dating=" + "False";

                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);
            }
        }
    }
}

