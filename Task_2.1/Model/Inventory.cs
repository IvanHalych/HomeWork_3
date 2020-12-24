using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1.Model
{
    public class Inventory
    {
        public string ProductId { get; }
        public string Location { get; }
        public int Balance { get; }
        public Inventory(string productId, string location, string balance)
        {
            ProductId = productId;
            Location = location;
            Balance = int.Parse(balance);
        }

        public override string ToString()
        {
            return $"ProductId: {ProductId}\t Location: {Location}\t Balance: {Balance}";
        }

        public override bool Equals(object obj)
        {
            return obj is Inventory inventory &&
                   ProductId == inventory.ProductId &&
                   Location == inventory.Location &&
                   Balance == inventory.Balance;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, Location, Balance);
        }
    }
}
