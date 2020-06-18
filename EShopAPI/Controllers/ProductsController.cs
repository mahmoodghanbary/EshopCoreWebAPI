using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShopAPI.Models;
using EShopAPI.Contracts;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {

            return _productRepository.GetAll().Result;

        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.ID)
            {
                return BadRequest();
            }
            await _productRepository.Update(product);

            return NoContent();
        }
        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productRepository.Add(product);

            return CreatedAtAction("GetProduct", new { id = product.ID }, product);
        }
        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.Remove(product.Result);

            return Ok(product);
        }
        private async Task<bool> ProductExists(int id)
        {
             await _productRepository.FirstOrDefault(i => i.ID == id);
            return true;
        }
    }
}