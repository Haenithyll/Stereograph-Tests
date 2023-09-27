using Microsoft.AspNetCore.Mvc;
using Moq;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Utils;
using Xunit;

namespace Stereograph.TechnicalTest.Tests.PersonController;

public class Delete
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

        var result = controller.DeletePerson(1);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void NotFoundResult()
    {
        var mockRepository = new Mock<IPeopleRepository>();
        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.DeletePerson(1);

        Assert.IsType<NotFoundObjectResult>(result);
    }
}