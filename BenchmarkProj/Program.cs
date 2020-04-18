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
		public static MatrixFixed matrixFixed;
		public static MatrixDouble matrixDouble;
		public static MatrixFloat matrixFloat;
		static Program()
		{
			int dimension = 20;
			a = new Fixed<Q24_8>(10);
			b = new Fixed<Q24_8>(15);
			Random rand = new Random();
			int[,] vals = new int[dimension,dimension];
			Console.WriteLine("Initializing matrices");
			for (int i = 0; i < dimension; i++)
			{
				for (int k = 0; k < dimension; k++)
				{
					vals[i,k] = rand.Next(1,2*dimension+1);
				}
			}
			matrixFixed = new MatrixFixed(vals, dimension);
			matrixFloat = new MatrixFloat(vals, dimension);
			matrixDouble = new MatrixDouble(vals, dimension);
			Console.WriteLine("Matrices ready.");
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
			var res = MatrixFixed.GaussWithLong(matrixFixed);
		}
		[Benchmark]
		public void GaussianEliminationWithoutLong()
		{
			var res = MatrixFixed.GaussWithoutLong(matrixFixed);
		}
		[Benchmark]
		public void GaussianEliminationCombined()
		{
			var res = MatrixFixed.GaussStandard(matrixFixed);
		}
		[Benchmark]
		public void GaussianEliminationDouble()
		{
			var res = MatrixDouble.GaussStandard(matrixDouble);
		}
		[Benchmark]
		public void GaussianEliminationFloat()
		{
			var res = MatrixFloat.GaussStandard(matrixFloat);
		}
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<Program>();
		}
	}
}
