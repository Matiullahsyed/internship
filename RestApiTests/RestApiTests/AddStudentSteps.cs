using NUnit.Framework;
using RestApiTests.DTO;
using RestApiTests.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;
using Ubiety.Dns.Core;

namespace RestApiTests
{
    [Binding]
    public class AddStudentSteps
    {
        private IRestResponse _restResponse;
        private HttpStatusCode _statusCode;
        [Given(@"Add New Student Details Call to Add Student ""(.*)""")]
        public void GivenAddNewStudentDetailsCallToAddStudent(string p0)
        {
            var request = new HttpRequestWrapper();
            _restResponse = new RestResponse();
            _restResponse = request.Execute();
            _statusCode = _restResponse.StatusCode;

            StudentPostDto student = new StudentPostDto();
            student.student = new Student();
            student.student.Name = "test";
            student.student.Email = "test@gmail.com";
            student.student.Contact = 3434344;
            student.student.Password = "dsgfsgg";
            student.student.ConfirmPassword = "dsfsgg";
            List<int> courses = new List<int>();
            courses.Add(1);
            courses.Add(2);
            courses.Add(3);
            student.CoursesList = courses;
            var Request = new HttpRequestWrapper()
                     .SetMethod(Method.POST)
                     .SetResourse("/api/Student")
                     .AddJsonContent(student);
            _restResponse = new RestResponse();
            _restResponse = Request.Execute();
            _statusCode = _restResponse.StatusCode;
        }
        [Then(@"return will be true")]
        public void ThenReturnWillBeTrue()
        {
            Assert.AreEqual("\"Student has been Added\"",_restResponse.Content);
        }
    }
}
