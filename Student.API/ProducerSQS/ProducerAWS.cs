using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;

namespace Student.API.ProducerSQS
{
    public class ProducerAWS
    {
        private readonly AmazonSQSClient _sqsClient;
        private readonly string _queueUrl;

        public ProducerAWS(IConfiguration configuration)
        {
            // Lê os valores do arquivo de configuração (appsettings.json)
            string awsAccessKeyId = configuration["AWS:AccessKeyId"];
            string awsSecretAccessKey = configuration["AWS:SecretAccessKey"];
            string awsRegion = configuration["AWS:Region"];
            string queueName = configuration["AWS:QueueName"];

            // Configuração do cliente SQS
            var sqsConfig = new AmazonSQSConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(awsRegion)
            };

            _sqsClient = new AmazonSQSClient(awsAccessKeyId, awsSecretAccessKey, sqsConfig);

            // Obtém a URL da fila pelo nome
            _queueUrl = GetQueueUrlByName(queueName).GetAwaiter().GetResult();
        }

        // Método para enviar a mensagem para a fila
        public async Task<string> SendMessageToSQS(string message)
        {
            try
            {
                var request = new SendMessageRequest
                {
                    QueueUrl = _queueUrl,
                    MessageBody = message
                };

                // Envia a mensagem para a fila SQS
                var response = await _sqsClient.SendMessageAsync(request);
                return response.MessageId;
            }
            catch (Exception ex)
            {
                // Trate a exceção aqui ou apenas lance-a novamente para ser tratada externamente
                throw;
            }
        }

        // Método auxiliar para obter a URL da fila pelo nome
        private async Task<string> GetQueueUrlByName(string queueName)
        {
            try
            {
                var request = new GetQueueUrlRequest
                {
                    QueueName = queueName
                };

                var response = await _sqsClient.GetQueueUrlAsync(request);
                return response.QueueUrl;
            }
            catch (Exception ex)
            {
                // Trate a exceção aqui ou apenas lance-a novamente para ser tratada externamente
                throw;
            }
        }
    }
}
