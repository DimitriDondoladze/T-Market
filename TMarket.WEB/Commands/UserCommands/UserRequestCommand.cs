using System.ComponentModel.DataAnnotations;
using MediatR;
using TMarket.WEB.RequestModels;

namespace TMarket.WEB.Commands.UserCommands
{
    public class UserRequestCommand : IRequest<UserRespond>
    {
        [Display(Name="სახელ")]
        public string Name { get; set; }

        [Display(Name="გვარ")]
        public string Lastname { get; set; }
    }
}