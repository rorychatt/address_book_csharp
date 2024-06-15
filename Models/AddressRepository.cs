namespace address_book_csharp.Models
{
    public class AddressRepository
    {
        private static readonly List<Address> _addresses = [];
        private static int _nextId = 1;

        public List<Address> GetAll() => _addresses;

        public Address GetByID(int id) => _addresses.First(a => a.Id == id);

        public void Add(Address address)
        {
            address.Id = _nextId++;
            _addresses.Add(address);
        }

        public void Update(Address address)
        {
            var existingAddress = GetByID(address.Id);
            if (existingAddress != null)
            {
                existingAddress.Name = address.Name;
                existingAddress.Street = address.Street;
                existingAddress.City = address.City;
                existingAddress.State = address.State;
                existingAddress.Zip = address.Zip;
            }
        }

        public void Delete(int id)
        {
            var address = GetByID(id);
            if (address != null)
            {
                _addresses.Remove(address);
            }
        }
    }
}