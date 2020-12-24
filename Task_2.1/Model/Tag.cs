using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1.Model
{
    public class Tag
    {
        public string ProductId { get; }
        public string Value { get; }

        public Tag(string productId, string value)
        {
            ProductId = productId;
            Value = value;
        }
        public override string ToString()
        {
            return $"ProductId: {ProductId}\t Value: {Value}";
        }

        public override bool Equals(object obj)
        {
            return obj is Tag tag &&
                   ProductId == tag.ProductId &&
                   Value == tag.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, Value);
        }
    }
}
