using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using Student.Application.Dtos;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Student.ConsumerAWS.ConsumerSQS
{
    public class ConsumerAmazonWS
    {
        private readonly AmazonSQSClient _sqsClient;
        private readonly string? _queueUrl;

        public ConsumerAmazonWS(string awsAccessKeyId, string awsSecretAccessKey, string awsRegion, string queueName)
        {
            // Configuração do cliente SQS
            var sqsConfig = new AmazonSQSConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(awsRegion)
            };

            _sqsClient = new AmazonSQSClient(awsAccessKeyId, awsSecretAccessKey, sqsConfig);

            // Obtém a URL da fila pelo nome
            _queueUrl = GetQueueUrlByName(queueName).GetAwaiter().GetResult();
        }

        public async Task StartListening(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var request = new ReceiveMessageRequest
                    {
                        QueueUrl = _queueUrl,
                        MaxNumberOfMessages = 10, // Número máximo de mensagens a serem recebidas de uma vez
                        WaitTimeSeconds = 20 // Tempo de espera (em segundos) para receber novas mensagens
                    };

                    var response = await _sqsClient.ReceiveMessageAsync(request, cancellationToken);

                    if (response.Messages.Count > 0)
                    {
                        foreach (var message in response.Messages)
                        {
                            // Processar a mensagem recebida aqui
                            Console.WriteLine($"Mensagem Recebida: {message.Body}");

                            await SendHttpRequest(message.Body);
                            // Deletar a mensagem da fila após processamento
                            await DeleteMessageFromQueue(message.ReceiptHandle, cancellationToken);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Trate a exceção aqui ou apenas lance-a novamente para ser tratada externamente
                    Console.WriteLine($"Erro ao receber mensagens da fila SQS: {ex.Message}");
                }
            }
        }

        private static async Task SendHttpRequest(string message)
        {
            string? _apiBase = ConfigurationManager.AppSettings["ApiBase"];
            string? apiUrl = _apiBase + "/UpdateStudentCouse";
            
            using HttpClient? client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = JsonConvert.DeserializeObject<StudentCourseDto>(message);

            StudentCourseDto studentCourseDto = new StudentCourseDto
            {
                StudentenId = content.StudentenId,
                StudentCourseId = content.StudentCourseId,
                Course = content.Course,
                CourseId = content.CourseId,
                Created = content.Created,
                Status = content.Status,
                Studenten = content.Studenten,
                Updated = content.Updated
            };

            var response = await client.PutAsJsonAsync(apiUrl, studentCourseDto);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Chamada Http realizada com Sucesso.");
            }
            else
            {
                Console.WriteLine($"Falha na messagem: {response.StatusCode}");
            }
        }

        private async Task DeleteMessageFromQueue(string receiptHandle, CancellationToken cancellationToken)
        {
            try
            {
                var request = new DeleteMessageRequest
                {
                    QueueUrl = _queueUrl,
                    ReceiptHandle = receiptHandle
                };

                await _sqsClient.DeleteMessageAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar mensagem da fila SQS: {ex.Message}");
            }
        }

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
                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
