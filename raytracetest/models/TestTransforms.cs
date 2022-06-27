namespace RayTraceTest.Models
{
    using RayTrace.Models;
    using RayTrace.Extensions;
    using RayTrace.Transforms;
    using RayTraceTest.Assertors;

    [TestClass]
    public class TestTransforms
    {
        [TestMethod] 
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
        public void InverseScaleVectorSuccess()
        {
            var vector = RayTuple.Vector(-4,6,8);
            var scaleMatrix = ScalingTransform.ScaleMatrix(2,3,4);
            RayTuple.Vector(-2,2,2)
                    .Assert(scaleMatrix.Inverse().Transform(vector));
        }
        [TestMethod]
        public void ReflectPointSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var scaleMatrix = ScalingTransform.ScaleMatrix(-1,1,1);
            RayTuple.Point(-2,3,4)
                    .Assert(scaleMatrix.Transform(point));
        }
        [TestMethod]
        public void RotateXPointSucceeds()
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
        public void InverseRotateXPointSucceeds()
        {
            var point = RayTuple.Point(0,1,0);
            var half_q = RotateXTransform.RotateXMatrix(Math.PI/4).Inverse();
            RayTuple.Point(0,(Math.Sqrt(2)/2),-((Math.Sqrt(2)/2)))
                    .Assert(half_q.Transform(point));
        }
        [TestMethod]
        public void RotateYPointSucceeds()
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
        public void RotateZPointSucceeds()
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
        public void ShearXPointInProportionYSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(1,0,0,0,0,0);

            RayTuple.Point(5,3,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearXPointInProportionZSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,1,0,0,0,0);

            RayTuple.Point(6,3,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearYPointInProportionXSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,0,1,0,0,0);

            RayTuple.Point(2,5,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearYPointInProportionZSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,0,0,1,0,0);

            RayTuple.Point(2,7,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearZPointInProportionXSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,0,0,0,1,0);

            RayTuple.Point(2,3,6)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearZPointInProportionYSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var shearingMatrix = ShearingTransform.ShearingMatrix(0,0,0,0,0,1);

            RayTuple.Point(2,3,7)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void MultiplyPointTranslationMatrixSucceeds()
        {
            var point = RayTuple.Point(-3,4,5);
            var translationMatrix = TranslationTransform.TranslationMatrix(5,-3,2);
            RayTuple.Point(2,1,7)
                    .Assert(translationMatrix.Transform(point));
        }
        [TestMethod]
        public void MultiplyInversePointTranslationMatrixSucceeds()
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
        public void TestPointTransformationsSequenceSucceeds()
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
        public void TestPointTransformationsChainedSequenceSucceeds()
        {
            var point = RayTuple.Point(1,0,1);
            var rotation = RotateXTransform.RotateXMatrix(Math.PI/2);
            var scaling = ScalingTransform.ScaleMatrix(5,5,5);
            var translation = TranslationTransform.TranslationMatrix(10,5,7);

            var t = translation * scaling * rotation;
            RayTuple.Point(15,0,7).Assert(t.Transform(point));
        }
        [TestMethod]
        public void TestScalingSucceeds()
        {
            var ray = new Ray(RayTuple.Point(1,2,3),RayTuple.Vector(0,1,0));
            var transform = ScalingTransform.ScaleMatrix(2,3,4);

            var expectedResult = transform.Transform(ray);
            RayTuple.Point(2,6,12).Assert(expectedResult.Point);
            RayTuple.Vector(0,3,0).Assert(expectedResult.Direction);
        }
        [TestMethod]
        public void TestTranslateSucceeds()
        {
            var ray = new Ray(RayTuple.Point(1,2,3),RayTuple.Vector(0,1,0));
            var translationMatrix = new Matrix(new double[,] {{3,4,5}});

            var expectedResult = ray.Translate(translationMatrix);
            RayTuple.Point(4,6,8).Assert(expectedResult.Point);
            RayTuple.Vector(0,1,0).Assert(expectedResult.Direction);
        }
        [TestInitialize]
        public void Setup()
        {
            Intersections.List.Clear();
        }  
    }
}