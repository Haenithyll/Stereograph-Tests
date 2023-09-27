using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Stereograph.TechnicalTest.Api.Entities;
using Stereograph.TechnicalTest.Api.Utils;
using Xunit;

namespace Stereograph.TechnicalTest.Tests.PersonController;

public class Get
{
    #region TestPeople

    private readonly EPerson _johnDoe = new()
    {
        Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@test.com", Address = "1 test address",
        City = "X city"
    };

    private readonly EPerson _janeDoe = new()
    {
        Id = 2, FirstName = "Jane", LastName = "Doe", Email = "janedoe@test.com", Address = "7 test address",
        City = "Y city"
    };

    private readonly EPerson _jamesSmith = new()
    {
        Id = 3, FirstName = "James", LastName = "Smith", Email = "jsmith@test.com", Address = "53 test address",
        City = "Z city"
    };

    #endregion
    
    [Fact]
    public void OkResult_ID()
    {
        var mockRepository = new Mock<IPeopleRepository>();
        mockRepository
            .Setup(repo => repo.GetById(1))
            .Returns(_johnDoe);

        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.GetPeople(1, null, null, null, null, null);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var person = Assert.IsAssignableFrom<EPerson>(okResult.Value);

        Assert.Equal(_johnDoe, person);
    }
    
    [Fact]
    public void OkResult_Parameter()
    {
        var testPeople = new List<EPerson>() { _johnDoe, _janeDoe, _jamesSmith };
        
        var mockRepository = new Mock<IPeopleRepository>();
        mockRepository
            .Setup(repo => repo.Get(null, null, null, null, null))
            .Returns(testPeople);

        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.GetPeople(null, null, null, null, null, null);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var people = Assert.IsAssignableFrom<IEnumerable<EPerson>>(okResult.Value).ToList();

        Assert.Equal(testPeople, people);
    }

    [Fact]
    public void NotFoundResult()
    {
        var mockRepository = new Mock<IPeopleRepository>();
        mockRepository
            .Setup(repo => repo.Get("Paul", null, null, null, null))
            .Returns(new List<EPerson>());

        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.GetPeople(null, "Paul", null, null, null, null);

        Assert.IsType<NotFoundObjectResult>(result.Result);
    }
}