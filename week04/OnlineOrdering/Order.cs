public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    private decimal GetShippingCost()
    {
        return _customer.IsInUSA() ? 5.00m : 35.00m;
    }

    public decimal CalculateTotalCost()
    {
        decimal productCostTotal = 0;
        foreach (Product product in _products)
        {
            productCostTotal += product.GetTotalCost();
        }
        return productCostTotal + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"  ID: {product.GetProductId()} - Name: {product.GetName()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string name = _customer.GetName();
        string addressString = _customer.GetAddress().GetAddressString();
        
        return $"Shipping Label:\n{name}\n{addressString}";
    }
}