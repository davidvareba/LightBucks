﻿namespace LightBucks.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Descriptions { get; set; }
        public string ImgUrl { get; set; }
        public int CoffeeId { get; set; }
        public int UserId { get; set; }
    }
}
