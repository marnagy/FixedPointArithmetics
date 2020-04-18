using System;
using System.Collections.Generic;
using System.Text;
using Cuni.Arithmetics.FixedPoint;

namespace BenchmarkProj
{
	public struct Matrix
	{
		public readonly int dimension;
		internal Fixed<Q8_24>[,] values;
		internal Matrix(int[,] vals)
		{
			dimension = vals.Length;
			values = new Fixed<Q8_24>[vals.Length, vals.Length];
			int i = 0;
			while (i < vals.Length)
			{
				int k = 0;
				while (k < vals.Length)
				{
					values[i, k] = (Fixed<Q8_24>)vals[i, k];
					k++;
				}
				i++;
			}
		}
		internal static Matrix GaussWithLong(Matrix m)
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
		internal static Matrix GaussWithoutLong(Matrix m)
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
	}
}
