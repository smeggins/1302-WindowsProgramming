using System;
using System.Collections.Generic;
using System.Text;

public class Home
{
    public decimal squareFootage;
    public int numberOfBedrooms;
    public int numberOfWashrooms;
    public TypeOfHome typeOfHome;
    public decimal price;
    public List<string> imageFiles; 

    public enum TypeOfHome
    {
        Apartment,
        TownHouse,
        Detached,
        Duplex,
        Triplex,
        Mobile
    }
}

public abstract class HomeV2
{
    public Address address;
    public decimal squareFootage;
    public int numberOfBedrooms;
    public int numberOfWashrooms;
    public decimal price;
    public List<string> imageFiles;
    public List<Room> rooms;

    public virtual decimal getLiability()
    {
        return 0;
    }
}

public class Townhouse : HomeV2
{
    public decimal backyardSQFT;
}

public class House : HomeV2
{
    public decimal landSQFT;
}

public class Apartment : HomeV2
{
    public decimal StrataFee;

}