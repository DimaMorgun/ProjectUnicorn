using EducationApp.Framework.Interfaces;
using System;
using System.Diagnostics;

namespace EducationApp.Framework.Core
{
    public class Delegate : ITopic
    {
        private static int InvocationCount { get; set; } = 0;

        public delegate string CowSay(string message);

        public string SayMessage(string message)
        {
            return $"Cow said: {message}. InvocationCount = {++InvocationCount}";
        }

        public static string SayStaticMessage(string message)
        {
            return $"Cow said statically: {message}. InvocationCount = {++InvocationCount}";
        }

        public void TestTopic()
        {
            CowSay cowSayHandler1 = SayMessage;
            CowSay cowSayHandler2 = SayMessage;
            CowSay cowSayHandler3 = SayStaticMessage;
            CowSay cowSayHandler = cowSayHandler1 + cowSayHandler2 + cowSayHandler3;

            string cowSayResult = cowSayHandler("Hello Bitches");
            var debugString = $"Delegate Result: {cowSayResult}";

            Debug.WriteLine(debugString);

            Program.Separator();

            CovarianceDelegate.TestTopic();

            Program.Separator();

            ContravarianceDelegate.TestTopic();

            Program.Separator();

        }

    }

    public class Rectangle
    {
        public int TopSideSize { get; set; }
        public int RightSideSize { get; set; }
        public int BottomSideSize { get; set; }
        public int LeftSideSize { get; set; }
    }

    public class Square : Rectangle
    {
        public int GetPerimeter
        {
            get
            {
                ValidateInstanceState();

                int perimeter = TopSideSize + RightSideSize + BottomSideSize + LeftSideSize;

                return perimeter;
            }
        }

        public bool IsTrueSquare
        {
            get
            {
                ValidateInstanceState();

                bool isTrueSquare = TopSideSize == RightSideSize && BottomSideSize == LeftSideSize && TopSideSize == BottomSideSize;

                return isTrueSquare;
            }
        }

        private void ValidateInstanceState()
        {
            if (TopSideSize == 0 | RightSideSize == 0 | BottomSideSize == 0 | LeftSideSize == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public class CovarianceDelegate
    {
        delegate Rectangle RectangleBuilder();

        public static void TestTopic()
        {
            RectangleBuilder rectangleBuilder = BuildBaseSquare;

            Rectangle rectangle = rectangleBuilder();
            Debug.WriteLine($"CovarianceDelegate: Rectangle has been created with sides top-right-bottom-left - {rectangle.TopSideSize}-{rectangle.RightSideSize}-{rectangle.BottomSideSize}-{rectangle.LeftSideSize}.");
        }

        public static Square BuildBaseSquare()
        {
            var baseSquare = new Square()
            {   
                TopSideSize = 5,
                RightSideSize = 5,
                BottomSideSize = 5,
                LeftSideSize = 5
            };

            return baseSquare;
        }
    }

    public class ContravarianceDelegate
    {
        delegate int SquareDelegate(Square square);

        public static void TestTopic()
        {
            SquareDelegate squareDelegate = GetRectangleSidesSum;

            Square baseSquare = CovarianceDelegate.BuildBaseSquare();

            int rectangleSidesSum = squareDelegate(baseSquare);

            Debug.WriteLine($"Contravariance: Rectangle sides sum is {rectangleSidesSum}.");
        }

        private static int GetRectangleSidesSum(Rectangle rectangle)
        {
            int result = rectangle.TopSideSize + rectangle.RightSideSize + rectangle.BottomSideSize + rectangle.LeftSideSize;

            return result;
        }
    }
}
