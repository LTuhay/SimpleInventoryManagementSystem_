

namespace SimpleInventoryManagementSystem.ProductManagement
{
    public class Product
    {

        public int Id    { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; private set; }

        public Product(int id, string name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public virtual void IncreaseQuantity (int quantityToIncrease)
        {
            Quantity += quantityToIncrease;
        }

        public void DecreaseQuantity(int quantityToDecrease)
        {
            if (quantityToDecrease < Quantity)
            {
                Quantity = Quantity - quantityToDecrease;
            }
            else
            {
                Console.WriteLine($"Not enough items on stock. {Quantity} available but {quantityToDecrease} requested.");
            }

        }

        public void PrintProduct()
        {

            Console.WriteLine($"Id: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}");
        }


    }
}
