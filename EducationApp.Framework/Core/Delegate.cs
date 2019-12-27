using EducationApp.Framework.Interfaces;
using System.Diagnostics;

namespace EducationApp.Framework.Core
{
    public class Delegate : ITopic
    {
        private int InvocationCount { get; set; } = 0;

        public delegate string CowSay(string message);

        public string SayMessage(string message)
        {
            return $"Cow said: {message}. InvocationCount = {++InvocationCount}";
        }

        public void TestTopic()
        {
            CowSay cowSayHandler1 = SayMessage;
            CowSay cowSayHandler2 = SayMessage;
            CowSay cowSayHandler = cowSayHandler1 + cowSayHandler2 + cowSayHandler3 + cowSayHandler4 + cowSayHandler5;

            string cowSayResult = cowSayHandler("Hello Bitches");
            var debugString = $"Delegate Result: {cowSayResult}";

            Debug.WriteLine(debugString);
        }

    }
}
