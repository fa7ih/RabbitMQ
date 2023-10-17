using RabbitMQ.Client;
using System.Text;

//Bağlantı Oluşturma
ConnectionFactory factory = new();
factory.Uri = new("amqps://wjeoqwrv:CWXM4V0Vt0-6NSwNq_35VRdCRJHiNS1u@crow.rmq.cloudamqp.com/wjeoqwrv");

//Bağlantıyı Aktifleştirme ve Kanal Açma 
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue Oluşturma 
channel.QueueDeclare(queue: "Example-Queue",exclusive: false);
/*Eğer bir kuyruk exclusive yapıya uygun oluşturuluyorsa daha sonra o kuyruk imha edilir.*/

//Queue'ya mesaj gönderme
/*RabbitMQ kuyruğa atacağı mesajları byte türünden abul etmektedir. Haliyle mesajları bizim byte dönüştürmemiz gerekmektedir.*/

byte[] message = Encoding.UTF8.GetBytes("Mesaj");
channel.BasicPublish(exchange: "", routingKey: "Example-Queue", body: message);

Console.Read();
