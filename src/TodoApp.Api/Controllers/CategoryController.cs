using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>  
    /// Yeni bir kategori ekler.  
    /// </summary>  
    /// <param name="addCategoryRequest">Kategori bilgileri</param>  
    /// <returns>Eklenen kategorinin bilgileri</returns>  
    [HttpPost("[action]")]
    public async Task<IActionResult> AddNewCategory([FromBody] AddCategoryRequest addCategoryRequest)
    {
        var result = await _mediator.Send(addCategoryRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Mevcut bir kategoriyi günceller.  
    /// </summary>  
    /// <param name="updateCategoryRequest">Güncellenecek kategori bilgileri</param>  
    /// <returns>Güncellenen kategorinin bilgileri</returns>  
    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest updateCategoryRequest)
    {
        var result = await _mediator.Send(updateCategoryRequest);
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir kategoriyi siler.  
    /// </summary>  
    /// <param name="id">Silinecek kategorinin ID'si</param>  
    /// <returns>Silme işleminin sonucu</returns>  
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteCategoryRequest { Id = id });
        return Ok(result);
    }

    /// <summary>  
    /// Tüm kategorileri listeler.  
    /// </summary>  
    /// <returns>Kategorilerin listesi</returns>  
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _mediator.Send(new GetAllCategoriesRequest());
        return Ok(result);
    }

    /// <summary>  
    /// Belirli bir kategoriyi ID ile getirir.  
    /// </summary>  
    /// <param name="id">Kategorinin ID'si</param>  
    /// <returns>Kategorinin bilgileri</returns>  
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdRequest { Id = id });
        return Ok(result);
    }
}

/// <summary>
/// Requestler bunları backend servislerine göre ayarlayacağız
/// </summary>
public class AddCategoryRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class UpdateCategoryRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class DeleteCategoryRequest
{
    public int Id { get; set; }
}

public class GetAllCategoriesRequest
{
}

public class GetCategoryByIdRequest
{
    public int Id { get; set; }
}