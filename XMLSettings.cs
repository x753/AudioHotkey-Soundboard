using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace AudioHotkeySoundboard
{
    public class XMLSettings
    {
        readonly static SoundboardSettings DEFAULT_SOUNDBOARD_SETTINGS = new SoundboardSettings(new Keys[] { Keys.Pause }, new Keys[] { Keys.Oemtilde, Keys.LControlKey }, new LoadXMLFile[] { new LoadXMLFile(new Keys[] { }, "") }, false, true, false, "", "", "");

        internal static SoundboardSettings soundboardSettings = new SoundboardSettings();

        //saving XML files like this makes the XML messy, but it works
        #region Keys and sounds settings
        public class SoundHotkey
        {
            public Keys[] Keys;
            public string[] SoundLocations;
            public string SoundClips;

            public SoundHotkey() { }

            public SoundHotkey(Keys[] keys, string[] soundLocs)
            {
                Keys = keys;
                SoundLocations = soundLocs;
                SoundClips = Helper.fileNamesFromLocations(soundLocs);
            }
        }

        [Serializable]
        public class Settings
        {
            public SoundHotkey[] SoundHotkeys;

            public Settings() { }

            public Settings(SoundHotkey[] sh)
            {
                SoundHotkeys = sh;
            }
        }
        #endregion

        #region Soundboard settings
        public class LoadXMLFile
        {
            public Keys[] Keys;
            public string XMLLocation;

            public LoadXMLFile() { }

            public LoadXMLFile(Keys[] keys, string xmlLocation)
            {
                Keys = keys;
                XMLLocation = xmlLocation;
            }
        }

        [Serializable]
        public class SoundboardSettings
        {
            public Keys[] StopSoundKeys, PlaySelectionKeys;
            public LoadXMLFile[] LoadXMLFiles;
            public bool MinimizeToTray, PlaySoundsOverEachOther, RememberGainControl;
            public string LastPlaybackDevice, LastPlaybackDevice2, LastLoopbackDevice;

            public bool GoEvenFurtherBeyond;
            public int GainValue;

            public SoundboardSettings() { }

            public SoundboardSettings(Keys[] stopSoundKeys, Keys[] playSelectionKeys, LoadXMLFile[] loadXMLFiles, bool minimizeToTray, bool playSoundsOverEachOther, bool rememberGainControl, string lastPlaybackDevice, string lastPlaybackDevice2, string lastLoopbackDevice)
            {
                StopSoundKeys = stopSoundKeys;
                PlaySelectionKeys = playSelectionKeys;
                LoadXMLFiles = loadXMLFiles;
                MinimizeToTray = minimizeToTray;
                PlaySoundsOverEachOther = playSoundsOverEachOther;
                RememberGainControl = rememberGainControl;
                LastPlaybackDevice = lastPlaybackDevice;
                LastPlaybackDevice2 = lastPlaybackDevice2;
                LastLoopbackDevice = lastLoopbackDevice;
            }
        }
        #endregion

        internal static void WriteXML(object kl, string xmlLoc)
        {
            XmlSerializer serializer = new XmlSerializer(kl.GetType());

            using (MemoryStream memStream = new MemoryStream())
            {
                using (StreamWriter stream = new StreamWriter(memStream, Encoding.Unicode))
                {
                    var settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = true;

                    using (var writer = XmlWriter.Create(stream, settings))
                    {
                        var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                        serializer.Serialize(writer, kl, emptyNamepsaces);

                        int count = (int)memStream.Length;

                        byte[] arr = new byte[count];
                        memStream.Seek(0, SeekOrigin.Begin);

                        memStream.Read(arr, 0, count);

                        using (BinaryWriter binWriter = new BinaryWriter(File.Open(xmlLoc, FileMode.Create)))
                        {
                            binWriter.Write(arr);
                        }
                    }
                }
            }
        }

        internal static object ReadXML(Type type, string xmlLoc)
        {
            var serializer = new XmlSerializer(type);

            using (var reader = XmlReader.Create(xmlLoc))
            {
                if (serializer.CanDeserialize(reader))
                {
                    return serializer.Deserialize(reader);
                }
                else return null;
            }
        }

        internal static void SaveSoundboardSettingsXML()
        {
            WriteXML(soundboardSettings, Path.GetDirectoryName(Application.ExecutablePath) + "\\AHS-settings.xml");
        }

        internal static void LoadSoundboardSettingsXML()
        {
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\AHS-settings.xml";
            string oldFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\settings.xml";

            if (!File.Exists(filePath)) { filePath = oldFilePath; } // try the old file path if the new one doesn't exist

            if (File.Exists(filePath))
            {
                SoundboardSettings settings;

                try
                {
                    settings = (SoundboardSettings)ReadXML(typeof(SoundboardSettings), filePath);
                }
                catch
                {
                    soundboardSettings = DEFAULT_SOUNDBOARD_SETTINGS;
                    return;
                }

                if (settings == null)
                {
                    soundboardSettings = DEFAULT_SOUNDBOARD_SETTINGS;
                    return;
                }

                if (settings.StopSoundKeys == null) settings.StopSoundKeys = new Keys[] { Keys.Pause };
                if (settings.PlaySelectionKeys == null) settings.PlaySelectionKeys = new Keys[] { Keys.Oemtilde, Keys.LControlKey };

                if (settings.LoadXMLFiles == null) settings.LoadXMLFiles = new LoadXMLFile[] { };

                if (settings.LastPlaybackDevice == null) settings.LastPlaybackDevice = "";
                if (settings.LastPlaybackDevice2 == null) settings.LastPlaybackDevice2 = "";

                if (settings.LastLoopbackDevice == null) settings.LastLoopbackDevice = "";

                if (settings.RememberGainControl)
                {
                    MainForm.Instance.SetGain(settings.GainValue);
                    if (settings.GoEvenFurtherBeyond)
                    {
                        MainForm.Instance.GoEvenFurtherBeyond(true);
                    }
                }

                soundboardSettings = settings;
            }
            else
            {
                WriteXML(DEFAULT_SOUNDBOARD_SETTINGS, filePath);
                soundboardSettings = DEFAULT_SOUNDBOARD_SETTINGS;

                for (int i = 0; i < WaveOut.DeviceCount; i++)
                {
                    if (WaveOut.GetCapabilities(i).ProductName.Contains("VB-Cable Input") || WaveOut.GetCapabilities(i).ProductName.Contains("CABLE Input") || WaveOut.GetCapabilities(i).ProductName.Contains("VoiceMeeter Input"))
                    {
                        soundboardSettings.LastPlaybackDevice = WaveOut.GetCapabilities(i).ProductName;
                        WriteXML(soundboardSettings, filePath);
                    }
                }
            }
        }
    }
}
