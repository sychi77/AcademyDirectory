using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Academy.Services;
using Academy.Models.Domain;
using System.Collections.Generic;

namespace Academy.Tests
{
    [TestClass]
    public class StudentsServicesTests
    {
        [TestMethod]
        public void StudentsServices_SelectAll_Test()
        {
            StudentsService svc = new StudentsService();
            List<Students> model = svc.SelectAll();
            Assert.IsNotNull(model);
        }
    }
}
