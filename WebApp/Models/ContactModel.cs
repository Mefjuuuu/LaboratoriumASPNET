using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class ContactModel {
    [HiddenInput] public int Id { get; set; }

    [Required]
    [MaxLength(length: 20, ErrorMessage = "Imię jest za długie!")]
    [MinLength(length: 2, ErrorMessage = "Imię jest za krótkie!")]
    [Display(Name = "Imię")]
    public string Name { get; set; }

    [Required]
    [MaxLength(length: 50, ErrorMessage = "Nazwisko jest za długie!")]
    [MinLength(length: 2, ErrorMessage = "Naziwsko jest za krótkie!")]
    [Display(Name = "Nazwisko")]
    public string Surname { get; set; }

    [EmailAddress] 
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}", ErrorMessage = "Niepoprawny format numeru telefonu! (xxx xxx xxx)")]
    [Display(Name = "Numer telefonu")]
    public string PhoneNumber { get; set; }

    [DataType(DataType.Date)] 
    [Display(Name = "Data urodzenia")]
    public DateOnly BirthDate { get; set; }
    
    [Display(Name = "Kategoria")]
    public Category Category { get; set; }
}