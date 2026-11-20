namespace Domain.Entities;

// Сутність, що представляє ресторан у системі доставки їжі
public class Restaurant
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string DeliveryTime { get; private set; } = string.Empty;
    public int MinOrder { get; private set; }
    public bool IsSelected { get; private set; }

    public Restaurant(string name, string deliveryTime, int minOrder)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Назва не може бути порожньою");
            
        Id = Guid.NewGuid();
        Name = name;
        DeliveryTime = deliveryTime;
        MinOrder = minOrder;
        IsSelected = false;
    }

    public void Select() => IsSelected = true;
    public void Deselect() => IsSelected = false;
}