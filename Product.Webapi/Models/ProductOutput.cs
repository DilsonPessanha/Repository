namespace Product.Webapi.Models
{
    /// <summary>
    /// Produto
    /// </summary>
    public class ProductOutput
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
