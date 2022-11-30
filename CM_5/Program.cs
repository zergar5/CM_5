using CM_5.IO;
using CM_5.Models;
using CM_5.Tools;

var matrixI = new MatrixIO("../CM_5/Input/Diagonal/");
var vectorI = new VectorIO("../CM_5/Input/Diagonal/");
var parametersI = new ParametersIO("../CM_5/Input/");
var eigenvaluesO = new EigenvaluesIO("../CM_5/Output/");

var startVector = vectorI.Read("vector.txt");

var matrix = matrixI.Read("matrixB.txt");

var hilbertMatrix = new Matrix();
hilbertMatrix.GenerateHilbert(startVector.Count);

var (eps, maxIter) = parametersI.ReadMethodParameters("parameters.txt");

var maxEigenvalue = EigenvalueFinder.FindMax(in matrix, in startVector, eps, maxIter);
var minEigenvalue = EigenvalueFinder.FindMin(in matrix, in startVector, eps, maxIter);

eigenvaluesO.Write(maxEigenvalue, minEigenvalue, "output.txt");