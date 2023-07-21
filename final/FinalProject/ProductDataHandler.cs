using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class ProductDataHandler
{
    private const string FolderName = "Sales Manager";
    private const string FileName = "Products.csv";

    private List<Product> _products;

    public ProductDataHandler()
    {
        _products = LoadFromCSV();
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public void SaveToCSV(List<Product> products)
    {
        StringBuilder csv = new StringBuilder();

        csv.AppendLine("ProductID,Name,Description,Price");

        foreach (Product product in products)
        {
            csv.Append(product.ProductID);
            csv.Append(",");
            csv.Append(ParseValue(product.Name));
            csv.Append(",");
            csv.Append(ParseValue(product.Description));
            csv.Append(",");
            csv.Append(ParseValue(product.Price.ToString()));
            csv.AppendLine();
        }

        SaveToFile(csv.ToString());
        _products = new List<Product>(products);
    }

    public List<Product> LoadFromCSV()
    {
        if (_products != null)
        {
            return _products;
        }

        _products = new List<Product>();

        StringBuilder csv = LoadFromFile();

        string[] rows = csv.ToString().Split("\n");
        int i = 0;
        foreach (string row in rows)
        {
            i++;
            if (string.IsNullOrWhiteSpace(row) || i == 1)
                continue;
            string[] values = row.Split(",");

            Product product = new Product();
            product.ProductID = int.Parse(values[0]);
            product.Name = UnescapeValue(values[1]);
            product.Description = UnescapeValue(values[2]);
            product.Price = float.Parse(UnescapeValue(values[3]));

            _products.Add(product);
        }

        return _products;
    }

    private StringBuilder LoadFromFile()
    {
        StringBuilder csv = new StringBuilder();

        string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string path = Path.Combine(folder, FolderName, FileName);

        if (!File.Exists(path))
        {
            return csv;
        }

        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                csv.Append(line);
                csv.AppendLine();
            }
        }

        return csv;
    }

    private void SaveToFile(string contents)
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filepath = Path.Combine(folder, FolderName, FileName);

        if (!Directory.Exists(Path.GetDirectoryName(filepath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));
        }

        File.WriteAllText(filepath, contents);
    }

    private string ParseValue(string value)
    {
        if (value.Contains(",") || value.Contains("\"") || value.Contains("\r\n"))
        {
            return $"\"{value.Replace("\"", "\"\"")}\"";
        }
        else
        {
            return value;
        }
    }

    private string UnescapeValue(string value)
    {
        if (value.StartsWith("\"") && value.EndsWith("\""))
        {
            value = value.Trim('"');
            value = value.Replace("\"\"", "\"");
        }

        return value;
    }

}