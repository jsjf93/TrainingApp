using System;
using System.ComponentModel.DataAnnotations;

namespace Train.Domain.Models
{
    public class Order : ValueObject<Order>
    {
        [Range(0, int.MaxValue, ErrorMessage = "Order value must be a non-negative number")]
        public int Value { get; set; }

        public Order(int value)
        {
            this.Value = value;
        }

        protected override bool EqualsCore(Order other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
