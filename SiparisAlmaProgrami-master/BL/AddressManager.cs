using Entities;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class AddressManager : Repository<Address>
    {
        public IEnumerable<Address> GetAddressByCustomers()
        {
            return _objectSet.Include("Customer").ToList(); // Adreslerin içerisine ona bağlı Müşteriyi dahil eder. Linq Include metodu sql deki Join ile tablo birleştirme işlemini yapar
        }
    }
}
