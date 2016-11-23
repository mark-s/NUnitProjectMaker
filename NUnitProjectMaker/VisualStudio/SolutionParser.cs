using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Construction;

namespace NUnitProjectMaker.VisualStudio
{
    internal static class SolutionParser
    {
        public static List<TestProject> GetTestProjects(string solutionFile, string testProjectExtension)
        {
            string pathToUse = "";

            if (Path.IsPathRooted(solutionFile))
                pathToUse = solutionFile;
            else
                pathToUse = Path.Combine(Environment.CurrentDirectory, solutionFile);

            var solutionItems = SolutionFile.Parse(pathToUse);

            return solutionItems.ProjectsInOrder
                                                .Where(p => p.ProjectName.EndsWith(testProjectExtension))
                                                    .Select(p => new TestProject(p.AbsolutePath, p.ProjectName, p.RelativePath) )
                                                    .ToList();

        }
    }
}