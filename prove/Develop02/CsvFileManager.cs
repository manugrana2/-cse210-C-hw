public class CsvFileManager
{
    private string _filePath;

    public CsvFileManager(string filePath)
    {
        _filePath = filePath;
    }

    public void AddRowToCsv(string[] rowData)
    {
        try
        {
            string row = string.Join(",", Array.ConvertAll(rowData, EscapeCsvField));

            string directoryPath = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(_filePath))
            {
                using (StreamWriter writer = File.CreateText(_filePath))
                {
                    writer.WriteLine(row);
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(_filePath))
                {
                    writer.WriteLine(row);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding a row to the CSV file to save your journal: {ex.Message}");
        }
    }

    private string EscapeCsvField(string fieldValue)
    {
        if (string.IsNullOrEmpty(fieldValue))
            return string.Empty;

        // Check if the field contains special characters or needs escaping
        if (fieldValue.Contains(",") || fieldValue.Contains("\"") || fieldValue.Contains(Environment.NewLine))
        {
            // Escape double quotes by doubling them
            fieldValue = fieldValue.Replace("\"", "\"\"");

            // Enclose the field value in double quotes
            fieldValue = $"\"{fieldValue}\"";
        }

        return fieldValue;
    }

    public List<string[]> GetAllRowsFromCsv()
    {
        List<string[]> rows = new List<string[]>();

        try
        {
            if (File.Exists(_filePath))
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] rowData = ParseCsvLine(line);
                        rows.Add(rowData);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving rows from the CSV file: {ex.Message}");
        }

        return rows;
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> columns = new List<string>();

        int startIndex = 0;
        int endIndex;
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char currentChar = line[i];
            char nextChar = (i < line.Length - 1) ? line[i + 1] : '\0';

            if (currentChar == '"')
            {
                if (nextChar == '"')
                {
                    i++; // Skip the second quote
                    continue;
                }

                inQuotes = !inQuotes;
            }
            else if (currentChar == ',' && !inQuotes)
            {
                endIndex = i;
                string column = line.Substring(startIndex, endIndex - startIndex);
                columns.Add(column);
                startIndex = i + 1;
            }
        }

        // Add the last column
        string lastColumn = line.Substring(startIndex);
        columns.Add(lastColumn);

        return columns.ToArray();
    }
}
