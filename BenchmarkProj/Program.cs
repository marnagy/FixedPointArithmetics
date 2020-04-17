using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Cuni.Arithmetics.FixedPoint;

namespace BenchmarkProj
{
	public class Program
	{
		public static Fixed<Q24_8> a;
		public static Fixed<Q24_8> b;
		static Program()
		{
			a = new Fixed<Q24_8>(10);
			b = new Fixed<Q24_8>(15);
		}
		[Benchmark]
		public void AddWithLong()
		{
			var res = a.Add(b);
		}
		[Benchmark]
		public void AddWithoutLong()
		{
			
		}
		[Benchmark]
		public void SubtractWithLong()
		{
			var res = a.Subtract(b);
		}
		[Benchmark]
		public void SubtractWithoutLong()
		{
			
		}
		[Benchmark]
		public void MultiplyWithLong()
		{
			var res = a.Multiply(b);
		}
		[Benchmark]
		public void MultiplyWithoutLong()
		{
			
		}
		[Benchmark]
		public void DivideWithLong()
		{
			var res = a.Divide(b);
		}
		[Benchmark]
		public void DivideWithoutLong()
		{
			
		}
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Program>();
		}
	}
}
