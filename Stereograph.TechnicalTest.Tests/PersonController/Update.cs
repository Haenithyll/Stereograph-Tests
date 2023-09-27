using Microsoft.AspNetCore.Mvc;
using Moq;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Utils;
using Stereograph.TechnicalTest.Api.Models;
using Xunit;

namespace Stereograph.TechnicalTest.Tests.PersonController;

public class Update
{
    private readonly EPerson _johnDoe = new()
    {
        Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@test.com", Address = "1 test address",
        City = "X city"
    };
    
    private readonly MPerson _johnDoeInfo = new()
    {
        FirstName = "John", LastName = "Doe", Email = "johndoe@test.com", Address = "1 test address",
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

        var result = controller.UpdatePerson(1, _johnDoeInfo);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void NotFoundResult()
    {
        var mockRepository = new Mock<IPeopleRepository>();
        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.UpdatePerson(1, _johnDoeInfo);

        Assert.IsType<NotFoundObjectResult>(result);
    }
}