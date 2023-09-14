using System.ComponentModel.DataAnnotations;
using App.Example.Domain.Models;

namespace App.Example.Infrastructure.ViewModels;

public class ProductDetailViewModel 
{
    public Product Product {get; set;}
}