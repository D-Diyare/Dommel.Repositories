# Dommel.Repositories
Repository Pattern &amp; UnitOfWork Implementation For [Dommel](https://github.com/henkmollema/Dommel).

### Description
> Dommel.Repositories is a library that makes the implementation of Repository Pattern and UnitOfWork a lot easier.
The Implementation sample taken from [Tim Schreiber](https://github.com/timschreiber/DapperUnitOfWork) example.

### Download

Nuget
> Directly download from [Nuget](https://www.nuget.org/packages/Dommel.Repositories/)

Package Manager Console 
> PM > Install-Package Dommel.Repositories

### Usage

POCO's:

```cs
[Table(nameof(Category))]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; set; }
}
```

```cs
[Table(nameof(Product))]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public int Quantity { get; set; }

    public int? CategoryId { get; set; }
    public Category Category { get; set; }
}
```
#### Dommel.Repositories contains two types of repositories and unit of works:

1. Async Repository (Asynchronous CRUD operations)
    <br>- Async UnitOfWork
   
2. Sync Repository (Synchronous CRUD Operations)
   <br>- Sync UnitOfWork
   
It's all up to you to inherit from which one, Here we inherit the repository for entities from synchronous repository base.

```cs
public class CategoryRepository : SyncRepository<Category>
{
    public CategoryRepository(IDbConnection connection) : base(connection)
    {
    }
    
    // Custom other operations other than those provided by the library.
}
```
```cs
public class ProductRepository : SyncRepository<Product>
{
    public ProductRepository(IDbConnection connection) : base(connection)
    {
    }
    
    // Custom other operations other than those provided by the library.
}
```
We also inherit our context from synchronous unitofwork:

```cs
public class AppDbContext : SyncUnitOfWork
{
    private ISyncRepository<Category> _categories;
    private ISyncRepository<Product> _products;

    public AppDbContext(IConnection connection, IConnectionHelper connectionHelper)
        : base(connection, connectionHelper)
    {
    }

    public ISyncRepository<Product> Products =>
        _products ?? new ProductRepository(Connection);

    public ISyncRepository<Category> Categories =>
        _categories ?? new CategoryRepository(Connection);

    protected override void ResetRepositories()
    {
        _products = null;
        _categories = null;
    }
}
```
Note:
> Both AsyncUnitOfWork and SyncUnitOfWork contain constructor parameters 
> -[x] [IConnection](https://github.com/D-Diyare/Dommel.Repositories/blob/master/src/Lib/Dommel.Repositories/Connection/IConnection.cs) (Connection type such as SQLiteConnection, SqlConnection, MySqlConnection, ...)
> -[x] [IConnectionHelper](https://github.com/D-Diyare/Dommel.Repositories/blob/master/src/Lib/Dommel.Repositories/Connection/IConnectionHelper.cs) (Connection string)

You need to implement these two interfaces as well, for example (sqlite):

```cs
public class DbConnection : IConnection
{
    public IDbConnection Connection(string connectionString)
    {
        return new SQLiteConnection(connectionString);
    }
}
```
```cs
public class ConnectionHelper : IConnectionHelper
{
    public string ConnectionString => @"Data Source=.\Database.db;Version=3;";
}
```

```cs
internal static class Program
{
    static void Main(string[] args)
    {
        // Insert Category
        using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());
        var result = (long) context.Categories.Insert(category) > 0;
        result &= context.SaveChanges();
        if (result)
            Console.WriteLine($"{category.Name} Successfully Inserted.");
            
        // Read Category By Id with it's products.
        using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());
        var category = context.Categories.GetById<Product>(1);
        Console.WriteLine(
            $" Category Id : {category.Id} \n Category Name : {category.Name} \n Product : {category.Products.FirstOrDefault()?.Name}");
            
        // Read Products with their categories.
        using var context = new AppDbContext(new DbConnection(), new ConnectionHelper());
        // Get Products with their categories.
        var products = context.Products.GetAll<Category>();
        foreach (var product in products)
        {
            Console.WriteLine(
                $" Product Id : {product.Id} \n Product Name : {product.Name} \n CategoryName : {product.Category?.Name}");
        }
            
    }
{ 
```

> See the full **[Demo](https://github.com/D-Diyare/Dommel.Repositories/tree/master/src/Demo)**.
 
### What's included inside repository ?

```cs 
T GetById(int id);
T GetById<T2>(int id);
T GetById<T2, T3>(int id);
T GetById<T2, T3, T4>(int id);
T GetById<T2, T3, T4, T5>(int id);
T GetById<T2, T3, T4, T5, T6>(int id);

IEnumerable<T> GetAll();
IEnumerable<T> GetAll<T2>();
IEnumerable<T> GetAll<T2, T3>();
IEnumerable<T> GetAll<T2, T3, T4>();
IEnumerable<T> GetAll<T2, T3, T4, T5>();
IEnumerable<T> GetAll<T2, T3, T4, T5, T6>();

object Insert(T entity);

bool Delete(T entity);
int DeleteMultiple(Expression<Func<T, bool>> predicate);
int DeleteAll();

bool Update(T entity);

IEnumerable<T> Select(Expression<Func<T, bool>> predicate);
IEnumerable<T> SelectPaged(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);

T FirstOrDefault(Expression<Func<T, bool>> predicate);
```

### What if I want to use it with dependency injection?

You can simply create an interface for the repository inhert from IAsyncRepository<T> or ISyncRepository<T>

```cs 
public interface ICategoryRepository : ISyncRepository<Category>
{
    
}
```

```cs 
public class CategoryRepository : SyncRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IDbConnection connection) : base(connection)
    {
    }
}
```

Then simply registering it like:

    Container.RegisterType<ICategoryRepository, CategoryRepository>();
    
    
    Container.RegisterType<ISyncUnitOfWork, AppDbContext>();

### License
> [MIT License](https://github.com/D-Diyare/Dommel.Repositories/blob/master/LICENSE)
