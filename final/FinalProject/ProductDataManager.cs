public class ProductDataManager : DataManager
{
    private List<Product> _productList;
    private ProductDataHandler _dataHandler;

    public ProductDataManager(List<Product> productList)
    {
        _productList = productList;
        _dataHandler = new ProductDataHandler();
    }

    public override bool Create()
    {
        Console.WriteLine("Enter product name (0 to cancel):");
        string name = Console.ReadLine();
        if (name == "0") return false;

        Console.WriteLine("Enter product description (0 to cancel):");
        string description = Console.ReadLine();
        if (description == "0") return false;

        Console.WriteLine("Enter product price (0 to cancel):");
        float price;
        while (!float.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price. Please enter a valid number (0 to cancel).");
            if (price == 0) return false;
        }

        Product newProduct = new Product
        {
            ProductID = _productList.Count + 1,
            Name = name,
            Description = description,
            Price = price
        };

        _productList.Add(newProduct);
        _dataHandler.SaveToCSV(_productList);
        return true;
    }

    public override bool Edit()
    {
        if (_productList.Count == 0)
        {
            TextUtils.BlinkText("There are no products to edit.");
            return false;
        }
        Console.WriteLine("{0,-10} {1,-20} {2,-10}", "ID", "Name", "Price");
        for (int i = 0; i < _productList.Count; i++)
        {
            Console.WriteLine("{0,-10} {1,-20} {2,-10}", (i + 1), _productList[i].Name, _productList[i].Price);
        }

        Console.WriteLine("Enter the ID of the product you want to edit (0 to cancel):");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0 || id > _productList.Count)
        {
            Console.WriteLine("Invalid ID. Please enter a valid ID (0 to cancel).");
            if (id == 0) return false;
        }

        Console.WriteLine($"You are editing product: {_productList[id - 1].Name}, Price: {_productList[id - 1].Price}. Do you want to continue? \n1.Yes \n2-No");
        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
        {
            Console.WriteLine("Invalid option. Please enter 1 for Yes, 2 for No.");
        }
        if (option == 2) return false;

        Console.WriteLine("Enter new product name (current: " + _productList[id - 1].Name + "):");
        string name = Console.ReadLine();

        Console.WriteLine("Enter new product description (current: " + _productList[id - 1].Description + "):");
        string description = Console.ReadLine();

        Console.WriteLine("Enter new product price (current: " + _productList[id - 1].Price + "):");
        float price;
        while (!float.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price. Please enter a valid number.");
        }

        _productList[id - 1].Name = name;
        _productList[id - 1].Description = description;
        _productList[id - 1].Price = price;

        return true;
    }

    public override bool Delete()
    {
        Console.WriteLine("{0,-10} {1,-20} {2,-10}", "ID", "Name", "Price");
        for (int i = 0; i < _productList.Count; i++)
        {
            Console.WriteLine("{0,-10} {1,-20} {2,-10}", (i + 1), _productList[i].Name, _productList[i].Price);
        }

        Console.WriteLine("Enter the ID of the product you want to delete, 0 to cancel:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id) || id <= 0 || id > _productList.Count)
        {
            Console.WriteLine("Invalid ID. Please enter a valid ID.");
            if (id == 0) return false;
        }

        Console.WriteLine($"You are about to delete product: {_productList[id - 1].Name}, Price: {_productList[id - 1].Price}. Are you sure? 1. Yes, \n2. No");
        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
        {
            Console.WriteLine("Invalid option. Please enter 1 for Yes, 2 for No.");
        }
        if (option == 2) return false;

        _productList.RemoveAt(id - 1);
        return true;
    }
    public List<Product> GetProducts()
    {
        return _productList;
    }
    public Product GetProductById(int productId)
    {
        return _productList.FirstOrDefault(p => p.ProductID == productId);
    }
}
