﻿using System;
using System.Linq;
using System.Linq.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

namespace ExpressionToDynamicLinqUnitTest.ExpressionString
{
    [TestClass]
    public class AdditiveSubtractTest
    {
        //[TestMethod]
        //public void AdditiveSubtractString()
        //{
        //    var value = "a1";
        //    Expression<Func<Model1, bool>> expression1 = f => (value - f.Name=="");
        //    var s1 = expression1.ToExpressionString();
        //    Expression<Func<Model1, bool>> expression2 = f => ("a1" - f.Name == "");
        //    var s2 = expression2.ToExpressionString();
        //    Expression<Func<Model1, bool>> expression3 = f => ("a1" - f.B5.Name == "");
        //    var s3 = expression3.ToExpressionString();
        //    Expression<Func<Model1, bool>> expression4 = f => (f.Name - f.B5.Name == "");
        //    var s4 = expression4.ToExpressionString();
        //    Assert.AreEqual(s1, "(\"a1\" - Name)");
        //    Assert.AreEqual(s2, "(\"a1\" - Name)");
        //    Assert.AreEqual(s3, "(\"a1\" - B5.Name)");
        //    Assert.AreEqual(s4, "(Name - B5.Name)");

        //    var models = new Model1[] { };
        //    var m1 = models.Where(s1).ToArray();
        //    var m2 = models.Where(s2).ToArray();
        //    var m3 = models.Where(s3).ToArray();
        //    var m4 = models.Where(s4).ToArray();
        //}
        [TestMethod]
        public void AdditiveSubtractInt()
        {
            var value = 1;
            Expression<Func<Model1, bool>> expression1 = f => (value - f.Age == 5);
            var s1 = expression1.ToExpressionString();
            Expression<Func<Model1, bool>> expression2 = f => (1 - f.Age == 5);
            var s2 = expression2.ToExpressionString();
            Expression<Func<Model1, bool>> expression3 = f => (1 - f.B5.Age == 5);
            var s3 = expression3.ToExpressionString();
            Expression<Func<Model1, bool>> expression4 = f => (f.Age - f.B5.Age == 5);
            var s4 = expression4.ToExpressionString();
            Assert.AreEqual(s1, "((1 - (it).Age) == 5)");
            Assert.AreEqual(s2, "((1 - (it).Age) == 5)");
            Assert.AreEqual(s3, "((1 - (it).B5.Age) == 5)");
            Assert.AreEqual(s4, "(((it).Age - (it).B5.Age) == 5)");

            var models = new Model1[] { };
            var m1 = models.Where(s1).ToArray();
            var m2 = models.Where(s2).ToArray();
            var m3 = models.Where(s3).ToArray();
            var m4 = models.Where(s4).ToArray();
        }
        [TestMethod]
        public void AdditiveSubtractDecimal()
        {
            var value = 1.11M;
            Expression<Func<Model1, bool>> expression1 = f => (value - f.B1 == 5M);
            var s1 = expression1.ToExpressionString();
            Expression<Func<Model1, bool>> expression2 = f => (1.11M - f.B1 == 5M);
            var s2 = expression2.ToExpressionString();
            Expression<Func<Model1, bool>> expression3 = f => (1.11M - f.B5.B1 == 5M);
            var s3 = expression3.ToExpressionString();
            Expression<Func<Model1, bool>> expression4 = f => (f.B1 - f.B5.B1 == 5M);
            var s4 = expression4.ToExpressionString();
            Assert.AreEqual(s1, "((1.11 - (it).B1) == 5)");
            Assert.AreEqual(s2, "((1.11 - (it).B1) == 5)");
            Assert.AreEqual(s3, "((1.11 - (it).B5.B1) == 5)");
            Assert.AreEqual(s4, "(((it).B1 - (it).B5.B1) == 5)");

            var models = new Model1[] { };
            var m1 = models.Where(s1).ToArray();
            var m2 = models.Where(s2).ToArray();
            var m3 = models.Where(s3).ToArray();
            var m4 = models.Where(s4).ToArray();
        }

        [TestMethod]
        public void AdditiveSubtractDateTime()
        {
            var value = new System.DateTime(2012, 1, 1);
            var value2 = new TimeSpan(1, 0, 0);

            Expression<Func<Model1, bool>> expression1 = f => (value - value2 <= f.B2);
            var s1 = expression1.ToExpressionString();
            Expression<Func<Model1, bool>> expression2 = f => (new System.DateTime(2012, 1, 1) - new TimeSpan(1, 0, 0) <= f.B2);
            var s2 = expression2.ToExpressionString();
            Expression<Func<Model1, bool>> expression2_1 = f => (System.DateTime.Now - new TimeSpan(1, 0, 0) <= f.B2);
            var s2_1 = expression2_1.ToExpressionString();
            Expression<Func<Model1, bool>> expression3 = f => (new System.DateTime(2012, 1, 1) - new TimeSpan(1, 0, 0) <= f.B5.B2);
            var s3 = expression3.ToExpressionString();
            Expression<Func<Model1, bool>> expression4 = f => (f.B2 - new TimeSpan(1, 0, 0) <= f.B5.B2);
            var s4 = expression4.ToExpressionString();
            Assert.AreEqual(s1, "((DateTime(634609728000000000) - TimeSpan(36000000000)) <= (it).B2)");
            Assert.AreEqual(s2, "((DateTime(2012,1,1) - TimeSpan(1,0,0)) <= (it).B2)");
            //Assert.AreEqual(s2_1, "(1.11 >= B2)");
            Assert.AreEqual(s3, "((DateTime(2012,1,1) - TimeSpan(1,0,0)) <= (it).B5.B2)");
            Assert.AreEqual(s4, "(((it).B2 - TimeSpan(1,0,0)) <= (it).B5.B2)");

            var models = new Model1[] { };
            var m1 = models.Where(s1).ToArray();
            var m2 = models.Where(s2).ToArray();
            var m3 = models.Where(s3).ToArray();
            var m4 = models.Where(s4).ToArray();
        }
        //[TestMethod]
        //public void AdditiveSubtractDateTimeOffset()
        //{
        //    var value = new System.DateTimeOffset(new System.DateTime(2012, 1, 1));
        //    var value2 = new TimeSpan(1, 0, 0);
        //    Expression<Func<Model1, bool>> expression1 = f => (value - value2 <= f.B3);
        //    var s1 = expression1.ToExpressionString();
        //    Expression<Func<Model1, bool>> expression2 = f => (new System.DateTimeOffset(new System.DateTime(2012, 1, 1)) - new TimeSpan(1, 0, 0) <= f.B3);
        //    var s2 = expression2.ToExpressionString();
        //    Expression<Func<Model1, bool>> expression2_1 = f => (System.DateTimeOffset.Now - new TimeSpan(1, 0, 0) <= f.B3);
        //    var s2_1 = expression2_1.ToExpressionString();
        //    Expression<Func<Model1, bool>> expression3 = f => (new System.DateTimeOffset(new System.DateTime(2012, 1, 1)) - new TimeSpan(1, 0, 0) <= f.B5.B3);
        //    var s3 = expression3.ToExpressionString();
        //    Expression<Func<Model1, bool>> expression4 = f => (f.B2 - new TimeSpan(1, 0, 0) <= f.B5.B2);
        //    var s4 = expression4.ToExpressionString();
        //    Assert.AreEqual(s1, "(DateTimeOffset(DateTime(634609728000000000)) <= B3)");
        //    Assert.AreEqual(s2, "(DateTimeOffset(DateTime(2012,1,1)) <= B3)");
        //    //Assert.AreEqual(s2_1, "(1.11 >= B2)");
        //    Assert.AreEqual(s3, "(DateTimeOffset(DateTime(2012,1,1)) <= B5.B3)");
        //    Assert.AreEqual(s4, "(B2 <= B5.B2)");

        //    var models = new Model1[] { };
        //    var m1 = models.Where(s1).ToArray();
        //    var m2 = models.Where(s2).ToArray();
        //    var m3 = models.Where(s3).ToArray();
        //    var m4 = models.Where(s4).ToArray();
        //}
    }
}
