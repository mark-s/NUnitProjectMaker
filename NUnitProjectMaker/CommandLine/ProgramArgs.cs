namespace NUnitProjectMaker.CommandLine
{
    public struct ProgramArgs
    {
        public string BasePath { get; }
        public string SolutionFile { get; }
        public string TestsProjectExtension { get; }
        public string OutputFileName { get; }

        public ProgramArgs(string basePath, string solutionFile, string testsProjectExtension, string outputFileName)
        {
            BasePath = basePath;
            SolutionFile = solutionFile;
            TestsProjectExtension = testsProjectExtension;
            OutputFileName = outputFileName;
        }
    }
}
