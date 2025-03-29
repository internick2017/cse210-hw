// Address.cs
using System;

public class Address
{
    // Private member variables
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;
    private string _postalCode;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country, string postalCode)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
        _postalCode = postalCode;
    }

    // Method to determine if the address is in the USA
    public bool IsInUSA()
    {
        // Case-insensitive check for USA
        return _country.ToUpper() == "USA" || _country.ToUpper() == "UNITED STATES" ||
               _country.ToUpper() == "UNITED STATES OF AMERICA" || _country.ToUpper() == "U.S.A.";
    }

    // Method to get the full address as a formatted string
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince} {_postalCode}\n{_country}";
    }
}