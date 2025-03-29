// Customer.cs
using System;

public class Customer
{
    // Private member variables
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getter for name
    public string GetName()
    {
        return _name;
    }

    // Getter for address
    public Address GetAddress()
    {
        return _address;
    }

    // Method to determine if the customer lives in the USA
    public bool IsInUSA()
    {
        // Call the address method to determine if it's in the USA
        return _address.IsInUSA();
    }
}