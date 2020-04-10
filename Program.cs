using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace CommandLineParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Bienvenido ---");

            var obj = new Factura()
            {
                FechaFactura = DateTime.Now.ToString()
            };

            Console.WriteLine("\nIngrese el numero de factura: ");
            obj.NumeroFactura = Console.ReadLine();

            Console.WriteLine("\nIngrese el numero la cedula: ");
            obj.Cedula = Console.ReadLine();

            Console.WriteLine("\nIngrese el monto: ");
            obj.Monto = Console.ReadLine();


            Console.WriteLine("\nIngrese las condiciones: ");
            obj.Condiciones = Console.ReadLine();

            Console.WriteLine("\nIngrese el estado: ");
            obj.Estado = Console.ReadLine();

            using (var db = new DataContext())
            {
                // Create
                Console.WriteLine("\nInsertando en la db...");
                db.Facturas.Add(obj);
                db.SaveChanges();

            }
            string strCmdText = $"/k node test-open-terminal.js {obj.Cedula}";
            Console.WriteLine($"\nEjecutando el comando {strCmdText}");

            var psi = new ProcessStartInfo("cmd.exe", strCmdText);
            psi.UseShellExecute = true;
            Process.Start(psi);

            Console.ReadKey();

        }


    }


}
