using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSConvertisseur.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }

        /// <summary>
        /// Test GetDataOnLoadAsyncTest OK
        /// </summary>
        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();

            Thread.Sleep(1000);
            //Act
            convertisseurEuro.GetDataOnLoadAsync();
            //Assert
            Assert.IsNotNull(convertisseurEuro.LesDevises);
        }

/*        [TestMethod()]
        public void GetDataOnLoadAsyncTest_NonOK_WS_NonDemarre()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();

            Thread.Sleep(1000);
            //Act
            convertisseurEuro.GetDataOnLoadAsync();
            //Assert
            Assert.IsNull(convertisseurEuro.LesDevises);
        }*/

        [TestMethod()]
        public void ActionSetConversionTest()
        {
            //Arrange
            //Création d'un objet de type ConvertisseurEuroViewModel
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Property MontantEuro = 100 (par exemple)
            convertisseurEuro.Montant = 100;
            //Création d'un objet Devise, dont Taux=1.07
            Devise ladevise = new Devise(4, "Zouble", 1.07);
            //Property DeviseSelectionnee = objet Devise instancié
            convertisseurEuro.SelectedDevise = ladevise;
            //Act
            //Appel de la méthode ActionSetConversion
            convertisseurEuro.ActionSetConversion();
            //Assert
            //Assertion : MontantDevise est égal à la valeur espérée 107
            Assert.AreEqual(107, convertisseurEuro.ConvertedAmount, "ConvertedAmount doit etre égal à 107");
        }
    }
}