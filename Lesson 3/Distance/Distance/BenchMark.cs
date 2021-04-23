using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

namespace Distance
{
    public class PointClass
    {
        //Для типа float
        public float X;
        public float Y;
        //Для типа Double
        public double Xd;
        public double Yd;
    }
    public struct PointStruct
    {
        //Для типа float
        public float X;
        public float Y;
        //Для типа double
        public double Xd;
        public double Yd;
    }
    public class BenchmarkClass
    {
        //Задача 1:
        public float PointDistanceShortFloat(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        [Benchmark]
        public void BenchmarkOfPointShortDistanceFloat()
        {
            PointClass pF1 = new PointClass() { X = 34.5f, Y = 34.5f };
            PointClass pF2 = new PointClass() { X = 55.4f, Y = 55.4f };
            PointDistanceShortFloat(pF1, pF2);
            PointClass pF3 = new PointClass() { X = 88.2f, Y = 88.2f };
            PointClass pF4 = new PointClass() { X = 12.5f, Y = 12.5f };
            PointDistanceShortFloat(pF3, pF4);
            PointClass pF5 = new PointClass() { X = 21.1f, Y = 21.1f };
            PointClass pF6 = new PointClass() { X = 66.8f, Y = 66.8f };
            PointDistanceShortFloat(pF5, pF6);
            PointClass pF7 = new PointClass() { X = 92.34f, Y = 92.34f };
            PointClass pF8 = new PointClass() { X = 12.5f, Y = 12.5f };
            PointDistanceShortFloat(pF7, pF8);
            PointClass pF9 = new PointClass() { X = 1.5f, Y = 1.5f };
            PointClass pF10 = new PointClass() { X = 78.34f, Y = 78.34f };
            PointDistanceShortFloat(pF9, pF10);
        }
        //Задача 2:
        public float PointDistanceFloatWithSqrt(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void BenchmarkOfPointDistanceFloatWithSqrt()
        {
            PointStruct pF1 = new PointStruct() { X = 34.5f, Y = 34.5f };
            PointStruct pF2 = new PointStruct() { X = 55.4f, Y = 55.4f };
            PointDistanceFloatWithSqrt(pF1, pF2);
            PointStruct pF3 = new PointStruct() { X = 88.2f, Y = 88.2f };
            PointStruct pF4 = new PointStruct() { X = 12.5f, Y = 12.5f };
            PointDistanceFloatWithSqrt(pF3, pF4);
            PointStruct pF5 = new PointStruct() { X = 21.1f, Y = 21.1f };
            PointStruct pF6 = new PointStruct() { X = 66.8f, Y = 66.8f };
            PointDistanceFloatWithSqrt(pF5, pF6);
            PointStruct pF7 = new PointStruct() { X = 92.34f, Y = 92.34f };
            PointStruct pF8 = new PointStruct() { X = 12.5f, Y = 12.5f };
            PointDistanceFloatWithSqrt(pF7, pF8);
            PointStruct pF9 = new PointStruct() { X = 1.5f, Y = 1.5f };
            PointStruct pF10 = new PointStruct() { X = 78.34f, Y = 78.34f };
            PointDistanceFloatWithSqrt(pF9, pF10);
        }
        //Задача 3:
        public double PointDistanceShortDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double xD = pointOne.Xd - pointTwo.Xd;
            double yD = pointOne.Yd - pointTwo.Yd;
            return (xD * xD) + (yD * yD);
        }
        [Benchmark]
        public void BenchmarkOfPointDistanceShortDouble()
        {
            PointStruct pF1 = new PointStruct() { Xd = 34.5d, Yd = 34.5d };
            PointStruct pF2 = new PointStruct() { Xd = 55.4d, Yd = 55.4d };
            PointDistanceShortDouble(pF1, pF2);
            PointStruct pF3 = new PointStruct() { Xd = 88.2d, Yd = 88.2d };
            PointStruct pF4 = new PointStruct() { Xd = 12.5d, Yd = 12.5d };
            PointDistanceShortDouble(pF3, pF4);
            PointStruct pF5 = new PointStruct() { Xd = 21.1d, Yd = 21.1d };
            PointStruct pF6 = new PointStruct() { Xd = 66.8d, Yd = 66.8d };
            PointDistanceShortDouble(pF5, pF6);
            PointStruct pF7 = new PointStruct() { Xd = 92.34d, Yd = 92.34d };
            PointStruct pF8 = new PointStruct() { Xd = 12.5d, Yd = 12.5d };
            PointDistanceShortDouble(pF7, pF8);
            PointStruct pF9 = new PointStruct() { Xd = 1.5d, Yd = 1.5d };
            PointStruct pF10 = new PointStruct() { Xd = 78.34d, Yd = 78.34d };
            PointDistanceShortDouble(pF9, pF10);
        }
        //Задача 4:
        public float PointDistanceShortFloat(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        [Benchmark]
        public void BenchmarkOfPointDistanceShortFloat()
        {
            PointStruct pF1 = new PointStruct() { X = 34.5f, Y = 34.5f };
            PointStruct pF2 = new PointStruct() { X = 55.4f, Y = 55.4f };
            PointDistanceShortFloat(pF1, pF2);
            PointStruct pF3 = new PointStruct() { X = 88.2f, Y = 88.2f };
            PointStruct pF4 = new PointStruct() { X = 12.5f, Y = 12.5f };
            PointDistanceShortFloat(pF3, pF4);
            PointStruct pF5 = new PointStruct() { X = 21.1f, Y = 21.1f };
            PointStruct pF6 = new PointStruct() { X = 66.8f, Y = 66.8f };
            PointDistanceShortFloat(pF5, pF6);
            PointStruct pF7 = new PointStruct() { X = 92.34f, Y = 92.34f };
            PointStruct pF8 = new PointStruct() { X = 12.5f, Y = 12.5f };
            PointDistanceShortFloat(pF7, pF8);
            PointStruct pF9 = new PointStruct() { X = 1.5f, Y = 1.5f };
            PointStruct pF10 = new PointStruct() { X = 78.34f, Y = 78.34f };
            PointDistanceShortFloat(pF9, pF10);
        }
    }
}
