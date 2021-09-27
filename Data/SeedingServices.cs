using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingServices
    {
        private SalesWebMvcContext _context;

        public SeedingServices(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departament.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //banco de dados já foi populado
            }

            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Eletronics");
            Departament d3 = new Departament(3, "Books");
            Departament d4 = new Departament(4, "Fashion");

            Seller s1 = new Seller(1, "Bob", "bob@gmail.com", new DateTime(1988, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria", "maria@gmail.com", new DateTime(1998, 9, 21), 1500.0, d1);
            Seller s3 = new Seller(3, "Pedro", "pedro@gmail.com", new DateTime(1999, 4, 8), 2000.0, d2);
            Seller s4 = new Seller(4, "Carl", "carl@gmail.com", new DateTime(2000, 6, 21), 1599.99, d3);
            Seller s5 = new Seller(5, "John", "john@gmail.com", new DateTime(1988, 1, 1), 5000.0, d4);
            Seller s6 = new Seller(6, "Carla", "carla@gmail.com", new DateTime(1998, 7, 20), 5999.99, d1);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2021, 9, 25), 500.00, SalesStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2021, 9, 01), 1500.00, SalesStatus.Canceled, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2021, 9, 15), 950.5, SalesStatus.Billed, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2021, 9, 05), 998.88, SalesStatus.Pending, s5);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2021, 9, 22), 550.50, SalesStatus.Billed, s6);
            SalesRecord sr6 = new SalesRecord(6, new DateTime(2021, 9, 03), 425.50, SalesStatus.Billed, s4);

            _context.Departament.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6);

            _context.SaveChanges();

        }
    }
}
