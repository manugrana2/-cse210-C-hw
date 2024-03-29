public class SalesDataManager : DataManager
{
  private List<Sale> _salesList;
  private ProductDataManager _productManager;

  public SalesDataManager(ProductDataManager productManager)
  {
    _salesList = new List<Sale>();
    _productManager = productManager;
  }

  public override bool Create()
  {
    // First, check if there are any products available
    if (_productManager.GetProducts().Count <= 0)
    {
      TextUtils.BlinkText("You need to add products before creating a sale.");
      return false;
    }

    Sale newSale = new Sale();

    Console.WriteLine("Enter sale date (in format yyyy-mm-dd) (leave blank for current date, 0 to cancel):");
    DateTime date;
    string dateInput = Console.ReadLine();
    if (dateInput == "0") return false;
    if (string.IsNullOrEmpty(dateInput))
    {
      date = DateTime.Now;
    }
    else
    {
      while (!DateTime.TryParse(dateInput, out date))
      {
        Console.WriteLine("Invalid date. Please enter a valid date (leave blank for current date, 0 to cancel).");
        dateInput = Console.ReadLine();
        if (dateInput == "0") return false;
      }
    }
    newSale.SetDate(date);

    // Display the list of available products
    Console.WriteLine("Available Products:");
    Console.WriteLine("{0,-10} {1,-20} {2,-10}", "ID", "Name", "Price");
    for (int i = 0; i < _productManager.GetProducts().Count; i++)
    {
      Product product = _productManager.GetProducts()[i];
      Console.WriteLine("{0,-10} {1,-20} {2,-10}", (i + 1), product.Name, product.Price);
    }

    Console.WriteLine("Enter the ID of the product you want to add to the sale (0 to cancel, S to save):");

    while (true)
    {
      string input = Console.ReadLine().Trim();
      if (input.Equals("0", StringComparison.OrdinalIgnoreCase))
      {
        // User input 0 to cancel
        return false;
      }
      else if (input.Equals("S", StringComparison.OrdinalIgnoreCase))
      {
        // User input S to save the sale
        if (_salesList.Count > 0)
        {
          return true;
        }
        else
        {
          TextUtils.BlinkText("No sale added because no products were added", true);
          return false;
        }
        return true;
      }
      else
      {
        // Parse the product ID
        if (!int.TryParse(input, out int productID) || productID <= 0 || productID > _productManager.GetProducts().Count)
        {
          Console.WriteLine("Invalid ID. Please enter a valid ID (0 to cancel, S to save).");
          continue;
        }

        // Get the selected product
        Product selectedProduct = _productManager.GetProducts()[productID - 1];

        Console.WriteLine("Enter the quantity of the product:");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        {
          TextUtils.BlinkText("Invalid quantity. Please enter a valid quantity.", true);
          continue;
        }

        // Create a new sale item with the selected product and quantity
        SaleItem newItem = new SaleItem();
        newItem.SetProduct(selectedProduct);
        newItem.SetQuantity(quantity);

        // Add the sale item to the sale
        newSale.AddSaleItem(newItem);

        // Display the current added product names and quantities
        Console.WriteLine("Current Added Products:");
        Console.WriteLine("{0,-10} {1,-20} {2,-10}", "ID", "Product", "Quantity");
        for (int i = 0; i < newSale.GetSaleItems().Count; i++)
        {
          SaleItem saleItem = newSale.GetSaleItems()[i];
          Console.WriteLine("{0,-10} {1,-20} {2,-10}", (i + 1), saleItem.GetProduct().Name, saleItem.GetQuantity());
        }

        Console.WriteLine("Enter the ID of the next product to add (0 to cancel, S to save):");
      }
    }
  }


  public override bool Edit()
  {
    if (_salesList.Count == 0)
    {
      TextUtils.BlinkText("There are no sales available to edit", true);
      return false;
    }

    // Display the list of sales with IDs
    Console.WriteLine("Sales:");
    Console.WriteLine("{0,-10} {1,-20} {2,-10}", "ID", "Date", "Total Amount");
    for (int i = 0; i < _salesList.Count; i++)
    {
      Sale sale = _salesList[i];
      string productNames = GetProductNamesString(sale);
      if (productNames.Length > 25)
      {
        productNames = productNames.Substring(0, 22) + "...";
      }
      Console.WriteLine("{0,-10} {1,-20} {2,-10}", (i + 1), sale.Date, sale.CalculateTotalAmount(), productNames);
    }

    Console.WriteLine("Enter the ID of the sale you want to edit (0 to cancel):");
    int saleID;
    while (!int.TryParse(Console.ReadLine(), out saleID) || saleID <= 0 || saleID > _salesList.Count)
    {
      Console.WriteLine("Invalid ID. Please enter a valid ID (0 to cancel).");
      if (saleID == 0) return false;
    }

    Sale selectedSale = _salesList[saleID - 1];

    // Display the selected sale and its sale items
    Console.WriteLine("Selected Sale:");
    Console.WriteLine("{0,-10} {1,-20} {2,-10}", "ID", "Date", "Total Amount");
    Console.WriteLine("{0,-10} {1,-20} {2,-10}", saleID, selectedSale.Date, selectedSale.CalculateTotalAmount());

    Console.WriteLine("Sale Items:");
    Console.WriteLine("{0,-10} {1,-20} {2,-10}", "ID", "Product", "Quantity");
    for (int i = 0; i < selectedSale.GetSaleItems().Count; i++)
    {
      SaleItem saleItem = selectedSale.GetSaleItems()[i];
      Console.WriteLine("{0,-10} {1,-20} {2,-10}", (i + 1), saleItem.GetProduct().Name, saleItem.GetQuantity());
    }

    return true;
  }

  public override bool Delete()
  {
    if (_salesList.Count == 0)
    {
      TextUtils.BlinkText("There are no sales available to delete", true);
      return false;
    }
    // Display the list of sales with IDs
    Console.WriteLine("Sales:");
    Console.WriteLine("{0,-10} {1,-20} {2,-10}", "ID", "Date", "Total Amount");
    for (int i = 0; i < _salesList.Count; i++)
    {
      Sale sale = _salesList[i];
      string productNames = GetProductNamesString(sale);
      if (productNames.Length > 25)
      {
        productNames = productNames.Substring(0, 22) + "...";
      }
      Console.WriteLine("{0,-10} {1,-20} {2,-10}", (i + 1), sale.Date, sale.CalculateTotalAmount(), productNames);
    }

    Console.WriteLine("Enter the ID of the sale you want to delete, 0 to cancel:");
    int id;
    while (!int.TryParse(Console.ReadLine(), out id) || id <= 0 || id > _salesList.Count)
    {
      Console.WriteLine("Invalid ID. Please enter a valid ID.");
      if (id == 0) return false;
    }

    _salesList.RemoveAt(id - 1);
    return true;
  }
  private string GetProductNamesString(Sale sale)
  {
    List<SaleItem> saleItems = sale.GetSaleItems();
    List<string> productNames = new List<string>();

    foreach (SaleItem saleItem in saleItems)
    {
      string productName = saleItem.GetProduct().Name;
      productNames.Add(productName);
    }

    return string.Join(", ", productNames);
  }
}
