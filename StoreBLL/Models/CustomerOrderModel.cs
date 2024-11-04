using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBLL.Models
{
    public class CustomerOrderModel : AbstractModel
    {
        public CustomerOrderModel(int id, string operationTime, int userId, int orderStateId)
    : base(id)
        {
            this.Id = id;
            this.OperationTime = operationTime;
            this.UserId = userId;
            this.OrderStateId = orderStateId;
        }

        public string OperationTime { get; set; }

        public int UserId { get; set; }

        public int OrderStateId { get; set; }

        public override string ToString()
        {
            return $"Id:{this.Id}, {this.OperationTime}, {this.UserId} ,{this.OrderStateId}";
        }
    }
}
