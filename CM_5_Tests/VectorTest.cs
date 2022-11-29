using CM_5.Models;

namespace CM_5_Tests
{
    public class Tests
    {
        private Vector _vector;

        [SetUp]
        public void Setup()
        {
            var vector = new[] { 1.0, 2.0, 3.0 };
            _vector = new Vector(vector);
        }

        [TestCase(3.741657386773941385)]
        public void CalcNormTest(double actual)
        {
            var expected = _vector.CalcNorm();
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}