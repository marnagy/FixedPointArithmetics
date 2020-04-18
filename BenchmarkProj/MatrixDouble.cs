using System;
using System.Collections.Generic;
using System.Text;
using Cuni.Arithmetics.FixedPoint;

namespace BenchmarkProj
{
	public struct MatrixDouble
	{
		public readonly int dimension;
		internal double[,] values;
		internal MatrixDouble(int[,] vals, int dimension)
		{
			this.dimension = dimension;
			values = new double[dimension, dimension];
			for (int i = 0; i < dimension; i++)
			{
				for (int k = 0; k < dimension; k++)
				{
					values[i, k] = vals[i, k];
				}
			}
		}
		internal static MatrixDouble GaussWithLong(MatrixDouble m)
		{
			for (int i = 0; i < m.dimension; i++)
			{
				if (m.values[i,i] != 1)
				{
					var temp = m.values[i,i];
					for (int k = i; k < m.dimension; k++)
					{
						m.values[i,k] = m.values[i,k].Divide(temp);
					}
				}

				for (int k = i+1; k < m.dimension; k++)
				{
					if (m.values[k,i] != 0)
					{
						var temp = m.values[k,i];
						for (int j = i; j < m.dimension; j++)
						{
							m.values[k,j] = m.values[k,j].Add( temp.Multiply( m.values[i,j] ) );
						}
					}
				}
			}
			return m;
		}
		internal static MatrixDouble GaussWithoutLong(MatrixDouble m)
		{
			for (int i = 0; i < m.dimension; i++)
			{
				if (m.values[i,i] != 1)
				{
					var temp = m.values[i,i];
					for (int k = i; k < m.dimension; k++)
					{
						m.values[i,k] = m.values[i,k].DivideWithoutLong(temp);
					}
				}

				for (int k = i+1; k < m.dimension; k++)
				{
					if (m.values[k,i] != 0)
					{
						var temp = m.values[k,i];
						for (int j = i; j < m.dimension; j++)
						{
							m.values[k,j] = m.values[k,j].AddWithoutLong( temp.MultiplyWithoutLong( m.values[i,j] ) );
						}
					}
				}
			}
			return m;
		}
		internal static MatrixFixed GaussStandard(MatrixFixed m)
		{
			for (int i = 0; i < m.dimension; i++)
			{
				if (m.values[i,i] != 1)
				{
					var temp = m.values[i,i];
					for (int k = i; k < m.dimension; k++)
					{
						m.values[i,k] = m.values[i,k] / temp;
					}
				}

				for (int k = i+1; k < m.dimension; k++)
				{
					if (m.values[k,i] != 0)
					{
						var temp = m.values[k,i];
						for (int j = i; j < m.dimension; j++)
						{
							m.values[k,j] = m.values[k,j] + temp * m.values[i,j];
						}
					}
				}
			}
			return m;
		}
	}
}
