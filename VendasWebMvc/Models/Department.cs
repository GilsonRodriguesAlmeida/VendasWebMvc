using System.Security.Policy;

namespace VendasWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AssSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            //Soma as vendas do departamento de todos os vendedores
            //pega cada vendedor da lista, pega o total de vendas no periodo, e soma o resultado de todos os vendedores do departamento.
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
