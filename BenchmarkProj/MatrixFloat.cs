using System;
using System.Collections.Generic;
using System.Text;
using Cuni.Arithmetics.FixedPoint;

namespace BenchmarkProj
{
	public struct MatrixFloat
	{
		public readonly int dimension;
		internal float[,] values;
		internal MatrixFloat(int[,] vals, int dimension)
		{
			this.dimension = dimension;
			values = new float[dimension, dimension];
			for (int i = 0; i < dimension; i++)
			{
				for (int k = 0; k < dimension; k++)
				{
					values[i, k] = vals[i, k];
				}
			}
		}
		internal static MatrixFloat GaussStandard(MatrixFloat m)
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
