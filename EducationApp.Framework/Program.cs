using EducationApp.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EducationApp.Framework
{
    class Program
    {
        static ICollection<ITopic> _topics = new List<ITopic>();

        static void Main(string[] args)
        {
            BuildTopics();

            foreach (var topic in _topics)
            {
                topic.TestTopic();
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void BuildTopics()
        {
            _topics.Add(new Core.Delegate());
        }

        public static void Separator()
        {
            int length = 50;
            var separator = new string('-', length);

            Debug.WriteLine(separator);
        }
    }
}
