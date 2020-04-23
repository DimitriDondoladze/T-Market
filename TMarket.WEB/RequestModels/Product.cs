﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TMarket.WEB.RequestModels
{
    public class Product 
    {
        public int Id { get; set; }

        [Display(Name="პროდუქტის სახელ")]
        public string Name { get; set; }

        [Display(Name="პროდუქტის ფას")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        [Display(Name="პროდუქტის ვად")]
        public DateTime UsefulnessTerm { get; set; }

        [Display(Name="ხელმისწავდომი პროდუქტის რაოდენობ")]
        public int AvailableCount { get; set; }
    }
}
