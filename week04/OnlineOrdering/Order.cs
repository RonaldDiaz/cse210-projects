public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = [];
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalProductCost = _products.Sum(product => product.GetTotalCost());
        decimal shippingCost = _customer.LivesInUsa() ? 5.00m : 35.00m;
        return totalProductCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string title = $"============= PACKING LABEL =============";
        string[] products = [.. from product in _products select product.DisplayData()];
        return $"{title}\n{string.Join("\n", products)}";
    }

    public string GetShippingLabel()
    {
        string title = $"============= SHIPPING LABEL =============";
        return $"{title}\n{_customer.DisplayData()}";
    }

    public string DisplayShippingCost()
    {
        return $"Shipping Location: {(_customer.LivesInUsa() ? "USA (Shipping: $5.00)" : "International (Shipping: $35.00)")}";
    }
}