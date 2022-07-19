using APINasa.Controllers;
using APINasa.DataAccess;
using APINasa.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
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

            List<Meteorito> meteoros = new List<Meteorito>();
            for (int i = 0; i < 3; i++)
            {
                Meteorito meteorito = new Meteorito()
                {
                    _nombre = "algo",
                    _diametro = 1.2F,
                    _fecha="0120329239",
                    _planeta="Earth",
                    _velocidad="23423"
                };
                meteoros.Add(meteorito);
            }

            var customer=Task.FromResult(meteoros);
            var result = _apimock.Setup(x => x.Obtenertop3(3)).Returns(customer);

            var ok = _apimock.Object.Obtenertop3(3);


            Assert.Equal(result.ToString(), ok.ToString());
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
