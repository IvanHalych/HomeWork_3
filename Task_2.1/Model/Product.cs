using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1.Model
{
    public class Product
    {
        public string Id { get; }
        public string Brand { get; }
        public string Model { get; }
        public string Price { get; }
        public Product(string id, string brand, string   model, string price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Price = price;
        }

        public override string ToString()
        {
            return $"Id: {Id}\t Brand: {Brand}\t Model: {Model}\t Price: {Price}";
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id == product.Id &&
                   Brand == product.Brand &&
                   Model == product.Model &&
                   Price == product.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Brand, Model, Price);
        }
    }
}
