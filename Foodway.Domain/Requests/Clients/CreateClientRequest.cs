using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Foodway.Domain.Requests.Clients
{
    public class CreateClientRequest
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
