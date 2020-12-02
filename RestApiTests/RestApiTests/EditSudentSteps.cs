using NUnit.Framework;
using RestApiTests.DTO;
using RestApiTests.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestApiTests
{
    [Binding]
    public class EditSudentSteps
    {
        StudentPostDto student = new StudentPostDto();
        private IRestResponse _restResponse;
        [Given(@"the user Enter Edit Student of Id")]
        public void GivenTheUserEnterEditStudentOfId()
        {
            student.Id = 10;
            student.Name = "EditiedRecord";
            student.Email = "Editedtest@gmail.com";
            student.Contact = 788888909;
            student.Password = "seeding";
            student.ConfirmPassword = "seeding";
            int[] CoursesList = { 1, 2, 3 };
            student.CoursesList = new List<int>(CoursesList);
        }
        [When(@"the Request to Edit record Made")]
        public void WhenTheRequestToEditRecordMade()
        {
            var Request = new HttpRequestWrapper()
                      .SetMethod(Method.PUT)
                      .SetResourse("/api/Student")
                      .AddJsonContent(student);
            _restResponse = new RestResponse();
            _restResponse = Request.Execute();
        }
        [Then(@"the return will be true")]
        public void ThenTheReturnWillBeTrue()
        {
            Assert.AreEqual("\"Student has been updateds\"", _restResponse.Content);
        }
    }
}
