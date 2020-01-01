using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XamarinAppTemplate
{
    public class MobileAppSettings
    {
        public static IConfiguration Configuration { get; set; }

        public static string DATABASE_FULL_FILE_NAME
        {
            get
            {
                return Path.Combine(DATABASE_FOLDER_PATH, DATABASE_FILENAME);
            }
        }

        public static string DATABASE_FOLDER_PATH
        {
            get
            {
                string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                string path = Path.Combine(personalFolder, "Database");

                return path;

            }
        }


        public const string DATABASE_FILENAME = "database.db";
    }
}
