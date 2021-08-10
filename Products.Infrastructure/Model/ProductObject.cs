namespace Products.Infrastructure.Model
{
    /// <summary>
    /// Produto
    /// </summary>
    public class ProductObject
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
