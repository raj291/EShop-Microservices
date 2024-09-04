using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Azure.Storage.Queues;

namespace OrderApi.MessagingService;

public class QueueService : IQueueService
{
    private readonly IConfiguration _configuration;

    public QueueService(IConfiguration  configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMessageAsync<T>(T message, string queueName)
    {
        var queueClient = new ServiceBusClient(_configuration.GetConnectionString("AzureServiceBus"));
        var sender = queueClient.CreateSender(queueName);
        //Send A Message Api
        string messagebody = JsonSerializer.Serialize(message);
        var messageData = new ServiceBusMessage(Encoding.UTF8.GetBytes(messagebody));
        await sender.SendMessageAsync(messageData);
    }
}  