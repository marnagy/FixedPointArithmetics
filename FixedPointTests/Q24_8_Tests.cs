using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using Cuni.Arithmetics.FixedPoint;

namespace FixedPointTests
{
    public class Q24_8_Tests
    {
        [Fact]
        public void AdditionTestPositive()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(3);
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(2);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>(5), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void AdditionTestBothNegative()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(-3);
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(-2);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>(-5), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void AdditionTestZero()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(3);
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(-3);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>(0), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        } 
        [Fact]
        public void AdditionTestOneNegative()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(3);
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(-5);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>(-2), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void AdditionTestReal()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(1L << 6); // 1/4
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(1L << 7); // 1/2

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>(3L << 6), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void MultiplicationTestPositive()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(1L << 7); // 1/2
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(5); // 5

            //Act
            var result = var1.Multiply(var2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>(5L << 7), result); // 2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void MultiplicationTestOneNegative()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(1L << 7); // 1/2
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(-5);

            //Act
            var result = var1.Multiply(var2);
            var binaryRes = Convert.ToString(result.Value, 2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>(0xFF_FF_FD_80L), result); // -2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void MultiplicationTestBothNegative()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(-1L << 7); // -1/2
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(-5); // -5

            //Act
            var result = var1.Multiply(var2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>(5L << 7), result); // 2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void DivisionTestPositive()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(3);
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(2);

            //Act
            var result = var1.Divide(var2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>((long)3 << 7), result); // 1,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void DivisionTestOneNegative()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(5);
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(-2);

            //Act
            var result = var1.Divide(var2);
            Console.WriteLine(Convert.ToString(result.Value, 2));

            //Assert
            Assert.Equal(new Fixed<Q24_8>(0xFF_FF_FD_80L), result); // -2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void DivisionTestBothNegative()
        {
            //Arrange
            Fixed<Q24_8> var1 = new Fixed<Q24_8>(-3);
            Fixed<Q24_8> var2 = new Fixed<Q24_8>(-2);

            //Act
            var result = var1.Divide(var2);

            //Assert
            Assert.Equal(new Fixed<Q24_8>((long)3 << 7), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
    }
}
