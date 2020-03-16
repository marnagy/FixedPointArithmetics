using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using Cuni.Arithmetics.FixedPoint;

namespace FixedPointTests
{
    public class Q16_16_Tests
    {
        [Fact]
        public void AdditionTestPositive()
        {
            //Arrange
            Fixed<Q16_16> var1 = new Fixed<Q16_16>(3);
            Fixed<Q16_16> var2 = new Fixed<Q16_16>(2);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q16_16>(5), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void AdditionTestBothNegative()
        {
            //Arrange
            Fixed<Q16_16> var1 = new Fixed<Q16_16>(-3);
            Fixed<Q16_16> var2 = new Fixed<Q16_16>(-2);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q16_16>(-5), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void AdditionTestZero()
        {
            //Arrange
            Fixed<Q16_16> var1 = new Fixed<Q16_16>(3);
            Fixed<Q16_16> var2 = new Fixed<Q16_16>(-3);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q16_16>(0), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        } 
        [Fact]
        public void AdditionTestOneNegative()
        {
            //Arrange
            Fixed<Q16_16> var1 = new Fixed<Q16_16>(3);
            Fixed<Q16_16> var2 = new Fixed<Q16_16>(-5);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q16_16>(-2), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void AdditionTestReal()
        {
            //Arrange
            Fixed<Q16_16> var1 = new Fixed<Q16_16>(1L << 14); // 1/4
            Fixed<Q16_16> var2 = new Fixed<Q16_16>(1L << 15); // 1/2

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q16_16>(3L << 14), result); // 3/4
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void MultiplicationTestPositive()
        {
            //Arrange
            Fixed<Q16_16> var1 = new Fixed<Q16_16>(1L << 15); // 1/2
            Fixed<Q16_16> var2 = new Fixed<Q16_16>(5); // 5

            //Act
            var result = var1.Multiply(var2);

            //Assert
            Assert.Equal(new Fixed<Q16_16>(5L << 15), result); // 2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void MultiplicationTestOneNegative()
        {
            //Arrange
            Fixed<Q16_16> var1 = new Fixed<Q16_16>(1L << 15); // 1/2
            Fixed<Q16_16> var2 = new Fixed<Q16_16>(-5);

            //Act
            var result = var1.Multiply(var2);
            var binaryRes = Convert.ToString(result.Value, 2);

            //Assert
            Assert.Equal(new Fixed<Q16_16>(0xFF_FD_80_00L), result); // -2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void MultiplicationTestBothNegative()
        {
            //Arrange
            Fixed<Q16_16> var1 = new Fixed<Q16_16>(-1L << 15); // -1/2
            Fixed<Q16_16> var2 = new Fixed<Q16_16>(-5); // -5

            //Act
            var result = var1.Multiply(var2);

            //Assert
            Assert.Equal(new Fixed<Q16_16>(5L << 15), result); // 2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
    }
}
