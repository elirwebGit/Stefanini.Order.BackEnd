using Microsoft.EntityFrameworkCore;

namespace Stefanini.Order.Infra
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Context.EfCore())
            {
                db.Database.Migrate();

                if (!db.Product.Any())
                {
                    db.Product.Add(new Domain.Entites.Product {  ProductName = "Mouse", Value=56.45m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Computador", Value = 900.00m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Teclado", Value = 145.56m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Monitor", Value = 89.23m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Tela", Value = 41.78m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Impressora", Value = 600.00m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Caixa Som", Value = 56.00m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Bateria", Value = 168.90m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Had Fone", Value = 78.45m });
                    db.Product.Add(new Domain.Entites.Product {  ProductName = "Web Cam", Value = 120.48m });
                    db.Product.Add(new Domain.Entites.Product {  ProductName = "Mouse com Fio", Value = 58.18m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Ventilador", Value = 56.45m });
                    db.Product.Add(new Domain.Entites.Product {  ProductName = "Cadeira", Value = 895.48m });
                    db.Product.Add(new Domain.Entites.Product {  ProductName = "CD Rom", Value = 12.74m });
                    db.Product.Add(new Domain.Entites.Product {  ProductName = "Placa mãe", Value = 149.23m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "CD Windows", Value = 45.29m });
                    db.Product.Add(new Domain.Entites.Product {  ProductName = "Squize", Value = 19.29m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Extensão", Value = 189.19m });
                    db.Product.Add(new Domain.Entites.Product {  ProductName = "Laptop", Value = 345.75m });
                    db.Product.Add(new Domain.Entites.Product { ProductName = "Bolsa Laptop", Value = 84.00m });
                    db.SaveChanges();
                }

              
            }


        }
    }
}

