using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using Cuni.Arithmetics.FixedPoint;

namespace FixedPointTests
{
    public class Q8_24_Tests
    {
        [Fact]
        public void AdditionTestPositive()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(3);
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(2);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(5), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void AdditionTestBothNegative()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(-3);
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(-2);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(-5), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void AdditionTestZero()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(3);
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(-3);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(0), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        } 
        [Fact]
        public void AdditionTestOneNegative()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(3);
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(-5);

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(-2), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void AdditionTestReal()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(1L << 22); // 1/4
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(1L << 23); // 1/2

            //Act
            var result = var1.Add(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(3L << 22), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void MultiplicationTestPositive()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(1L << 23); // 1/2
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(5); // 5

            //Act
            var result = var1.Multiply(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(5L << 23), result); // 2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void MultiplicationTestOneNegative()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(1L << 23); // 1/2
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(-5);

            //Act
            var result = var1.Multiply(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(0xFD_80_00_00L), result); // -2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void MultiplicationTestBothNegative()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(-1L << 23); // -1/2
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(-5); // -5

            //Act
            var result = var1.Multiply(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(5L << 23), result); // 2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void DivisionTestPositive()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(3);
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(2);

            //Act
            var result = var1.Divide(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(3L << 23), result); // 1,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void DivisionTestOneNegative()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(5);
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(-2);

            //Act
            var result = var1.Divide(var2);
            var binRes = Convert.ToString(result.Value,2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(0xFD_80_00_00L), result); // -2,5
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
        [Fact]
        public void DivisionTestBothNegative()
        {
            //Arrange
            Fixed<Q8_24> var1 = new Fixed<Q8_24>(-3);
            Fixed<Q8_24> var2 = new Fixed<Q8_24>(-2);

            //Act
            var result = var1.Divide(var2);

            //Assert
            Assert.Equal(new Fixed<Q8_24>(3L << 23), result);
            // make sure implementation return new object
            Assert.False(object.ReferenceEquals(var1, result));
            Assert.False(object.ReferenceEquals(var2, result));
        }
    }
}
