﻿using Microsoft.Azure.WebJobs;
using System;
using System.IO;

namespace EventGridBinding
{
    public static class Function
    {
        public static void TestEventGrid([EventGridTrigger] EventGridEvent value)
        {
            Console.WriteLine(value);
        }

        public static void TestInputStream([EventGridTrigger("eventhubcapture")] Stream myBlob, string blobTrigger)
        {
            Console.WriteLine($"file name {blobTrigger}");
            var reader = new StreamReader(myBlob);
            string line = null;
            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                Console.WriteLine(line);
            }
        }

    }
}
