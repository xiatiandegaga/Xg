using Cloud.Parking.KeTuo.Model;
using Cloud.Snowflake;
using Cloud.Utilities.Json;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SnowflakeTest
{
    public class SnowflakeTest
    {
        private static HashSet<long> set = new HashSet<long>();
        private static ConcurrentQueue<int> queue = new();
        private static readonly object o = new object();

        //[Fact]
        public void TestSpan()
        {
            var name = "王梓恒男";
            var name1 = "王梓男";
            var name2 = "王男";
            var spanName = HandleString(name);
            var spanName1 = HandleString(name1);
            var spanName2 = HandleString(name2);
        }
        public string HandleString(string name)
        {
            if (name.Length < 3)
                return name;
            var spanLastName = name.AsSpan(name.Length - 1, 1);
            var lastName = spanLastName.ToString();
            if (lastName == "男" || lastName == "女")
            {
                return name.AsSpan(0, name.Length - 1).ToString();
            }
            return name;
        }

        [Fact]
        public void GetIds()
        {
            var instance = new SnowflakeIdWorker(1, 1);
            var instance1 = SeataSnowflakeIdWorker.Default() ;

            var id = new SnowflakeIdWorker(1, 1).NextId();
            var qw = id.ToString().Length;

            var id1 = new SnowflakeIdWorker(10, 10).NextId();
            var qw1 = id1.ToString().Length;

            var id2 = new SnowflakeIdWorker(20, 20).NextId();
            var qw2 = id2.ToString().Length;

            var id3 = new SnowflakeIdWorker(31, 0).NextId();
            var qw3 = id3.ToString().Length;

            var id4 = new SnowflakeIdWorker(0, 31).NextId();
            var qw4 = id4.ToString().Length;
            foreach (var i in Enumerable.Range(0, 10))
            {
                Task.Run(() =>
                {
                    foreach (var index in Enumerable.Range(0, 9))
                    {
                        var id = instance1.NextId();
                        Console.WriteLine($"{id}");

                        lock (o)
                        {
                            if (set.Contains(id))
                            {
                                Assert.False(false);
                            }
                            else
                            {
                                set.Add(id);
                            }
                        }
                    }
                });
            }
        }

        public void TestThread()
        {
            Thread thread = new Thread(MultithreadGetIds);
            var x = thread.IsBackground;
            thread.Start();
        }

        //[Fact]

        public async Task SendAsync()
        {
      
            string v1 = "1";
            await SendEmail();
            string v2 = "1";
        }
        //[Fact]
        public void MultithreadGetIds()
        {
            foreach (var i in Enumerable.Range(0, 31))
            {
                queue.Enqueue(i);
            }
            foreach (var i in Enumerable.Range(0, 31))
            {
                var dataId = 0;
                queue.TryDequeue(out dataId);
            }
        }

        //[Fact]
        public void TestSurplus()
        {
            List<int> listNum = new();
            List<int> newListNum = new();
            foreach (var i in Enumerable.Range(1, 100))
            {
                listNum.Add(i);
            }
            listNum.AsParallel().ForAll(x =>
            {

            });
            foreach (var i in listNum)
            {
                newListNum.Add(i);
                if (newListNum.Count % 3 == 0)
                {
                    newListNum.Clear();
                }
            }
        }
        //[Fact]
        public void TestJsonDynamic()
        {
            JsonNode jNode = JsonNode.Parse(@"{""MyProperty"":42}");
            int value = (int)jNode["MyProperty"];
            Debug.Assert(value == 42);

            value = jNode["MyProperty"].GetValue<int>();
            Debug.Assert(value == 42);

            var complexObj = new
            {
                Name = "Mike",
                Users = new[]
    {
        new {Name = "Alice", Age = 6},
        new {Name = "Anna", Age = 8}
    }
            };
            var jsonString = JsonSerializer.Serialize(complexObj);

            var jsonNode = JsonNode.Parse(jsonString);
            jsonNode?["Users"]?.AsArray().Select(item => $"--{item["Name"]}, {item["Age"]}");
            var test = $"{jsonString}222po";
        }

        //[Fact]
        public void Deser()
        {
            var data = "{\"resCode\":\"0\",\"resMsg\":\"成功\",\"data\":\"{\"carStyle\":\"0\"}\"} ";
            var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponse<string>>(data);

        }
        //[Fact]
        public async Task  SendEmail()
        {
            try
            {
                string fromAddress = "service@ihall.com.cn";
            string toAddress = "2013808429@qq.com";
            string fromToken = "JtNkN7GcQ5ahbjDK1";
            MimeMessage message = new MimeMessage();
            //发件人
            message.From.Add(new MailboxAddress(fromAddress, fromAddress));
            var listAddress = new InternetAddressList();
            //收件人
            string toAdressArray;
            toAdressArray = toAddress;
            foreach (var address in toAdressArray.Split(','))
            {
                listAddress.Add(new MailboxAddress(address, address));
            }
            message.To.AddRange(listAddress);
            //标题
            message.Subject = "111";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "2222";
            message.Body = bodyBuilder.ToMessageBody();
            using var client = new SmtpClient
            {
                ServerCertificateValidationCallback = (s, c, h, e) => true,
                CheckCertificateRevocation = false
            };
            await client.ConnectAsync("smtp.exmail.qq.com", 465, SecureSocketOptions.Auto);
            await client.AuthenticateAsync(fromAddress, fromToken);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
               
            }
        }

    }
    public class ParkingPaymentInfoResponse1
    {
        public string carStyle { get; set; }
    }

}

