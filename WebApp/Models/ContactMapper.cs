namespace WebApp.Models;

public class ContactMapper {

    public static ContactEntity? ToEntity(ContactModel model) {
        return new ContactEntity {
            Name = model.Name,
            Surname = model.Surname,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            BirthDate = model.BirthDate,
            Category = model.Category,
            Created = DateTime.Now,
            Organization = model.Organization,
            OrganizationId = model.OrganizationId
        };
    }
    
    public static ContactModel ToModel(ContactEntity entity) {
        return new ContactModel {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            BirthDate = entity.BirthDate,
            Category = entity.Category,
            Organization = entity.Organization,
            OrganizationId = entity.OrganizationId
        };
    }
}