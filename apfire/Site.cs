using System;
using System.Collections.Generic;
using System.Text;

namespace apfire
{
    public class Site
    {
        public string url { get; set; }
        public string debugMode { get; set; }
        public string method { get; set; }
        public int hitCount { get; set; }

        public void testApiEndpoint()
        {
            for(int i = 0; i <= hitCount; i++)
            {
                sendRequest();
            }
        }

        public void sendRequest()
        {
            Console.WriteLine("Send Request");
        }
    }
}
