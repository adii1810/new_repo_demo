﻿using DataAccessLayer;
using Food_Delivery_Api.Data;
using Food_Delivery_Api.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
    public class CustomerMethod : ICustomerInterface
    {
        private readonly ApplicationDbContext _context;

        public CustomerMethod(ApplicationDbContext context)
        {
            _context = context;
        }

        public string AddCustomer(User_Data ud)
        {
            _context.User_Data.Add(ud);
            _context.SaveChanges();
            return "true";
        }
        public async Task<User_Data> LoginCustomer(string uname, string pass)
        {
            var data = await _context.User_Data.Where(x => x.User_UserName == uname && x.User_Password == pass).FirstOrDefaultAsync();
            return data;
        }
        public async Task<IEnumerable<ProductforCustomerViewModel>> ShowProduct(string tab)
        {
            List<Product> data = null;
            List<ProductforCustomerViewModel> lvm = new List<ProductforCustomerViewModel>();
            if (tab == "tab1")
            {
                data = _context.Product.Include("Sub_Category").Where(x => (int)x.Sub_Category.Main_Category_Id == 1).ToList();
            }
            else if (tab == "tab2")
            {
                data = _context.Product.Include("Sub_Category").Where(x => (int)x.Sub_Category.Main_Category_Id == 0).ToList();
            }
            else if (tab == "tab3")
            {
                data = _context.Product.Include("Sub_Category").Where(x => (int)x.Sub_Category.Main_Category_Id == 2).ToList();
            }
            else
            {
                data = _context.Product.Include("Sub_Category").ToList();
            }
            foreach (var item in data)
            {
                ProductforCustomerViewModel p = new ProductforCustomerViewModel();
                p.Description = item.Description;
                p.Product_Id = item.Product_Id;
                p.Product_Name = item.Product_Name;
                p.Product_Price = item.Product_Price;
                p.Product_Status = item.Product_Status;
                var link = await _context.ProductImages.Where(x => x.ProductId == item.Product_Id).Take(1).Select(x => x.ImgLink).FirstOrDefaultAsync();
                p.ImgLink = link;
                lvm.Add(p);
            }
            return lvm;
        }

        //Addin product to temp order
        public string AddProductCart(CartProductViewModel vm)
        {
            var countData = _context.tempOrder_Detail.Include("Order").Where(x => x.OrderId == x.Order.Order_Id && x.Order.User_DataId == vm.User_DataId && x.ProductId == vm.ProductId).Count();
            if (countData == 0)
            {
                /* Adding procduct to tempOrder*/
                tempOrder TO = new tempOrder();
                TO.Order_Date = vm.Order_Date;
                TO.User_DataId = vm.User_DataId;
                _context.tempOrder.Add(TO);
                _context.SaveChanges();

                /* fetching current orderId*/
                var orderId = _context.tempOrder.OrderByDescending(x => x.Order_Id).Take(1).Select(x => x.Order_Id).FirstOrDefault();

                /* Adding procduct to tempOrderDetail*/
                tempOrderDetails TOD = new tempOrderDetails();
                TOD.OrderId = orderId;
                TOD.ProductId = vm.ProductId;
                TOD.Quantity = vm.Quantity;
                _context.tempOrder_Detail.Add(TOD);
                _context.SaveChanges();
            }
            else
            {
                var data = _context.tempOrder_Detail.Include("Order").Where(x => x.Order.User_DataId == vm.User_DataId && x.ProductId == vm.ProductId).FirstOrDefault();
                data.Quantity += 1;
                _context.Update(data);
                _context.SaveChanges();
            }
            return "true";
        }

        public IEnumerable<CartProductViewModel> ViewProductCart(int userId)
        {
            var data = _context.tempOrder.Where(x => x.User_DataId == userId).ToList();
            List<CartProductViewModel> lvm = new List<CartProductViewModel>();
            foreach (var item in data)
            {
                CartProductViewModel cvm = new CartProductViewModel();
                cvm.Order_Date = item.Order_Date;
                var orderDetail = _context.tempOrder_Detail.Where(x => x.OrderId == item.Order_Id).FirstOrDefault();
                var productDetails = _context.Product.Where(x => x.Product_Id == orderDetail.ProductId).FirstOrDefault();
                var ImgLink = _context.ProductImages.Where(x => x.ProductId == productDetails.Product_Id).Select(x => x.ImgLink).FirstOrDefault();
                cvm.ProductId = orderDetail.ProductId;
                cvm.Quantity = orderDetail.Quantity;
                cvm.ProductName = productDetails.Product_Name;
                cvm.Price = productDetails.Product_Price;
                cvm.ImgLink = ImgLink;
                lvm.Add(cvm);
            }
            return lvm;
        }

        public string deleteProduct(int ProdId, int userId)
        {
            var data = _context.tempOrder_Detail.Include("Order").Where(x => x.Order.User_DataId == userId && x.OrderId == x.Order.Order_Id && x.ProductId == ProdId).FirstOrDefault();
            var dataOrder = _context.tempOrder.Where(x => x.Order_Id == data.OrderId).FirstOrDefault();
            _context.tempOrder_Detail.Remove(data);
            _context.tempOrder.Remove(dataOrder);
            _context.SaveChanges();
            return "true";
        }
        public string IncrementDecrement(string status, int prodId, int userId)
        {
            var data = _context.tempOrder_Detail.Include("Order").Where(x => x.Order.User_DataId == userId && x.OrderId == x.Order.Order_Id && x.ProductId == prodId).FirstOrDefault();
            if (status == "plus")
                data.Quantity = data.Quantity + 1;
            else if (status == "minus")
                if (data.Quantity > 1)
                    data.Quantity = data.Quantity - 1;

            _context.tempOrder_Detail.Update(data);
            _context.SaveChanges();
            return "true";
        }
        public string CheckOut(int userId)
        {
            var tempOrders = _context.tempOrder.Where(x => x.User_DataId == userId).ToList();
            Order od = new Order();
            od.Order_Date = DateTime.Now;
            od.User_DataId = userId;
            od.Order_Status_Id = 0;
            _context.Order.Add(od);
            _context.SaveChanges();

            // Get current Order Id
            var orderId = _context.Order.OrderByDescending(x => x.Order_Id).Take(1).Select(x => x.Order_Id).FirstOrDefault();
            //=========================================
            var detailId = 1;
            foreach (var item in tempOrders)
            {
                var data = _context.tempOrder_Detail.Where(x => x.OrderId == item.Order_Id).FirstOrDefault();
                Order_Detail ordDetail = new Order_Detail();
                ordDetail.OrderId = orderId;
                ordDetail.Order_Detail_Id = detailId;
                ordDetail.ProductId = data.ProductId;
                ordDetail.Quantity = data.Quantity;
                detailId++;

                _context.Order_Detail.Add(ordDetail);
                _context.tempOrder_Detail.Remove(data);
                _context.tempOrder.Remove(item);
                _context.SaveChanges();
            }
            return "true";
        }

        public IEnumerable<ShowOrderViewModel> ShowOrder(int userId)
        {
            List<ShowOrderViewModel> lvm = new List<ShowOrderViewModel>();
            var data = _context.Order.Where(x=>x.User_DataId == userId).OrderByDescending(x=>x.Order_Date).ToList();
            foreach (var item in data)
            {
                ShowOrderViewModel vm = new ShowOrderViewModel();
                vm.OrderDate = item.Order_Date.ToString("D");
                vm.OrderId = item.Order_Id;
                vm.OrderStatus = (int)item.Order_Status_Id;
                var amt = _context.Order_Detail.Where(x => x.OrderId == item.Order_Id).Sum(x => x.Product.Product_Price * x.Quantity);
                vm.TotalPrice = amt;
                lvm.Add(vm);
            }
            return lvm;
        }

        public IEnumerable<CartProductViewModel> ShowOrderDetail(int userId,int ordId)
        {
            var orderData = _context.Order.Where(x => x.User_DataId == userId && x.Order_Id == ordId).FirstOrDefault();
            List<CartProductViewModel> lvm = new List<CartProductViewModel>();
            var data = _context.Order_Detail.Where(x => x.OrderId == ordId).ToList();
            foreach (var item in data)
            {
                CartProductViewModel cvm = new CartProductViewModel();
                cvm.Order_Date = orderData.Order_Date;
               
                var productDetails = _context.Product.Where(x => x.Product_Id == item.ProductId).FirstOrDefault();
                var ImgLink = _context.ProductImages.Where(x => x.ProductId == productDetails.Product_Id).Select(x => x.ImgLink).FirstOrDefault();
                cvm.ProductId = item.ProductId;
                cvm.Quantity = item.Quantity;
                cvm.ProductName = productDetails.Product_Name;
                cvm.Price = productDetails.Product_Price;
                cvm.ImgLink = ImgLink;
                lvm.Add(cvm);
            }
            return lvm;
        }

        
    }
}
