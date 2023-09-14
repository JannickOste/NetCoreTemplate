using Microsoft.AspNetCore.Mvc;
using App.Core.Domain.ViewModels.User;

using App.Core.Domain.Database;
using App.Core.Domain.Mappers.Entity;
using App.Core.Domain.ViewModels.Default;
using App.Auth.Domain.ViewModels.User;
using App.Auth.Domain.User;
using Microsoft.AspNetCore.Authorization;
using App.Example.Domain.Models;
using App.Example.Infrastructure.ViewModels;

namespace App.Auth.Infrastructure.Controllers;

/**
* @author: Oste Jannick
* @description: A User endpoint controller template for CRUD user interactions with the API. 
* @Date: 2023-09-11
*/
[Route("[controller]")]
public class ProductController : Controller
{
    private readonly IDatabaseRepository<Product> repository;

    private readonly IEntityRemapper<ProductCreateViewModel, Product> createMapper;
    private readonly IEntityRemapper<ProductUpdateViewModel, Product> updateMapper;

    public ProductController(
        IDatabaseRepository<Product> repository,
        IEntityRemapper<ProductCreateViewModel, Product>  createMapper,
        IEntityRemapper<ProductUpdateViewModel, Product>  updateMapper
    )
    {
        this.repository = repository;
        this.createMapper = createMapper;
        this.updateMapper = updateMapper;
    }

    [HttpPost("")]
    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Create([FromBody] ProductCreateViewModel productCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

            Product product = this.repository.Insert(
                this.createMapper.Remap(productCreateViewModel)
            );
        try
        {

            return Ok(new ProductDetailViewModel()
            {
                Product = product
            });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }

    }

    [HttpGet("")]
    [ProducesResponseType(typeof(UserListViewModel), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult List()
    {
        try
        {
            return Ok(new ProductListViewModel()
            {
                Products = this.repository.GetAll()
            });

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Detail(int id)
    {
        try
        {
            Product? target = this.repository.GetById(id);
            if (target is null)
            {
                return BadRequest(new ErrorViewModel()
                {
                    Error = "Product not found"
                });
            }

            return Ok(new ProductDetailViewModel()
            {
                Product = target
            });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UserDetailViewModel), 200)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Update(int id, [FromBody] ProductUpdateViewModel userUpdateViewModel)
    {
        Product? user = this.repository.GetById(id);
        if (user is null)
        {
            return BadRequest(new ErrorViewModel()
            {
                Error = "Product not found"
            });
        }

        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Product updatedUser = this.updateMapper.Copy(userUpdateViewModel, user);
        this.repository.Update(updatedUser);

        return Ok(new ProductDetailViewModel(){
            Product = updatedUser
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ErrorViewModel), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public ActionResult Delete(int id)
    {
        try
        {
            Product? target = this.repository.GetById(id);
            if (target is null)
            {
                return BadRequest(new ErrorViewModel()
                {
                    Error = "Product not found"
                });
            }

            this.repository.Delete(target);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}