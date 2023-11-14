using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace osu_launcher
{
    public partial class Form1 : Form
    {
        private readonly PrivateFontCollection _fontCollection;
        private readonly JObject _configFiles;
        
        public Form1()
        {
            _fontCollection = new PrivateFontCollection();
            _fontCollection.AddFontFile("./Font/NotoSans-Regular.ttf");
            _fontCollection.AddFontFile("./Font/NotoSans-Light.ttf");
            InitializeComponent();

            StreamReader streamReader = new StreamReader("data.json", Encoding.GetEncoding("Shift_JIS"));
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            _configFiles = JObject.Parse(str);

            foreach (var server in _configFiles["links"])
            {
                serverList.Items.Add(server);
            }
            serverList.Text = (string)_configFiles["links"][0];
            if (string.IsNullOrEmpty(serverList.Text))
            {
                saveServer.Enabled = false;
                saveServer.Checked = false;
            }

            osuFolderbox.Text = (string)_configFiles["osuLocation"];
            if (string.IsNullOrEmpty(osuFolderbox.Text))
            {
                saveFolder.Enabled = false;
                saveFolder.Checked = false;
            }

            if (_configFiles["username"] == null)
            {
                saveUsername.Enabled = false;
                saveUsername.Checked = false;
            }
            else
            {
                foreach (var username in _configFiles["username"])
                {
                    usernameBox.Items.Add(username);
                }
                usernameBox.Text = (string)_configFiles["username"][0];
                if (string.IsNullOrEmpty(usernameBox.Text))
                {
                    saveUsername.Enabled = false;
                    saveUsername.Checked = false;
                }
            }

            foreach (var folder in _configFiles["SongsFolder"])
            {
                SongsFolderbox.Items.Add(folder);
            }
            SongsFolderbox.Text = (string)_configFiles["SongsFolder"][0];
            if (!string.IsNullOrEmpty(SongsFolderbox.Text)) return;
            SaveSongs.Enabled = false;
            SaveSongs.Checked = false;
        }

        private void Osulaunch_pushed(object sender, EventArgs e)
        {
            try
            {
                string osulocation = osuFolderbox.Text;
                string serverlocation = "-devserver " + serverList.Text;
                
                if (osulocation == "")
                {
                    MessageBox.Show(@"osu!のインストール先を指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (serverList.Text == @"osu!bancho" || serverList.Text == "") serverlocation = "";

                if (saveServer.Checked)
                {
                    if (!ArrayContains(_configFiles["links"].ToObject<string[]>(), serverList.Text)) _configFiles["links"].Last.AddAfterSelf(serverList.Text);
                    if (!serverList.Items.Contains(serverList.Text)) serverList.Items.Add(serverList.Text);
                }

                if (saveUsername.Checked)
                {
                    if (_configFiles["username"] == null)
                    {
                        _configFiles.Add("username", new JArray(usernameBox.Text));
                    }
                    else if (!ArrayContains(_configFiles["username"].ToObject<string[]>(), usernameBox.Text))
                    {
                        _configFiles["username"].Last.AddAfterSelf(usernameBox.Text);
                    }
                    
                    if (!usernameBox.Items.Contains(usernameBox.Text)) usernameBox.Items.Add(usernameBox.Text);
                }

                if (saveFolder.Checked) _configFiles["osuLocation"] = osuFolderbox.Text;
                
                if (advancedSetting.Checked && (usecustomResolution.Checked || changeSongs.Checked))
                {
                    string filePath = Path.Combine(osulocation, Config.Text);
                    if (!File.Exists(filePath) || Config.Text == "")
                    {
                        MessageBox.Show("Configファイルが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    var resolutionHeightResult = int.TryParse(resolutionHeight.Text, out int resolutionHeightInt);
                    var resolutionWidthResult = int.TryParse(resolutionWidth.Text, out int resolutionWidthInt);
                    if (usecustomResolution.Checked && (!resolutionHeightResult || resolutionHeightInt <= 0 || !resolutionWidthResult || resolutionWidthInt <= 0))
                    {
                        MessageBox.Show("解像度の欄には正の整数のみを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    if (Digit(resolutionHeightInt) > 4 || Digit(resolutionWidthInt) > 4)
                    {
                        MessageBox.Show("解像度の欄には4桁以下の正の整数のみを入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (changeSongs.Checked && !Directory.Exists(SongsFolderbox.Text) && SongsFolderbox.Text != "Songs")
                    { 
                        MessageBox.Show("指定されたSongsフォルダが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (changeSongs.Checked && lines[i].Contains("BeatmapDirectory = ")) lines[i] = "BeatmapDirectory = " + SongsFolderbox.Text;
                            if (usecustomResolution.Checked && changeonlyFullscreen.Checked && lines[i].Contains("HeightFullscreen = ")) lines[i] = "HeightFullscreen = " + resolutionHeightInt;
                            if (usecustomResolution.Checked && changeonlyFullscreen.Checked && lines[i].Contains("WidthFullscreen = ")) lines[i] = "WidthFullscreen = " + resolutionWidthInt;
                            if (usecustomResolution.Checked && !changeonlyFullscreen.Checked && lines[i].Contains("Height = ")) lines[i] = "Height = " + resolutionHeightInt;
                            if (usecustomResolution.Checked && !changeonlyFullscreen.Checked && lines[i].Contains("Width = ")) lines[i] = "Width = " + resolutionWidthInt;
                        }
                        File.WriteAllLines(filePath, lines);
                        lines = null;
                    } 
                    catch
                    {
                        MessageBox.Show("Configファイルの書き込みに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (SaveSongs.Checked)
                    {
                        if (!ArrayContains(_configFiles["SongsFolder"].ToObject<string[]>(), SongsFolderbox.Text)) _configFiles["SongsFolder"].Last.AddAfterSelf(SongsFolderbox.Text);
                        if (!SongsFolderbox.Items.Contains(SongsFolderbox.Text)) SongsFolderbox.Items.Add(SongsFolderbox.Text);
                    }
                }
                
                if (usernameBox.Text != "") Clipboard.SetText(usernameBox.Text);
                
                if (saveServer.Checked || saveUsername.Checked || saveFolder.Checked || SaveSongs.Checked)
                {
                    StreamWriter streamWriter = new StreamWriter("data.json", false, Encoding.GetEncoding("Shift_JIS"));
                    streamWriter.Write(JsonConvert.SerializeObject(_configFiles, Formatting.Indented));
                    streamWriter.Close();
                    if (saveServer.Checked)
                    {
                        var result = ArrayContains(_configFiles["links"].ToObject<string[]>(), serverList.Text);
                        saveServer.Enabled = !result;
                        saveServer.Checked = !result;
                    }

                    if (saveUsername.Checked)
                    {
                        var result = ArrayContains(_configFiles["username"].ToObject<string[]>(), usernameBox.Text);
                        saveUsername.Enabled = !result;
                        saveUsername.Checked = !result;
                    }

                    if (saveFolder.Checked)
                    {
                        var result = (string)_configFiles["osuLocation"] == osuFolderbox.Text;
                        saveFolder.Enabled = !result;
                        saveFolder.Checked = !result;
                    }

                    if (SaveSongs.Enabled)
                    {
                        var result = ArrayContains(_configFiles["SongsFolder"].ToObject<string[]>(), SongsFolderbox.Text);
                        SaveSongs.Enabled = !result;
                        SaveSongs.Checked = !result;
                    }
                }
                
                if (Process.GetProcessesByName("osu!").Length != 0)
                {
                    MessageBox.Show("osu!は既に起動中です。一度osu!を閉じてから起動してください。", "起動できません！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(Path.Combine(osulocation, "osu!.exe")))
                {
                    MessageBox.Show("osu!.exeがフォルダ内から見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                Process.Start(Path.Combine(osulocation, "osu!.exe"), serverlocation);
            }
            catch
            {
                MessageBox.Show("osu!の起動に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool ArrayContains(IEnumerable<string> array, string value)
        {
            return array.Any(item => item == value);
        }
        
        private static int Digit(int num)
        {
            return num == 0 ? 1 : (int)Math.Log10(num) + 1;
        }

        private void osuFolderbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(osuFolderbox.Text))
            {
                saveFolder.Text = "フォルダの保存";
                Config.Items.Clear();
                saveFolder.Enabled = false;
                saveFolder.Checked = false;
                return;
            }

            if (!Directory.Exists(osuFolderbox.Text))
            {
                saveFolder.Text = "フォルダが見つかりませんでした。";
                Config.Items.Clear();
                saveFolder.Enabled = false;
                saveFolder.Checked = false;
                return;
            }
            
            if (!File.Exists(Path.Combine(osuFolderbox.Text, "osu!.exe")))
            {
                saveFolder.Text = "フォルダ内にosu!.exeが見つかりませんでした。";
                Config.Items.Clear();
                saveFolder.Enabled = false;
                saveFolder.Checked = false;
                return;
            }
            
            saveFolder.Text = "フォルダの保存";
            var result = (string)_configFiles["osuLocation"] == osuFolderbox.Text;
            saveFolder.Enabled = !result;
            if (result && saveFolder.Checked) saveFolder.Checked = false;
            
            string[] configFiles = { };
            configFiles = Directory.GetFiles(osuFolderbox.Text, "osu!*.cfg");
            
            Config.Items.Clear();
            foreach (string configFile in configFiles)
            {
                string fileName = Path.GetFileName(configFile);
                if (fileName != "osu!.cfg")
                {
                    Config.Items.Add(fileName);
                }
            }
            Config.Text = configFiles.Length == 0 ? "" : Config.Items[0].ToString();
            configFiles = null;
        }

        private void automaticDetection_Click(object sender, EventArgs e)
        {
            var processes = Process.GetProcessesByName("osu!");
            if (processes.Length == 0)
            {
                MessageBox.Show("osu!.exeが見つかりませんでした。osu!を起動してからもう一度お試しください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string processPath = processes[0].MainModule.FileName;
            osuFolderbox.Text = Path.GetDirectoryName(processPath);   
        }

        private void usecustomResolution_CheckedChanged(object sender, EventArgs e)
        {
            resolutionWidth.Enabled = usecustomResolution.Checked;
            resolutionHeight.Enabled = usecustomResolution.Checked;
            if (!usecustomResolution.Checked) changeonlyFullscreen.Checked = false;
            changeonlyFullscreen.Enabled = usecustomResolution.Checked;
        }
        
        private void changeSongs_CheckedChanged(object sender, EventArgs e)
        {
            SongsFolderbox.Enabled = changeSongs.Checked;
            if (!changeSongs.Checked)
            {
                SaveSongs.Text = "Songsフォルダの保存";
                SaveSongs.Enabled = false;
                SaveSongs.Checked = false;
            }
            else if (!Directory.Exists(SongsFolderbox.Text) && SongsFolderbox.Text != "Songs")
            {
                SaveSongs.Text = "指定されたSongsフォルダが見つかりませんでした。";
                SaveSongs.Enabled = false;
                SaveSongs.Checked = false;
            } 
            else if (ArrayContains(_configFiles["SongsFolder"].ToObject<string[]>(), SongsFolderbox.Text))
            {
                SaveSongs.Text = "Songsフォルダの保存";
                SaveSongs.Enabled = false;
                SaveSongs.Checked = false;
            }
            else
            {
                SaveSongs.Text = "Songsフォルダの保存";
                SaveSongs.Enabled = true;
            }
            
        }
        
        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernameBox.Text))
            {
                saveUsername.Enabled = false;
                saveUsername.Checked = false;
                return;
            }
            
            if (_configFiles["username"] == null)
            {
                saveUsername.Enabled = true;
                return;
            }
            
            var result = ArrayContains(_configFiles["username"].ToObject<string[]>(), usernameBox.Text);
            saveUsername.Enabled = !result;
            if (result && saveUsername.Checked) saveUsername.Checked = false;
        }
        
        private void serverList_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(serverList.Text))
            {
                saveServer.Enabled = false;
                saveServer.Checked = false;
                return;
            }
            
            var result = ArrayContains(_configFiles["links"].ToObject<string[]>(), serverList.Text);
            saveServer.Enabled = !result;
            if (result && saveServer.Checked) saveServer.Checked = false;
        }
        
        private void SongsFolderbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SongsFolderbox.Text))
            {
                SaveSongs.Text = "Songsフォルダの保存";
                SaveSongs.Enabled = false;
                SaveSongs.Checked = false;
                return;
            }
            
            if (!Directory.Exists(SongsFolderbox.Text) && SongsFolderbox.Text != "Songs")
            {
                SaveSongs.Text = "指定されたSongsフォルダが見つかりませんでした。";
                SaveSongs.Enabled = false;
                SaveSongs.Checked = false;
                return;
            }
            
            SaveSongs.Text = "Songsフォルダの保存";
            var result = ArrayContains(_configFiles["SongsFolder"].ToObject<string[]>(), SongsFolderbox.Text);
            SaveSongs.Enabled = !result;
            if (result && SaveSongs.Checked) SaveSongs.Checked = false;
        }

        private void advancedSetting_CheckedChanged(object sender, EventArgs e)
        {
            osulaunch.Location = advancedSetting.Checked ? new Point(272, 392) : new Point(180, 213);
            Size = advancedSetting.Checked ? new Size(696, 486) : new Size(537, 302);
            changeonlyFullscreen.Visible = advancedSetting.Checked;
            crossResolution.Enabled = advancedSetting.Checked;
            crossResolution.Visible = advancedSetting.Checked;
            resolutionHeight.Visible = advancedSetting.Checked;
            resolutionWidth.Visible = advancedSetting.Checked;
            ResolutionText.Enabled = advancedSetting.Checked;
            ResolutionText.Visible = advancedSetting.Checked;
            usecustomResolution.Enabled = advancedSetting.Checked;
            usecustomResolution.Visible = advancedSetting.Checked;
            SaveSongs.Visible = advancedSetting.Checked;
            SongsFolderbox.Visible = advancedSetting.Checked;
            changeSongs.Enabled = advancedSetting.Checked;
            changeSongs.Visible = advancedSetting.Checked;
            configText.Enabled = advancedSetting.Checked;
            configText.Visible = advancedSetting.Checked;
            Config.Enabled = advancedSetting.Checked;
            Config.Visible = advancedSetting.Checked;
            SongsFolderText.Enabled = advancedSetting.Checked;
            SongsFolderText.Visible = advancedSetting.Checked;
        }
    }
}
