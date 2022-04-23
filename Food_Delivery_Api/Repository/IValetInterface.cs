using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
    public interface IValetInterface
    {
        public Valet ValetLogin(string user, string pass);
        public string ValetReg(Valet val);
        public IEnumerable<OrderViewForValet> ShowOrder();
    }
}
