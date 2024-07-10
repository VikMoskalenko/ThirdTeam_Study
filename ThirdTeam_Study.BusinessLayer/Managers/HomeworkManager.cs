using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ThirdTeam_Study.Data.Classes;

namespace ThirdTeam_Study.BusinessLayer.Managers
{
    public class HomeworkManager
    {
        const string noFile = "File not found";

        private static readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;

        private readonly string destinationDirectory = Path.Combine(basePath.Replace("bin\\Debug\\net8.0\\", ""), "uploads");

        private void UploadHomeWork(string sourceFilePath)
        {
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException(noFile, sourceFilePath);
            }

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }
            string fileName = Path.GetFileName(sourceFilePath);

            string destinationFilePath = Path.Combine(destinationDirectory, fileName);

            File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
        }
        public string GetStudentFullName(Student student) => $"{student.Name} {student.LastName}";

        // ToDo: get lesson number from Lesson class 
        public string GetHWTitle(Student student) => $"Home work to lesson 1 from student {GetStudentFullName(student)}";

        public void SubmitHW()
        {
            while (true)
            {
                OutputManager.Write("Enter path to your home work file:");
                string sourceFilePath = Console.ReadLine() ?? string.Empty;

                if (String.IsNullOrEmpty(sourceFilePath))
                {
                    OutputManager.Write("You need to paste path to home work file");
                }

                try
                {
                    UploadHomeWork(sourceFilePath ?? string.Empty);
                    OutputManager.Write("File saved successfully.");
                    break;
                }
                catch (Exception ex)
                {
                    OutputManager.Write($"Error occur: {ex.Message}");
                }
            }
        }

        public void AssertHW(HomeWork homeWork)
        {
            while (true)
            {
                OutputManager.Write("enter homework grade");
                string value = Console.ReadLine() ?? string.Empty;

                if (!ushort.TryParse(value, out ushort result))
                {
                    OutputManager.Write("Wrong format. Please enter number between 1 and 100");
                    continue;
                }
                else if (result < 0 || result > 100)
                {
                    OutputManager.Write("Grade should be between 1 and 100");
                    continue;
                }
                else
                {
                    homeWork.Grade = result;
                }
                break;
            }
        }

        public void AddHWComment(HomeWork homeWork)
        {
            while (true)
            {
                OutputManager.Write("Add some comment or leave it empty:");
                string comment = Console.ReadLine() ?? string.Empty;

                if (!Regex.IsMatch(comment, @"[A-Za-z]?"))
                {
                    OutputManager.Write("Only letters allowed");
                }
                else
                {
                    homeWork.Comment = comment;
                    break;
                }
            }
        }
    }
}
