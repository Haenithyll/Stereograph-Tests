using Microsoft.AspNetCore.Mvc;
using Moq;
using Stereograph.TechnicalTest.Api.Models;
using Stereograph.TechnicalTest.Api.Utils;
using Xunit;

namespace Stereograph.TechnicalTest.Tests.PersonController;

public class Create
{
    private readonly MPerson _johnDoeInfo = new()
    {
        FirstName = "John", LastName = "Doe", Email = "johndoe@test.com", Address = "1 test address",
        City = "X city"
    };

    [Fact]
    public void OkResult()
    {
        var mockRepository = new Mock<IPeopleRepository>();
        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.CreateNewPerson(_johnDoeInfo);

        Assert.IsType<OkObjectResult>(result);
    }
}