using CleanApi.Application.Common;
using CleanApi.Application.Products.Commands;
using CleanApi.Application.Products.DTOs;
using CleanApi.Application.Products.Queries;
using CleanApi.API.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ApiResponse<PagedResult<ProductDto>>>> GetProducts(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await _sender.Send(new GetProductsQuery(page, pageSize));
        return Ok(ApiResponse<PagedResult<ProductDto>>.Ok(result));
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<ApiResponse<ProductDto>>> GetProductById(Guid id)
    {
        var result = await _sender.Send(new GetProductByIdQuery(id));
        if (result.IsFailure)
            return NotFound(ApiResponse<ProductDto>.Fail(result.ErrorMessage!));

        return Ok(ApiResponse<ProductDto>.Ok(result.Value!));
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ApiResponse<Guid>>> CreateProduct([FromBody] CreateProductDto dto)
    {
        var result = await _sender.Send(new CreateProductCommand(dto));
        if (result.IsFailure)
            return BadRequest(ApiResponse<Guid>.Fail(result.ErrorMessage!));

        return CreatedAtAction(nameof(GetProductById), new { id = result.Value }, ApiResponse<Guid>.Ok(result.Value));
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<ApiResponse<object>>> UpdateProduct(Guid id, [FromBody] UpdateProductDto dto)
    {
        var result = await _sender.Send(new UpdateProductCommand(id, dto));
        if (result.IsFailure)
            return NotFound(ApiResponse<object>.Fail(result.ErrorMessage!));

        return Ok(ApiResponse<object>.Ok(null!, "Product updated successfully."));
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<ApiResponse<object>>> DeleteProduct(Guid id)
    {
        var result = await _sender.Send(new DeleteProductCommand(id));
        if (result.IsFailure)
            return NotFound(ApiResponse<object>.Fail(result.ErrorMessage!));

        return NoContent();
    }
}
