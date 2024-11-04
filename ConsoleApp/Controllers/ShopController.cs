using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Controllers;
using ConsoleApp.Handlers.ContextMenuHandlers;
using ConsoleApp.Helpers;
using ConsoleApp1;
using ConsoleMenu;
using StoreBLL.Models;
using StoreBLL.Services;
using StoreDAL.Data;

namespace ConsoleApp.Services
{
    public enum OrderStates
    {
        Pending,
        Processed,
        Shipped,
        Delivered,
        Canceled,
    }

    public static class ShopController
    {
        private static StoreDbContext context = UserMenuController.Context;

        public static void AddOrder()
        {
            throw new NotImplementedException();
        }

        public static void UpdateOrder()
        {
            Console.Write("Enter the Order ID to add feedback: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid Order ID. Please enter a valid number.");
                return;
            }

            Console.Write("Enter your feedback: ");
            var feedback = Console.ReadLine();
            ArgumentNullException.ThrowIfNull(feedback);

            string logEntry = $"Order ID: {orderId}, Feedback: {feedback}, Date: {DateTime.Now}";
            string filePath = "OrderFeedbackLog.txt";

            try
            {
                File.AppendAllText(filePath, logEntry + Environment.NewLine);
                Console.WriteLine("Feedback recorded successfully (stored in a log file).");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error while saving feedback: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        public static void DeleteOrder()
        {
            var service = new OrderDetailService(context);
            Console.WriteLine("Input OrderId To Cancel Order");
            var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
            service.Delete(id);
            Console.WriteLine("Your order has been deleted");
        }

        public static void ShowOrder()
        {
            throw new NotImplementedException();
        }

        public static void ShowAllOrders()
        {
            var service = new OrderDetailService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadOrderDetailModel), service.GetAll);
            menu.Run();
        }

        public static void AddOrderDetails()
        {
            var service = new CustomerOrderService(context);
            Console.WriteLine("Input state order detail id");
            var id = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
            Console.WriteLine("Input stateId");
            var stateId = int.Parse(Console.ReadLine() !, CultureInfo.InvariantCulture);
            service.Update(new CustomerOrderModel(id, DateTime.Now.ToString(CultureInfo.InvariantCulture), 1, stateId));
            Console.WriteLine("Your order status has been updated.");
        }

        public static void UpdateOrderDetails()
        {
            throw new NotImplementedException();
        }

        public static void DeleteOrderDetails()
        {
            throw new NotImplementedException();
        }

        public static void ShowAllOrderDetails()
        {
            throw new NotImplementedException();
        }

        public static void ProcessOrder()
        {
            throw new NotImplementedException();
        }

        public static void ShowAllOrderStates()
        {
            var service = new OrderStateService(context);
            var menu = new ContextMenu(new AdminContextMenuHandler(service, InputHelper.ReadOrderStateModel), service.GetAll);
            menu.Run();
        }
    }
}
