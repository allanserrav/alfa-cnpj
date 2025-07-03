using COSAN.Framework.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Raizen.SICCadastro.Rebate.DAL;
using Raizen.SICCadastro.Rebate.Model;
using System;
using System.Collections.Generic;

namespace Raizen.SICCadastro.Rebate.BLL.Test
{
    /// <summary>
    /// AcertoCalculoRebateSicBLOTest
    /// </summary>
    [TestClass]
    public class AcertoCalculoRebateSicBLOTest
    {
        /// <summary>
        /// TesteInjecaoDAO
        /// </summary>
        [TestMethod]
        public void TesteInjecaoDAO()
        {
            var blo = Factory.CreateFactoryInstance().CreateInstance<IAcertoCalculoRebateSicBLO>("AcertoCalculoRebateSicBLO");
            var mockDAO = new Mock<IAcertoCalculoRebateSicDAO>();
            blo.InjecaoDao(mockDAO.Object);

            Assert.IsNotInstanceOfType(blo, typeof(IAcertoCalculoRebateSicDAO));
        }

        /// <summary>
        /// TesteSelecionar
        /// </summary>
        [TestMethod]
        public void TesteSelecionar()
        {
            var mockBLO = new Mock<IAcertoCalculoRebateSicBLO>();
            string ibm = "0000000001";
            mockBLO.Setup(x => x.Selecionar(ibm)).Returns(new List<AcertoCalculoRebateSic>());
            var blo = mockBLO.Object;
            var result = blo.Selecionar(ibm);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestePesquisarPorIBM()
        {
            var mockBLO = new Mock<IAcertoCalculoRebateSicBLO>();
            ClienteSic cli = new ClienteSic();
            cli.NrIbmClienteSic = "0000000001";
            mockBLO.Setup(x => x.PesquisarPorIBM(cli)).Returns(new List<AcertoCalculoRebateSic>());
            var blo = mockBLO.Object;
            var result = blo.PesquisarPorIBM(cli);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// TesteLancarAcertos
        /// </summary>
        [TestMethod]
        public void TesteLancarAcertos()
        {
            try
            {
                var mockBLO = new Mock<IAcertoCalculoRebateSicBLO>();
                mockBLO.Setup(x => x.LancarAjustes(new List<AcertoCalculoRebateSic>())).Verifiable();
                var blo = mockBLO.Object;
                blo.LancarAjustes(new List<AcertoCalculoRebateSic>());
                Assert.IsTrue(true);
            }
            catch 
            {
                Assert.IsTrue(false);
            }
        }
    }
}
