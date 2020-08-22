using OrderProcessingMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessingMicroservice.DataAccess
{
    public interface IDataAccessOrder
    {
        Task<Order> GetOrderByID(int id);
        Task<List<Order>> GetAllOrders();
        Task<bool> Add(Order orderRequest);
        Task<bool> Update(Order orderRequest);
        Task<bool> Delete(int orderId);

    }
    public class DataAccessOrder : IDataAccessOrder
    {
        //TOOD: create object for Database connection string

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderByID(int id)
        {

            //TODO : Filter record by id and return 

            Order orderDetials = new Order();

            return orderDetials;
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAllOrders()
        {

            //TODO : returns all orders from backend 

            List<Order> ordersDetials = new List<Order>();

            return ordersDetials;
        }
        /// <summary>
        /// save order after processed 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Add(Order orderReuqest)
        {

            //TODO : save order into database after processed. 

            return true;
        }

        /// <summary>
        /// Update order after processed 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Update(Order orderReuqest)
        {

            //TODO : update order into database after changes. 

            return true;
        }
        /// <summary>
        /// Delete specific order by id 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Delete(int orderId)
        {

            //TODO : Delete order into database after changes. 

            return true;
        }

    }
}
