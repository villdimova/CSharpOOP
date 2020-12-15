using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        public  Item itemOne;
        public  Item itemTwo;
        public  Item itemThree;
        [SetUp]
        public void Setup()
        {
            itemOne = new Item("Iva", "BB50");
            itemTwo= new Item("Maria", "B560");
            itemThree = new Item("Pesho", "7788");
        }

        [Test]
        public void ItemConstructorShouldSetCerrectInfo()
        {
           Item item = new Item("Ivan", "5550");

            Assert.AreEqual("Ivan", item.Owner);
            Assert.AreEqual("5550", item.ItemId);


        }

        [Test]
        public void BankVaultConstructorShouldSetCerrectInfo()
        {
            BankVault bankVault = new BankVault();
            Assert.IsNotNull(bankVault.VaultCells);
            



        }

        [Test]
        public void MethodAddItemShouldThrowArgumentExceptionByAddingNonExistingCell()
        {

            BankVault bankVault = new BankVault();
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("Ivan", itemTwo));



        }

        [Test]
        public void MethodAddItemShouldThrowArgumentExceptionByAddingInNotNullCell()
        {

            BankVault bankVault = new BankVault();
            bankVault.AddItem("A1", itemTwo);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", itemOne));



        }

        [Test]
        public void MethodAddItemShouldThrowArgumentExceptionByAddingAlreadyAddedCell()
        {

            BankVault bankVault = new BankVault();
            bankVault.AddItem("A1", itemTwo);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", itemTwo));


        }

        [Test]
        public void MethodAddItemShouldReturnCorrectString()
        {

            BankVault bankVault = new BankVault();
            

            string result = $"Item:{itemTwo.ItemId} saved successfully!";
            Assert.AreEqual(result, bankVault.AddItem("A1", itemTwo));

        }
        [Test]
        public void MethodRemoveItemShouldReturnCorrectString()
        {

            BankVault bankVault = new BankVault();
            bankVault.AddItem("A1", itemTwo);
           

            string result = $"Remove item:{itemTwo.ItemId} successfully!";
            Assert.AreEqual(result, bankVault.RemoveItem("A1", itemTwo));

        }

        [Test]
        public void MethodRemoveShouldThrowExceptionIfCellDoesntExist()
        {

            BankVault bankVault = new BankVault();
            bankVault.AddItem("A1", itemTwo);


            
            Assert.Throws<ArgumentException>(()=> bankVault.RemoveItem("Y2", itemOne));
            Assert.Throws<ArgumentException>(()=> bankVault.RemoveItem("Y2", itemTwo));

        }

        [Test]
        public void MethodRemoveShouldThrowExceptionIfItemDoesntExist()
        {

            BankVault bankVault = new BankVault();
            bankVault.AddItem("A1", itemTwo);



            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", itemOne));
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A2", itemThree));

        }
    }
}