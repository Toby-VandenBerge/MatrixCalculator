using Autofac;
using CommandLine;
using InterviewMatrix.Commands;
using InterviewMatrix.IoC;
using System;

namespace InterviewMatrix
{
    class Program
    {
        private static object _command;

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<InterviewMatrixModule>();
            var container = builder.Build();

            var parser = new Parser(config =>
            {
                config.MutuallyExclusive = true;
                config.HelpWriter = Parser.Default.Settings.HelpWriter;
            });

            if (!parser.ParseArguments(args, new CommandOptions(),
                (verb, subOptions) =>
                {
                    if (subOptions == null)
                    {
                        Console.WriteLine($"Error: Invalid command line args passed for command {verb}");
                        Environment.Exit(Parser.DefaultExitCodeFail);
                    }

                    var generic = typeof(ICommand<>);
                    Type[] typeArgs = { subOptions.GetType() };
                    var typeToBeConstructed = generic.MakeGenericType(typeArgs);

                    _command = container.Resolve(typeToBeConstructed);

                    var commandType = _command.GetType();
                    var method = commandType.GetMethod("Run");
                    method.Invoke(_command, new[] { subOptions });
                }))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
            }

            Environment.Exit(0);
        }
    }
}
