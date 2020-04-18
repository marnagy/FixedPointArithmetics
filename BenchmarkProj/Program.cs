using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Cuni.Arithmetics.FixedPoint;

namespace BenchmarkProj
{
	[MemoryDiagnoser]
	public class Program
	{
		public static Fixed<Q24_8> a;
		public static Fixed<Q24_8> b;
		public static MatrixFixed matrix;
		static Program()
		{
			int dimension = 20;
			a = new Fixed<Q24_8>(10);
			b = new Fixed<Q24_8>(15);
			Random rand = new Random();
			int[,] vals = new int[dimension,dimension];
			Console.WriteLine("Initializing matrix");
			for (int i = 0; i < dimension; i++)
			{
				for (int k = 0; k < dimension; k++)
				{
					vals[i,k] = rand.Next(1,2*dimension+1);
				}
			}
			matrix = new MatrixFixed(vals, dimension);
			Console.WriteLine("Matrix ready.");
		}
		[Benchmark]
		public void AddWithLong()
		{
			var res = a.Add(b);
		}
		[Benchmark]
		public void AddWithoutLong()
		{
			var res = a.AddWithoutLong(b);
		}
		[Benchmark]
		public void SubtractWithLong()
		{
			var res = a.Subtract(b);
		}
		[Benchmark]
		public void SubtractWithoutLong()
		{
			var res = a.SubtractWithoutLong(b);
		}
		[Benchmark]
		public void MultiplyWithLong()
		{
			var res = a.Multiply(b);
		}
		[Benchmark]
		public void MultiplyWithoutLong()
		{
			var res = a.MultiplyWithoutLong(b);
		}
		[Benchmark]
		public void DivideWithLong()
		{
			var res = a.Divide(b);
		}
		[Benchmark]
		public void DivideWithoutLong()
		{
			var res = a.DivideWithoutLong(b);
		}
		[Benchmark]
		public void GaussianEliminationWithLong()
		{
			var res = MatrixFixed.GaussWithLong(matrix);
		}
		[Benchmark]
		public void GaussianEliminationWithoutLong()
		{
			var res = MatrixFixed.GaussWithoutLong(matrix);
		}
		[Benchmark]
		public void GaussianEliminationCombined()
		{
			var res = MatrixFixed.GaussStandard(matrix);
		}
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Program>();
		}
	}
}
