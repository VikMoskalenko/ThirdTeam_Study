﻿namespace ThirdTeam_Study
{
    public class HomeWork
    {
        private readonly Tutor Tutor;

        const string noFile = "File not found";
        // ToDo: chenge to lesson type
        public ushort HomeWorkNumber { get; set; } = 1;
        // ToDo: redo to Student type
        public string StudentName { get; set; } = "Mike Tyson";
        public required string Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public ushort Grade { get; set; }

        protected string HomeWorkFile { get; set; } = string.Empty;

        private static readonly string basePath = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string destinationDirectory = Path.Combine(basePath.Replace("bin\\Debug\\net8.0\\", ""), "uploads");

        public HomeWork(Tutor _tutor)
        {
            Tutor = _tutor;
        }

        public void UploadHomeWork(string sourceFilePath)
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

        public string GetTutorFullName() => $"{Tutor.FirstName} {Tutor.LastName}";
    }
}