using System;
using System.Collections.Generic;
using System.Text;

public class Address
{
    public string unitNumber;
    public string buildingNumber;
    public string street;
    public string city;
    public string country;
    public string postalCode;
    public Address(string buildingNumber, string street, string city, string country, string postalCode, string unitNumber = null)
    {
        this.unitNumber = unitNumber;
        this.buildingNumber = buildingNumber;
        this.street = street;
        this.city = city;
        this.country = country;
        this.postalCode = postalCode;
    }
}
