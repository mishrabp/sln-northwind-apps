using Xunit;
using FakeItEasy;
using corenorthwindapi.Services;
using corenorthwindapi.Controllers;

namespace core.northwind.api.unittest
{
    public class CustomersControllerTest
    {
        [Fact]
        public void Get_Test()
        {
            //Arrange
            var customerRep = A.Fake<ICustomersService>();
            var controller = new CustomersController(customerRep);

            //Act


            //Assert

        }
    }
}