using DataAccessLayer;
using Food_Delivery_Api.ViewModel;
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
        public string ApproveOrder(int OrdId, int valId);
        public IEnumerable<OrderViewForValet> ApprovedOrders(int valId);
        public IEnumerable<OrderDetailForValet> ShowOrderDetails(int OrdId);
        public string ChangeStatus(int OrdId, int status);
        public int ValetConfirmPassword(string username, string password);
        public string ChangePassword(string username, string password);

    }
}
