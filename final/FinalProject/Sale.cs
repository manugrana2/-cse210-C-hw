public class Sale
{
    private int _saleID;
    private DateTime _date;
    private List<SaleItem> _saleItems;
    private float _totalAmount;

    public int SaleID
    {
        get { return _saleID; }
        set { _saleID = value; }
    }

    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public List<SaleItem> SaleItems
    {
        get { return _saleItems; }
        set { _saleItems = value; }
    }

    public Sale()
    {
        _saleItems = new List<SaleItem>();
    }

    public void AddSaleItem(SaleItem saleItem)
    {
        _saleItems.Add(saleItem);
    }

    public float CalculateTotalAmount()
    {
        float total = 0;
        foreach (SaleItem saleItem in _saleItems)
        {
            total += saleItem.GetSubtotal();
        }
        return total;
    }

    public List<SaleItem> GetSaleItems()
    {
        return _saleItems;
    }

    public void SetDate(DateTime date)
    {
        _date = date;
    }

    public void SetTotalAmount(float totalAmount)
    {
        _totalAmount = totalAmount;
    }
}

