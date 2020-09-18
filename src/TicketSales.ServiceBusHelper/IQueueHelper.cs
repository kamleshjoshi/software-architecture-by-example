﻿using Microsoft.Azure.ServiceBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TicketSales.ServiceBusHelper
{
    public interface IQueueHelper
    {
        Task<string> AddNewMessage(string messageBody, string clientId, string correlationId = "");
        Task<string> GetMessageByCorrelationId(string correlationId, string clientFilter);
        Task<string> SendMessageAwaitReply(string messageBody);
        void Listen(
            Func<Message, CancellationToken, Task> onMessageReceived,
            bool autoComplete);
    }
}
