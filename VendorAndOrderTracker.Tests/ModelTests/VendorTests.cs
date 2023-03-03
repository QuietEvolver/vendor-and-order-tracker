using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorAndOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorAndOrderTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  { 
    // running Tests, increases _instances which increased ID's which is a moving target; We fix by disposing of all Vendors between tests with a teardown method similar to the one we implemented in our Triangle: 

    public void Dispose()   // && define this ClearAll() method: in Models
    {
      Vendor.ClearAll();
    }
    
    // confirm our constructor can successfully create Vendor objects
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("Test Vendor");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());    
    }
    // test that a Vendor can successfully retrieve its name
    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Vendor";
      Vendor newVendor = new Vendor(name);

      //Act
      string result = newVendor.Name;
      
      //Assert
      Assert.AreEqual(name, result);    
    }

    // test that we can retrieve Vendor IDs
    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      //Arrange
      string name = "Test Vendor";
      Vendor newVendor = new Vendor(name);

      //Act
      int result = newVendor.Id;
      
      //Assert
      Assert.AreEqual(1, result);    
    }

    // retrieve all Vendor objects to display in app:
    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
    //Arrange
      string name01 = "3 Challah Breads";
      string name02 = "4 Cakes";
    Vendor newVendor1 = new Vendor(name01);
    Vendor newVendor2 = new Vendor(name02);
    List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

    //Act
    List<Vendor> result = Vendor.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
    }

    // Find() method to locate and display specific Vendor objects.
    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      //Arrange
      string name01 = "3 Challah Breads";
      string name02 = "4 Cakes";
      Vendor newVendor1 = new Vendor(name01);
      Vendor newVendor2 = new Vendor(name02);

      //Act
      Vendor result = Vendor.Find(2);

      //Assert
      Assert.AreEqual(newVendor2, result);
    }

    //make sure we can add an Order object into the Orders property of a Vendor object.
    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      //Arrange
      string description = "12 Croissants";
      Order newOrder = new Order(description);
      List<Order> newList = new List<Order> { newOrder };
      string name = "3 Challah Breads";
      Vendor newVendor = new Vendor (name);
      newVendor.AddOrder(newOrder); 
      //Act
      List<Order> result = newVendor.Orders;
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}