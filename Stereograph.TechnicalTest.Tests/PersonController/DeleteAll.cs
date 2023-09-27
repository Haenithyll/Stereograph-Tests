using Microsoft.AspNetCore.Mvc;
using Moq;
using Stereograph.TechnicalTest.Api.Utils;
using Xunit;

namespace Stereograph.TechnicalTest.Tests.PersonController;

public class DeleteAll
{
    [Fact]
    public void OkResult()
    {
        var mockRepository = new Mock<IPeopleRepository>();
        var controller = new Api.Controllers.PersonController(mockRepository.Object);

        var result = controller.DeleteAllPeople();

        Assert.IsType<OkObjectResult>(result);
    }
}