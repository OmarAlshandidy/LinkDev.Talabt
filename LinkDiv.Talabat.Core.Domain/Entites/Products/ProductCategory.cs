using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Core.Domain.Comman;

namespace LinkDev.Talabat.Core.Domain.Entites.Products
{
    public class ProductCategory : BaseEntity<int>
    {
        public required  string Name { get; set; }
    }
}
