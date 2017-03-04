using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutilsFormels;


namespace OutilsFormelTest
{
    [TestClass]
    public class LoginPageTest
    {
        [TestMethod]
        public void ValiderFunction_login_jrambo_mdp_guerre()
        {
            User user = new User(0, "", "", "", "Guerre37", "jrambo");
            LoginPage loginPage = new LoginPage();
            bool result = loginPage.ValiderFunction(ref user);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValiderFunction_login_guerre_mdp_jrambo()
        {
            User user = new User(0, "", "", "", "jrambo", "guerre");
            LoginPage loginPage = new LoginPage();
            bool result = loginPage.ValiderFunction(ref user);
            Assert.AreEqual(false, result);
        }
    }
}
