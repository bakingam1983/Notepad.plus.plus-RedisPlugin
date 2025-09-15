// Visit https://npp-dotnet.github.io/Npp.DotNet.Plugin to learn more.

using Npp.DotNet.Plugin;
using Npp.DotNet.Plugin.Winforms;
using Npp.DotNet.Plugin.Winforms.Classes;
using StackExchange.Redis;

namespace RedisPlugin
{
#nullable disable warnings
    internal class Form1 : DockingForm
    {
        public Form1(int dlgID, string pluginName, Icon frmIcon)
            : base(dlgID, pluginName, FormTitle, null, frmIcon, InitialDockPosition)
        {
            InitializeComponent();
            AttachEventHandlers();
            ToggleDarkMode(PluginData.Notepad.IsDarkModeEnabled());

            //MessageBox.Show("form1 new", "Redis Debug", MessageBoxButtons.OK);
            config = new IniFile();
            //MessageBox.Show($"config.FilePath: {config.FilePath}", "Redis Debug", MessageBoxButtons.OK);
            config.Load(config.FilePath);
            //MessageBox.Show($"config.RedisDefaultServer: {config.RedisDefaultServer}", "Redis Debug", MessageBoxButtons.OK);
            TxtRedisServer.Text= config.RedisDefaultServer;
        }

        /// <inheritdoc cref="FormBase.ToggleDarkMode"/>
        public override void ToggleDarkMode(bool isDark)
        {
            //if (isDark)
            //{
            //    DarkMode.DarkModeColors theme = new();
            //    button1.BackColor = theme.SofterBackground;
            //    button1.ForeColor = theme.Text;
            //}
            //else
            //{
            //    button1.BackColor = Color.FromKnownColor(KnownColor.ButtonFace);
            //    button1.ForeColor = DefaultForeColor;
            //}
        }

        /// <inheritdoc cref="FormBase.AttachEventHandlers"/>
        protected override void AttachEventHandlers()
        {
            base.AttachEventHandlers();
            //textBox1?.Focus();

        }

        private void Button1Click(object? sender, EventArgs e)
        {
            try
            {
                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"https://npp-user-manual.org/docs/plugin-communication/#2036nppm_modelessdialog";
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"{error.Message}\0",
                    $"{error.GetType().Name}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnConnect = new Button();
            TxtRedisServer = new TextBox();
            label1 = new Label();
            listBox1 = new ListBox();
            BtnLoadKey = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(listBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(BtnLoadKey, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(914, 600);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.Controls.Add(BtnConnect, 2, 0);
            tableLayoutPanel2.Controls.Add(TxtRedisServer, 1, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(908, 39);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // BtnConnect
            // 
            BtnConnect.Dock = DockStyle.Fill;
            BtnConnect.Location = new Point(811, 3);
            BtnConnect.Name = "BtnConnect";
            BtnConnect.Size = new Size(94, 33);
            BtnConnect.TabIndex = 1;
            BtnConnect.Text = "Connect";
            BtnConnect.UseVisualStyleBackColor = true;
            BtnConnect.Click += BtnConnect_Click;
            // 
            // TxtRedisServer
            // 
            TxtRedisServer.Dock = DockStyle.Fill;
            TxtRedisServer.Location = new Point(102, 3);
            TxtRedisServer.Name = "TxtRedisServer";
            TxtRedisServer.Size = new Size(703, 27);
            TxtRedisServer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 2;
            label1.Text = "Server Redis:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(3, 48);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(908, 509);
            listBox1.TabIndex = 1;
            // 
            // BtnLoadKey
            // 
            BtnLoadKey.Dock = DockStyle.Fill;
            BtnLoadKey.Location = new Point(3, 563);
            BtnLoadKey.Name = "BtnLoadKey";
            BtnLoadKey.Size = new Size(908, 34);
            BtnLoadKey.TabIndex = 2;
            BtnLoadKey.Text = "Load";
            BtnLoadKey.UseVisualStyleBackColor = true;
            BtnLoadKey.Click += BtnLoadKey_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(tableLayoutPanel1);
            Location = new Point(0, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        static readonly string FormTitle = "Redis Plugin";
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnConnect;
        private TextBox TxtRedisServer;
        private Label label1;
        private ListBox listBox1;
        static readonly NppTbMsg InitialDockPosition = NppTbMsg.DWS_DF_CONT_RIGHT;
        ConnectionMultiplexer Redis;
        private Button BtnLoadKey;
        IniFile config;
        IDatabase RedisDb;
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Redis = StackExchange.Redis.ConnectionMultiplexer.Connect(TxtRedisServer.Text, x => { x.AbortOnConnectFail=false; x.SyncTimeout=120000; });
            var redisConnectionStatus = Redis.GetStatus();
            //MessageBox.Show(redisConnectionStatus, "Redis Connection Status", MessageBoxButtons.OK);
            var server = Redis.GetServer(TxtRedisServer.Text);
            var keys = server.Keys();

            foreach (var key in keys)
            {
                listBox1.Items.Add(key);
            }
            RedisDb = Redis.GetDatabase();

        }                
        private void BtnLoadKey_Click(object sender, EventArgs e)
        {
            var key = listBox1.SelectedItem.ToString();           
            var tmp = RedisDb.StringGet(key);
            PluginData.Notepad.FileNew();
            PluginData.Editor.AddText(tmp);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                Redis.Close();
                Redis.Dispose();
            }
        }
    }
}
