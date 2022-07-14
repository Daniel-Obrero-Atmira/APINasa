using APINasa.Controllers;
using APINasa.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace APINasa.Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Casovalido()
        {
            var model = new API();
            var controller = new ModelController(model);
            var response = (OkObjectResult)await controller.GetTop3(3);

            response.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task Casonovalidofueraderango()
        {
            var model = new API();
            var controller = new ModelController(model);
            var response = (BadRequestResult)await controller.GetTop3(8);

            response.StatusCode.Should().Be(400);
        }
        [Fact]
        public async Task Casovalidonodevuldeninguno()
        {
            var model = new API();
            var controller = new ModelController(model);
            var response = (OkObjectResult)await controller.GetTop3(1);

            response.StatusCode.Should().Be(200);
        }
    }
}
