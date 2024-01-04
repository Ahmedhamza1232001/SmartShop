﻿using SmartShop;
using SmartShop.Enums;
using SmartShop.Models;

namespace test_api;

public abstract class Product : BaseEntity
{
    public required string Name { get; set; }
    public float Rate { get; set; }
    public bool InStock { get; set; }
    public int Quantity { get; set; }
    public int SubCategoryId { get; set; }
    public required SubCategory SubCategory { get; set; }
    public int BrandId { get; set; }
    public required Brand Brand { get; set; }
    public Color Color { get; set; }
}