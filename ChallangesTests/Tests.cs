using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
namespace ChallangesTests;

[TestClass]
public class TestValidation
{
    [DataTestMethod]
    [DataRow("60in")]
    [DataRow("190cm")]
    public void TestHeightCheckValid(string height)
    {
        // Act and Assert Section
        Assert.AreEqual(true,Validation.HeightCheck(height));
    }
    
    [DataTestMethod]
    [DataRow("190in")]
    [DataRow("190")]
    public void TestHeightCheckInvalid(string height)
    {
        // Act and Assert Section
        Assert.AreEqual(false,Validation.HeightCheck(height));
    }
    
    [DataTestMethod]
    [DataRow("#123abz")]
    [DataRow("123abz")]
    public void TestHairColourCheckInvalid(string hairColour)
    {
        // Act and Assert Section
        Assert.AreEqual(false,Validation.HairColorCheck(hairColour));
    }
    
    [DataTestMethod]
    [DataRow("#123abc")]
    [DataRow("#def972")]
    public void TestHairColourCheckValid(string hairColour)
    {
        // Act and Assert Section
        Assert.AreEqual(true,Validation.HairColorCheck(hairColour));
    }
    
    [DataTestMethod]
    [DataRow("000000001")]
    [DataRow("002300561")]
    public void TestPassportValid(string passport)
    {
        // Act and Assert Section
        Assert.AreEqual(true,Validation.PassportCheck(passport));
    }
    
    [DataTestMethod]
    [DataRow("0123456789")]
    [DataRow("0023Z0561")]
    public void TestPassportInValid(string passport)
    {
        // Act and Assert Section
        Assert.AreEqual(false,Validation.PassportCheck(passport));
    }
    
    [DataTestMethod]
    [DataRow("1999",1920,2002)]
    [DataRow("1920",1920,2002)]
    [DataRow("2002",1920,2002)]
    public void TestYearValid(string year, int lower, int upper)
    {
        // Act and Assert Section
        Assert.AreEqual(true,Validation.YearCheck(year,lower,upper));
    }
    
    [DataTestMethod]
    [DataRow("1919",1920,2002)]
    [DataRow("2003",1920,2002)]
    [DataRow("1540",1920,2002)]
    public void TestYearInValid(string year, int lower, int upper)
    {
        // Act and Assert Section
        Assert.AreEqual(false,Validation.YearCheck(year,lower,upper));
    }

    [DataTestMethod]
    [DataRow("amb")]
    [DataRow("blu")]
    [DataRow("brn")]
    [DataRow("gry")]
    [DataRow("grn")]
    [DataRow("hzl")]
    [DataRow("oth")]
    public void TestYearValid(string eyeColour)
    {
        // Act and Assert Section
        Assert.AreEqual(true,Validation.EyeColorCheck(eyeColour));
    }
    [DataTestMethod]
    [DataRow("kgb")]
    [DataRow("pzp")]

    public void TestYearInValid(string eyeColour)
    {
        // Act and Assert Section
        Assert.AreEqual(false,Validation.EyeColorCheck(eyeColour));
    }
}