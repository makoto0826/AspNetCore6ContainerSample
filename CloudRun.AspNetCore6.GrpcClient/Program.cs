using Grpc.Net.Client;
using CloudRun.AspNetCore6.GrpcServer;

//Cloud RunのURLを設定
var address = "";

using var channel = GrpcChannel.ForAddress(address);
var client = new Greeter.GreeterClient(channel);

var name = Console.ReadLine();
var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
Console.WriteLine("Greeting: " + reply.Message);
