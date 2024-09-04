namespace OrderApi.MessagingService;

public interface IQueueService
{
    Task SendMessageAsync<T>(T message, string queueName);
}