namespace RayTraceTest.Models
{
    using RayTrace.Models;
    using RayTrace.Extensions;
    using RayTrace.Transforms;
    using RayTraceTest.Assertors;

    [TestClass]
    public class TestRayTraceTuple
    {
        [TestMethod]
        public void TestPoint()
        {
            var tuple = RayTuple.Point(0.1, 1.3, -4.3);

            tuple.Assert(0.1, 1.3, -4.3, RayTupleType.Point);
        }
        [TestMethod]
        public void TestVector()
        {
            var tuple = RayTuple.Vector(0.1, 1.3, -4.3);

            tuple.Assert(0.1, 1.3, -4.3, RayTupleType.Vector);
        }
        [TestMethod]
        public void TestAddPointVectorSucceeds()
        {
            var point = RayTuple.Point(3,-2,5);
            var vector = RayTuple.Vector(-2,3,1);

            RayTuple.Point(1,1,6)
                    .Assert(point + vector);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Both Tuples may not be Point types")]
        public void TestAddPointPointFails()
        {
            var point = RayTuple.Point(3,-2,5);
            var vector = RayTuple.Point(-2,3,1);

            RayTuple.Point(1,1,6)
                    .Assert(point + vector);
        }
        [TestMethod]
        public void TestAddVectorVectorFails()
        {
            var vector1 = RayTuple.Vector(3,-2,5);
            var vector2 = RayTuple.Vector(-2,3,1);

            RayTuple.Vector(1,1,6)
                    .Assert(vector1 + vector2);
        }
        [TestMethod]
        public void TestSubtractPointPointSucceeds()
        {
            var point1 = RayTuple.Point(3,2,1);
            var point2 = RayTuple.Point(5,6,7);

            RayTuple.Vector(-2,-4,-6)
                    .Assert(point1-point2);
        }
        [TestMethod]
        public void TestSubtractPointVectorSuccess()
        {
            var point = RayTuple.Point(3,2,1);
            var vector = RayTuple.Vector(5,6,7);

            RayTuple.Point(-2,-4,-6)
                    .Assert(point-vector);
        }
        [TestMethod]
        public void TestSubtractVectorVectorSuccess()
        {
            var vector1 = RayTuple.Vector(3,2,1);
            var vector2 = RayTuple.Vector(5,6,7);

            RayTuple.Vector(-2,-4,-6)
                    .Assert(vector1 - vector2);
        }
        [TestMethod]
        public void TestNegateVectorSuccess()
        {
            var vector = RayTuple.Vector(1,-2,3);

            RayTuple.Vector(-1,2,-3)
                    .Assert(!vector);
        }
        [TestMethod]
        public void TestScalarMultiplicationSucceeds()
        {
            var vector = RayTuple.Vector(1,-2,3);

            RayTuple.Vector(3.5, -7, 10.5)
                    .Assert(vector * 3.5);
        }
        [TestMethod]
        public void TestScalarFractionalMultiplicationSucceeds()
        {
            var vector = RayTuple.Vector(1,-2,3);

            RayTuple.Vector(0.5, -1, 1.5)
                    .Assert(vector * 0.5);
        }
        [TestMethod]
        public void TestScalarDivisionSucceeds()
        {
            var vector = RayTuple.Vector(1,-2,3);

            RayTuple.Vector(0.5, -1, 1.5)
                    .Assert(vector / 2);
        }
        [TestMethod]
        public void TestMagnitudeSucceeds()
        {
            var vector = RayTuple.Vector(0,1,0);

            var expectedResult = 1;

            Assert.AreEqual(expectedResult, vector.Magnitude());
        }
        [TestMethod]
        public void TestMagnitudeNegValuesSucceeds()
        {
            var vector = RayTuple.Vector(-1,2,-3);

            var expectedResult = Math.Sqrt(14);

            Assert.AreEqual(expectedResult, vector.Magnitude());
        }
        [TestMethod]
        public void TestNormalisationSucceeds()
        {
            var tuple = RayTuple.Vector(4,0,0);

            RayTuple.Vector(1,0,0)
                    .Assert(tuple.Normalise());
        }
        [TestMethod]
        public void TestFractionalNormalisationSucceeds()
        {
            var tuple = RayTuple.Vector(1,2,3);
 
            RayTuple.Vector(0.2672612419124244,0.5345224838248488,0.8017837257372732)
                    .Assert(tuple.Normalise());
        }
        [TestMethod]
        public void TestDotProductSucceeds()
        {
            var vector1 = RayTuple.Vector(1,2,3);
            var vector2 = RayTuple.Vector(2,3,4);

            Assert.AreEqual(20, vector1.DotProduct(vector2));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "DotProduct() - Both tuples must be vectors")]
        public void TestDotProductPointFails()
        {
            var vector1 = RayTuple.Point(1,2,3);
            var vector2 = RayTuple.Vector(2,3,4);

            Assert.AreEqual(20, vector1.DotProduct(vector2));
        }
        [TestMethod]
        public void TestCrossProductSucceeds()
        {
            var vector1 = RayTuple.Vector(1,2,3);
            var vector2 = RayTuple.Vector(2,3,4);

            RayTuple.Vector(-1,2,-1)
                    .Assert(vector1.CrossProduct(vector2));

            RayTuple.Vector(1,-2,1)
                    .Assert(vector2.CrossProduct(vector1));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "CrossProduct() - Both tuples must be vectors")]
        public void TestCrossProductPointFails()
        {
            var vector1 = RayTuple.Point(1,2,3);
            var vector2 = RayTuple.Vector(2,3,4);

            RayTuple.Vector(-1,2,-1)
                    .Assert(vector1.CrossProduct(vector2));

            RayTuple.Vector(1,-2,1)
                    .Assert(vector2.CrossProduct(vector1));
        }
        [TestMethod] // TODO: Move to transform tests class
        public void ScalePointSuccess()
        {
            var point = RayTuple.Point(-4,6,8);
            var transform = ScalingTransform.ScaleMatrix(2,3,4);

            RayTuple.Point(-8,18,32)
                    .Assert(transform.Transform(point));
        }
        [TestMethod]
        public void ScaleVectorSuccess()
        {
            var vector = RayTuple.Vector(-4,6,8);
            var scaleMatrix = ScalingTransform.ScaleMatrix(2,3,4);
            RayTuple.Vector(-8,18,32)
                    .Assert(scaleMatrix.Transform(vector));
        }
        [TestMethod]
        public void ScaleInverseVectorSuccess()
        {
            var vector = RayTuple.Vector(-4,6,8);
            var scaleMatrix = ScalingTransform.ScaleMatrix(2,3,4);
            RayTuple.Vector(-2,2,2)
                    .Assert(scaleMatrix.Inverse().Transform(vector));
        }
        [TestMethod]
        public void ReflectionSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var scaleMatrix = ScalingTransform.ScaleMatrix(-1,1,1);
            RayTuple.Point(-2,3,4)
                    .Assert(scaleMatrix.Transform(point));
        }
        [TestMethod]
        public void RotateXSucceeds()
        {
            var point = RayTuple.Point(0,1,0);
            var half_q = RotateXTransform.RotateXMatrix(Math.PI/4);
            var full_q = RotateXTransform.RotateXMatrix(Math.PI/2);

            RayTuple.Point(0,(Math.Sqrt(2)/2),(Math.Sqrt(2)/2))
                    .Assert(half_q.Transform(point));
            RayTuple.Point(0,0,1)
                    .Assert(full_q.Transform(point));
        }
        [TestMethod]
        public void InverseRotateXSucceeds()
        {
            var point = RayTuple.Point(0,1,0);
            var half_q = RotateXTransform.RotateXMatrix(Math.PI/4).Inverse();
            RayTuple.Point(0,(Math.Sqrt(2)/2),-((Math.Sqrt(2)/2)))
                    .Assert(half_q.Transform(point));
        }
        [TestMethod]
        public void RotateYSucceeds()
        {
            var point = RayTuple.Point(0,0,1);
            var half_q = RotateYTransform.RotateYMatrix(Math.PI/4);
            var full_q = RotateYTransform.RotateYMatrix(Math.PI/2);
            RayTuple.Point((Math.Sqrt(2)/2),0,(Math.Sqrt(2)/2))
                    .Assert(half_q.Transform(point));
            RayTuple.Point(1,0,0)
                    .Assert(full_q.Transform(point));
        }
        [TestMethod]
        public void RotateZSucceeds()
        {
            var point = RayTuple.Point(0,1,0);
            var half_q = RotateZTransform.RotateZMatrix(Math.PI/4);
            var full_q = RotateZTransform.RotateZMatrix(Math.PI/2);
            RayTuple.Point(-(Math.Sqrt(2)/2),(Math.Sqrt(2)/2),0)
                    .Assert(half_q.Transform(point));
            RayTuple.Point(-1,0,0)
                    .Assert(full_q.Transform(point));

        }
        [TestMethod]
        public void ShearXInProportionYSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(1,0,0,0,0,0);

            RayTuple.Point(5,3,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearXInProportionZSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,1,0,0,0,0);

            RayTuple.Point(6,3,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearYInProportionXSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,0,1,0,0,0);

            RayTuple.Point(2,5,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearYInProportionZSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,0,0,1,0,0);

            RayTuple.Point(2,7,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearZInProportionXSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,0,0,0,1,0);

            RayTuple.Point(2,3,6)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearZInProportionYSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,0,0,0,0,1);

            RayTuple.Point(2,3,7)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void MultiplyTranslationMatrixSucceeds()
        {
            var point = RayTuple.Point(-3,4,5);
            var translationMatrix = TranslationTransform.TranslationMatrix(5,-3,2);
            RayTuple.Point(2,1,7)
                    .Assert(translationMatrix.Transform(point));
        }
        [TestMethod]
        public void MultiplyInverseTranslationMatrixSucceeds()
        {
            var point = RayTuple.Point(-3,4,5);
            var translationMatrix = TranslationTransform.TranslationMatrix(5,-3,2).Inverse();
            RayTuple.Point(-8,7,3)
                    .Assert(translationMatrix.Transform(point));
        }
        [TestMethod]
        public void MultiplyVectorTranslationMatrixFails()
        {
            var vector = RayTuple.Vector(-3,4,5);
            var translationMatrix = TranslationTransform.TranslationMatrix(5,-3,2);
            RayTuple.Vector(-3,4,5)
                    .Assert(translationMatrix.Transform(vector));
        }
        [TestMethod]
        public void TestTransformationsSequenceSucceeds()
        {
            var point = RayTuple.Point(1,0,1);
            var rotation = RotateXTransform.RotateXMatrix(Math.PI/2);
            var scaling = ScalingTransform.ScaleMatrix(5,5,5);
            var translation = TranslationTransform.TranslationMatrix(10,5,7);

            var p2 = rotation.Transform(point);
            RayTuple.Point(1,-1,0).Assert(p2);

            var p3 = scaling.Transform(p2);
            RayTuple.Point(5,-5,0).Assert(p3);

            var p4 = translation.Transform(p3);
            RayTuple.Point(15,0,7).Assert(p4);
        }
        public void TestTransformationsChainedSequenceSucceeds()
        {
            var point = RayTuple.Point(1,0,1);
            var rotation = RotateXTransform.RotateXMatrix(Math.PI/2);
            var scaling = ScalingTransform.ScaleMatrix(5,5,5);
            var translation = TranslationTransform.TranslationMatrix(10,5,7);

            var t = translation * scaling * rotation;
            RayTuple.Point(15,0,7).Assert(t.Transform(point));
        }
    }
}

