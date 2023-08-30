using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;
using System.Linq;

namespace osu_launcher
{
    public partial class Form1 : Form
    {
        private static Process _osuprocess;
        public Form1()
        {
            InitializeComponent();

            //ウィンドウの設定
            ResumeLayout(false);
            PerformLayout();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            //label1の設定
            label1.ForeColor = Color.FromArgb(255, 255, 255);
            label1.BackColor = Color.Transparent;

            //label3の設定 
            label3.ForeColor = Color.FromArgb(255, 255, 255);
            label3.BackColor = Color.Transparent;

            //checkBox1,2の設定
            checkBox1.ForeColor = Color.FromArgb(255, 255, 255);
            checkBox1.BackColor = Color.Transparent;
            checkBox1.Enabled = false;
            checkBox2.ForeColor = Color.FromArgb(255, 255, 255);
            checkBox2.BackColor = Color.Transparent;
            if (textBox1.Text == "")
            {
                checkBox2.Enabled = false;
            }

            //サーバー一覧を取得し、comboBox1に追加
            StreamReader streamReader = new StreamReader("./serverdata.json", Encoding.GetEncoding("Shift_JIS"));
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            JObject serverdata = JObject.Parse(str);

            //osu!のインストール先を取得
            StreamReader osustreamReader = new StreamReader("./osulocation.txt", Encoding.GetEncoding("Shift_JIS"));
            string locationstr = osustreamReader.ReadToEnd();
            osustreamReader.Close();

            //osu!のインストール先をtextBox1に、サーバーをcomboBox1に追加
            comboBox1.Text = "osu!bancho";
            textBox1.Text = locationstr;

            //サーバー一覧をcomboBox1に追加
            foreach (var server in serverdata["links"])
            {
                comboBox1.Items.Add(server);
            }
        }

        private void Osulaunch_pushed(object sender, EventArgs e)
        {
            try
            {
                //osu!のインストール先を取得
                StreamReader osustreamReader = new StreamReader("./osulocation.txt", Encoding.GetEncoding("Shift_JIS"));
                string locationstr = osustreamReader.ReadToEnd();
                osustreamReader.Close();

                //osu!のインストール先とサーバーの指定(サーバーはプラベ鯖メインで考えてある)
                string osulocation = locationstr.Replace("/osu!.exe", "");
                string serverlocation = $"-devserver {comboBox1.Text}";

                //osu!のインストール先の指定がない場合の処理
                if (locationstr == "" && textBox1.Text == "") //osu!のインストール先が保存されてない、かつ指定されていない場合
                {
                    MessageBox.Show(@"osu!のインストール先を指定してください。", "エラー");
                    return;
                }
                else if (locationstr != "" && textBox1.Text == "") //osu!のインストール先が保存されている、かつ指定されていない場合
                {
                    osulocation = locationstr;
                }
                else if (locationstr != "" && textBox1.Text != "") //osu!のインストール先が保存されている、かつ指定されている場合。この場合は入力された方を優先して指定する
                {
                    osulocation = textBox1.Text.Replace("/osu!.exe", "");
                }
                else //とりあえず指定された方を優先して指定する
                {
                    osulocation = textBox1.Text.Replace("/osu!.exe", "");
                }

                if (comboBox1.Text == @"osu!bancho" | comboBox1.Text == "") //サーバーがosu!bancho、または指定されていない場合はサーバーの指定をせず、そのまま起動する
                {
                    serverlocation = "";
                }

                if (checkBox1.Checked) //サーバーの登録チェックボックスがチェックされている場合
                {
                    //サーバーの登録
                    StreamReader streamReader = new StreamReader("./serverdata.json", Encoding.GetEncoding("Shift_JIS"));
                    string str = streamReader.ReadToEnd();
                    streamReader.Close();
                    JObject serverdata = JObject.Parse(str);
                    serverdata["links"].Last.AddAfterSelf(comboBox1.Text);
                    Encoding enc = Encoding.GetEncoding("Shift_JIS");
                    StreamWriter writer = new StreamWriter("./serverdata.json", false, enc);
                    string jsonData = JsonConvert.SerializeObject(serverdata, Formatting.Indented);
                    writer.Write(jsonData);
                    writer.Close();
                    comboBox1.Items.Add(comboBox1.Text);
                    MessageBox.Show("サーバーの登録が完了しました。", "サーバー登録完了");
                    checkBox1.Checked = false;
                }

                if (checkBox2.Checked) //osu!のインストール先の保存チェックボックスがチェックされている場合
                {
                    StreamWriter osustreamWriter = new StreamWriter("./osulocation.txt", false, Encoding.GetEncoding("Shift_JIS"));
                    osustreamWriter.Write(textBox1.Text.Replace("/osu!.exe", ""));
                    osustreamWriter.Close();
                }

                if (Process.GetProcessesByName("osu!").Length > 0) //osu!が既に起動している場合
                {
                    MessageBox.Show("osu!は既に起動中です。一度osu!を閉じてから起動してください。", "起動できません！");
                    return;
                }

                StreamReader serverReader = new StreamReader("./serverdata.json", Encoding.GetEncoding("Shift_JIS"));
                string serverString = serverReader.ReadToEnd();
                serverReader.Close();
                JObject serverRawData = JObject.Parse(serverString);
                string[] serverlistarray = serverRawData["links"].ToObject<string[]>();

                checkBox2.Enabled = textBox1.Text != locationstr;
                checkBox1.Enabled = !ArrayContains(serverlistarray, comboBox1.Text);

                //osu!の起動
                _osuprocess = new Process();
                _osuprocess.StartInfo.FileName = $"{osulocation}/osu!.exe";
                _osuprocess.StartInfo.Arguments = serverlocation;
                _osuprocess.StartInfo.UseShellExecute = false;
                _osuprocess.Start();
            }
            catch (Exception)　//osu!.exeが見つからなかった場合
            {
                MessageBox.Show("フォルダからosu!.exeが見つかりませんでした。", "エラー");
            }
        }

        private bool ArrayContains(string[] array, string value)
        {
            foreach (string item in array)
            {
                if (item == value)
                {
                    return true;
                }
            }
            return false;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //サーバーの登録
            StreamReader streamReader = new StreamReader("./serverdata.json", Encoding.GetEncoding("Shift_JIS"));
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            JObject serverdata = JObject.Parse(str);
            string[] serverarray = serverdata["links"].ToObject<string[]>();
            if (comboBox1.Text == "")
            {
                checkBox1.Enabled = false;
                return;
            }
            checkBox1.Enabled = !ArrayContains(serverarray, comboBox1.Text); //既に登録されている場合
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //osu!のインストール先を取得
            StreamReader osustreamReader = new StreamReader("./osulocation.txt", Encoding.GetEncoding("Shift_JIS"));
            string locationstr = osustreamReader.ReadToEnd();
            osustreamReader.Close();
            if (textBox1.Text == "")
            {
                checkBox2.Enabled = false;
                return;
            }
            checkBox2.Enabled = textBox1.Text != locationstr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string processName = "osu!";

            string processPath = GetProcessPath(processName);

            if (!string.IsNullOrEmpty(processPath))
            {
                textBox1.Text = processPath.Replace(@"\osu!.exe", "");
            }
            else
            {
                MessageBox.Show("osu!.exeが見つかりませんでした。起動してからもう一度お試しください。", "エラー");
            }
        }

        static string GetProcessPath(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 0)
            {
                string processPath = processes[0].MainModule.FileName;
                return processPath;
            }

            return null;
        }
    }
}
