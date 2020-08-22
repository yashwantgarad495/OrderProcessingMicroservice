using OrderProcessingMicroservice.BusinessRules;
using OrderProcessingMicroservice.DataAccess;
using OrderProcessingMicroservice.Models;
using OrderProcessingMicroservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessingMicroservice.Repositories
{
    public interface IProcessOrderRepository
    {
        Task<Order> GetOrderByID(int id);
        Task<List<Order>> GetAllOrders();
        Task<bool> Add(Order orderRequest);
        Task<bool> Update(Order orderRequest);
        Task<bool> Delete(int orderId);

    }

    public class ProcessOrderRepository : BaseRepository, IProcessOrderRepository
    {

        private IDataAccessOrder _orderProcessingDal;

        public ProcessOrderRepository(IDataAccessOrder orderDataAccess)
        {
            _orderProcessingDal = orderDataAccess;
        }


        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderByID(int id)
        {

            Order orderDetials = await _orderProcessingDal.GetOrderByID(id);
            try
            {
                //TODO : Filter record by id and return 
                return orderDetials;

            }
            catch (Exception ex)
            {
                //TODO: log the exceptions
                return null;
            }

        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAllOrders()
        {

            //TODO : returns all orders from backend 

            List<Order> ordersDetials = await _orderProcessingDal.GetAllOrders();

            return ordersDetials;
        }
        /// <summary>
        /// save order after processed 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Add(Order orderReuqest)
        {

            //TODO : perform DB and payment opearation. 
           bool isAdded= await _orderProcessingDal.Add(orderReuqest);
            //apply business rule after payment processed
            if (isAdded)
            {
                bool IsBusinessRuleApplied = await ApplyBusineesRule(orderReuqest);
            }
            return isAdded;
        }

        /// <summary>
        /// Update order after processed 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Update(Order orderReuqest)
        {

            //TODO : update order into database after changes. 
            bool isUpdated = await _orderProcessingDal.Update(orderReuqest);
            return isUpdated;
        }
        /// <summary>
        /// Delete specific order by id 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Delete(int orderId)
        {

            //TODO : Delete order into database after changes. 
            bool isDeleted = await _orderProcessingDal.Delete(orderId);

            return isDeleted;
        }
        private async Task<bool> ApplyBusineesRule(Order orderRequest)
        {
            bool bussinesRuleStatus = false;

            switch (orderRequest.PaymentType)
            {
                case BusinessRule.BOOK:
                    GeneratePackingSlip(orderRequest);
                    bool isBookCommisionPaid = await ComissionPaymentToAgent(orderRequest);
                    break;
                case BusinessRule.PRODUCT:
                    GeneratePackingSlip(orderRequest);
                    bool isProductCommisionPaid = await ComissionPaymentToAgent(orderRequest);

                    break;
                case BusinessRule.MEMBERSHIP:
                    AddMembership(orderRequest);
                    break;
                case BusinessRule.MEMBERSHIPUPGRADE:
                    UpgradeMembership(orderRequest);
                    break;
                case BusinessRule.SKI:
                    // code block
                    break;
                default:
                    // code block
                    break;
            }
            return true;
        }

        private async Task<bool> GeneratePackingSlip(Order orderRequest)
        {
            //TODO: Get requried info from backend from orderRequest to genarate packing slip 
            OrderViewModel orderdetials; //assign data from backend 

            //Perform requried opration to genreate slip

            if (orderRequest.PaymentType == BusinessRule.BOOK)
            {

                //TOOD:send duplicate copy to Royalty department
            }

            if (orderRequest.PaymentType == BusinessRule.SKI)
            {

                //TOOD: Add vedio link
            }
            return true;


        }
        private async Task<bool> AddMembership(Order orderRequest)
        {

           

            return true;
        }
        private async Task<bool> UpgradeMembership(Order orderRequest)
        {

           
            return true;
        }
        private async Task<bool> ComissionPaymentToAgent(Order orderRequest)
        {
            if (orderRequest.PaymentType == BusinessRule.BOOK)
            {
                //calculate and Make payment for commision to Agent for book 

            }
            if (orderRequest.PaymentType == BusinessRule.PRODUCT)
            {
                //calculate and Make payment for commision to Agent for Product 

            }
            return true;

        }
    }
}
