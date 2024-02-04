using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace osu_launcher
{
    partial class OsuLauncher
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OsuLauncher));
            this.osulaunch = new System.Windows.Forms.Button();
            this.serverList = new System.Windows.Forms.ComboBox();
            this.serverText = new System.Windows.Forms.Label();
            this.osuFolderText = new System.Windows.Forms.Label();
            this.saveServer = new System.Windows.Forms.CheckBox();
            this.saveFolder = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.osuFolderbox = new System.Windows.Forms.TextBox();
            this.automaticDetection = new System.Windows.Forms.Button();
            this.SongsFolderText = new System.Windows.Forms.Label();
            this.Config = new System.Windows.Forms.ComboBox();
            this.configText = new System.Windows.Forms.Label();
            this.changeSongs = new System.Windows.Forms.CheckBox();
            this.SongsFolderbox = new System.Windows.Forms.ComboBox();
            this.SaveSongs = new System.Windows.Forms.CheckBox();
            this.usecustomResolution = new System.Windows.Forms.CheckBox();
            this.ResolutionText = new System.Windows.Forms.Label();
            this.resolutionWidth = new System.Windows.Forms.TextBox();
            this.resolutionHeight = new System.Windows.Forms.TextBox();
            this.crossResolution = new System.Windows.Forms.Label();
            this.changeonlyFullscreen = new System.Windows.Forms.CheckBox();
            this.advancedSetting = new System.Windows.Forms.CheckBox();
            this.saveUsername = new System.Windows.Forms.CheckBox();
            this.usernameText = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // osulaunch
            // 
            this.osulaunch.BackColor = System.Drawing.SystemColors.Control;
            this.osulaunch.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.osulaunch.Image = ((System.Drawing.Image)(resources.GetObject("osulaunch.Image")));
            this.osulaunch.Location = new System.Drawing.Point(182, 213);
            this.osulaunch.Name = "osulaunch";
            this.osulaunch.Size = new System.Drawing.Size(178, 51);
            this.osulaunch.TabIndex = 0;
            this.osulaunch.UseVisualStyleBackColor = false;
            this.osulaunch.Click += new System.EventHandler(this.Osulaunch_pushed);
            // 
            // serverList
            // 
            this.serverList.FormattingEnabled = true;
            this.serverList.Location = new System.Drawing.Point(182, 12);
            this.serverList.Name = "serverList";
            this.serverList.Size = new System.Drawing.Size(260, 20);
            this.serverList.TabIndex = 1;
            this.serverList.TextChanged += new System.EventHandler(this.serverList_TextChanged);
            // 
            // serverText
            // 
            this.serverText.AutoSize = true;
            this.serverText.BackColor = System.Drawing.Color.Transparent;
            this.serverText.ForeColor = System.Drawing.Color.Black;
            this.serverText.Location = new System.Drawing.Point(50, 9);
            this.serverText.Name = "serverText";
            this.serverText.Size = new System.Drawing.Size(38, 12);
            this.serverText.TabIndex = 2;
            this.serverText.Text = "Server";
            // 
            // osuFolderText
            // 
            this.osuFolderText.AutoSize = true;
            this.osuFolderText.BackColor = System.Drawing.Color.Transparent;
            this.osuFolderText.ForeColor = System.Drawing.Color.Black;
            this.osuFolderText.Location = new System.Drawing.Point(25, 70);
            this.osuFolderText.Name = "osuFolderText";
            this.osuFolderText.Size = new System.Drawing.Size(62, 12);
            this.osuFolderText.TabIndex = 5;
            this.osuFolderText.Text = "osu! Folder";
            // 
            // saveServer
            // 
            this.saveServer.AutoSize = true;
            this.saveServer.BackColor = System.Drawing.Color.Transparent;
            this.saveServer.ForeColor = System.Drawing.Color.Black;
            this.saveServer.Location = new System.Drawing.Point(182, 45);
            this.saveServer.Name = "saveServer";
            this.saveServer.Size = new System.Drawing.Size(98, 16);
            this.saveServer.TabIndex = 6;
            this.saveServer.Text = "サーバーの保存";
            this.saveServer.UseVisualStyleBackColor = false;
            // 
            // saveFolder
            // 
            this.saveFolder.AutoSize = true;
            this.saveFolder.BackColor = System.Drawing.Color.Transparent;
            this.saveFolder.ForeColor = System.Drawing.Color.Black;
            this.saveFolder.Location = new System.Drawing.Point(182, 106);
            this.saveFolder.Name = "saveFolder";
            this.saveFolder.Size = new System.Drawing.Size(93, 16);
            this.saveFolder.TabIndex = 7;
            this.saveFolder.Text = "フォルダの保存";
            this.saveFolder.UseVisualStyleBackColor = false;
            // 
            // osuFolderbox
            // 
            this.osuFolderbox.Location = new System.Drawing.Point(182, 73);
            this.osuFolderbox.Name = "osuFolderbox";
            this.osuFolderbox.Size = new System.Drawing.Size(260, 19);
            this.osuFolderbox.TabIndex = 8;
            this.osuFolderbox.TextChanged += new System.EventHandler(this.osuFolderbox_TextChanged);
            // 
            // automaticDetection
            // 
            this.automaticDetection.Location = new System.Drawing.Point(448, 73);
            this.automaticDetection.Name = "automaticDetection";
            this.automaticDetection.Size = new System.Drawing.Size(68, 27);
            this.automaticDetection.TabIndex = 9;
            this.automaticDetection.Text = "自動検出";
            this.automaticDetection.UseVisualStyleBackColor = true;
            this.automaticDetection.Click += new System.EventHandler(this.automaticDetection_Click);
            // 
            // SongsFolderText
            // 
            this.SongsFolderText.AutoSize = true;
            this.SongsFolderText.BackColor = System.Drawing.Color.Transparent;
            this.SongsFolderText.Enabled = false;
            this.SongsFolderText.ForeColor = System.Drawing.Color.Black;
            this.SongsFolderText.Location = new System.Drawing.Point(16, 244);
            this.SongsFolderText.Name = "SongsFolderText";
            this.SongsFolderText.Size = new System.Drawing.Size(72, 12);
            this.SongsFolderText.TabIndex = 10;
            this.SongsFolderText.Text = "Songs Folder";
            this.SongsFolderText.Visible = false;
            // 
            // Config
            // 
            this.Config.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Config.Enabled = false;
            this.Config.FormattingEnabled = true;
            this.Config.Location = new System.Drawing.Point(479, 246);
            this.Config.Name = "Config";
            this.Config.Size = new System.Drawing.Size(177, 20);
            this.Config.TabIndex = 11;
            this.Config.Visible = false;
            // 
            // configText
            // 
            this.configText.AutoSize = true;
            this.configText.BackColor = System.Drawing.Color.Transparent;
            this.configText.Enabled = false;
            this.configText.ForeColor = System.Drawing.Color.Black;
            this.configText.Location = new System.Drawing.Point(525, 208);
            this.configText.Name = "configText";
            this.configText.Size = new System.Drawing.Size(36, 12);
            this.configText.TabIndex = 13;
            this.configText.Text = "Config";
            this.configText.Visible = false;
            // 
            // changeSongs
            // 
            this.changeSongs.AutoSize = true;
            this.changeSongs.BackColor = System.Drawing.Color.Transparent;
            this.changeSongs.Enabled = false;
            this.changeSongs.ForeColor = System.Drawing.Color.Black;
            this.changeSongs.Location = new System.Drawing.Point(182, 226);
            this.changeSongs.Name = "changeSongs";
            this.changeSongs.Size = new System.Drawing.Size(152, 16);
            this.changeSongs.TabIndex = 14;
            this.changeSongs.Text = "Songsフォルダーを変更する";
            this.changeSongs.UseVisualStyleBackColor = false;
            this.changeSongs.Visible = false;
            this.changeSongs.CheckedChanged += new System.EventHandler(this.changeSongs_CheckedChanged);
            // 
            // SongsFolderbox
            // 
            this.SongsFolderbox.Enabled = false;
            this.SongsFolderbox.FormattingEnabled = true;
            this.SongsFolderbox.Location = new System.Drawing.Point(182, 248);
            this.SongsFolderbox.Name = "SongsFolderbox";
            this.SongsFolderbox.Size = new System.Drawing.Size(261, 20);
            this.SongsFolderbox.TabIndex = 15;
            this.SongsFolderbox.Visible = false;
            this.SongsFolderbox.TextChanged += new System.EventHandler(this.SongsFolderbox_TextChanged);
            // 
            // SaveSongs
            // 
            this.SaveSongs.AutoSize = true;
            this.SaveSongs.BackColor = System.Drawing.Color.Transparent;
            this.SaveSongs.Enabled = false;
            this.SaveSongs.ForeColor = System.Drawing.Color.Black;
            this.SaveSongs.Location = new System.Drawing.Point(182, 281);
            this.SaveSongs.Name = "SaveSongs";
            this.SaveSongs.Size = new System.Drawing.Size(124, 16);
            this.SaveSongs.TabIndex = 16;
            this.SaveSongs.Text = "Songsフォルダの保存";
            this.SaveSongs.UseVisualStyleBackColor = false;
            this.SaveSongs.Visible = false;
            // 
            // usecustomResolution
            // 
            this.usecustomResolution.AutoSize = true;
            this.usecustomResolution.BackColor = System.Drawing.Color.Transparent;
            this.usecustomResolution.Enabled = false;
            this.usecustomResolution.ForeColor = System.Drawing.Color.Black;
            this.usecustomResolution.Location = new System.Drawing.Point(182, 309);
            this.usecustomResolution.Name = "usecustomResolution";
            this.usecustomResolution.Size = new System.Drawing.Size(130, 16);
            this.usecustomResolution.TabIndex = 17;
            this.usecustomResolution.Text = "カスタム解像度の使用";
            this.usecustomResolution.UseVisualStyleBackColor = false;
            this.usecustomResolution.Visible = false;
            this.usecustomResolution.CheckedChanged += new System.EventHandler(this.usecustomResolution_CheckedChanged);
            // 
            // ResolutionText
            // 
            this.ResolutionText.AutoSize = true;
            this.ResolutionText.BackColor = System.Drawing.Color.Transparent;
            this.ResolutionText.Enabled = false;
            this.ResolutionText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResolutionText.ForeColor = System.Drawing.Color.Black;
            this.ResolutionText.Location = new System.Drawing.Point(31, 341);
            this.ResolutionText.Name = "ResolutionText";
            this.ResolutionText.Size = new System.Drawing.Size(59, 12);
            this.ResolutionText.TabIndex = 18;
            this.ResolutionText.Text = "Resolution";
            this.ResolutionText.Visible = false;
            // 
            // resolutionWidth
            // 
            this.resolutionWidth.Enabled = false;
            this.resolutionWidth.Location = new System.Drawing.Point(182, 346);
            this.resolutionWidth.Name = "resolutionWidth";
            this.resolutionWidth.Size = new System.Drawing.Size(110, 19);
            this.resolutionWidth.TabIndex = 19;
            this.resolutionWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.resolutionWidth.Visible = false;
            // 
            // resolutionHeight
            // 
            this.resolutionHeight.Enabled = false;
            this.resolutionHeight.Location = new System.Drawing.Point(333, 347);
            this.resolutionHeight.Name = "resolutionHeight";
            this.resolutionHeight.Size = new System.Drawing.Size(110, 19);
            this.resolutionHeight.TabIndex = 20;
            this.resolutionHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.resolutionHeight.Visible = false;
            // 
            // crossResolution
            // 
            this.crossResolution.AutoSize = true;
            this.crossResolution.BackColor = System.Drawing.Color.Transparent;
            this.crossResolution.Enabled = false;
            this.crossResolution.ForeColor = System.Drawing.Color.Black;
            this.crossResolution.Location = new System.Drawing.Point(299, 346);
            this.crossResolution.Name = "crossResolution";
            this.crossResolution.Size = new System.Drawing.Size(17, 12);
            this.crossResolution.TabIndex = 21;
            this.crossResolution.Text = "×";
            this.crossResolution.Visible = false;
            // 
            // changeonlyFullscreen
            // 
            this.changeonlyFullscreen.AutoSize = true;
            this.changeonlyFullscreen.BackColor = System.Drawing.Color.Transparent;
            this.changeonlyFullscreen.Enabled = false;
            this.changeonlyFullscreen.ForeColor = System.Drawing.Color.Black;
            this.changeonlyFullscreen.Location = new System.Drawing.Point(182, 327);
            this.changeonlyFullscreen.Name = "changeonlyFullscreen";
            this.changeonlyFullscreen.Size = new System.Drawing.Size(131, 16);
            this.changeonlyFullscreen.TabIndex = 22;
            this.changeonlyFullscreen.Text = "フルスクリーン時の変更";
            this.changeonlyFullscreen.UseVisualStyleBackColor = false;
            this.changeonlyFullscreen.Visible = false;
            // 
            // advancedSetting
            // 
            this.advancedSetting.AutoSize = true;
            this.advancedSetting.BackColor = System.Drawing.Color.Transparent;
            this.advancedSetting.ForeColor = System.Drawing.Color.Black;
            this.advancedSetting.Location = new System.Drawing.Point(182, 185);
            this.advancedSetting.Name = "advancedSetting";
            this.advancedSetting.Size = new System.Drawing.Size(72, 16);
            this.advancedSetting.TabIndex = 23;
            this.advancedSetting.Text = "詳細設定";
            this.advancedSetting.UseVisualStyleBackColor = false;
            this.advancedSetting.CheckedChanged += new System.EventHandler(this.advancedSetting_CheckedChanged);
            // 
            // saveUsername
            // 
            this.saveUsername.AutoSize = true;
            this.saveUsername.BackColor = System.Drawing.Color.Transparent;
            this.saveUsername.ForeColor = System.Drawing.Color.Black;
            this.saveUsername.Location = new System.Drawing.Point(182, 165);
            this.saveUsername.Name = "saveUsername";
            this.saveUsername.Size = new System.Drawing.Size(110, 16);
            this.saveUsername.TabIndex = 26;
            this.saveUsername.Text = "ユーザー名の保存";
            this.saveUsername.UseVisualStyleBackColor = false;
            // 
            // usernameText
            // 
            this.usernameText.AutoSize = true;
            this.usernameText.BackColor = System.Drawing.Color.Transparent;
            this.usernameText.ForeColor = System.Drawing.Color.Black;
            this.usernameText.Location = new System.Drawing.Point(30, 130);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(56, 12);
            this.usernameText.TabIndex = 25;
            this.usernameText.Text = "Username";
            // 
            // usernameBox
            // 
            this.usernameBox.FormattingEnabled = true;
            this.usernameBox.Location = new System.Drawing.Point(182, 132);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(260, 20);
            this.usernameBox.TabIndex = 24;
            this.usernameBox.TextChanged += new System.EventHandler(this.usernameBox_TextChanged);
            // 
            // Form1
            // 
            this.usernameBox.Font = new System.Drawing.Font(_fontCollection.Families[0], 10F);
            this.usernameText.Font = new System.Drawing.Font(_fontCollection.Families[1], 17F);
            this.crossResolution.Font = new System.Drawing.Font(_fontCollection.Families[0], 15F);
            this.resolutionHeight.Font = new System.Drawing.Font(_fontCollection.Families[0], 10F);
            this.resolutionWidth.Font = new System.Drawing.Font(_fontCollection.Families[0], 10F);
            this.ResolutionText.Font = new System.Drawing.Font(_fontCollection.Families[1], 17F);
            this.SongsFolderbox.Font = new System.Drawing.Font(_fontCollection.Families[0], 10F);
            this.configText.Font = new System.Drawing.Font(_fontCollection.Families[1], 17F);
            this.Config.Font = new System.Drawing.Font(_fontCollection.Families[0], 12F);
            this.SongsFolderText.Font = new System.Drawing.Font(_fontCollection.Families[1], 17F);
            this.osuFolderbox.Font = new System.Drawing.Font(_fontCollection.Families[0], 10F);
            this.osuFolderText.Font = new System.Drawing.Font(_fontCollection.Families[1], 17F);
            this.serverText.Font = new System.Drawing.Font(_fontCollection.Families[1], 17F);
            this.serverList.Font = new System.Drawing.Font(_fontCollection.Families[0], 10F);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(533, 277);
            this.Controls.Add(this.saveUsername);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.advancedSetting);
            this.Controls.Add(this.automaticDetection);
            this.Controls.Add(this.osuFolderbox);
            this.Controls.Add(this.saveFolder);
            this.Controls.Add(this.saveServer);
            this.Controls.Add(this.osuFolderText);
            this.Controls.Add(this.serverText);
            this.Controls.Add(this.serverList);
            this.Controls.Add(this.osulaunch);
            this.Controls.Add(this.changeonlyFullscreen);
            this.Controls.Add(this.crossResolution);
            this.Controls.Add(this.resolutionHeight);
            this.Controls.Add(this.resolutionWidth);
            this.Controls.Add(this.ResolutionText);
            this.Controls.Add(this.usecustomResolution);
            this.Controls.Add(this.SaveSongs);
            this.Controls.Add(this.SongsFolderbox);
            this.Controls.Add(this.changeSongs);
            this.Controls.Add(this.configText);
            this.Controls.Add(this.Config);
            this.Controls.Add(this.SongsFolderText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OsuLauncher";
            this.Text = "osu! Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Button osulaunch;
        private System.Windows.Forms.ComboBox serverList;
        private System.Windows.Forms.Label serverText;
        private System.Windows.Forms.Label osuFolderText;
        private CheckBox saveServer;
        private CheckBox saveFolder;
        private FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox osuFolderbox;
        private Button automaticDetection;
        private System.Windows.Forms.Label SongsFolderText;
        private ComboBox Config;
        private System.Windows.Forms.Label configText;
        private CheckBox changeSongs;
        private System.Windows.Forms.ComboBox SongsFolderbox;
        private CheckBox SaveSongs;
        private CheckBox usecustomResolution;
        private System.Windows.Forms.Label ResolutionText;
        private System.Windows.Forms.TextBox resolutionWidth;
        private System.Windows.Forms.TextBox resolutionHeight;
        private Label crossResolution;
        private CheckBox changeonlyFullscreen;
        private CheckBox advancedSetting;
        private CheckBox saveUsername;
        private System.Windows.Forms.Label usernameText;
        private ComboBox usernameBox;
    }
}

