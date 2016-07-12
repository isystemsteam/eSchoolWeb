using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSchool.WebApi.Controllers;

namespace HSchool.WebApi.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void CreateTest()
        {
            AccountController controller = new AccountController();
            controller.Register("pariventhan");
        }
    }
}
