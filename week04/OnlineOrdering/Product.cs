// Product.cs
using System;

public class Product
{
    // Private member variables
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    // Constructor
    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    // Method to calculate the total cost for this product
    public decimal GetTotalPrice()
    {
        return _price * _quantity;
    }
}