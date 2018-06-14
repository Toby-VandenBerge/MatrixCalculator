using InterviewMatrix.Models;
using System;

namespace InterviewMatrix.Commands.AlphaMatrix
{
    public class AlphaMatrixCommand : ICommand<AlphaMatrixSubOptions>
    {
        public AlphaMatrixCommand()
        {
        }

        public void Run(AlphaMatrixSubOptions options)
        {
            var matrix = new Matrix<char>(options.Width, options.Height, options.Dictionary.ToCharArray(), options.TraverseOrientation);

            Console.WriteLine(matrix.Print());
        }
    }
}
