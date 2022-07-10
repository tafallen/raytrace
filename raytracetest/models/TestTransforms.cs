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
            var point = new Point(-4,6,8);
            var transform = Transformation.Scale(2,3,4);

            new Point(-8,18,32)
                    .Assert(transform.Transform(point));
        }
        [TestMethod]
        public void ScaleVectorSuccess()
        {
            var vector = new Vector(-4,6,8);
            var scaleMatrix = Transformation.Scale(2,3,4);
            new Vector(-8,18,32)
                    .Assert(scaleMatrix.Transform(vector));
        }
        [TestMethod]
        public void InverseScaleVectorSuccess()
        {
            var vector = new Vector(-4,6,8);
            var scaleMatrix = Transformation.Scale(2,3,4);
            new Vector(-2,2,2)
                    .Assert(scaleMatrix.Inverse().Transform(vector));
        }
        [TestMethod]
        public void ReflectPointSucceeds()
        {
            var point = new Point(2,3,4);
            var scaleMatrix = Transformation.Scale(-1,1,1);
            new Point(-2,3,4)
                    .Assert(scaleMatrix.Transform(point));
        }
        [TestMethod]
        public void RotateXPointSucceeds()
        {
            var point = new Point(0,1,0);
            var half_q = Transformation.RotateX(Math.PI/4);
            var full_q = Transformation.RotateX(Math.PI/2);

            new Point(0,(Math.Sqrt(2)/2),(Math.Sqrt(2)/2))
                    .Assert(half_q.Transform(point));
            new Point(0,0,1)
                    .Assert(full_q.Transform(point));
        }
        [TestMethod]
        public void InverseRotateXPointSucceeds()
        {
            var point = new Point(0,1,0);
            var half_q = Transformation.RotateX(Math.PI/4).Inverse();
            new Point(0,(Math.Sqrt(2)/2),-((Math.Sqrt(2)/2)))
                    .Assert(half_q.Transform(point));
        }
        [TestMethod]
        public void RotateYPointSucceeds()
        {
            var point = new Point(0,0,1);
            var half_q = Transformation.RotateY(Math.PI/4);
            var full_q = Transformation.RotateY(Math.PI/2);
            new Point((Math.Sqrt(2)/2),0,(Math.Sqrt(2)/2))
                    .Assert(half_q.Transform(point));
            new Point(1,0,0)
                    .Assert(full_q.Transform(point));
        }
        [TestMethod]
        public void RotateZPointSucceeds()
        {
            var point = new Point(0,1,0);
            var half_q = Transformation.RotateZ(Math.PI/4);
            var full_q = Transformation.RotateZ(Math.PI/2);
            new Point(-(Math.Sqrt(2)/2),(Math.Sqrt(2)/2),0)
                    .Assert(half_q.Transform(point));
            new Point(-1,0,0)
                    .Assert(full_q.Transform(point));

        }
        [TestMethod]
        public void ShearXPointInProportionYSucceeds()
        {
            var point = new Point(2,3,4);
            var shearingMatrix = Transformation.Shearing(1,0,0,0,0,0);

            new Point(5,3,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearXPointInProportionZSucceeds()
        {
            var point = new Point(2,3,4);
            var shearingMatrix = Transformation.Shearing(0,1,0,0,0,0);

            new Point(6,3,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearYPointInProportionXSucceeds()
        {
            var point = new Point(2,3,4);
            var shearingMatrix = Transformation.Shearing(0,0,1,0,0,0);

            new Point(2,5,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearYPointInProportionZSucceeds()
        {
            var point = new Point(2,3,4);
            var shearingMatrix = Transformation.Shearing(0,0,0,1,0,0);

            new Point(2,7,4)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearZPointInProportionXSucceeds()
        {
            var point = new Point(2,3,4);
            var shearingMatrix = Transformation.Shearing(0,0,0,0,1,0);

            new Point(2,3,6)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void ShearZPointInProportionYSucceeds()
        {
            var point = new Point(2,3,4);
            var shearingMatrix = Transformation.Shearing(0,0,0,0,0,1);

            new Point(2,3,7)
                    .Assert(shearingMatrix.Transform(point));
        }
        [TestMethod]
        public void MultiplyPointTranslationMatrixSucceeds()
        {
            var point = new Point(-3,4,5);
            var translationMatrix = Transformation.Translation(5,-3,2);
            new Point(2,1,7)
                    .Assert(translationMatrix.Transform(point));
        }
        [TestMethod]
        public void MultiplyInversePointTranslationMatrixSucceeds()
        {
            var point = new Point(-3,4,5);
            var translationMatrix = Transformation.Translation(5,-3,2).Inverse();
            new Point(-8,7,3)
                    .Assert(translationMatrix.Transform(point));
        }
        [TestMethod]
        public void MultiplyVectorTranslationMatrixFails()
        {
            var vector = new Vector(-3,4,5);
            var translationMatrix = Transformation.Translation(5,-3,2);
            new Vector(-3,4,5)
                    .Assert(translationMatrix.Transform(vector));
        }
        [TestMethod]
        public void TestPointTransformationsSequenceSucceeds()
        {
            var point = new Point(1,0,1);
            var rotation = Transformation.RotateX(Math.PI/2);
            var scaling = Transformation.Scale(5,5,5);
            var translation = Transformation.Translation(10,5,7);

            var p2 = rotation.Transform(point);
            new Point(1,-1,0).Assert(p2);

            var p3 = scaling.Transform(p2);
            new Point(5,-5,0).Assert(p3);

            var p4 = translation.Transform(p3);
            new Point(15,0,7).Assert(p4);
        }
        public void TestPointTransformationsChainedSequenceSucceeds()
        {
            var point = new Point(1,0,1);
            var rotation = Transformation.RotateX(Math.PI/2);
            var scaling = Transformation.Scale(5,5,5);
            var translation = Transformation.Translation(10,5,7);

            var t = translation * scaling * rotation;
            new Point(15,0,7).Assert(t.Transform(point));
        }
        [TestMethod]
        public void TestScalingSucceeds()
        {
            var ray = new Ray(new Point(1,2,3),new Vector(0,1,0));
            var transform = Transformation.Scale(2,3,4);

            var expectedResult = transform.Transform(ray);
            new Point(2,6,12).Assert(expectedResult.Point);
            new Vector(0,3,0).Assert(expectedResult.Direction);
        }
        [TestMethod]
        public void TestTranslateSucceeds()
        {
            var ray = new Ray(new Point(1,2,3),new Vector(0,1,0));
            var transform = Transformation.Translation(3,4,5);

            var expectedResult = transform.Transform(ray);
            new Point(4,6,8).Assert(expectedResult.Point);
            new Vector(0,1,0).Assert(expectedResult.Direction);
        }
        [TestMethod]
        public void TransformationMatrixForDefaultOrientation()
        {
            var from = new Point(0, 0, 0);
            var to   = new Point(0, 0,-1);
            var up   = new Vector(0, 1, 0);

            var transform = ViewTransform.ViewTransformMatrix(from, to, up);

            transform.Matrix.Assert(Matrix.IdentityMatrix);
        }
        [Ignore]
        [TestMethod]
        public void TransformationMatrixPosZDirection()
        {
            var from = new Point(0, 0, 0);
            var to   = new Point(0, 0, 1);
            var up   = new Vector(0, 1, 0);

            var transform = ViewTransform.ViewTransformMatrix(from, to, up);
            
            Transformation.Scale(-1,-1,-1).Matrix.Assert(transform.Matrix);
        }
        [Ignore]
        [TestMethod]
        public void TransformationMovesWorld()
        {
            var from = new Point(0, 0, 8);
            var to   = new Point(0, 0, 0);
            var up   = new Vector(0, 1, 0);

            var transform = ViewTransform.ViewTransformMatrix(from, to, up);

            Transformation.Scale( 0, 0,-8).Matrix.Assert(transform.Matrix);
        }
        [TestMethod]
        public void TransformationArbitrary()
        {
            var from = new Point(1, 3, 2);
            var to   = new Point(4, -2, 8);
            var up   = new Vector(1, 1, 0);

            var transform = ViewTransform.ViewTransformMatrix(from, to, up);

            var expected = new Matrix(new double[,] {
                {-0.50709, 0.50709,  0.67612, -2.36643},
 	            { 0.76772, 0.60609,  0.12122, -2.82843},
 	            {-0.35857, 0.59761, -0.71714,  0.00000},
 	            { 0.00000, 0.00000,  0.00000,  1.00000}});
            expected.Assert(transform.Matrix);
        }
    }
}