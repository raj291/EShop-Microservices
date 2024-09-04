using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http.HttpResults;
using SharedServiceMessage;

namespace NotificationApi.MessagingQueue;

public class QueueService
{
    private readonly IConfiguration _configuration;

    public QueueService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Orderdetails> ReadMsgAsync(string queueName)
    {
        var queueClient = new ServiceBusClient(_configuration.GetConnectionString("AzureServiceBus"));
        var receiver = queueClient.CreateReceiver(queueName);
        var message = await receiver.ReceiveMessageAsync();
        var encodedmesge = Encoding.UTF8.GetString(message.Body);
        var od = JsonSerializer.Deserialize<Orderdetails>(encodedmesge);
        return od;

    }
}