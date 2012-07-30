using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NUnit;
using NUnit.Framework;
using Moq;
using MvcTestingSamples.Repositories;
using MvcTestingSamples.Models;
using MvcTestingSamples.Controllers;

namespace MvcTestingSamples.Tests
{
    [TestFixture]
    public class SampleControllerUnitTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        public TestContext TestContext { get; set; }

        [Test]
        public void IndexActionReturnsListOfSomethings()
        {
            var mock = new Mock<ISampleRepository>();
            var list = new List<Something> { new Something { ID = 1 }, new Something { ID = 2 } };
            mock.Setup<IEnumerable<Something>>(r => r.GetSomethings()).Returns(list);

            var controller = new SampleController(mock.Object);
            var result = (ViewResult)controller.Index();

            Assert.IsNotAssignableFrom<IEnumerable<Something>>(result.ViewData.Model);
            var viewList = result.ViewData.Model as IEnumerable<Something>;
            Assert.AreEqual(2, viewList.Count());
        }
    }
}
