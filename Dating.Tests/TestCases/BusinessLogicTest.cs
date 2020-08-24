
using Dating.BusinessLayer.Interface;
using Dating.BusinessLayer.Service;
using Dating.BusinessLayer.Service.Repository;
using Dating.Entities;
using Dating.Tests.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dating.Tests.TestCases
{
    [Collection("parallel")]
    public  class BusinessLogicTest
    {
        // private reference declaration

        readonly IConfigurationRoot config;
        static FileUtility fileUtility;
        private readonly InMemoryDBUtility _InMemoryDB;
        private readonly DateDetails _date;
        readonly User _user;
        readonly Profile _profile;
        private  IUserService _userService;
        private  IDateService _dateService;
        String testResult;

        private IUserRepository _userRepository;
        private IDateRepository _dateRepository;
        

        public BusinessLogicTest()
        {
            _InMemoryDB = new InMemoryDBUtility();

            _profile = new Profile
            {
                FirstName = "aniha",
                LastName = "patil",
                AlternateEmail = "aniha@gmail.com",
                MobileNumber = 2565987456,
                Occupation = "Student",
                Gender = "Female"
            };

            _user = new User
            {               
                UserName = "Dnyati",
                Password = "Dube",
                Email = "dnyati@gmail.com",
                MobileNumber = 9685744263,
             };
            _userRepository = new UserRepository(_InMemoryDB.GetUserContext());
            _userService = new UserService(_userRepository);

            _dateRepository = new DateRepository(_InMemoryDB.GetDateContext());
            _dateService = new DateService(_dateRepository);
           
        }
        static BusinessLogicTest()
        {
            fileUtility = new FileUtility
            {
                FilePath = "../../../../output_business_revised.txt"
            };
            fileUtility.CreateTextFile();
        }

       
        /// <summary>
        /// Test methods for User Service
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestFor_ListOfMembers()
        {
            try
            {
                var result = await _userService.CreateNewUser(_user);
                if (result == "New User Registered")
                {
                    testResult = "TestFor_ListOfMembers=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                }
                else
                {
                    Assert.Equal("New User Registered", result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_ListOfMembers=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task TestFor_VerifyUser()
        {
            try
            {
                _user.UserName = "Preeti";
                _user.Password = "preeti";
                _user.Email = "preeti@gmail.com";
                 var result1 = await _userService.CreateNewUser(_user);
                 var result = await _userService.VerifyUser(_user.UserName,_user.Password);
                if (result.UserName == _user.UserName && result.Password == _user.Password)
                {
                    testResult = "TestFor_VerifyUser=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.Equal(_user, result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_VerifyUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task TestFor_AddProfile()
        {
            try
            {
               var result = await _userService.AddProfile(_profile);
                if (result !=null)
                {
                    testResult = "TestFor_AddProfile=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                                
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_AddProfile=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
               
            }
        }

        //Test Methods for User Service

        [Fact]
        public async Task TestFor_CreateNewUser()
        {
            try
            {
              var result = await _userService.CreateNewUser(_user);
                if(result == "New User Registered")
                {
                    testResult = "TestFor_CreateNewUser=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                 
                }
                else
                {
                    Assert.Equal("New User Registered", result);
                }
            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "TestFor_CreateNewUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }
    
    }
}
