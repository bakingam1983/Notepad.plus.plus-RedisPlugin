// Visit https://npp-dotnet.github.io/Npp.DotNet.Plugin to learn more.

using Microsoft.VisualBasic;
using Npp.DotNet.Plugin;
using Npp.DotNet.Plugin.Winforms;
using Npp.DotNet.Plugin.Winforms.Classes;
using StackExchange.Redis;
using System.Windows.Forms;

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

            BtnLoadKey.Enabled=false;
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnConnect = new Button();
            TxtRedisServer = new TextBox();
            label1 = new Label();
            BtnLoadKey = new Button();
            Key = new DataGridViewTextBoxColumn();
            Expiry = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Obj = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
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
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Key, Expiry, Size, Obj });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(908, 509);
            dataGridView1.TabIndex = 3;
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
            // Key
            // 
            Key.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Key.HeaderText = "Key";
            Key.MinimumWidth = 6;
            Key.Name = "Key";
            Key.ReadOnly = true;
            // 
            // Expiry
            // 
            Expiry.HeaderText = "Expiration";
            Expiry.MinimumWidth = 6;
            Expiry.Name = "Expiry";
            Expiry.ReadOnly = true;
            Expiry.Width = 125;
            // 
            // Size
            // 
            Size.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Size.HeaderText = "Size";
            Size.MinimumWidth = 6;
            Size.Name = "Size";
            Size.ReadOnly = true;
            Size.Width = 65;
            // 
            // Obj
            // 
            Obj.HeaderText = "Obj";
            Obj.MinimumWidth = 6;
            Obj.Name = "Obj";
            Obj.ReadOnly = true;
            Obj.Visible = false;
            Obj.Width = 125;
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        static readonly NppTbMsg InitialDockPosition = NppTbMsg.DWS_DF_CONT_RIGHT;
        private Button BtnLoadKey;
        IniFile config;
        private System.ComponentModel.IContainer components;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn Expiry;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Obj;
        private DataGridView dataGridView1;
     
        private async void BtnConnect_Click(object sender, EventArgs e)
        {         
            dataGridView1.Rows.Clear();
         
            if (string.IsNullOrEmpty(TxtRedisServer.Text))
            {
                MessageBox.Show($"Set the server address", "Redis Plugin", MessageBoxButtons.OK);
                return;
            }

            try
            {
                using var redis = await StackExchange.Redis.ConnectionMultiplexer.ConnectAsync(TxtRedisServer.Text, x => { x.AbortOnConnectFail=true; x.SyncTimeout=30000; });

                var server = redis.GetServer(TxtRedisServer.Text);
                var keys = server.Keys();

                var orderedKeys = keys.Where(x => !string.IsNullOrEmpty(x.ToString())).OrderBy(x => x.ToString());

                foreach (var key in orderedKeys)
                {
                    var result = server.Execute("MEMORY", "USAGE", key);
                    var value = result.ToString();
                    if (result.Resp2Type== ResultType.Integer)
                    {
                        var val = int.Parse(value);
                        //val in Bytes

                        if (val<1024)
                        {
                            value= $"{val:0.00} B";
                        }
                        else
                        {
                            var valKB = val/1024.0;
                            if (valKB>1024)
                            {
                                var valMB = valKB/1024.0;
                                value= $"{valMB:0.00} MB";
                            }
                            else
                            {
                                value= $"{valKB:0.00} KB";
                            }
                        }
                    }

                    var expireTime = await redis.GetDatabase().KeyExpireTimeAsync(key);

                    RedisKey newkey = new RedisKey()
                    {
                        KeyName = key,
                        KeyExpiry=expireTime,
                        KeyMemoryUsageResult = value
                    };

                    //the datagridrow is like this:
                    //| KeyName | Expiry | KeyMemoryUsageResult | RedisKey |
                    dataGridView1.Rows.Add(newkey.KeyName, newkey.KeyExpiry, newkey.KeyMemoryUsageResult, newkey);
                }                
            }
            catch (RedisConnectionException rcex)
            {
                MessageBox.Show("Error in server connection, check the exception message:\n " + rcex.ToString(), "Redis plugin", MessageBoxButtons.OK);
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Redis connection timeout, check the server address and/or if the server is online.", "Redis plugin", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Redis plugin", MessageBoxButtons.OK);
            }
            finally
            {
                if (dataGridView1.Rows.Count>0)
                {
                    BtnLoadKey.Enabled=true;
                }
            }

        }                
        private async void BtnLoadKey_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count==0)
            {
                MessageBox.Show($"Select a key to open.", "Redis Plugin", MessageBoxButtons.OK);
                return;
            }
            
            if (dataGridView1.SelectedCells.Count>0)
            {
                //the datagridrow is like this:
                //| KeyName | Expiry | KeyMemoryUsageResult | RedisKey |
                try
                {
                    var obj = dataGridView1.SelectedCells[0].OwningRow.Cells[3].Value as RedisKey;

                    using var redis = await StackExchange.Redis.ConnectionMultiplexer.ConnectAsync(TxtRedisServer.Text, x => { x.AbortOnConnectFail=true; x.SyncTimeout=30000; });
                    var redisDb = redis.GetDatabase();
                    var tmp = await redisDb.StringGetAsync(obj.KeyName);
                    PluginData.Notepad.FileNew();
                    PluginData.Editor.AddText(tmp);
                }
                catch (TimeoutException)
                {
                    MessageBox.Show("Redis connection timeout, check the server address and/or if the server is online.", "Redis plugin", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Redis plugin", MessageBoxButtons.OK);
                }
                
            }            
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);            
        }
    }
    public class RedisKey
    {
        public string KeyName { get; set; }
        public DateTime? KeyExpiry { get; set; }
        public string KeyMemoryUsageResult{get;set;}

        public override string ToString()
        {
            return KeyName + " | " + KeyMemoryUsageResult;
        }
    }
}
