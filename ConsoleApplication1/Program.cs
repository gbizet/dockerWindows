using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace ConsoleApplication1
{
    class Program
    {
                
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            //doing it by using only the dll from nuget
            System.Uri url = new System.Uri("tcp://178.33.83.158:2375");
            var config = new DockerClientConfiguration(url);
            DockerClient client = config.CreateClient();
            ListContainersParameters containerslist = new Docker.DotNet.Models.ListContainersParameters();
            IList<ContainerListResponse> containers = await client.Containers.ListContainersAsync(
                new ListContainersParameters()
                {
                    Limit = 10,
                });



            //GBI implementation of this lib
            Finaxys.Docker.DockerFinaxysClient dockerClient = 
                new Finaxys.Docker.DockerFinaxysClient("tcp://178.33.83.158:2375");
            var result = await dockerClient.DockerGetContainers();
            var info = await dockerClient.DockerInfo();
            
        }

    }
}
