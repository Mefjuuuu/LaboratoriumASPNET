namespace WebApp.Models.services;

public class EFContantService : IContactService {
    
    private readonly AppDbContext _context;

    public EFContantService(AppDbContext context) {
        _context = context;
    }

    public void Add(ContactModel model) {
        _context.Type.Add(ContactMapper.ToEntity(model));
        _context.SaveChanges();
    }

    public void Update(ContactModel model) {
        _context.Type.Update(ContactMapper.ToEntity(model));
        _context.SaveChanges();
    }

    public void Delete(int id) {
        _context.Type.Remove(_context.Type.Find(id));
        _context.SaveChanges();
    }

    public List<ContactModel> GetAll() {
        return _context.Type.Select(ContactMapper.ToModel!).ToList();
    }

    public ContactModel? GetById(int id) {
        throw new NotImplementedException();
    }
}