using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IOrderService
    {
        void GenerateOrder(int userId);

        void PayOrder(int Id, int amount);
    }
}
