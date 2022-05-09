//using My_Project.Areas.Client.ViewModels;
using My_Project.Areas.Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Hubs
{
   public interface IStatusInterface
    {
       // Task StatusUpdated(List<Areas.Client.ViewModels.ShowOrderViewModel> ovm);
        Task StatusUpdateProductApproveByRestaurant(int Ordid,int status = 1);
        Task StatusUpdateProductApproveByValet(int Ordid,int status = 2);
        Task StatusUpdateByValet(int Ordid,int status);
        Task ShowCurrentOrders(List<ShowOrderViewModel> ovm);
    }
}
