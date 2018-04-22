using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resistor_Calculator.Models;

namespace Resistor_Calculator.Tests
{
    [TestClass]
    public class ResistorDataTest
    {
        ResistorData resistorData = new ResistorData();

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void LoadBandDataTest()
        {
            resistorData.LoadData();

            Assert.IsNotNull(resistorData.BandColors);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void LoadMultiplierDataTest()
        {
            resistorData.LoadData();
            Assert.IsNotNull(resistorData.Multipliers);
        }

        [TestMethod]
        public void LoadToleranceDataTest()
        {
            resistorData.LoadData();
            Assert.IsNotNull(resistorData.Tolerances);

        }

        [TestMethod]
        public void CalculateOhmValueTest()
        {
            int val = resistorData.CalculateOhmValue("Yellow", "Violet", "RED @ x100", "GOLD @ 5%");

            Assert.AreEqual(4465, val);
        }

        [TestMethod]
        public void CalculateOhmValueExceptionTest()
        {
            int val = resistorData.CalculateOhmValue("", "", "", "");
            Assert.AreEqual(0, val);
        }

        [TestMethod]
        public void LoadBandDataExceptionTest()
        {
            resistorData.LoadData();
            Assert.AreNotEqual(null, resistorData.BandColors);
        }
    }
}
