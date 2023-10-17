using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//Bağlantı Oluşturma 


ConnectionFactory factory = new();
factory.Uri = new("amqps://wjeoqwrv:CWXM4V0Vt0-6NSwNq_35VRdCRJHiNS1u@crow.rmq.cloudamqp.com/wjeoqwrv");

//Bağlantı Aktifleştirme ve Kanal Açma 
using IConnection conneciton = factory.CreateConnection(); 
using IModel channel = conneciton.CreateModel();


// Queue Oluşturma : Publisher da ne varsa burda da aynı olmalı
channel.QueueDeclare(queue: "Example-Queue", exclusive: false);


//Queue'dan Mesaj Okuma 
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "Example-Queue",false,consumer);
/*Burda ne yapmış olduk ne zamanki "Example-Queue" kuyruğuna mesaj gelir bilader sen bunu consume et*/
consumer.Received += (sender
    , e) =>
{
    //Kuyruğa gelen mesajın işlendiği yerdir!!!
    //e.Body : Kuyruktaki mesajın verisini bütünsel olarak getirecektir.
    //e.Body.Span veya e.Body.ToArray(); : Kuyruktaki mesajın byte verisini getirecektir.
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));//Elimizdeki byte dizisini stringe dönüştürüp ekrana yazdır gardaşş
};