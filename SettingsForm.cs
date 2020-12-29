using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AudioHotkeySoundboard
{
    public partial class SettingsForm : Form
    {
        private readonly StartupManager startupManager;

        internal List<XMLSettings.LoadXMLFile> loadXMLFilesList = new List<XMLSettings.LoadXMLFile>(XMLSettings.soundboardSettings.LoadXMLFiles); //list so can dynamically add/remove

        internal static bool addingEditingLoadXMLFile = false;

        public SettingsForm()
        {
            InitializeComponent();

            startupManager = new StartupManager();

            for (int i = 0; i < loadXMLFilesList.Count; i++)
            {
                bool keysLengthCorrect = loadXMLFilesList[i].Keys.Length > 0;
                bool xmlLocationUnempty = !string.IsNullOrWhiteSpace(loadXMLFilesList[i].XMLLocation);

                if (!keysLengthCorrect && !xmlLocationUnempty) //remove if empty
                {
                    loadXMLFilesList.RemoveAt(i);
                    i--;
                    continue;
                }

                object[] newRow = new object[2];
                newRow[0] = Path.GetFileName((xmlLocationUnempty ? loadXMLFilesList[i].XMLLocation : ""));
                newRow[1] = (keysLengthCorrect ? string.Join("+", loadXMLFilesList[i].Keys) : "");

                dgvSoundboardFiles.Rows.Add(newRow);
            }

            tbStopSoundKeys.Text = Helper.keysToString(XMLSettings.soundboardSettings.StopSoundKeys);
            tbPlaySelectionKeys.Text = Helper.keysToString(XMLSettings.soundboardSettings.PlaySelectionKeys);

            cbMinimizeToTray.Checked = XMLSettings.soundboardSettings.MinimizeToTray;
            cbStartup.Checked = XMLSettings.soundboardSettings.AutoStartup;
            cbPlaySoundsOverEachOther.Checked = XMLSettings.soundboardSettings.PlaySoundsOverEachOther;
            cbRememberGainControl.Checked = XMLSettings.soundboardSettings.RememberGainControl;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addingEditingLoadXMLFile = true;

            var form = new AddEditHotkeyForm();
            form.ShowDialog();

            addingEditingLoadXMLFile = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSoundboardFiles.SelectedRows.Count > 0)
            {
                addingEditingLoadXMLFile = true;

                var form = new AddEditHotkeyForm();

                form.editIndex = dgvSoundboardFiles.SelectedRows[0].Index;
                form.editStrings = new string[] { (string)loadXMLFilesList[form.editIndex].XMLLocation, (string)dgvSoundboardFiles.SelectedRows[0].Cells[1].Value };

                form.ShowDialog();

                addingEditingLoadXMLFile = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvSoundboardFiles.SelectedRows.Count > 0 && MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = dgvSoundboardFiles.SelectedRows[0].Index;

                dgvSoundboardFiles.Rows.RemoveAt(index);
                loadXMLFilesList.RemoveAt(index);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Keys[] keysArr = null;
            Keys[] keysArr2 = null;
            string error = "";

            if ((string.IsNullOrWhiteSpace(tbStopSoundKeys.Text) || Helper.keysArrayFromString(tbStopSoundKeys.Text, out keysArr, out error)) && (string.IsNullOrWhiteSpace(tbPlaySelectionKeys.Text) || Helper.keysArrayFromString(tbPlaySelectionKeys.Text, out keysArr2, out error)))
            {
                if (loadXMLFilesList.Count == 0 || loadXMLFilesList.All(x => x.Keys.Length > 0 && !string.IsNullOrWhiteSpace(x.XMLLocation) && File.Exists(x.XMLLocation)))
                {
                    XMLSettings.soundboardSettings.StopSoundKeys = (keysArr == null ? new Keys[] { } : keysArr);
                    XMLSettings.soundboardSettings.PlaySelectionKeys = (keysArr2 == null ? new Keys[] { } : keysArr2);

                    XMLSettings.soundboardSettings.LoadXMLFiles = loadXMLFilesList.ToArray();

                    XMLSettings.soundboardSettings.MinimizeToTray = cbMinimizeToTray.Checked;
                    XMLSettings.soundboardSettings.AutoStartup = cbStartup.Checked;
                    startupManager.Startup = (bool)cbStartup.Checked;

                    XMLSettings.soundboardSettings.PlaySoundsOverEachOther = cbPlaySoundsOverEachOther.Checked;

                    XMLSettings.soundboardSettings.RememberGainControl = cbRememberGainControl.Checked;

                    XMLSettings.soundboardSettings.GainValue = MainForm.Instance.trackbarVolume.Value;
                    XMLSettings.soundboardSettings.GoEvenFurtherBeyond = MainForm.Instance.cbAudioOverdrive.Checked;

                    XMLSettings.SaveSoundboardSettingsXML();

                    this.Close();
                }
                else MessageBox.Show("One or more entries either have no keys added, the location is empty, or the file the location points to does not exist");
            }
            else if (error != "")
            {
                MessageBox.Show(error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvKeysLocs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void tbStopSoundKeys_Enter(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void tbStopSoundKeys_Leave(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        int lastAmountPressed = 0;

        const string invalidKeys = " None Shift Control Alt Modifiers LButton RButton ";

        private void timer1_Tick(object sender, EventArgs e)
        {
            int amountPressed = 0;

            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                lastAmountPressed = 50;

                tbStopSoundKeys.Text = "";
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
                    tbStopSoundKeys.Text = Helper.keysToString(pressedKeys.ToArray());
                }

                lastAmountPressed = amountPressed;
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            tbStopSoundKeys.Text = "";
        }

        private void TbPlaySelectionKeys_Enter(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void TbPlaySelectionKeys_Leave(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        int lastAmountPressed2 = 0;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            int amountPressed = 0;

            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                lastAmountPressed2 = 50;

                tbPlaySelectionKeys.Text = "";
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

                if (amountPressed > lastAmountPressed2)
                {
                    tbPlaySelectionKeys.Text = Helper.keysToString(pressedKeys.ToArray());
                }

                lastAmountPressed2 = amountPressed;
            }
        }

        private void ButtonClear2_Click(object sender, EventArgs e)
        {
            tbPlaySelectionKeys.Text = "";
        }
    }
}
