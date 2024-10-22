using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class ContactModel {
    [HiddenInput] public int Id { get; set; }

    [Required]
    [MaxLength(length: 20, ErrorMessage = "Imię jest za długie!")]
    [MinLength(length: 2, ErrorMessage = "Imię jest za krótkie!")]
    public string Name { get; set; }

    [Required]
    [MaxLength(length: 50, ErrorMessage = "Nazwisko jest za długie!")]
    [MinLength(length: 2, ErrorMessage = "Naziwsko jest za krótkie!")]
    public string Surname { get; set; }

    [EmailAddress] public string Email { get; set; }

    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}", ErrorMessage = "Niepoprawny format numeru telefonu! (xxx xxx xxx)")]
    public string PhoneNumber { get; set; }

    [DataType(DataType.Date)] public DateOnly BirthDate { get; set; }
}