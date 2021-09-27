using System.Collections.Generic;
using System;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //associação entre o departamento e os vendedores
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departament()
        {

        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSaller(Seller se)
        {
            Sellers.Add(se);
        }

        public double TotalSales(DateTime inicial, DateTime final)
        {
            return Sellers.Sum(se => se.TotalSales(inicial, final));
        }
    }
}
