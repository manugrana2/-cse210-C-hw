public class SaleItem
{
    private Product _product;
    private int _quantity;
    private float _subtotal;
    public int SaleId { get; set; } // Reference to parent Sale 
    public int ProductId { get; set; }

    public void SetProduct(Product product)
    {
        _product = product;
        ProductId = product.ProductID;
    }

    public Product GetProduct()
    {
        return _product;
    }
    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
        CalculateSubtotal();
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public void CalculateSubtotal()
    {
        _subtotal = _product.Price * _quantity;
    }

    public float GetSubtotal()
    {
        return _subtotal;
    }
    public int GetProductId(){
        return _product.ProductID;
    }
}
