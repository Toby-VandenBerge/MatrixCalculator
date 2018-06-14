using InterviewMatrix.Commands.AlphaMatrix;
using InterviewMatrix.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewMatrix.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var options = new AlphaMatrixSubOptions
            {
                Width = 2,
                Height = 2,
                TraverseOrientation = TraverseOrientation.TopToBottom
            };
            var matrix = new Matrix<char>(options.Width, options.Height, options.Dictionary.ToCharArray(), options.TraverseOrientation);

            var output = matrix.Print();

            Assert.IsTrue(output == "A,B,C,D");
        }
    }
}
