using TyruntSync.Theme;

namespace TyruntSync
{
    partial class TyruntForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TyruntForm));
            this.mNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.TyruntTabs = new TyruntSync.Theme.XylosTabControl();
            this.connectedPage = new System.Windows.Forms.TabPage();
            this.connectedPanel = new TyruntSync.Theme.GroupPanelBox();
            this.connectedDeviceListView = new TyruntSync.Theme.ListViewDB();
            this.device_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.device_version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.device_model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.device_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.device_connected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.homeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.torrentPage = new System.Windows.Forms.TabPage();
            this.launchedPanel = new TyruntSync.Theme.GroupPanelBox();
            this.torrentLogListView = new TyruntSync.Theme.ListViewDB();
            this.torrent_author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.torrent_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.torrent_size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.torrent_seeds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.torrent_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.torrentMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMagnetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.favPage = new System.Windows.Forms.TabPage();
            this.favoritePanel = new TyruntSync.Theme.GroupPanelBox();
            this.favoriteTorrentListView = new TyruntSync.Theme.ListViewDB();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.favMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMagnetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TyruntTabs.SuspendLayout();
            this.connectedPage.SuspendLayout();
            this.connectedPanel.SuspendLayout();
            this.homeMenu.SuspendLayout();
            this.torrentPage.SuspendLayout();
            this.launchedPanel.SuspendLayout();
            this.torrentMenu.SuspendLayout();
            this.favPage.SuspendLayout();
            this.favoritePanel.SuspendLayout();
            this.favMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mNotify
            // 
            this.mNotify.Text = "notifyIcon1";
            this.mNotify.Visible = true;
            // 
            // TyruntTabs
            // 
            this.TyruntTabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TyruntTabs.Controls.Add(this.connectedPage);
            this.TyruntTabs.Controls.Add(this.torrentPage);
            this.TyruntTabs.Controls.Add(this.favPage);
            this.TyruntTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TyruntTabs.FirstHeaderBorder = false;
            this.TyruntTabs.ItemSize = new System.Drawing.Size(40, 180);
            this.TyruntTabs.Location = new System.Drawing.Point(0, 0);
            this.TyruntTabs.Multiline = true;
            this.TyruntTabs.Name = "TyruntTabs";
            this.TyruntTabs.SelectedIndex = 0;
            this.TyruntTabs.Size = new System.Drawing.Size(834, 341);
            this.TyruntTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TyruntTabs.TabIndex = 0;
            // 
            // connectedPage
            // 
            this.connectedPage.BackColor = System.Drawing.Color.White;
            this.connectedPage.Controls.Add(this.connectedPanel);
            this.connectedPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.connectedPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.connectedPage.Location = new System.Drawing.Point(184, 4);
            this.connectedPage.Name = "connectedPage";
            this.connectedPage.Padding = new System.Windows.Forms.Padding(3);
            this.connectedPage.Size = new System.Drawing.Size(646, 333);
            this.connectedPage.TabIndex = 0;
            this.connectedPage.Text = "Home";
            // 
            // connectedPanel
            // 
            this.connectedPanel.Controls.Add(this.connectedDeviceListView);
            this.connectedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectedPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.connectedPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.connectedPanel.Location = new System.Drawing.Point(3, 3);
            this.connectedPanel.Name = "connectedPanel";
            this.connectedPanel.NoRounding = false;
            this.connectedPanel.Size = new System.Drawing.Size(640, 327);
            this.connectedPanel.TabIndex = 0;
            this.connectedPanel.Text = "Connected Devices";
            // 
            // connectedDeviceListView
            // 
            this.connectedDeviceListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectedDeviceListView.BackColor = System.Drawing.SystemColors.Control;
            this.connectedDeviceListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.connectedDeviceListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.device_type,
            this.device_version,
            this.device_model,
            this.device_ip,
            this.device_connected});
            this.connectedDeviceListView.ContextMenuStrip = this.homeMenu;
            this.connectedDeviceListView.FullRowSelect = true;
            this.connectedDeviceListView.Location = new System.Drawing.Point(3, 32);
            this.connectedDeviceListView.Name = "connectedDeviceListView";
            this.connectedDeviceListView.Size = new System.Drawing.Size(634, 292);
            this.connectedDeviceListView.TabIndex = 0;
            this.connectedDeviceListView.UseCompatibleStateImageBehavior = false;
            this.connectedDeviceListView.View = System.Windows.Forms.View.Details;
            // 
            // device_type
            // 
            this.device_type.Text = "Device";
            this.device_type.Width = 103;
            // 
            // device_version
            // 
            this.device_version.Text = "Version";
            this.device_version.Width = 189;
            // 
            // device_model
            // 
            this.device_model.Text = "Model";
            this.device_model.Width = 106;
            // 
            // device_ip
            // 
            this.device_ip.Text = "IP";
            this.device_ip.Width = 152;
            // 
            // device_connected
            // 
            this.device_connected.Text = "Connected";
            this.device_connected.Width = 82;
            // 
            // homeMenu
            // 
            this.homeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectToolStripMenuItem});
            this.homeMenu.Name = "homeMenu";
            this.homeMenu.Size = new System.Drawing.Size(134, 26);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // torrentPage
            // 
            this.torrentPage.BackColor = System.Drawing.Color.White;
            this.torrentPage.Controls.Add(this.launchedPanel);
            this.torrentPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.torrentPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.torrentPage.Location = new System.Drawing.Point(184, 4);
            this.torrentPage.Name = "torrentPage";
            this.torrentPage.Padding = new System.Windows.Forms.Padding(3);
            this.torrentPage.Size = new System.Drawing.Size(646, 333);
            this.torrentPage.TabIndex = 1;
            this.torrentPage.Text = "Torrents";
            // 
            // launchedPanel
            // 
            this.launchedPanel.Controls.Add(this.torrentLogListView);
            this.launchedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.launchedPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.launchedPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.launchedPanel.Location = new System.Drawing.Point(3, 3);
            this.launchedPanel.Name = "launchedPanel";
            this.launchedPanel.NoRounding = false;
            this.launchedPanel.Size = new System.Drawing.Size(640, 327);
            this.launchedPanel.TabIndex = 1;
            this.launchedPanel.Text = "Launched Torrents";
            // 
            // torrentLogListView
            // 
            this.torrentLogListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.torrentLogListView.BackColor = System.Drawing.SystemColors.Control;
            this.torrentLogListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.torrentLogListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.torrent_author,
            this.torrent_name,
            this.torrent_size,
            this.torrent_seeds,
            this.torrent_date});
            this.torrentLogListView.ContextMenuStrip = this.torrentMenu;
            this.torrentLogListView.FullRowSelect = true;
            this.torrentLogListView.Location = new System.Drawing.Point(3, 32);
            this.torrentLogListView.Name = "torrentLogListView";
            this.torrentLogListView.Size = new System.Drawing.Size(634, 292);
            this.torrentLogListView.TabIndex = 0;
            this.torrentLogListView.UseCompatibleStateImageBehavior = false;
            this.torrentLogListView.View = System.Windows.Forms.View.Details;
            // 
            // torrent_author
            // 
            this.torrent_author.Text = "Author";
            this.torrent_author.Width = 110;
            // 
            // torrent_name
            // 
            this.torrent_name.Text = "Torrent";
            this.torrent_name.Width = 227;
            // 
            // torrent_size
            // 
            this.torrent_size.Text = "Size";
            this.torrent_size.Width = 88;
            // 
            // torrent_seeds
            // 
            this.torrent_seeds.Text = "Seeds";
            // 
            // torrent_date
            // 
            this.torrent_date.Text = "Date";
            this.torrent_date.Width = 148;
            // 
            // torrentMenu
            // 
            this.torrentMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMagnetToolStripMenuItem,
            this.downloadToolStripMenuItem1});
            this.torrentMenu.Name = "torrentMenu";
            this.torrentMenu.Size = new System.Drawing.Size(147, 48);
            // 
            // copyMagnetToolStripMenuItem
            // 
            this.copyMagnetToolStripMenuItem.Name = "copyMagnetToolStripMenuItem";
            this.copyMagnetToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.copyMagnetToolStripMenuItem.Text = "Copy Magnet";
            this.copyMagnetToolStripMenuItem.Click += new System.EventHandler(this.copyMagnetToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem1
            // 
            this.downloadToolStripMenuItem1.Name = "downloadToolStripMenuItem1";
            this.downloadToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.downloadToolStripMenuItem1.Text = "Download";
            this.downloadToolStripMenuItem1.Click += new System.EventHandler(this.downloadToolStripMenuItem1_Click);
            // 
            // favPage
            // 
            this.favPage.BackColor = System.Drawing.Color.White;
            this.favPage.Controls.Add(this.favoritePanel);
            this.favPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.favPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.favPage.Location = new System.Drawing.Point(184, 4);
            this.favPage.Name = "favPage";
            this.favPage.Padding = new System.Windows.Forms.Padding(3);
            this.favPage.Size = new System.Drawing.Size(646, 333);
            this.favPage.TabIndex = 2;
            this.favPage.Text = "Favorites";
            // 
            // favoritePanel
            // 
            this.favoritePanel.Controls.Add(this.favoriteTorrentListView);
            this.favoritePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favoritePanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.favoritePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.favoritePanel.Location = new System.Drawing.Point(3, 3);
            this.favoritePanel.Name = "favoritePanel";
            this.favoritePanel.NoRounding = false;
            this.favoritePanel.Size = new System.Drawing.Size(640, 327);
            this.favoritePanel.TabIndex = 2;
            this.favoritePanel.Text = "Favorite Torrents";
            // 
            // favoriteTorrentListView
            // 
            this.favoriteTorrentListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.favoriteTorrentListView.BackColor = System.Drawing.SystemColors.Control;
            this.favoriteTorrentListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.favoriteTorrentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.favoriteTorrentListView.ContextMenuStrip = this.favMenu;
            this.favoriteTorrentListView.FullRowSelect = true;
            this.favoriteTorrentListView.Location = new System.Drawing.Point(3, 32);
            this.favoriteTorrentListView.Name = "favoriteTorrentListView";
            this.favoriteTorrentListView.Size = new System.Drawing.Size(634, 292);
            this.favoriteTorrentListView.TabIndex = 0;
            this.favoriteTorrentListView.UseCompatibleStateImageBehavior = false;
            this.favoriteTorrentListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Author";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Torrent";
            this.columnHeader2.Width = 231;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Seeds";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date";
            this.columnHeader5.Width = 144;
            // 
            // favMenu
            // 
            this.favMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMagnetToolStripMenuItem1,
            this.downloadToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.favMenu.Name = "favMenu";
            this.favMenu.Size = new System.Drawing.Size(147, 70);
            // 
            // copyMagnetToolStripMenuItem1
            // 
            this.copyMagnetToolStripMenuItem1.Name = "copyMagnetToolStripMenuItem1";
            this.copyMagnetToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.copyMagnetToolStripMenuItem1.Text = "Copy Magnet";
            this.copyMagnetToolStripMenuItem1.Click += new System.EventHandler(this.copyMagnetToolStripMenuItem1_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // TyruntForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 341);
            this.Controls.Add(this.TyruntTabs);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TyruntForm";
            this.Text = "TyruntSync - Mr Smithy x";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnTyruntFormClosing);
            this.TyruntTabs.ResumeLayout(false);
            this.connectedPage.ResumeLayout(false);
            this.connectedPanel.ResumeLayout(false);
            this.homeMenu.ResumeLayout(false);
            this.torrentPage.ResumeLayout(false);
            this.launchedPanel.ResumeLayout(false);
            this.torrentMenu.ResumeLayout(false);
            this.favPage.ResumeLayout(false);
            this.favoritePanel.ResumeLayout(false);
            this.favMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Theme.XylosTabControl TyruntTabs;
        private System.Windows.Forms.TabPage connectedPage;
        private System.Windows.Forms.TabPage torrentPage;
        private ListViewDB torrentLogListView;
        private System.Windows.Forms.ColumnHeader torrent_author;
        private System.Windows.Forms.ColumnHeader torrent_name;
        private System.Windows.Forms.ColumnHeader torrent_size;
        private System.Windows.Forms.ColumnHeader torrent_seeds;
        private System.Windows.Forms.ColumnHeader torrent_date;
        private System.Windows.Forms.TabPage favPage;
        private GroupPanelBox connectedPanel;
        private ListViewDB connectedDeviceListView;
        private System.Windows.Forms.ColumnHeader device_type;
        private System.Windows.Forms.ColumnHeader device_version;
        private System.Windows.Forms.ColumnHeader device_model;
        private System.Windows.Forms.ColumnHeader device_ip;
        private System.Windows.Forms.ColumnHeader device_connected;
        private GroupPanelBox launchedPanel;
        private System.Windows.Forms.NotifyIcon mNotify;
        private GroupPanelBox favoritePanel;
        private ListViewDB favoriteTorrentListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip homeMenu;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip torrentMenu;
        private System.Windows.Forms.ToolStripMenuItem copyMagnetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip favMenu;
        private System.Windows.Forms.ToolStripMenuItem copyMagnetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}

