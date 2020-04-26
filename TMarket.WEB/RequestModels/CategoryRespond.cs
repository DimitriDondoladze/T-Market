using System.ComponentModel.DataAnnotations;

namespace TMarket.WEB.RequestModels
{
    public class CategoryRespond
    {
        public int Id { get; set; }

        [Display(Name = "სახელ")]
        public string Name { get; set; }
    }
}
