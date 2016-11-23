using System;
using System.IO;

namespace NUnitProjectMaker.CommandLine
{
    public static class ArgsParser
    {
        private const int ARG_COUNT_REQUIRED = 4;

        private const int SOLUTION_FILE_ARG_INDEX = 0;
        private const int BASE_PATH_ARG_INDEX = 1;
        private const int TESTS_EXTENSION_ARG_INDEX = 2;
        private const int NUNIT_PROJECT_OUTPUT_FILENAME_ARG_INDEX = 3;

        public static ProgramArgs Parse(string[] args)
        {
            var basePath = GetBasePath(args);

            var solutionFile = GetSolutionFile(args);

            var testsProjectExtension = GetTestExtension(args);

            var outPutFileName = GetNunitOutputFileName(args);

            return new ProgramArgs(basePath, solutionFile, testsProjectExtension, outPutFileName);

        }

        public static bool Validate(string[] args, out string message)
        {
            message = string.Empty;
            var isValid = false;

            if (args == null || args.Length != ARG_COUNT_REQUIRED)
                message = $"Usage: {AppDomain.CurrentDomain.FriendlyName} src c:\\projects\\project.sln .Tests tests.nunit";
            else
                isValid = true;

            return isValid;
        }

        private static string GetSolutionFile(string[] args)
        {
            var solutionFilePath = args[SOLUTION_FILE_ARG_INDEX];

            if (solutionFilePath.ToUpperInvariant().EndsWith(".SLN") == false)
                throw new ArgumentNullException(nameof(args), @"Provide full path to the .sln file (eg: c:\projects\project.sln)");

            if (File.Exists(solutionFilePath))
                return solutionFilePath;
            else
                throw new FileNotFoundException($"Cannot find solution File {solutionFilePath}");

        }

        private static string GetBasePath(string[] args)
        {
            var basePath = args[BASE_PATH_ARG_INDEX];

            if (basePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                throw new ArgumentException($"Invalid base path [{basePath}]");

            return basePath;
        }

        private static string GetNunitOutputFileName(string[] args)
        {
            var outputFileName = args[NUNIT_PROJECT_OUTPUT_FILENAME_ARG_INDEX];

            if (outputFileName.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                throw new ArgumentException($"Invalid output file name [{outputFileName}]");

            return outputFileName;
        }

        private static string GetTestExtension(string[] args)
        {
            var testExtension = args[TESTS_EXTENSION_ARG_INDEX];

            if(string.IsNullOrEmpty(testExtension) || testExtension.Contains(".") == false)
                throw new ArgumentException($"Invalid test extension [{testExtension}] - example .Tests for projects like Abc.Xyz.Tests");

            return testExtension;
        }
    }
}
