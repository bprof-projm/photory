using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryModels
{
    public class TokenViewModel
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

    }
}
