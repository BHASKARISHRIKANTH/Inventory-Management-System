using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Exceptions
{
    internal class InvalidProductIdException:Exception
    {
        public InvalidProductIdException(string message):base(message) { }
    }
}
