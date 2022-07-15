using APINasa.Controllers;
using APINasa.DataAccess;
using APINasa.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace APINasa.Test
{
    public class UnitTest1
    {
        private readonly ModelController _model;
        private readonly Mock<API> _apimock= new Mock<API>();
        public UnitTest1()
        {
            _model = new ModelController(_apimock.Object);
        }
        
        [Fact]
        public async Task Casovalido()
        {

            int dia = 4;
            var customer=(OkObjectResult)await _model.GetTop3(dia);
            var ok=(OkObjectResult)await _model.GetTop3(dia);


            Assert.Equal(customer.ToString(), ok.ToString());
        }
        [Fact]
        public async Task Casonovalidofueraderango()
        {
           
            var customer = (BadRequestResult)await _model.GetTop3(8);
            var bad = (BadRequestResult)await _model.GetTop3(8);

            Assert.Equal(customer.ToString(), bad.ToString());
        }
        [Fact]
        public async Task Casovalidonodevuldeninguno()
        {
            int dia = 1;
            var customer = (OkObjectResult)await _model.GetTop3(dia);
            var ok = (OkObjectResult)await _model.GetTop3(dia);


            Assert.Equal(customer.ToString(), ok.ToString());
        }
    }
}
