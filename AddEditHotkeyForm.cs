using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AudioHotkeySoundboard
{
  public partial class AddEditHotkeyForm : Form
  {
    internal string[] editStrings = null;
    internal int editIndex = -1;

    private MainForm mainForm;
    private SettingsForm settingsForm;

    public AddEditHotkeyForm()
    {
      InitializeComponent();
    }

    private void AddEditSoundKeys_Load(object sender, EventArgs e)
    {
      if (SettingsForm.addingEditingLoadXMLFile)
      {
        settingsForm = Application.OpenForms[1] as SettingsForm;

        this.Text = "Add/edit keys and XML location";

        if (editIndex != -1)
        {
          tbLocation.Text = editStrings[0];
          tbKeys.Text = editStrings[1];
        }
      }
      else
      {
        mainForm = Application.OpenForms[0] as MainForm;

        //labelLoc.Text += " (use a semi-colon (;) to separate multiple locations)";

        if (editIndex != -1)
        {
          tbLocation.Text = editStrings[0];
          tbKeys.Text = editStrings[1];
        }
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(tbLocation.Text))
      {
        MessageBox.Show("Location is empty");
        return;
      }

      string[] soundLocs = null;
      string errorMessage = "";

      if (!SettingsForm.addingEditingLoadXMLFile)
      {
        if (Helper.soundLocsArrayFromString(tbLocation.Text, out soundLocs, out errorMessage))
        {
          if (soundLocs.Any(x => string.IsNullOrWhiteSpace(x) || !File.Exists(x)))
          {
            MessageBox.Show("The file/one of the files does not exist");

            this.Close();

            return;
          }
        }

        if (soundLocs == null)
        {
          MessageBox.Show(errorMessage);
          return;
        }
      }

      Keys[] keysArr;

      if (!Helper.keysArrayFromString(tbKeys.Text, out keysArr, out errorMessage))
      {
        keysArr = new Keys[] { };
      }

      if (SettingsForm.addingEditingLoadXMLFile)
      {
        if (editIndex != -1)
        {
          settingsForm.dgvSoundboardFiles.Rows[editIndex].Cells[0].Value = tbLocation.Text;
          settingsForm.dgvSoundboardFiles.Rows[editIndex].Cells[1].Value = tbKeys.Text;

          settingsForm.loadXMLFilesList[editIndex].Keys = keysArr;
          settingsForm.loadXMLFilesList[editIndex].XMLLocation = tbLocation.Text;
        }
        else
        {
          object[] newRow = new object[2];
          newRow[0] = Helper.fileNamesFromLocations(tbLocation.Text);
          newRow[1] = tbKeys.Text;

          settingsForm.dgvSoundboardFiles.Rows.Add(newRow);

          settingsForm.loadXMLFilesList.Add(new XMLSettings.LoadXMLFile(keysArr, tbLocation.Text));
        }
      }
      else
      {
        if (editIndex > -1)
        {
          mainForm.dgvKeySounds.Rows[editIndex].Cells[0].Value = Helper.fileNamesFromLocations(tbLocation.Text);
          mainForm.dgvKeySounds.Rows[editIndex].Cells[1].Value = tbKeys.Text;

          mainForm.soundHotkeys[editIndex] = new XMLSettings.SoundHotkey(keysArr, soundLocs);
        }
        else
        {
          object[] newRow = new object[2];
          newRow[0] = Helper.fileNamesFromLocations(tbLocation.Text);
          newRow[1] = tbKeys.Text;

          mainForm.dgvKeySounds.Rows.Add(newRow);

          mainForm.soundHotkeys.Add(new XMLSettings.SoundHotkey(keysArr, soundLocs));
        }

        mainForm.dgvKeySounds.Sort(mainForm.dgvKeySounds.Columns[0], ListSortDirection.Ascending);
        mainForm.soundHotkeys.Sort(delegate (XMLSettings.SoundHotkey x, XMLSettings.SoundHotkey y)
        {
          if (x.SoundClips == null && y.SoundClips == null)
          {
            return 0;
          }
          else if (x.SoundClips == null)
          {
            return -1;
          }
          else if (y.SoundClips == null) {
            return 1;
          }
          else
          {
            return x.SoundClips.CompareTo(y.SoundClips);
          }
        });
      }

      MainForm.Instance.AutoSave();

      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnBrowseSoundLoc_Click(object sender, EventArgs e)
    {
      var diag = new OpenFileDialog();

      diag.Multiselect = !SettingsForm.addingEditingLoadXMLFile;

      diag.Filter = (SettingsForm.addingEditingLoadXMLFile ? "XML file containing keys and sounds|*.xml" : "Supported audio formats|*.mp3;*.m4a;*.wav;*.wma;*.ac3;*.aiff;*.mp2|All files|*.*");

      DialogResult result = diag.ShowDialog();

      if (result == DialogResult.OK)
      {
        string text = "";

        for (int i = 0; i < diag.FileNames.Length; i++)
        {
          string fileName = diag.FileNames[i];

          if (fileName != "")
          {
            text += (i == 0 ? "" : " > ") + fileName;
          }
        }

        tbLocation.Text = text;
        if (!SettingsForm.addingEditingLoadXMLFile)
        {
          if (text.Contains(">"))
          {
            labelLoc.Text = "Location of file (Multiple selected, a sound will be selected at random each play)";
          }
        }
      }
    }

    private void tbKeys_Enter(object sender, EventArgs e)
    {
      timer1.Enabled = true;
    }

    private void tbKeys_Leave(object sender, EventArgs e)
    {
      timer1.Enabled = false;
    }

    private int lastAmountPressed = 0;
    private const string invalidKeys = " None Shift Control Alt Modifiers LButton RButton ";

    private void timer1_Tick(object sender, EventArgs e)
    {
      int amountPressed = 0;

      if (Keyboard.IsKeyDown(Keys.Escape))
      {
        lastAmountPressed = 50;

        tbKeys.Text = "";
      }
      else
      {
        var pressedKeys = new List<Keys>();

        string lastKey = "None";
        foreach (Keys key in Enum.GetValues(typeof(Keys)))
        {
          if (key.ToString() == lastKey) { continue; }
          lastKey = key.ToString();

          if (Keyboard.IsKeyDown(key) && !invalidKeys.Contains(" " + key.ToString() + " "))
          {
            amountPressed++;
            pressedKeys.Add(key);
          }
        }

        if (amountPressed > lastAmountPressed)
        {
          tbKeys.Text = Helper.keysToString(pressedKeys.ToArray());
        }

        lastAmountPressed = amountPressed;
      }
    }

    private int lastAmountPressed2 = 0;

    private void timer2_Tick(object sender, EventArgs e)
    {
      int amountPressed = 0;

      if (Keyboard.IsKeyDown(Keys.Escape))
      {
        lastAmountPressed2 = 50;

        tbKeys.Text = "";
      }
      else
      {
        var pressedKeys = new List<Keys>();

        foreach (Keys key in Enum.GetValues(typeof(Keys)))
        {
          if (Keyboard.IsKeyDown(key) && key.ToString() != "LButton" && key.ToString() != "RButton")
          {
            amountPressed++;
            pressedKeys.Add(key);
          }
        }

        if (amountPressed > lastAmountPressed2)
        {
          tbKeys.Text = Helper.keysToString(pressedKeys.ToArray());
        }

        lastAmountPressed2 = amountPressed;
      }
    }

    private void ButtonClear_Click(object sender, EventArgs e)
    {
      tbKeys.Text = "";
    }
  }
}
