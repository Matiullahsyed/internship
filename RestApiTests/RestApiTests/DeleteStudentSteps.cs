using NUnit.Framework;
using RestApiTests.DTO;
using RestApiTests.Helper;
using RestSharp;
using System;
using TechTalk.SpecFlow;
namespace RestApiTests
{
    [Binding]
    public class DeleteStudentSteps
    {
        private int _id;
        private IRestResponse _restResponse;
        [Given(@"the Id of Student to deleted")]
        public void GivenTheIdOfStudentToDeleted()
        {
            _id = 2;
            var Request = new HttpRequestWrapper()
                     .SetMethod(Method.DELETE)
                     .SetResourse("/api/Student/?id=" + _id);
                     _restResponse = new RestResponse();
                     _restResponse = Request.Execute();
        }
        [When(@"the Student of that Id get and Request to Delete record Made")]
        public void WhenTheStudentOfThatIdGetAndRequestToDeleteRecordMade()
        { 
            if(_restResponse.Content == "Student has been Deleted") { 
            Assert.AreEqual("\"Student has been Deleted\"", _restResponse.Content);
            }
            else if(_restResponse.Content == "Already Deleted")
            {
                Assert.AreEqual("\"Already Deleted\"", _restResponse.Content);
            }
        }
        [Then(@"the return will be delete true")]
        public void ThenTheReturnWillBeDeleteTrue()
        {
            Console.WriteLine("Ahhhhaaa");
        }
    }
}
