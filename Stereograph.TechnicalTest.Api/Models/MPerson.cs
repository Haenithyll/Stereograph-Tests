using System.ComponentModel.DataAnnotations;

namespace Stereograph.TechnicalTest.Api.Models;

public class MPerson
{
    [Required(ErrorMessage = "firstName is required")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "lastName is required")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "email is required")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "address is required")]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "city is required")]
    public string City { get; set; }
}