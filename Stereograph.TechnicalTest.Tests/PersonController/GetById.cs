using Microsoft.AspNetCore.Mvc;
using Moq;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Utils;
using Xunit;

namespace Stereograph.TechnicalTest.Tests.PersonController;

public class GetById
{
    private readonly EPerson _johnDoe = new()
    {
        Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@test.com", Address = "1 test address",
        City = "X city"
    };
    
    [Fact]
    public void OkResult()
    {
        var mockRepository = new Mock<IPeopleRepository>();
        mockRepository
            .Setup(repo => repo.GetById(1))
            .Returns(_johnDoe);

        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.GetPersonById(1);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var person = Assert.IsAssignableFrom<EPerson>(okResult.Value);

        Assert.Equal(_johnDoe, person);
    }

    [Fact]
    public void BadRequestResult()
    {
        var mockRepository = new Mock<IPeopleRepository>();
        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.GetPersonById(0);

        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
    
    [Fact]
    public void NotFoundResult()
    {
        var mockRepository = new Mock<IPeopleRepository>();
        mockRepository
            .Setup(repo => repo.GetById(4))
            .Returns((EPerson)null);

        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.GetPersonById(4);

        Assert.IsType<NotFoundObjectResult>(result.Result);
    }
}