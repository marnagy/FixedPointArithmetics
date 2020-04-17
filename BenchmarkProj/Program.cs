using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkProj
{
	class Program
	{
		[Benchmark]
		public static void Add()
		{

		}
		[Benchmark]
		public static void Subtract()
		{

		}
		[Benchmark]
		public static void Multiply()
		{

		}
		[Benchmark]
		public static void Divide()
		{

		}
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Program>();
		}
	}
}
