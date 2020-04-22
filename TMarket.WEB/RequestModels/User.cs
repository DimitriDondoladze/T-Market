using System.ComponentModel;

namespace TMarket.WEB.RequestModels
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("სახელ")]
        public string Name { get; set; }

        [DisplayName("გვარ")]
        public string Lastname { get; set; }
    }
}
