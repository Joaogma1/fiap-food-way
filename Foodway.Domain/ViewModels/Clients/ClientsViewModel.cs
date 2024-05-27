using Foodway.Domain.Entities;
using Foodway.Domain.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Domain.ViewModels.Clients
{
    public class ClientsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
