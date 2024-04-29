using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInventoryManagementSystem.ProductManagement
{
    public class Product
    {
        private int id;
        private string name;
        private double price;
        private int quantity;

        public int Id    { get { return id; } set { id = value; } }
        public string Name { get { return name; } set {  name = value; } }

        public double Price { get; set; }

        public int Quantity { get; private set; }

        public Product(int Id, string Name, double Price)
        {
            this.id = Id;
            this.name = Name;
            this.Price = Price;
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
