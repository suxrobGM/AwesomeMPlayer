using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            Id = Guid.NewGuid().ToString().Replace("-", "");
        }

        public string Id { get; set; }
    }
}
