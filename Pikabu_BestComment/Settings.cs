using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Pikabu_BestComment
{
    public sealed class Settings
    {
        public int IntervalMinutes;
        public int CommentsCount;
        [NonSerialized]
        public static string SaveDirPath = String.Format("{0}\\Pikabu - Top Comments", Environment.GetEnvironmentVariable("APPDATA"));
        [NonSerialized]
        public static string SettingsSavePath = String.Format("{0}\\settings.xml", SaveDirPath);
        [NonSerialized]
        public static string CommentsSavePath = String.Format("{0}\\comments.xml", SaveDirPath);
        public bool NotifyUser;

        public Settings()
        {
            this.IntervalMinutes = 10;
            this.CommentsCount = 100;
            this.NotifyUser = true;
        }

        public static Settings tryLoad()
        {
            Settings settings = null;
            if(Directory.Exists(SaveDirPath) && File.Exists(SettingsSavePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                using (XmlReader reader = new XmlTextReader(SettingsSavePath))
                {
                    settings = serializer.Deserialize(reader) as Settings;
                }
                if (settings.IntervalMinutes < 10)
                    settings.IntervalMinutes = 10;
            }
            else
                settings = new Settings();
            return settings;
        }

        public static void saveSettings(Settings settings)
        {
            if (!Directory.Exists(Settings.SaveDirPath) || !File.Exists(SettingsSavePath))
            {
                Directory.CreateDirectory(Settings.SaveDirPath);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (XmlTextWriter writer = new XmlTextWriter(SettingsSavePath, Encoding.Unicode))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, settings);
            }
        }
    }
}
