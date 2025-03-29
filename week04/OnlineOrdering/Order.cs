// Order.cs
using System;
using System.Collections.Generic;

public class Order
{
    // Private member variables
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate the total price of the order
    public decimal CalculateTotalPrice()
    {
        // Calculate the sum of all product prices
        decimal productTotal = 0;
        foreach (Product product in _products)
        {
            productTotal += product.GetTotalPrice();
        }

        // Add shipping cost based on customer location
        decimal shippingCost = CalculateShippingCost();

        return productTotal + shippingCost;
    }

    // Method to calculate shipping cost
    private decimal CalculateShippingCost()
    {
        // $5 for USA, $35 for international
        return _customer.IsInUSA() ? 5 : 35;
    }

    // Method to generate a packing label
    public string GetPackingLabel()
    {
        string packingLabel = "PACKING LABEL\n";
        packingLabel += "-------------\n";

        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return packingLabel;
    }

    // Method to generate a shipping label
    public string GetShippingLabel()
    {
        string shippingLabel = "SHIPPING LABEL\n";
        shippingLabel += "--------------\n";
        shippingLabel += $"Customer: {_customer.GetName()}\n";
        shippingLabel += $"Address:\n{_customer.GetAddress().GetFullAddress()}\n";

        return shippingLabel;
    }
}