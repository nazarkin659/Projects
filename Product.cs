using System;
using System.Collections;

public class Product
{
    public Product()
    { }

    public Product()
    {
        Price = -1;
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageURL { get; set; }

    public decimal Price { get; set; }

    public List<string> Features { get; set; }

    public Dictionary<string, string> Details { get; set; }
}
