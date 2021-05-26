using Cronos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        #region Testing constructor        
        [TestMethod]
        public void CreateTimeObject()
        {
            //Assign and action
            Time time = new Time(2, 195);
            Time expectedResult = new Time(5, 15);

            //Assertion
            Assert.AreEqual(expectedResult, time);
        }

        [TestMethod]
        public void CreateTimeObjectWithNegativeMinutes()
        {
            //Assign
            Time time = new Time(1, -30);
            Time expectedResult = new Time(0, 30);

            //Assertion
            Assert.AreEqual(expectedResult, time);

        }

        [TestMethod]
        public void CreateTimeObjectWithNegativeHours()
        {
            //Assign
            Time time = new Time(-1, 65);
            Time expectedResult = new Time(0, 5);

            //Assertion
            Assert.AreEqual(expectedResult, time);
        }
        #endregion

        #region Testing + operator
        [TestMethod]
        public void AddTwoTimes()
        {
            //Assign
            Time time1 = new Time(1, 10);
            Time time2 = new Time(0, 20);
            Time expectedResult = new Time(1, 30);

            //Action
            Time result = time1 + time2;

            //Assertion
            Assert.AreEqual(expectedResult, result, 
                $"{expectedResult._hour}h {expectedResult._minute}min == {result._hour}h {result._minute}min");
        }

        [TestMethod]
        public void AddTwoTimesExceeding60Minutes()
        {
            //Assign
            Time time1 = new Time(0, 40);
            Time time2 = new Time(0, 20);
            Time expectedResult = new Time(1, 0);

            //Action
            Time result = time1 + time2;

            //Assertion
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AddTwoTimesWithNegativeMinutes()
        {
            //Assign
            Time time1 = new Time(2, -30);
            Time time2 = new Time(0, 10);
            Time expectedResult = new Time(1, 40);

            //Action
            Time result = time1 + time2;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        #endregion

        #region Testing - operator
        [TestMethod]
        public void SubtractTwoTimes()
        {
            //Assign
            Time time1 = new Time(1, 5);
            Time time2 = new Time(2, 0);
            Time expectedResult = new Time(0, 55);

            //Action
            Time result = time1 - time2;

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SubtractTwoTimesNegativeMinutes()
        {
            //Arrange
            Time time1 = new Time(1, 40);
            Time time2 = new Time(0, 50);
            Time expectedTime = new Time(0, 50);

            //Action
            Time result = time1 - time2;

            //Assert
            Assert.AreEqual(expectedTime, result, $"{result._hour}, {result._minute}");
        }

        [TestMethod]
        public void SubtractTwoTimesNegativeHours()
        {
            //Arrange
            Time time1 = new Time(1, 30);
            Time time2 = new Time(3, 0);
            Time expectedTime = new Time(1, 30);

            //Action
            Time result = time1 - time2;

            //Assert
            Assert.AreEqual(expectedTime, result, $"{result._hour}, {result._minute}");
        }
        #endregion

        #region Testing == and != operators
        [TestMethod]
        public void CheckIfTimesAreEqualOrNot()
        {
            //Arrange
            Time time1 = new Time(1, 30);
            Time time2 = new Time(1, 30);
            Time time3 = new Time(0, 90);
            Time time4 = new Time(0, 0);

            //Action
            bool result1 = time1 == time2;
            bool result2 = time1 == time3;
            bool result3 = time1 == time4;
            bool result4 = time1 != time4;
            bool result5 = time1.GetHashCode() == time3.GetHashCode();

            //Assert
            Assert.IsTrue(result1, $"{time1._hour}h {time1._minute}min == {time2._hour}h {time2._minute}min");
            Assert.IsTrue(result2, $"{time1._hour}h {time1._minute}min == {time3._hour}h {time3._minute}min");
            Assert.IsFalse(result3, $"{time1._hour}h {time1._minute}min == {time4._hour}h {time4._minute}min");
            Assert.IsTrue(result4, $"{time1._hour}h {time1._minute}min == {time4._hour}h {time4._minute}min");
            Assert.IsTrue(result5);
        }
        #endregion

        #region Testing > and < operators
        [TestMethod]
        public void CompareTimes()
        {
            //Arrange
            Time time1 = new Time(1, 40);
            Time time2 = new Time(1, 30);

            //Action
            bool result1 = time1 > time2;
            bool result2 = time2 < time1;

            //Assert
            Assert.IsTrue(result1, $"{time1._hour}h {time1._minute}min > {time2._hour}h {time2._minute}min");
            Assert.IsTrue(result2, $"{time2._hour}h {time2._minute}min < {time1._hour}h {time1._minute}min");
        }
        #endregion

        #region Testing time convertion to float and vice-versa
        [TestMethod]
        public void ConvertTimeToFloat()
        {
            //Arrange
            Time time = new Time(1, 30);

            //Action
            float floatTime = (float)time;

            //Assert
            Assert.AreEqual(1.5f, floatTime, $"{floatTime}, {time}");
        }

        [TestMethod]
        public void ConvertFloatToTime()
        {
            //Arrange
            Time time = new Time(1, 30);

            //Action
            Time floatTime = (Time)1.5f;

            //Assert
            Assert.AreEqual(time, floatTime, $"{time._hour}h {time._minute}min == {floatTime._hour}h {floatTime._minute}min");
        }
        #endregion
    }
}
