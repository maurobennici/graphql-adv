using repository.Models;
using System.ComponentModel.DataAnnotations;

namespace graph.Mutations
{
    public partial class addressMutation
    {
        public Task<address> AddAddress(address address)
        {
            return Task.FromResult(new address());
        }

        public Task<address> AddAddress2(string city, string street)
        {
            return Task.FromResult(new address() { addressline1 = new string(street.Reverse().ToArray()) });
        }

        public Task<address> AddAddress3(string city, string street)
        {
            return Task.FromResult(new address() { addressline1 = new string(street.Reverse().ToArray()) });
        }

        public Task<address> AddAddress4(AddressInputModel input)
        {
            return Task.FromResult(new address() { addressline1 = new string(input.Street.Reverse().ToArray()) });
        }
    }

    public class AddressInputModel
    {
        [GraphQLDescription("This is a city!")]
        public string? City { get; set; }

        public required string Street { get; set; }
    }
}
