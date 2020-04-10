using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommandLineParameter
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DbSet<Factura> Facturas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=facturas.db");
    }


    public class Factura
    {
        [Key]
        public int Id { get; set; }
        public string NumeroFactura { get; set; }
        public string Condiciones { get; set; }
        public string Cedula { get; set; }
        public string FechaFactura { get; set; }
        public string Monto { get; set; }
        public string Estado { get; set; }

    }
}
