using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using App.Core.Domain.Database;
using App.Core.Domain.Mappers.Entity;
using App.Core.Domain.ViewModels.Default;

namespace App.Core.Domain.Controllers;

[Route("[controller]")]
public abstract class AEntityController<TEntity, TCreateViewModel, TUpdateViewModel> : Controller
    where TEntity : class
    where TCreateViewModel : class
    where TUpdateViewModel : class
{
    private readonly IDatabaseRepository<TEntity> repository;
    private readonly IEntityRemapper<TCreateViewModel, TEntity> createMapper;
    private readonly IEntityRemapper<TUpdateViewModel, TEntity> updateMapper;

    public AEntityController(
        IDatabaseRepository<TEntity> repository,
        IEntityRemapper<TCreateViewModel, TEntity> createMapper,
        IEntityRemapper<TUpdateViewModel, TEntity> updateMapper
    )
    {
        this.repository = repository;
        this.createMapper = createMapper;
        this.updateMapper = updateMapper;
    }

    [HttpPost("")]
    public virtual ActionResult Create([FromBody] TCreateViewModel createViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        TEntity entity = this.createMapper.Remap(createViewModel);

        try
        {
            entity = this.repository.Insert(entity);
            return Ok(entity);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("")]
    public virtual ActionResult List()
    {
        try
        {
            IEnumerable<TEntity> entities = this.repository.GetAll();
            return Ok(entities);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public virtual ActionResult Detail(int id)
    {
        try
        {
            TEntity? entity = this.repository.GetById(id);
            if (entity is null)
            {
                return BadRequest(new ErrorViewModel()
                {
                    Error = $"{typeof(TEntity).Name} not found"
                });
            }

            return Ok(entity);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public virtual ActionResult Update(int id, [FromBody] TUpdateViewModel updateViewModel)
    {
        TEntity? entity = this.repository.GetById(id);
        if (entity is null)
        {
            return BadRequest(new ErrorViewModel()
            {
                Error = $"{typeof(TEntity).Name} not found"
            });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        TEntity updatedEntity = this.updateMapper.Copy(updateViewModel, entity);
        this.repository.Update(updatedEntity);

        return Ok(updatedEntity);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            TEntity? entity = this.repository.GetById(id);
            if (entity is null)
            {
                return BadRequest(new ErrorViewModel()
                {
                    Error = $"{typeof(TEntity).Name} not found"
                });
            }

            this.repository.Delete(entity);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}