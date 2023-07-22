using Student.ConsumerAWS.ConsumerSQS;
using System.Configuration;

namespace Student.ConsumerAWS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Configurações da AWS
            string awsAccessKeyId = ConfigurationManager.AppSettings["AWSAccessKeyId"];
            string awsSecretAccessKey = ConfigurationManager.AppSettings["AWSSecretAccessKey"];
            string awsRegion = ConfigurationManager.AppSettings["AWSRegion"];
            string queueName = ConfigurationManager.AppSettings["QueueName"];


            // Criação do ConsumerAWS
            var consumer = new ConsumerAmazonWS(awsAccessKeyId, awsSecretAccessKey, awsRegion, queueName);

            // Token de cancelamento para parar o consumo
            using var cancellationTokenSource = new CancellationTokenSource();

            // Iniciar o consumo de mensagens em um loop infinito com intervalo de 10 segundos
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                await consumer.StartListening(cancellationTokenSource.Token);
                await Task.Delay(TimeSpan.FromSeconds(10), cancellationTokenSource.Token);
            }
        }
    }
}
