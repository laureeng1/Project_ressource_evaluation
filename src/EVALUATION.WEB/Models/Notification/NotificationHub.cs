using System.Collections.Generic;
using EVALUATION.CORE.Dto;
using Microsoft.AspNet.SignalR;

namespace EVALUATION.WEB.Models.Notification
{
    public class NotificationHub : Hub
    {
      

        //public static void SendPendingMessages(List<NotificationDto> action)
        //{
        //    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
        //    context.Clients.All.getUserNotification(action);
        //    // Get pending messages for user and send it
        //    //var meesages = DataAccess.GetPendingMessages(userName);
        //    //Clients.User(userName).processPendingMessages(messages);
        //}
    }
}