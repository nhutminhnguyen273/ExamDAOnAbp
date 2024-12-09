using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ExamDAOnAbp.DataWarehouse
{
    public class DataWarehouseHub : Hub
    {
        // Phương thức này cho phép client nhận thông báo khi dữ liệu đã được đồng bộ
        public async Task SendDataSyncedNotification(string message)
        {
            // Gửi thông báo tới tất cả các client đang kết nối
            await Clients.All.SendAsync("DataSynced", message);
        }
    }
}
