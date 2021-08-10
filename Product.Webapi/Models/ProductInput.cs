using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Webapi.Models
{
    /// <summary>
    /// Produto
    /// </summary>
    public class ProductInput
    {
        /// <summary>
        /// Codigo do produto
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Preço do produto
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Name { get; set; }

    }
}
