using EntityFramework.Modules;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    // Ham tao database
    static void CreateDatabase()
    {
        using var dbContetx = new ProductDbContext();
        string dbName = dbContetx.Database.GetDbConnection().Database;

        var rs = dbContetx.Database.EnsureCreated();
        if (rs)
            Console.WriteLine($"Create DB {dbName} successfully!");
        else
            Console.WriteLine($"Create DB {dbName} faild!");

    }
    // Ham xoa database
    static void DropDatabase()
    {
        using var dbContetx = new ProductDbContext();
        string dbName = dbContetx.Database.GetDbConnection().Database;

        var rs = dbContetx.Database.EnsureDeleted();
        if (rs)
            Console.WriteLine($"Delete DB {dbName} successfully!");
        else
            Console.WriteLine($"Delete DB {dbName} faild!");

    }
    // Them du lieu vao Product
    static void InsertProduct()
    {
        using var dbContetx = new ProductDbContext();
        //var p = new Product()
        //{
        //    ProductName = "San pham 2",
        //    Provider = "Cong ty 2"
        //};
        //dbContetx.Add(p); // Them 1 dong du lieu
        var products = new object[]
        {
            new Product() {ProductName = "San pham 3", Provider = "Cong ty A"},
            new Product() {ProductName = "San pham 4", Provider = "Cong ty A"},
            new Product() {ProductName = "San pham 5", Provider = "Cong ty A"}
        };
        dbContetx.AddRange(products); // Them nhieu dong du lieu
        int number_rows = dbContetx.SaveChanges();
        Console.WriteLine($"Inserted {number_rows} row!");
    }
    // Doc du lieu
    static void ReadProduct()
    {
        using var dbContetx = new ProductDbContext();
        //LinQ
        var products = dbContetx.products.ToList();
        products.ForEach(product => product.PrintInfo());
    }
    static void RenameProduct(int Id, string newName)
    {
        using var dbContetx = new ProductDbContext();
        Product product = (from p in dbContetx.products
                           where p.ProductId == Id
                           select p).FirstOrDefault();
        if(product != null )
        {
            product.ProductName = newName;
            int number_rows = dbContetx.SaveChanges();
            Console.WriteLine($"Rename {number_rows} row!");
        }
    }
    // Xoa 1 dong du lieu
    static void DeleteProduct(int Id)
    {
        using var dbContetx = new ProductDbContext();
        Product product = (from p in dbContetx.products
                           where p.ProductId == Id
                           select p).FirstOrDefault();
        if (product != null)
        {
            dbContetx.Remove(product);
            int number_rows = dbContetx.SaveChanges();
            Console.WriteLine($"Delete {number_rows} row!");
        }
    }
    private static void Main(string[] args)
    {
        DeleteProduct(2);
    }
}