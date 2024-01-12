using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechExam3.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechExam3.Model;

namespace TechExam3.Validator.Tests
{
    [TestClass()]
    public class EmployeeValidatorTests
    {
        [TestMethod()]
        public void ValidateRequestTest_EmployeeNameShouldNotBeNullOrEmpty()
        {
            var addEmployeeRequest = new AddEmployeeRequest
            {
                Name = string.Empty,
                Address = "123 A St",
                Email = "test@mail.com",
                PhoneNumber = "88123456",
                Position = "test position"

            };
            EmployeeValidator validator = new EmployeeValidator();
            var response = validator.ValidateRequest(addEmployeeRequest);

            Assert.IsTrue(response.HasError);
            Assert.AreEqual("Name can't be null or empty!", response.ErrorMessage);
        }
        [TestMethod()]
        public void ValidateRequestTest_EmployeeNameMustNotContainSpecialCharacters()
        {
            var addEmployeeRequest = new AddEmployeeRequest
            {
                Name = "test name !@",
                Address = "123 A St",
                Email = "test@mail.com",
                PhoneNumber = "88123456",
                Position = "test position"

            };
            EmployeeValidator validator = new EmployeeValidator();
            var response = validator.ValidateRequest(addEmployeeRequest);

            Assert.IsTrue(response.HasError);
            Assert.AreEqual("Name contains invalid inputs.", response.ErrorMessage);
        }

        [TestMethod()]
        public void ValidateRequestTest_EmployeeNameMustNotBeMoreThan100Characters()
        {
            var addEmployeeRequest = new AddEmployeeRequest
            {
                Name = "This Name Contains One Hundred Characters This Name Contains One Hundred Characters This Name Contains One Hundred Characters This Name Contains One Hundred Characters",
                Address = "123 A St",
                Email = "test@mail.com",
                PhoneNumber = "88123456",
                Position = "test position"

            };
            EmployeeValidator validator = new EmployeeValidator();
            var response = validator.ValidateRequest(addEmployeeRequest);

            Assert.IsTrue(response.HasError);
            Assert.AreEqual("Name length must be less than 100.", response.ErrorMessage);
        }
    }
}