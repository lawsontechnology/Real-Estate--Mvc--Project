using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Core.Domain.Entities
{
    public class Address : Auditable
    {
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public Profile Profile { get; set; } = default!;
    }
}