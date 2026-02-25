using Core.Entities;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IGenericRepository<Products> repo) : BaseAPIController
{


    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Products>>> GetProducts([FromQuery] ProductSpecParams specParams)
    {
        var spec = new ProductSpecification(specParams);
        return await CreatePagedResult(repo, spec,
            specParams.PageIndex, specParams.PageSize);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {

        var product = await repo.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(Products product)
    {

        repo.Add(product);

        bool result = await repo.SaveChangesAsync();
        if (!result) return BadRequest("Failed to create product");
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Products updatedProduct)
    {
        if (id != updatedProduct.Id || !ProductExists(id)) { return BadRequest("Product does not exist"); }




        repo.Update(updatedProduct);
        bool result = await repo.SaveChangesAsync();
        if (!result) { return BadRequest("Failed to update product"); }
        return NoContent();
    }
    [HttpGet("types")]
    public async Task<IActionResult> GetTypes()
    {
        var spec = new TypeListSpecification();
        var types = await repo.ListAsync(spec);
        return Ok(types);
    }
    [HttpGet("brands")]
    public async Task<IActionResult> GetBrands()
    {
        var spec = new BrandListSpecification();
        var products = await repo.ListAsync(spec);
        return Ok(products);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var existingProduct = repo.GetByIdAsync(id).Result;
        if (existingProduct == null) { return NotFound(); }
        repo.Delete(existingProduct);
        bool result = repo.SaveChangesAsync().Result;
        if (!result) { return BadRequest("Failed to delete product"); }
        return NoContent();
    }
    private bool ProductExists(int id)
    {
        return repo.Exists(id);
    }

}

