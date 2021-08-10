using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Webapi.Models;
using Products.Infrastructure.Model;
using Products.Infrastructure.Repository.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Product.Webapi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ProductOutput>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListProduct()
        {
            var list = await productRepository.GetListProduct();

            if (list is null)
            {
                return NotFound("Lista de produto não encontrado.");
            }

            return Ok(list);
        }

        [HttpGet]
        [Route("id")]
        [ProducesResponseType(typeof(ProductOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById([Required][FromQuery] int id)
        {
            var product = await productRepository.GetProductById(id);

            if(product is null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertProduct([Required][FromBody] ProductInput productInput)
        {
            var result = await productRepository.InsertProduct(mapper.Map<ProductObject>(productInput));

            if(result != 1)
            {
                return BadRequest("Erro ao inserir produto.");
            }

            return Ok("Produto inserido com sucesso.");
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductInput productInput)
        {
            var result = await productRepository.UpdateProduct(mapper.Map<ProductObject>(productInput));

            if (result != 1)
            {
                return BadRequest("Erro ao atualizar produto.");
            }

            return Ok("Produto atualizado com sucesso");
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ProductOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct([Required][FromQuery] int id)
        {
            var result = await productRepository.DeleteProductById(id);

            if (result != 1)
            {
                return BadRequest("Erro ao excluir produto.");
            }

            return Ok("Produto excluido com sucesso.");
        }
    }
}
