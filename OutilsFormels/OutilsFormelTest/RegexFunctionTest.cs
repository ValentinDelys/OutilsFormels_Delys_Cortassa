using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutilsFormels;

namespace OutilsFormelTest
{
    [TestClass]
    public class RegexFunctionTest
    {
        [TestMethod]
        public void isValidString_cacahuette37_1_20()
        {
          
            bool result = RegexFunction.isValidstring("cacahuette37", 1, 20);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void isValidString_cacahuette37_20_1()
        {
          
            bool result = RegexFunction.isValidstring("cacahuette37", 20, 1);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void isValidString_cacahuette_1_20()
        {
           
            bool result = RegexFunction.isValidstring("c@c@huette", 1, 20);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void isValidEmail_cacahuetteAchocolatcom()
        {
           
            bool result = RegexFunction.isValidEmail("cacahuette@chocolat.com");
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void isValidEmail_cacahuettechocolatcom()
        {
           
            bool result = RegexFunction.isValidEmail("cacahuettechocolat.com");
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void isValidEmail_cacahuettechocolat()
        {
           
            bool result = RegexFunction.isValidEmail("cacahuettechocolat");
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void isValidEmail_cacahuetteAchocolat()
        {
           
            bool result = RegexFunction.isValidEmail("cacahuette@chocolat");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void isValidPassword_CocoLasticot37()
        {        
            bool result = RegexFunction.isValidPassword("CocoLasticot37");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void isValidPassword_cocolasticot37()
        {
          
            bool result = RegexFunction.isValidPassword("cocolasticot37");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void isValidPassword_CocoLasticot()
        {
           
            bool result = RegexFunction.isValidPassword("CocoLasticot");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void isValidPassword_CocoL_asticot37()
        { 
            bool result = RegexFunction.isValidPassword("CocoL'asticot37");
            Assert.AreEqual(false, result);
        }
    }
}
