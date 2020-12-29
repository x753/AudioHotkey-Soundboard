using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Media;
using NAudio.Wave;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;

namespace AudioHotkeySoundboard
{
    public partial class MainForm : Form
    {
        WaveIn loopbackSourceStream = null;
        BufferedWaveProvider loopbackWaveProvider = null;
        WaveOut loopbackWaveOut = null;

        Random rand = new Random();
        
        // A lot of this code depends on soundHotkeys and dgvKeySounds both being sorted alphabetically
        // They aren't synced with each other in any way, so if one isn't properly sorted and you try to play a sound it can play the wrong sound
        internal List<XMLSettings.SoundHotkey> soundHotkeys = new List<XMLSettings.SoundHotkey>();
        internal string xmlLoc = "";

        public static MainForm Instance;

        public MainForm()
        {
            Instance = this;

            InitializeComponent();

            loadSoundDevices();

            XMLSettings.LoadSoundboardSettingsXML();

            if (cbPlaybackDevices.Items.Contains(XMLSettings.soundboardSettings.LastPlaybackDevice)) cbPlaybackDevices.SelectedItem = XMLSettings.soundboardSettings.LastPlaybackDevice;
            if (cbPlaybackDevices2.Items.Contains(XMLSettings.soundboardSettings.LastPlaybackDevice2)) cbPlaybackDevices2.SelectedItem = XMLSettings.soundboardSettings.LastPlaybackDevice2;

            if (cbLoopbackDevices.Items.Contains(XMLSettings.soundboardSettings.LastLoopbackDevice)) cbLoopbackDevices.SelectedItem = XMLSettings.soundboardSettings.LastLoopbackDevice;

            //add events after settings have been loaded
            cbPlaybackDevices.SelectedIndexChanged += cbPlaybackDevices_SelectedIndexChanged;
            cbPlaybackDevices2.SelectedIndexChanged += cbPlaybackDevices2_SelectedIndexChanged;
            cbLoopbackDevices.SelectedIndexChanged += cbLoopbackDevices_SelectedIndexChanged;

            mainTimer.Enabled = true;

            initAudioPlaybackEngine();

            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\AHS-autosave.xml";
            if (File.Exists(filePath))
            {
                loadXMLFile(filePath);
            }
        }

        private void initAudioPlaybackEngine()
        {
            int deviceNumberPrimary = cbPlaybackDevices.SelectedIndex - 1;
            int deviceNumberSecondary = cbPlaybackDevices2.SelectedIndex - 1;

            AudioPlaybackEngine.Primary.Dispose();
            AudioPlaybackEngine.Secondary.Dispose();
            stopLoopback();

            // Primary Playback
            if (cbPlaybackDevices.SelectedIndex > 0)
            {
                try
                {
                    AudioPlaybackEngine.Primary.Init(deviceNumberPrimary);
                }
                catch (NAudio.MmException ex)
                {
                    SystemSounds.Beep.Play();
                    string msg = ex.ToString();
                    if (msg.Contains("AlreadyAllocated calling waveOutOpen"))
                    {
                        msg = "Failed to open device for primary playback device. Already in exclusive use by another application? \n\n" + msg;
                    }
                    MessageBox.Show(msg);
                }
            }

            // Secondary Playback
            if (cbPlaybackDevices2.SelectedIndex > 0)
            {
                try
                {
                    AudioPlaybackEngine.Secondary.Init(deviceNumberSecondary);
                }
                catch (NAudio.MmException ex)
                {
                    SystemSounds.Beep.Play();
                    string msg = ex.ToString();
                    if (msg.Contains("AlreadyAllocated calling waveOutOpen"))
                    {
                        msg = "Failed to open device for secondary playback device. Already in exclusive use by another application? \n\n" + msg;
                    }
                    MessageBox.Show(msg);
                }
            }

            if (cbLoopbackDevices.SelectedIndex > 0) // loopback should only start if we have a primary playback device to loopback into
                startLoopback();
        }

        private void loadSoundDevices()
        {
            var playbackSources = new List<WaveOutCapabilities>();
            var loopbackSources = new List<WaveInCapabilities>();

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                playbackSources.Add(WaveOut.GetCapabilities(i));
            }

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                loopbackSources.Add(WaveIn.GetCapabilities(i));
            }

            cbPlaybackDevices.Items.Clear();
            cbPlaybackDevices2.Items.Clear();
            cbLoopbackDevices.Items.Clear();

            cbPlaybackDevices.Items.Add("");
            cbPlaybackDevices2.Items.Add("");
            cbLoopbackDevices.Items.Add("");

            foreach (var source in playbackSources)
            {
                cbPlaybackDevices.Items.Add(source.ProductName);
                cbPlaybackDevices2.Items.Add(source.ProductName);
            }

            cbPlaybackDevices.SelectedIndex = 0;
            cbPlaybackDevices2.SelectedIndex = 0;

            foreach (var source in loopbackSources)
            {
                cbLoopbackDevices.Items.Add(source.ProductName);
            }

            cbLoopbackDevices.SelectedIndex = 0;
        }

        private void startLoopback()
        {
            stopLoopback();

            int deviceNumber = cbLoopbackDevices.SelectedIndex - 1;

            if (deviceNumber >= 0)
            {
                if (loopbackSourceStream == null)
                    loopbackSourceStream = new WaveIn();
                loopbackSourceStream.DeviceNumber = deviceNumber;
                loopbackSourceStream.WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(deviceNumber).Channels);
                loopbackSourceStream.BufferMilliseconds = 25;
                loopbackSourceStream.NumberOfBuffers = 5;
                loopbackSourceStream.DataAvailable += loopbackSourceStream_DataAvailable;

                loopbackWaveProvider = new BufferedWaveProvider(loopbackSourceStream.WaveFormat);
                loopbackWaveProvider.DiscardOnBufferOverflow = true;

                if (loopbackWaveOut == null)
                    loopbackWaveOut = new WaveOut();
                loopbackWaveOut.DeviceNumber = cbPlaybackDevices.SelectedIndex - 1; // Loopback only goes through the primary playback device
                loopbackWaveOut.DesiredLatency = 125;
                loopbackWaveOut.Init(loopbackWaveProvider);

                loopbackSourceStream.StartRecording();
                loopbackWaveOut.Play();
            }
        }

        private void stopLoopback()
        {
            try
            {
                if (loopbackWaveOut != null)
                {
                    loopbackWaveOut.Stop();
                    loopbackWaveOut.Dispose();
                    loopbackWaveOut = null;
                }

                if (loopbackWaveProvider != null)
                {
                    loopbackWaveProvider.ClearBuffer();
                    loopbackWaveProvider = null;
                }

                if (loopbackSourceStream != null)
                {
                    loopbackSourceStream.StopRecording();
                    loopbackSourceStream.Dispose();
                    loopbackSourceStream = null;
                }
            }
            catch (Exception) { }
        }

        private void stopPlayback()
        {
            AudioPlaybackEngine.Primary.StopAllSounds();
            AudioPlaybackEngine.Secondary.StopAllSounds();
        }

        private void playSelection()
        {
            if (dgvKeySounds.SelectedRows.Count > 0)
                playKeySound(soundHotkeys[dgvKeySounds.SelectedRows[0].Index]);
        }

        private void playSound(string file)
        {
            if (!XMLSettings.soundboardSettings.PlaySoundsOverEachOther) stopPlayback();

            try
            {
                //AudioPlaybackEngine.Primary.PlaySound(file);
                //AudioPlaybackEngine.Secondary.PlaySound(file);

                CachedSound cachedSound = null;

                if (!AudioPlaybackEngine.cachedSounds.TryGetValue(file, out cachedSound))
                {
                    cachedSound = new CachedSound(file);
                    AudioPlaybackEngine.cachedSounds.Add(file, cachedSound);
                }

                AudioPlaybackEngine.Primary.PlaySound(cachedSound);
                AudioPlaybackEngine.Secondary.PlaySound(cachedSound);
            }
            catch (FormatException ex)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show(ex.ToString());
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show(ex.ToString());
            }
            catch (NAudio.MmException ex)
            {
                SystemSounds.Beep.Play();
                string msg = ex.ToString();
                MessageBox.Show((msg.Contains("UnspecifiedError calling waveOutOpen") ? "Something is wrong with either the sound you tried to play (" + file.Substring(file.LastIndexOf("\\") + 1) + ") (try converting it to another format) or your sound card driver\n\n" + msg : msg));
            }
        }

        private void loadXMLFile(string path)
        {
            XMLSettings.Settings s = (XMLSettings.Settings)XMLSettings.ReadXML(typeof(XMLSettings.Settings), path);

            if (s != null && s.SoundHotkeys != null && s.SoundHotkeys.Length > 0)
            {
                var items = new List<object[]>();
                string errors = "";

                for (int i = 0; i < s.SoundHotkeys.Length; i++)
                {
                    int kLength = s.SoundHotkeys[i].Keys.Length;
                    bool keysNull = (kLength > 0 && !s.SoundHotkeys[i].Keys.Any(x => x != 0));
                    int sLength = s.SoundHotkeys[i].SoundLocations.Length;
                    bool soundsNotEmpty = s.SoundHotkeys[i].SoundLocations.All(x => !string.IsNullOrWhiteSpace(x));
                    Environment.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                    bool filesExist = s.SoundHotkeys[i].SoundLocations.All(x => File.Exists(x));

                    if (keysNull || sLength < 1 || !soundsNotEmpty || !filesExist) //error in XML file
                    {
                        string tempErr = "";

                        if (kLength == 0 && (sLength == 0 || !soundsNotEmpty)) tempErr = "entry is empty";
                        else if (!keysNull) tempErr = "one or more sounds do not exist"; // "one or more keys are null";
                        else if (sLength == 0) tempErr = "no sounds provided";
                        else if (!filesExist) tempErr = "one or more sounds do not exist";

                        errors += "Entry #" + (i + 1).ToString() + " has an error: " + tempErr + "\r\n";
                    }

                    object[] temp = new object[2];
                    temp[0] = s.SoundHotkeys[i].SoundClips;
                    temp[1] = Helper.keysToString(s.SoundHotkeys[i].Keys);

                    items.Add(temp); // add even if there was an error, so that the user can fix within the app
                }
                
                if (items.Count > 0)
                {
                    if (errors != "")
                    {
                        MessageBox.Show((errors == "" ? "" : errors));
                    }

                    soundHotkeys.Clear();
                    soundHotkeys.AddRange(s.SoundHotkeys);

                    dgvKeySounds.Rows.Clear();
                    foreach (object[] row in items)
                    {
                        dgvKeySounds.Rows.Add(row);
                    }

                    xmlLoc = path;
                }
                else
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("No entries found, or all entries had errors in them (sound location behind empty or non-existant)");
                }
            }
            else
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("No entries found, or there was an error reading the settings file");
            }

            AutoSave();
        }

        private void editSelectedSoundHotkey()
        {
            if (dgvKeySounds.SelectedRows.Count > 0)
            {
                var form = new AddEditHotkeyForm();

                DataGridViewRow row = dgvKeySounds.SelectedRows[0];

                form.editIndex = dgvKeySounds.SelectedRows[0].Index;

                form.editStrings = new string[2];
                form.editStrings[0] = Helper.soundLocsArrayToString(soundHotkeys[form.editIndex].SoundLocations);
                form.editStrings[1] = (string)row.Cells[1].Value;

                form.ShowDialog();
            }

            AutoSave();
        }

        private void loopbackSourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (loopbackWaveProvider != null && loopbackWaveProvider.BufferedDuration.TotalMilliseconds <= 100)
                loopbackWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm();
            form.ShowDialog();
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/x753/");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddEditHotkeyForm();
            form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editSelectedSoundHotkey();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvKeySounds.SelectedRows.Count > 0)
            {
                soundHotkeys.RemoveAt(dgvKeySounds.SelectedRows[0].Index);
                dgvKeySounds.Rows.Remove(dgvKeySounds.SelectedRows[0]);
            }

            AutoSave();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all items?", "Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                soundHotkeys.Clear();
                dgvKeySounds.Rows.Clear();
            }

            AutoSave();
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            if (dgvKeySounds.SelectedRows.Count > 0)
                playKeySound(soundHotkeys[dgvKeySounds.SelectedRows[0].Index]);
        }

        private void btnStopAllSounds_Click(object sender, EventArgs e)
        {
            stopPlayback();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var diag = new OpenFileDialog();

            diag.Filter = "XML file containing keys and sounds|*.xml";

            var result = diag.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = diag.FileName;

                loadXMLFile(path);
            }
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (xmlLoc == "" || !File.Exists(xmlLoc))
        //        xmlLoc = Helper.userGetXMLLoc();

        //    if (xmlLoc != "")
        //    {
        //        XMLSettings.WriteXML(new XMLSettings.Settings() { SoundHotkeys = soundHotkeys.ToArray() }, xmlLoc);

        //        MessageBox.Show("Saved");
        //    }
        //}

        public void AutoSave()
        {
            XMLSettings.WriteXML(new XMLSettings.Settings() { SoundHotkeys = soundHotkeys.ToArray() }, Path.GetDirectoryName(Application.ExecutablePath) + "\\AHS-autosave.xml");
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            string last = xmlLoc;

            xmlLoc = Helper.userGetXMLLoc();

            if (xmlLoc == "")
                xmlLoc = last;
            else if (last != xmlLoc)
            {
                XMLSettings.WriteXML(new XMLSettings.Settings() { SoundHotkeys = soundHotkeys.ToArray() }, xmlLoc);
            }
        }

        private void btnReloadDevices_Click(object sender, EventArgs e)
        {
            stopPlayback();
            stopLoopback();

            loadSoundDevices();
        }

        private void dgvKeySounds_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editSelectedSoundHotkey();
        }

        Keys[] keysJustPressed = null;
        bool showingMsgBox = false;
        int lastIndex = -1;

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            int keysPressed = 0;

            if (soundHotkeys.Count > 0) //check that required keys are pressed to play sound
            {
                for (int i = 0; i < soundHotkeys.Count; i++)
                {
                    keysPressed = 0;

                    if (soundHotkeys[i].Keys.Length == 0) continue;

                    for (int j = 0; j < soundHotkeys[i].Keys.Length; j++)
                    {
                        if (Keyboard.IsKeyDown(soundHotkeys[i].Keys[j]))
                            keysPressed++;
                    }

                    if (keysPressed == soundHotkeys[i].Keys.Length)
                    {
                        if (keysJustPressed == soundHotkeys[i].Keys) continue;

                        if (soundHotkeys[i].Keys.Length > 0 && soundHotkeys[i].Keys.All(x => x != 0) && soundHotkeys[i].SoundLocations.Length > 0
                            && soundHotkeys[i].SoundLocations.Length > 0 && soundHotkeys[i].SoundLocations.Any(x => File.Exists(x)))
                        {
                            playKeySound(soundHotkeys[i]);
                            return;
                        }
                    }
                    else if (keysJustPressed == soundHotkeys[i].Keys)
                        keysJustPressed = null;
                }

                keysPressed = 0;
            }

            if (XMLSettings.soundboardSettings.StopSoundKeys != null && XMLSettings.soundboardSettings.StopSoundKeys.Length > 0) //check that required keys are pressed to stop all sounds
            {
                for (int i = 0; i < XMLSettings.soundboardSettings.StopSoundKeys.Length; i++)
                {
                    if (Keyboard.IsKeyDown(XMLSettings.soundboardSettings.StopSoundKeys[i])) keysPressed++;
                }

                if (keysPressed == XMLSettings.soundboardSettings.StopSoundKeys.Length)
                {
                    if (keysJustPressed == null || !keysJustPressed.Intersect(XMLSettings.soundboardSettings.StopSoundKeys).Any())
                    {
                        stopPlayback();

                        keysJustPressed = XMLSettings.soundboardSettings.StopSoundKeys;

                        return;
                    }
                }
                else if (keysJustPressed == XMLSettings.soundboardSettings.StopSoundKeys)
                    keysJustPressed = null;

                keysPressed = 0;
            }

            if (XMLSettings.soundboardSettings.PlaySelectionKeys != null && XMLSettings.soundboardSettings.PlaySelectionKeys.Length > 0) //check that required keys are pressed to play the currently selected sound
            {
                for (int i = 0; i < XMLSettings.soundboardSettings.PlaySelectionKeys.Length; i++)
                {
                    if (Keyboard.IsKeyDown(XMLSettings.soundboardSettings.PlaySelectionKeys[i])) keysPressed++;
                }

                if (keysPressed == XMLSettings.soundboardSettings.PlaySelectionKeys.Length)
                {
                    if (keysJustPressed == null || !keysJustPressed.Intersect(XMLSettings.soundboardSettings.PlaySelectionKeys).Any())
                    {
                        playSelection();

                        keysJustPressed = XMLSettings.soundboardSettings.PlaySelectionKeys;

                        return;
                    }
                }
                else if (keysJustPressed == XMLSettings.soundboardSettings.PlaySelectionKeys)
                    keysJustPressed = null;

                keysPressed = 0;
            }

            if (XMLSettings.soundboardSettings.LoadXMLFiles != null && XMLSettings.soundboardSettings.LoadXMLFiles.Length > 0) //check that required keys are pressed to load XML file
            {
                for (int i = 0; i < XMLSettings.soundboardSettings.LoadXMLFiles.Length; i++)
                {
                    if (XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys.Length == 0) continue;

                    keysPressed = 0;

                    for (int j = 0; j < XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys.Length; j++)
                    {
                        if (Keyboard.IsKeyDown(XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys[j])) keysPressed++;
                    }

                    if (keysPressed == XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys.Length)
                    {
                        if (keysJustPressed == null || !keysJustPressed.Intersect(XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys).Any())
                        {
                            if (!string.IsNullOrWhiteSpace(XMLSettings.soundboardSettings.LoadXMLFiles[i].XMLLocation) && File.Exists(XMLSettings.soundboardSettings.LoadXMLFiles[i].XMLLocation))
                            {
                                keysJustPressed = XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys;

                                loadXMLFile(XMLSettings.soundboardSettings.LoadXMLFiles[i].XMLLocation);
                            }

                            return;
                        }
                    }
                    else if (keysJustPressed == XMLSettings.soundboardSettings.LoadXMLFiles[i].Keys)
                    {
                        keysJustPressed = null;
                    }
                }

                keysPressed = 0;
            }
        }

        private void playKeySound(XMLSettings.SoundHotkey currentKeysSounds)
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            string path;

            if (currentKeysSounds.SoundLocations.Length > 1)
            {
                //get random sound
                int temp;

                while (true)
                {
                    temp = rand.Next(0, currentKeysSounds.SoundLocations.Length);

                    if (temp != lastIndex && File.Exists(currentKeysSounds.SoundLocations[temp])) break;
                    Thread.Sleep(1);
                }

                lastIndex = temp;

                path = currentKeysSounds.SoundLocations[lastIndex];
            }
            else
                path = currentKeysSounds.SoundLocations[0]; //get first sound

            if (File.Exists(path))
            {
                playSound(path);
                keysJustPressed = currentKeysSounds.Keys;
            }
            else if (!showingMsgBox) //dont run when already showing messagebox (don't want a bunch of these on your screen, do you?)
            {
                SystemSounds.Beep.Play();
                showingMsgBox = true;
                MessageBox.Show("File " + path + " does not exist");
                showingMsgBox = false;
            }
        }

        private void cbLoopbackDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            stopLoopback();
            if (cbLoopbackDevices.SelectedIndex > 0)
                startLoopback();

            XMLSettings.soundboardSettings.LastLoopbackDevice = (string)cbLoopbackDevices.SelectedItem;

            XMLSettings.SaveSoundboardSettingsXML();
        }

        private void cbPlaybackDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            stopPlayback();

            initAudioPlaybackEngine();

            XMLSettings.soundboardSettings.LastPlaybackDevice = (string)cbPlaybackDevices.SelectedItem;

            XMLSettings.SaveSoundboardSettingsXML();
        }

        private void cbPlaybackDevices2_SelectedIndexChanged(object sender, EventArgs e)
        {
            stopPlayback();

            initAudioPlaybackEngine();

            XMLSettings.soundboardSettings.LastPlaybackDevice2 = (string)cbPlaybackDevices2.SelectedItem;

            XMLSettings.SaveSoundboardSettingsXML();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (XMLSettings.soundboardSettings.MinimizeToTray)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    notifyIcon1.Visible = true;

                    this.Hide();
                }
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;

            //show form and give focus
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void DgvKeySounds_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void DgvKeySounds_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            bool unsupported = false;
            foreach (string file in files)
            {
                if (!Helper.isSupportedFileType(file))
                {
                    unsupported = true;
                    continue;
                }
                
                object[] newRow = new object[2];
                newRow[0] = Helper.fileNamesFromLocations(file);
                dgvKeySounds.Rows.Add(newRow);
                soundHotkeys.Add(new XMLSettings.SoundHotkey(new Keys[] { }, new string[] { file }));
            }

            // Sorting Alphabetically
            dgvKeySounds.Sort(dgvKeySounds.Columns[0], ListSortDirection.Ascending);
            soundHotkeys.Sort(delegate (XMLSettings.SoundHotkey x, XMLSettings.SoundHotkey y)
            {
                if (x.SoundClips == null && y.SoundClips == null) return 0;
                else if (x.SoundClips == null) return -1;
                else if (y.SoundClips == null) return 1;
                else return x.SoundClips.CompareTo(y.SoundClips);
            });

            if (unsupported) MessageBox.Show("One or more files were of an unsupported file type.");

            AutoSave();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            if (cbAudioOverdrive.Checked)
            {
                labelVolume.Text = (trackbarVolume.Value*3).ToString() + " dB";
            }
            else
            {
                labelVolume.Text = trackbarVolume.Value.ToString() + " dB";
            }
            XMLSettings.soundboardSettings.GainValue = trackbarVolume.Value;
            XMLSettings.SaveSoundboardSettingsXML();
        }

        public void GoEvenFurtherBeyond(bool state)
        {
            cbAudioOverdrive.Checked = state;
        }

        public void SetGain(int gain)
        {
            trackbarVolume.Value = gain;
            if (cbAudioOverdrive.Checked)
            {
                labelVolume.Text = (trackbarVolume.Value * 3).ToString() + " dB";
            }
            else
            {
                labelVolume.Text = trackbarVolume.Value.ToString() + " dB";
            }
        }
        public float GetGain()
        {
            if (cbAudioOverdrive.Checked)
            {
                return trackbarVolume.Value * 3;
            }
            else
            {
                return trackbarVolume.Value;
            }
        }

        private void CbAudioOverdrive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAudioOverdrive.Checked)
            {
                labelVolume.Text = (trackbarVolume.Value*3).ToString() + " dB";
            }
            else
            {
                labelVolume.Text = trackbarVolume.Value.ToString() + " dB";
            }
            XMLSettings.soundboardSettings.GoEvenFurtherBeyond = cbAudioOverdrive.Checked;
            XMLSettings.SaveSoundboardSettingsXML();
        }

        public static System.Windows.Forms.Timer IdleTimer = new System.Windows.Forms.Timer();
        public static string TypeTarget = "";
        // Jump to the first sound starting with whatever key you pressed if the DGV is selected
        private void DgvKeySounds_KeyPress(object sender, KeyPressEventArgs e)
        {
            TypeTarget += Char.ToLower(e.KeyChar);

            IdleTimer.Stop();
            IdleTimer.Interval = 600;
            IdleTimer.Tick += TypeTargetTimeDone;
            IdleTimer.Start();

            Debug.WriteLine(TypeTarget);

            for (int i = 0; i < dgvKeySounds.Rows.Count; i++)
            {
                if (dgvKeySounds.Rows[i].Cells[0].Value.ToString().ToLower().StartsWith(TypeTarget))
                {
                    BindingSource bs = new BindingSource();
                    dgvKeySounds.BindingContext[bs].Position = i;
                    dgvKeySounds.CurrentCell = dgvKeySounds.Rows[i].Cells[0];
                    return;
                }
            }
        }
        static private void TypeTargetTimeDone(object sender, EventArgs e)
        {
            IdleTimer.Stop();
            TypeTarget = "";
        }


        // Button for manually clearing cached sounds and running garbage collection
        private void MemoryManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioPlaybackEngine.cachedSounds.Clear();
            GC.Collect();
        }

        private void DownloadVBAudioCableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.vb-audio.com/Cable/");
        }
    }
}
