﻿namespace API.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
