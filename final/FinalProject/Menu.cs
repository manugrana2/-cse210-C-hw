public class Menu
{
    private ProductDataManager productManager;
    private DataManager salesManager;
    private ReportGenerator reportGenerator;

    public Menu()
    {
        ProductDataHandler savedProducts = new ProductDataHandler();
        productManager = new ProductDataManager(savedProducts.GetProducts());
        salesManager = new SalesDataManager(productManager);
        reportGenerator = new ReportGenerator();
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Create product");
            Console.WriteLine("2. Edit product");
            Console.WriteLine("3. Delete product");
            Console.WriteLine("4. Create sale");
            Console.WriteLine("5. Edit sale");
            Console.WriteLine("6. Delete sale");
            Console.WriteLine("7. Generate sales report");
            Console.WriteLine("8. Exit");
            Console.Write("Please select an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    if (productManager.Create())
                        TextUtils.BlinkText("Product created successfully!", false);
                    break;
                case "2":
                    if (productManager.Edit())
                        TextUtils.BlinkText("Product edited successfully!", false);
                    break;
                case "3":
                    if (productManager.Delete())
                        TextUtils.BlinkText("Product deleted successfully!", false);
                    break;
                case "4":
                    if (salesManager.Create())
                        TextUtils.BlinkText("Sale created successfully!", false);
                    break;
                case "5":
                    if (salesManager.Edit())
                        TextUtils.BlinkText("Sale edited successfully!", false);
                    break;
                case "6":
                    if (salesManager.Delete())
                        TextUtils.BlinkText("Sale deleted successfully!", false);
                    break;
                case "7":
                    reportGenerator.GenerateReport();
                    TextUtils.BlinkText("Report generated successfully!", false);
                    break;
                case "8":
                    return;
                default:
                    TextUtils.BlinkText("Invalid option. Please choose a valid one.", true);
                    break;
            }
            Console.Clear();
        }
    }
}
