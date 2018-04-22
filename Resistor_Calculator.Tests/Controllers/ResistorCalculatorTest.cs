using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resistor_Calculator.Controllers;
using Resistor_Calculator.Models;

namespace Resistor_Calculator.Tests.Controllers
{
    [TestClass]
    public class ResistorCalculatorTest
    {
        ResistorData resistorData = new ResistorData();
        [TestMethod]
        public void Index()
        {
            ResistorCalculatorController resistorCalculatorController = new ResistorCalculatorController();
            ViewResult viewResult = resistorCalculatorController.Index() as ViewResult;

            Assert.IsNotNull(viewResult);

        }
    }
}
