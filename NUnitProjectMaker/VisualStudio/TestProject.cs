using System.IO;

namespace NUnitProjectMaker.VisualStudio
{
    internal struct TestProject
    {
        public string AbsolutePath { get; }

        public string ProjectName { get; }

        public string RelativePath { get;  }

        public string ReleaseDllPath { get; }

        public TestProject(string absolutePath, string projectName, string relativePath)
        {
            AbsolutePath = absolutePath;
            ProjectName = projectName;
            RelativePath = relativePath;

            ReleaseDllPath = Path.Combine(ProjectName, @"bin\Release", ProjectName + ".dll");

        }
    }
}