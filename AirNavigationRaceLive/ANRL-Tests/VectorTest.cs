using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AirNavigationRaceLive.Comps.Helper;

namespace ANRL_Tests
{
    
    
    /// <summary>
    ///This is a test class for VectorTest and is intended
    ///to contain all VectorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VectorTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Vector Constructor
        ///</summary>
        [TestMethod()]
        public void VectorConstructorTest()
        {
            Vector v = new Vector(1,2,3);
            Vector target = new Vector(v);
            Assert.AreEqual(v,target);
        }

        /// <summary>
        ///A test for Vector Constructor
        ///</summary>
        [TestMethod()]
        public void VectorConstructorTest1()
        {
            double X = 1F;
            double Y = 3F;
            double Z = 2F; 
            Vector target = new Vector(X, Y, Z);
            Assert.AreEqual(X, target.X);
            Assert.AreEqual(Y, target.Y);
            Assert.AreEqual(Z, target.Z);
        }

        /// <summary>
        ///A test for Abs
        ///</summary>
        [TestMethod()]
        public void AbsTest()
        {
            Vector a = new Vector(0,3,4);
            double expected = 5F;
            double actual;
            actual = Vector.Abs(a);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Cross
        ///</summary>
        [TestMethod()]
        public void CrossTest()
        {
            /*Vector a = null; // TODO: Initialize to an appropriate value
            Vector b = null; // TODO: Initialize to an appropriate value
            Vector expected = null; // TODO: Initialize to an appropriate value
            Vector actual;
            actual = Vector.Cross(a, b);
            Assert.AreEqual(expected, actual);*/
        }

        /// <summary>
        ///A test for Direction
        ///</summary>
        [TestMethod()]
        public void DirectionTest()
        {
            Vector startPoint = new Vector(1,2,3);
            Vector endPoint = new Vector(2,3,4);
            Vector expected = new Vector(1,1,1);
            Vector actual;
            actual = Vector.Direction(startPoint, endPoint);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            Vector v = new Vector(8,99,234);
            Vector target = new Vector(8, 99, 234);
            object obj = v; 
            bool expected = true;
            bool actual;
            actual = target.Equals(obj);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetHashCode
        ///</summary>
        [TestMethod()]
        public void GetHashCodeTest()
        {
            Vector v = new Vector(8, 99, 234);
            Vector target = new Vector(8, 99, 234);
            int expected = v.GetHashCode();
            int actual;
            actual = target.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Interception
        ///</summary>
        [TestMethod()]
        public void InterceptionTest()
        {
            Vector LineA_A = new Vector(2, 2, 2);
            Vector LineA_B = new Vector(-2, -2, -2);
            Vector LineB_A = new Vector(1, 2, 1);
            Vector LineB_B = new Vector(1, -1, 1);
            Vector expected = new Vector(1, 1, 1);
            Vector actual;
            actual = Vector.Interception(LineA_A, LineA_B, LineB_A, LineB_B);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for Interception
        ///</summary>
        [TestMethod()]
        public void InterceptionTest2()
        {
            Vector LineA_A = new Vector(2, 2, 2);
            Vector LineA_B = new Vector(-2, -2, -2);
            Vector LineB_A = new Vector(3, -3, 3);
            Vector LineB_B = new Vector(-3, 3, -3);
            Vector expected = new Vector(0, 0, 0);
            Vector actual;
            actual = Vector.Interception(LineA_A, LineA_B, LineB_A, LineB_B);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Interception
        ///</summary>
        [TestMethod()]
        public void InterceptionTest3()
        {
            Vector LineA_A = new Vector(2, 2, 2);
            Vector LineA_B = new Vector(-2, -2, -2);
            Vector LineB_A = new Vector(9, 8, 10);
            Vector LineB_B = new Vector(8, 8, 10);
            Vector expected = null;
            Vector actual;
            actual = Vector.Interception(LineA_A, LineA_B, LineB_A, LineB_B);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Interception
        ///</summary>
        [TestMethod()]
        public void InterceptionTest4()
        {
            Vector LineA_A = new Vector(-2, -2, -2);
            Vector LineA_B = new Vector(2, 2, 2);
            Vector LineB_A = new Vector(9, 8, 10);
            Vector LineB_B = new Vector(8, 8, 10);
            Vector expected = null;
            Vector actual;
            actual = Vector.Interception(LineA_A, LineA_B, LineB_A, LineB_B);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LotInterception
        ///</summary>
        [TestMethod()]
        public void LotInterceptionTest()
        {
            Vector Start = new Vector(0,0,0); 
            Vector End = new Vector(2,0,0);
            Vector Point = new Vector(1,0,2);
            Vector expected = new Vector(1,0,0);
            Vector actual;
            actual = Vector.LotInterception(Start, End, Point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Middle
        ///</summary>
        [TestMethod()]
        public void MiddleTest()
        {
            Vector a = new Vector(10,10,10);
            Vector b = new Vector(20,20,20);
            Vector expected = new Vector(15,15,15);
            Vector actual;
            actual = Vector.Middle(a, b);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for MinDistance
        ///</summary>
        [TestMethod()]
        public void MinDistanceTest()
        {
            Vector Start = new Vector(0, 0, 0);
            Vector End = new Vector(2, 0, 0);
            Vector Point = new Vector(1, 0, 2);
            Vector expected = new Vector(0, 0, 2);
            Vector actual;
            actual = Vector.MinDistance(Start, End, Point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Orthogonal
        ///</summary>
        [TestMethod()]
        public void OrthogonalTest()
        {
            Vector a = new Vector(10,5,0);
            Vector expected = new Vector(-5,10,0);
            Vector actual;
            actual = Vector.Orthogonal(a);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Spat
        ///</summary>
        [TestMethod()]
        public void SpatTest()
        {
            /*Vector a = null; // TODO: Initialize to an appropriate value
            Vector b = null; // TODO: Initialize to an appropriate value
            Vector c = null; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = Vector.Spat(a, b, c);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");*/
        }

        /// <summary>
        ///A test for op_Addition
        ///</summary>
        [TestMethod()]
        public void op_AdditionTest()
        {
            Vector a = new Vector(100,99,29);
            Vector b = new Vector(2,1,2);
            Vector expected = new Vector(102,100,31);
            Vector actual;
            actual = (a + b);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Division
        ///</summary>
        [TestMethod()]
        public void op_DivisionTest()
        {
            Vector a = new Vector(100,100,100);
            double b = 0.5F;
            Vector expected = new Vector(200, 200, 200);
            Vector actual;
            actual = (a / b);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Multiply
        ///</summary>
        [TestMethod()]
        public void op_MultiplyTest()
        {
            Vector a = new Vector(2,3,4);
            Vector b = new Vector(2, 3, 4); 
            double expected = 2*2+3*3+4*4;
            double actual;
            actual = (a * b);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Multiply
        ///</summary>
        [TestMethod()]
        public void op_MultiplyTest1()
        {
            Vector a = new Vector(100,100,100);
            double b = 100;
            Vector expected = new Vector(10000,10000,10000);
            Vector actual;
            actual = (a * b);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Subtraction
        ///</summary>
        [TestMethod()]
        public void op_SubtractionTest()
        {
            Vector a = new Vector(30,40,50);
            Vector b = new Vector(2,3,4);
            Vector expected = new Vector(28,37,46);
            Vector actual;
            actual = (a - b);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for hasIntersections
        ///</summary>
        [TestMethod()]
        public void hasIntersectionsTest()
        {
            List<Vector> list = new List<Vector>();
            bool expected = false;
            bool actual;
            actual = Vector.hasIntersections(list);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for hasIntersections
        ///</summary>
        [TestMethod()]
        public void hasIntersectionsTest1()
        {
            List<Vector> list = new List<Vector>();
            list.Add(new Vector(10, 0, 0));
            list.Add(new Vector(10, 10, 0));
            list.Add(new Vector(0, 10, 0));
            bool expected = false;
            bool actual;
            actual = Vector.hasIntersections(list);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for hasIntersections
        ///</summary>
        [TestMethod()]
        public void hasIntersectionsTest2()
        {
            List<Vector> list = new List<Vector>();
            list.Add(new Vector(10, 0, 0));
            list.Add(new Vector(10, 10, 0));
            list.Add(new Vector(0, 10, 0));
            list.Add(new Vector(0, 0, 0));
            bool expected = false;
            bool actual;
            actual = Vector.hasIntersections(list);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for hasIntersections
        ///</summary>
        [TestMethod()]
        public void hasIntersectionsTest3()
        {
            List<Vector> list = new List<Vector>();
            list.Add(new Vector(10, 0, 0));
            list.Add(new Vector(0, 10, 0));
            list.Add(new Vector(10, 10, 0));
            list.Add(new Vector(0, 0, 0));
            bool expected = true;
            bool actual;
            actual = Vector.hasIntersections(list);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for hasIntersections
        ///</summary>
        [TestMethod()]
        public void hasIntersectionsTest4()
        {
            List<Vector> list = new List<Vector>();
            list.Add(new Vector(10, 0, 0));
            list.Add(new Vector(10, 10, 0));
            list.Add(new Vector(0, 10, 0));
            list.Add(new Vector(-10, 10, 0));
            list.Add(new Vector(-10, 0, 0));
            list.Add(new Vector(-10, -10, 0));
            list.Add(new Vector(0, -10, 0));
            list.Add(new Vector(10, -10, 0));
            list.Add(new Vector(0, 0, 0));
            bool expected = false;
            bool actual;
            actual = Vector.hasIntersections(list);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for hasIntersections
        ///</summary>
        [TestMethod()]
        public void hasIntersectionsTest5()
        {
            List<Vector> list = new List<Vector>();
            list.Add(new Vector(10, 0, 0));
            list.Add(new Vector(10, 10, 0));
            list.Add(new Vector(0, 10, 0));
            list.Add(new Vector(-10, 10, 0));
            list.Add(new Vector(-10, -10, 0));
            list.Add(new Vector(-10, 0, 0));
            list.Add(new Vector(0, -10, 0));
            list.Add(new Vector(10, -10, 0));
            list.Add(new Vector(0, 0, 0));
            bool expected = true;
            bool actual;
            actual = Vector.hasIntersections(list);
            Assert.AreEqual(expected, actual);
        }

   
        [TestMethod()]
        public void AngleTest()
        {
            Vector a = new Vector(0, 10, 0);
            Vector b = new Vector(0, 0, 0);
            Vector c = new Vector(10, 0, 0);
            double expected = Math.PI / 2;
            double actual;
            actual = Vector.Angle(a, b, c);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void AngleTest2()
        {
            Vector a = new Vector(0, 10, 0);
            Vector b = new Vector(0, 0, 0);
            Vector c = Vector.Middle(a, new Vector(10, 0, 0));
            double expected = Math.PI / 4;
            double actual;
            actual = Vector.Angle(a, b, c);
            Assert.IsTrue(Math.Abs(expected - actual) < 0.00000000001);
        }
 
        [TestMethod()]
        public void AngleTest3()
        {
            Vector a = new Vector(10, 0, 0);
            Vector b = new Vector(0, 0, 0);
            Vector c = new Vector(0, 10, 0);
            double expected = Math.PI / 2;
            double actual;
            actual = Vector.Angle(a, b, c);
            Assert.AreEqual(expected, actual);
        }
  
        [TestMethod()]
        public void AngleTest4()
        {
            Vector a = new Vector(10, 0, 0);
            Vector b = new Vector(0, 0, 0);
            Vector c = new Vector(-10, 0, 0);
            double expected = Math.PI;
            double actual;
            actual = Vector.Angle(a, b, c);
            Assert.AreEqual(expected, actual);
        }

   
        [TestMethod()]
        public void AngleClockwiseTest1()
        {
            Vector a = new Vector(10, 0, 0);
            Vector b = new Vector(0, 0, 0);
            Vector c = new Vector(-10, 0, 0);
            double expected = Math.PI;
            double actual;
            actual = Vector.AngleClockwise(a, b, c);
            Assert.AreEqual(expected, actual);
        }

      
        [TestMethod()]
        public void AngleClockwiseTest2()
        {
            Vector a = new Vector(10, 0, 0);
            Vector b = new Vector(0, 0, 0);
            Vector c = new Vector(0, 10, 0);
            double expected =(Math.PI*2)- Math.PI / 2;
            double actual;
            actual = Vector.AngleClockwise(a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AngleClockwiseTest3()
        {
            Vector a = new Vector(0, 10, 0);
            Vector b = new Vector(0, 0, 0);
            Vector c = new Vector(10, 0, 0);
            double expected = Math.PI / 2;
            double actual;
            actual = Vector.AngleClockwise(a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AngleClockwiseTest4()
        {
            Vector a1 = new Vector(9, -11, 0);
            Vector b1 = new Vector(10, -10, 0);
            Vector c1 = new Vector(2, -9, 0);
            double angle1 = Vector.AngleClockwise(a1, b1, c1);

            Vector a2 = new Vector(9, -11, 0);
            Vector b2 = new Vector(10, -10, 0);
            Vector c2 = new Vector(3, 3, 0);
            double angle2 = Vector.AngleClockwise(a2, b2, c2);
            Assert.IsTrue(angle1 < angle2);

            Vector a3 = new Vector(9, -11, 0);
            Vector b3 = new Vector(10, -10, 0);
            Vector c3 = new Vector(-10, 5, 0);
            double angle3 = Vector.AngleClockwise(a3, b3, c3);
            Assert.IsTrue(angle1 < angle3);

            Vector a4 = new Vector(9, -11, 0);
            Vector b4 = new Vector(10, -10, 0);
            Vector c4 = new Vector(11, -9, 0);
            double angle4 = Vector.AngleClockwise(a4, b4, c4);
            Assert.IsTrue(angle1 < angle4);

        }


        [TestMethod()]
        public void SortTest1()
        {
            List<Vector> list = new List<Vector>();
            list.Add(new Vector(11, -9, 0));
            list.Add(new Vector(5, 5, 0));
            list.Add(new Vector(-10, 5, 0));
            list.Add(new Vector(3, 3, 0));
            list.Add(new Vector(10, -8, 0));
            list.Add(new Vector(10, -10, 0));
            list.Add(new Vector(2, -9, 0));
            List<Vector> expected = new List<Vector>();
            expected.Add(new Vector(10, -10, 0));
            expected.Add(new Vector(2, -9, 0));
            expected.Add(new Vector(-10, 5, 0));
            expected.Add(new Vector(3, 3, 0));
            expected.Add(new Vector(5, 5, 0));
            expected.Add(new Vector(10, -8, 0));
            expected.Add(new Vector(11, -9, 0));
            List<Vector> actual = Vector.Sort(list);
            for (int i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(expected[i].Equals(actual[i]));
            }
        }

        [TestMethod()]
        public void KovexPolygonsTest1()
        {
            List<Vector> list = new List<Vector>();
            list.Add(new Vector(11, -9, 0));
            list.Add(new Vector(5, 5, 0));
            list.Add(new Vector(-10, 5, 0));
            list.Add(new Vector(3, 3, 0));
            list.Add(new Vector(10, -8, 0));
            list.Add(new Vector(10, -10, 0));
            list.Add(new Vector(2, -9, 0));
            List<Vector> expected = new List<Vector>();
            expected.Add(new Vector(10, -10, 0));
            expected.Add(new Vector(2, -9, 0));
            expected.Add(new Vector(-10, 5, 0));
            expected.Add(new Vector(3, 3, 0));
            expected.Add(new Vector(5, 5, 0));
            expected.Add(new Vector(10, -8, 0));
            expected.Add(new Vector(11, -9, 0));
            List<List<Vector>> actual = Vector.KonvexPolygons(list);
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(3, actual[0].Count);
            Assert.AreEqual(3, actual[1].Count);
            Assert.AreEqual(5, actual[2].Count);
        }
    }
}
