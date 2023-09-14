using System.ComponentModel.DataAnnotations;
using App.Core.Domain.Mappers.Entity;
using App.Example.Domain.Models;

namespace App.Example.Infrastructure.ViewModels;

[SetEntityRemapper(mapTo: typeof(Product))]
public class ProductCreateViewModel 
{
    [Required] public string Name {get; set;} = String.Empty;
    [Required] public decimal Price {get; set;} = 0.0M;
}