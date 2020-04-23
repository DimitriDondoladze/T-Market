using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TMarket.WEB.RequestModels
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name="სახელ")]
        public string Name { get; set; }

        [Display(Name="გვარ")]
        public string Lastname { get; set; }
    }
}
