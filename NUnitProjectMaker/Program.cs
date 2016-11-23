using System;
using NUnitProjectMaker.CommandLine;
using NUnitProjectMaker.Output;
using NUnitProjectMaker.VisualStudio;


namespace NUnitProjectMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            string errorMessage;

            if (ArgsParser.Validate(args, out errorMessage) != true)
            {
                Console.WriteLine(errorMessage);
                Environment.ExitCode = 1; // error
                return;
            }

            try
            {
                // parse the args
                var programArgs =ArgsParser.Parse(args);

                // parse the solution file
                var testProjects = SolutionParser.GetTestProjects(programArgs.SolutionFile, programArgs.TestsProjectExtension);

                // write to nunit project file
                NunitWriter.WriteProjectFile(testProjects, programArgs);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.ExitCode = 1; // error
            }

            
            Environment.ExitCode = 0; // success
        }


    }
}
