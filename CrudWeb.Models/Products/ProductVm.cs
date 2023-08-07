﻿namespace CrudWeb.Models.Products;

public class ProductVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool inStock { get; set; }
}