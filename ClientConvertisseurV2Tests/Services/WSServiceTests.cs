using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSConvertisseur.Models;
using ClientConvertisseurV2.ViewModels;

namespace ClientConvertisseurV2.Services.Tests
{

    [TestClass()]
    public class WSServiceTests
    {

        [TestMethod()]
        public void WSServiceTest()
        {
            WSService wSService = new WSService("https://localhost:7063/api/");
            Assert.IsNotNull(wSService);
        }

        [TestMethod()]
        public void GetDevisesAsyncTest()
        {
            WSService service = new WSService("https://localhost:7063/api/");

            //Act
            var result = service.GetDevisesAsync("devises").Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.IsInstanceOfType(result, (typeof(List<Devise>)));
        }


    }
}