using System;
using System.ComponentModel;

namespace TMarket.WEB.RequestModels
{
    public class Product 
    {
        public int Id { get; set; }

        [DisplayName("პროდუქტის სახელ")]
        public string Name { get; set; }

        [DisplayName("პროდუქტის ფას")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        [DisplayName("პროდუქტის ვად")]
        public DateTime UsefulnessTerm { get; set; }

        [DisplayName("ხელმისწავდომი პროდუქტის რაოდენობ")]
        public int AvailableCount { get; set; }
    }
}
