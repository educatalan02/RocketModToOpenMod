﻿using System;
using System.IO;
using System.Threading.Tasks;
using RocketToOpenMod.Data;
using RocketToOpenMod.Jobs;

namespace RocketToOpenMod
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("RocketMod to OpenMod");
            Console.WriteLine("If you haven't already please place this file inside the Rocket folder");
            
            if (!File.Exists("Rocket.Permissions.Xml"))
            {
                Console.WriteLine("Wrong folder! Exiting");
                await Task.Delay(3000);
                return;
            }

            Job currentJob;
            WriteFileType write;

            if (args.Length == 0)
                write = WriteFileType.Yaml;
            else
                write = args[0].ToLower() switch
                {
                    "json" => WriteFileType.Json,
                    "xml" => WriteFileType.Xml,
                    _ => WriteFileType.Yaml
                };

            Console.WriteLine("1. Role Permissions ");
            currentJob = new RolePermissionsJob(write);
            await currentJob.DoAsync();
            
            Console.WriteLine("2. User Permissions ");
            Console.WriteLine("Coming soon :p");
            
            Console.WriteLine("3. Users");
            currentJob = new UsersJob(write);
            await currentJob.DoAsync();
            
            Console.WriteLine("4. Core Translations");
            Console.WriteLine("Coming soon :p");

            Console.WriteLine("Done!");
            
            await Task.Delay(5000);
            
        }
        
        
    }
}