using System;
using System.Text;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
namespace ActiveMQConsume02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string clientid = GenerateRandom(8);
            InitConsumer();


            Console.ReadLine();
        }
        public static void InitConsumer()
        {

            //创建连接工厂
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            //通过工厂构建连接
            IConnection connection = factory.CreateConnection();
            //这个是连接的客户端名称标识
            connection.ClientId = "002";
            //启动连接，监听的话要主动启动连接
            connection.Start();
            //通过连接创建一个会话
            ISession session = connection.CreateSession();
            //通过会话创建一个消费者，这里就是Queue这种会话类型的监听参数设置
            IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue?consumer.prefetchSize=1"), "filter='demo'");
            //注册监听事件
            consumer.Listener += (IMessage mesage) =>
            {
                ITextMessage msg = (ITextMessage)mesage;
                Console.WriteLine(002 + "接收消息:" + msg.Text);
            };




        }

        private static char[] constant = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

        public static string GenerateRandom(int Length)
        {
            StringBuilder newRandom = new StringBuilder();
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(8)]);
            }
            return newRandom.ToString();

        }

    }
}
