using CM_5.Models;

namespace CM_5_Tests;

public class MatrixTest
{
    private Matrix _matrix;

    [SetUp]
    public void Setup()
    {
        var matrix = new[,]
        {
            { 5.0, 11.0, 17.0 },
            { 11.0, 25, 39.0 },
            { 17.0, 39.0, 60.0 }
        };
        _matrix = new Matrix(matrix);
    }

    [Test]
    public void LDUDecompositionTest()
    {
        var actual = new[,]
        {
            { 5.0, 2.2, 3.4 },
            { 2.2, 0.79999999999999716, 2.0000000000000089 },
            { 3.4, 2.0, -1.0 }
        };
        _matrix.LDUDecomposition();
        CollectionAssert.AreEqual(_matrix.MatrixElements, actual);
    }

    [Test]
    public void GenerateHilbertTest()
    {
        var actual = new[,]
        {
            { 1.0, 1.0/2, 1.0/3 },
            { 1.0/2, 1.0/3, 1.0/4 },
            { 1.0/3, 1.0/4, 1.0/5 }
        };
        _matrix.GenerateHilbert(_matrix.CountRows());
        CollectionAssert.AreEqual(_matrix.MatrixElements, actual);
    }
}