using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AudioHotkeySoundboard
{
  class Helper
  {
    internal static string userGetXMLLoc()
    {
      SaveFileDialog diag = new SaveFileDialog();

      diag.Filter = "XML file containing keys and sounds|*.xml";

      var result = diag.ShowDialog();

      if (result == DialogResult.OK)
      {
        return diag.FileName;
      }
      else return "";
    }

    //internal static string[] keysArrayToStringArray(Keys[] keysArr)
    //{
    //    var arr = new List<string>();

    //    for (int i = 0; i < keysArr.Length; i++)
    //    {
    //        arr.Add(keysArr[i].ToString());
    //    }

    //    return arr.ToArray();
    //}

    //internal static Keys[] stringArrayToKeysArray(string[] strArr)
    //{
    //    if (strArr == null) return new Keys[] { 0 };
    //    var arr = new List<Keys>();

    //    for (int i = 0; i < strArr.Length; i++)
    //    {
    //        Keys key;

    //        if (Enum.TryParse(strArr[i], out key))
    //        {
    //            arr.Add(key);
    //        }
    //        else
    //        {
    //            return new Keys[] { 0 };
    //        }
    //    }

    //    return arr.ToArray();
    //}

    internal static bool keysArrayFromString(string key, out Keys[] keysArr, out string errorMessage)
    {
      Dictionary<string, string> stringToKeyTranslations = keyToStringTranslations.ToDictionary(x => x.Value, x => x.Key);

      if (key.Contains("+"))
      {
        string[] sKeys = key.Split('+');
        var kKeys = new List<Keys>();

        for (int i = 0; i < sKeys.Length; i++)
        {
          Keys kKey;

          if (stringToKeyTranslations.ContainsKey(sKeys[i]))
          {
            sKeys[i] = stringToKeyTranslations[sKeys[i]];
          }

          if (Enum.TryParse(sKeys[i], out kKey))
          {
            kKeys.Add(kKey);
          }
          else
          {
            errorMessage = "Key string \"" + sKeys[i] + "\" doesn't exist";
            keysArr = null;
            return false;
          }
        }

        keysArr = kKeys.ToArray();
        errorMessage = string.Empty;
        return true;
      }
      else
      {
        Keys kKey;

        if (stringToKeyTranslations.ContainsKey(key))
        {
          key = stringToKeyTranslations[key];
        }

        if (Enum.TryParse(key, out kKey))
        {
          keysArr = new Keys[] { kKey };
          errorMessage = string.Empty;
          return true;
        }
        else
        {
          errorMessage = "Key string \"" + key + "\" doesn't exist";
          keysArr = null;
          return false;
        }
      }
    }

    public static Dictionary<string, string> keyToStringTranslations = new Dictionary<string, string>(){
            {"Oemcomma", "Comma"},
            {"OemPeriod", "Period"},
            {"OemQuestion", "ForwardSlash"},
            {"OemOpenBrackets", "LeftBracket"},
            {"Oem6", "RightBracket"},
            {"Oem5", "BackSlash"},
            {"Oemplus", "Plus"},
            {"OemMinus", "Minus"},
            {"Back", "Backspace"},
            {"Oemtilde", "Backtick"},
            {"D0", "0"},
            {"D1", "1"},
            {"D2", "2"},
            {"D3", "3"},
            {"D4", "4"},
            {"D5", "5"},
            {"D6", "6"},
            {"D7", "7"},
            {"D8", "8"},
            {"D9", "9"},
            {"Oem1", "Semicolon"},
            {"Oem7", "Quotation"}
        };
    internal static string keysToString(params Keys[] keysArr)
    {
      if (keysArr == null) return "";
      string result = "";
      int kLen = keysArr.Length;

      for (int i = 0; i < kLen; i++)
      {
        string next = keysArr[i].ToString();
        if (keyToStringTranslations.ContainsKey(next))
        {
          next = keyToStringTranslations[next];
        }

        result += next + (i == kLen - 1 ? "" : "+");
      }

      return result;
    }

    internal static bool soundLocsArrayFromString(string soundLocsStr, out string[] soundLocs, out string errorMessage)
    {
      if (soundLocsStr.Contains(">"))
      {
        string[] sLocs = soundLocsStr.Split('>');
        var lLocs = new List<string>();

        for (int i = 0; i < sLocs.Length; i++)
        {
          if (File.Exists(sLocs[i]))
          {
            lLocs.Add(sLocs[i]);
          }
          else
          {
            errorMessage = "File \"" + sLocs[i] + "\" does not exist";
            soundLocs = null;
            return false;
          }
        }

        soundLocs = lLocs.ToArray();
        errorMessage = string.Empty;
        return true;
      }
      else
      {
        if (File.Exists(soundLocsStr))
        {
          soundLocs = new string[] { soundLocsStr };
          errorMessage = string.Empty;
          return true;
        }
        else
        {
          errorMessage = "File \"" + soundLocsStr + "\" does not exist";
          soundLocs = null;
          return false;
        }
      }
    }

    internal static string soundLocsArrayToString(string[] soundLocations)
    {
      string temp = "";
      int sLen = soundLocations.Length;

      for (int i = 0; i < sLen; i++)
      {
        temp += soundLocations[i].ToString() + (i == sLen - 1 ? "" : ">");
      }

      return temp;
    }

    internal static string fileNamesFromLocations(string locations)
    {
      string[] locationsArray = locations.Split(new char[] { '>' });
      return fileNamesFromLocations(locationsArray);
    }

    internal static string fileNamesFromLocations(string[] locations)
    {
      string result = Path.GetFileName(locations[0]);
      for (int i = 1; i < locations.Length; i++)
      {
        result += "> " + Path.GetFileName(locations[i]);
      }
      return result;
    }

    internal static bool isSupportedFileType(string path)
    {
      string extension = Path.GetExtension(path);
      if (extension == ".mp3" || extension == ".m4a" || extension == ".wav" || extension == ".wma" || extension == ".ac3" || extension == ".aiff" || extension == ".mp2")
        return true;
      return false;
    }

    internal static string cleanFileName(string fileName)
    {
      return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
    }
  }
}
