using CommandLine;
using CommandLine.Text;
using InterviewMatrix.Commands.AlphaMatrix;
using InterviewMatrix.Models;

namespace InterviewMatrix.Commands
{
    public class CommandOptions
    {
        [VerbOption("AlphaMatrix", HelpText = "Create a NxM matrix populated with alpha characters")]
        public AlphaMatrixSubOptions AlphaMatrixSubOptions { get; set; }

        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            return HelpText.AutoBuild(this, verb);
        }        
    }

    public abstract class BaseOptions
    {
        [Option('w', "Width", Required = true, HelpText = "Width of the matrix")]
        public int Width { get; set; }

        [Option('h', "Height", Required = true, HelpText = "Height of the matrix")]
        public int Height { get; set; }

        [Option('t', "Traverse", Required = false, HelpText = "Traverse Orientation. One of [TopToBottom]")]
        public TraverseOrientation TraverseOrientation { get; set; }
    }
}
