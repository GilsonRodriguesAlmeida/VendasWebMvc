using VendasWebMvc.Data;
using VendasWebMvc.Models;
using System.Linq;

namespace VendasWebMvc.Services
{
    public class DepartmentService
    {
        private readonly VendasWebMvcContext _context;
        
        public DepartmentService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
