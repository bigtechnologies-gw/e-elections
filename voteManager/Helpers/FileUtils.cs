using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace EElections.Helpers
{
    public static class FileUtils
    {
        public static string BaseDir { get; set; }
        public static string LogoDir { get; set; }

        static FileUtils()
        {
            string path = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            BaseDir = Path.GetDirectoryName(path);
            LogoDir = Path.Combine(BaseDir, "logo");

            EnsureLogoDir();
        }

        public static void EnsureLogoDir()
        {
            string path = Path.Combine(BaseDir, "logo");
            if (Directory.Exists(path))
            {
                return;
            }
            try
            {
                Directory.CreateDirectory(path);
                Debug.WriteLine("Directory logo created");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
