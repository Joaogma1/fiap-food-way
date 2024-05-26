using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Foodway.Domain.Requests.Product
{
    public class UpdateProductRequest : CreateProductRequest
    {
        [JsonIgnore]
        public Guid? Id { get; set; }
    }
}
