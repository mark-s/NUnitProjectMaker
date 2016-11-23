using System.Collections.Generic;
using System.Xml;
using NUnitProjectMaker.CommandLine;
using NUnitProjectMaker.VisualStudio;

namespace NUnitProjectMaker.Output
{
    internal class NunitWriter
    {
        public static void WriteProjectFile(IEnumerable<TestProject> testProjects, ProgramArgs programArgs)
        {
            var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };

            using (var writer = XmlWriter.Create(programArgs.OutputFileName, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("NUnitProject");

                writer.WriteStartElement("Settings");
                writer.WriteAttributeString("activeconfig", "Release");
                writer.WriteEndElement();

                writer.WriteStartElement("Config");
                writer.WriteAttributeString("name", "Release");

                foreach (var testProject in testProjects)
                {
                    writer.WriteStartElement("assembly");
                    writer.WriteAttributeString("path", programArgs.BasePath + "\\" + testProject.ReleaseDllPath);
                    writer.WriteEndElement();

                }

                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }


        }









    }
}