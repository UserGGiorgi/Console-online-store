namespace StoreBLL.Models
{
    public class OrderDetailModel : AbstractModel
    {
        public OrderDetailModel(int id, int orderId, int productId, decimal price, int amount)
    : base(id)
        {
            this.Id = id;
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Price = price;
            this.Amount = amount;
        }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public override string ToString()
        {
            return $"Id:{this.Id}, {this.OrderId}, {this.ProductId}, {this.Price}, {this.Amount}";
        }
    }
}
