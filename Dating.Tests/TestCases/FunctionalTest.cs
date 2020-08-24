using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Dating.Tests.Utility;
using Dating.BusinessLayer.Interface;
using Dating.BusinessLayer.Service.Repository;
using Dating.Web.Controllers;
using Dating.BusinessLayer.Service;
using Dating.Entities;

namespace Dating.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public  class FunctionalTest
    {
        // private references declaration
        static FileUtility fileUtility;
        private readonly InMemoryDBUtility _InMemoryDB;
        
        private IUserService _userService;
   
        private IUserRepository _userRepository;
        private readonly UserController _userController;
        private User _user;
        private Profile _profile;
        private string testResult;

        public FunctionalTest()
        {
            _InMemoryDB = new InMemoryDBUtility();
            _userRepository = new UserRepository(_InMemoryDB.GetUserContext());
            _userService = new UserService(_userRepository);

            
            _userController = new UserController(_userService);
           _user = new User
            {
               UserName = "xyz",
               Password= "xyz",
               Email = "xyz@gmail.com",
               MobileNumber =9876543423
                
            };
            _profile = new Profile
            {
                FirstName = "aniha",
                LastName = "patil",
                AlternateEmail = "aniha@gmail.com",
                MobileNumber = 2565987456,
                Occupation = "Student",
                Gender = "Female"
            };
        }
        static FunctionalTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_revised.txt";
            fileUtility.CreateTextFile();
        }

        //Test methods for User Controller
        [Fact]
        public async Task TestFor_CreateNewUser()
        {
            try
            {


                var result =await  _userController.CreateNewUser(_user);
                            
                if (result != null)
                {
                    testResult = "TestFor_CreateNewUser=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.NotNull( result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
                testResult = "TestFor_CreateNewUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task TestFor_VerifyUser()
        {
            try
            {
                
                var rslt = await _userService.CreateNewUser(_user);
                var result =await _userController.Login(_user.UserName,_user.Password);
                
                if (result != null)
                {
                    testResult = "TestFor_VerifyUser=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
                testResult = "TestFor_VerifyUser=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        [Fact]
        public async Task TestFor_ListOfMembers()
        {
            try
            {

                var rslt = await _userService.CreateNewUser(_user);
                var result = await _userController.AllMembers();
                if (result != null)
                {
                    testResult = "TestFor_ListOfMembers=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
                testResult = "TestFor_ListOfMembers=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }

        //Test Methods for User Controller

        [Fact]
        public async Task TestFor_AddProfile()
        {
            try
            {
               
                var result =await _userController.AddProfile(_profile);
                if (result != null)
                {
                    testResult = "TestFor_AddProfile=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    
                }
                else
                {
                    Assert.NotNull(result);
                }
            }
            catch (Exception Functional)
            {
                var error = Functional;
                testResult = "TestFor_AddProfile=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                
            }
        }
     }
}
