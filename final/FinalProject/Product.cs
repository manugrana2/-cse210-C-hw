public class Product
{
    private int _productID;
    private string _name;
    private string _description;
    private float _price;

     public int ProductID { get { return _productID; } set { _productID = value; } }
    public string Name { get { return _name; } set { _name = value; } }
    public string Description { get { return _description; } set { _description = value; } }
    public float Price { get { return _price; } set { _price = value; } }
}
