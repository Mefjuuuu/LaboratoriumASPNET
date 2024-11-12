namespace WebApp.Models.services;

public interface IContactService {
    
    void Add(ContactModel model);

    void Update(ContactModel model);

    void Delete(int id);

    List<ContactModel> GetAll();
    
    ContactModel? GetById(int id);
    
    List<OrganizationEntity> GetAllOrganizations();
}