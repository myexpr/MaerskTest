using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessRule
{
    public interface IProduct
    {
        int ID { get; set; }

        string Name { get; set; }

        decimal Price { get; set; }

        void ExecuteOrder();
    }
}
