﻿using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture(Category = "Unit")]

    public class CustomerControllerTests
    {


        [Test]
        [TestCase(0, typeof(NotFound))]
        [TestCase(1, typeof(Ok))]
        [Category("Unit")]
        public void GetCustomer_WhenCalled_ReturnActionResult(int id, Type type)
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(id);

            Assert.That(result, Is.InstanceOf(type));
        }

    }
}
