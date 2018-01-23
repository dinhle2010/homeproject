namespace tradetool
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVolumePercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeltaOrderBook = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeltaOrderBookPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxBuyQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxSellQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStop = new Infragistics.Win.Misc.UltraButton();
            this.btnStart = new Infragistics.Win.Misc.UltraButton();
            this.btnAuto = new Infragistics.Win.Misc.UltraButton();
            this.btnClear = new Infragistics.Win.Misc.UltraButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTickTime = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLastRow = new Infragistics.Win.Misc.UltraButton();
            this.btnBalance = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblGetData = new System.Windows.Forms.Label();
            this.cmbCurrencyPair = new System.Windows.Forms.ComboBox();
            this.txtOrderbook = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.colTotalSell,
            this.colCurrentPrice,
            this.colLastPrice,
            this.colPercent,
            this.colVolumePercent,
            this.colDeltaOrderBook,
            this.colDeltaOrderBookPercent,
            this.colMaxBuyQuantity,
            this.colMaxSellQuantity,
            this.colDatetime});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.Location = new System.Drawing.Point(3, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(920, 367);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "TotalBuy";
            this.Column1.HeaderText = "Total Buy";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // colTotalSell
            // 
            this.colTotalSell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotalSell.DataPropertyName = "TotalSell";
            this.colTotalSell.HeaderText = "Total Sell";
            this.colTotalSell.Name = "colTotalSell";
            this.colTotalSell.ReadOnly = true;
            // 
            // colCurrentPrice
            // 
            this.colCurrentPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCurrentPrice.DataPropertyName = "CurrentPrice";
            this.colCurrentPrice.HeaderText = "Current Price";
            this.colCurrentPrice.Name = "colCurrentPrice";
            this.colCurrentPrice.ReadOnly = true;
            // 
            // colLastPrice
            // 
            this.colLastPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastPrice.DataPropertyName = "DeltaPrice";
            this.colLastPrice.HeaderText = "Delta Price";
            this.colLastPrice.Name = "colLastPrice";
            this.colLastPrice.ReadOnly = true;
            // 
            // colPercent
            // 
            this.colPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPercent.DataPropertyName = "Percent";
            this.colPercent.HeaderText = "Percent";
            this.colPercent.Name = "colPercent";
            this.colPercent.ReadOnly = true;
            // 
            // colVolumePercent
            // 
            this.colVolumePercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVolumePercent.DataPropertyName = "DeltaPercent";
            this.colVolumePercent.HeaderText = "Delta Percent";
            this.colVolumePercent.Name = "colVolumePercent";
            this.colVolumePercent.ReadOnly = true;
            // 
            // colDeltaOrderBook
            // 
            this.colDeltaOrderBook.DataPropertyName = "OrderBookPercent";
            this.colDeltaOrderBook.HeaderText = "OrderBook Percent";
            this.colDeltaOrderBook.Name = "colDeltaOrderBook";
            this.colDeltaOrderBook.ReadOnly = true;
            // 
            // colDeltaOrderBookPercent
            // 
            this.colDeltaOrderBookPercent.DataPropertyName = "DeltaOrderBookPercent";
            this.colDeltaOrderBookPercent.HeaderText = "Delta OrderBook Percent";
            this.colDeltaOrderBookPercent.Name = "colDeltaOrderBookPercent";
            this.colDeltaOrderBookPercent.ReadOnly = true;
            // 
            // colMaxBuyQuantity
            // 
            this.colMaxBuyQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMaxBuyQuantity.DataPropertyName = "MaxBuyQuantity";
            this.colMaxBuyQuantity.HeaderText = "MaxBuyQuantity";
            this.colMaxBuyQuantity.Name = "colMaxBuyQuantity";
            this.colMaxBuyQuantity.ReadOnly = true;
            // 
            // colMaxSellQuantity
            // 
            this.colMaxSellQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMaxSellQuantity.DataPropertyName = "MaxSellQuantity";
            this.colMaxSellQuantity.HeaderText = "Max Sell Quantity";
            this.colMaxSellQuantity.Name = "colMaxSellQuantity";
            this.colMaxSellQuantity.ReadOnly = true;
            // 
            // colDatetime
            // 
            this.colDatetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDatetime.DataPropertyName = "Datetime";
            this.colDatetime.HeaderText = "Datetime";
            this.colDatetime.Name = "colDatetime";
            this.colDatetime.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtURL, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOrderbook, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.985037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.01496F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(926, 500);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // txtURL
            // 
            this.txtURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtURL.Location = new System.Drawing.Point(3, 60);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(920, 20);
            this.txtURL.TabIndex = 4;
            this.txtURL.Text = "https://bittrex.com/api/v1.1/public/getmarkethistory?market=USDT-XRP";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.00211F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.99789F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel2.Controls.Add(this.btnStop, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnStart, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAuto, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClear, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLastRow, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBalance, 6, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 456);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(920, 41);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(646, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(91, 35);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(528, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAuto.Location = new System.Drawing.Point(399, 3);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(123, 35);
            this.btnAuto.TabIndex = 6;
            this.btnAuto.Text = "Auto 1 minute";
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(253, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 35);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txtTickTime, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblStatus, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(244, 35);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // txtTickTime
            // 
            this.txtTickTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTickTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTickTime.Location = new System.Drawing.Point(125, 3);
            this.txtTickTime.Multiline = true;
            this.txtTickTime.Name = "txtTickTime";
            this.txtTickTime.Size = new System.Drawing.Size(116, 29);
            this.txtTickTime.TabIndex = 0;
            this.txtTickTime.Text = "60";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(116, 35);
            this.lblStatus.TabIndex = 1;
            // 
            // btnLastRow
            // 
            this.btnLastRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLastRow.Location = new System.Drawing.Point(743, 3);
            this.btnLastRow.Name = "btnLastRow";
            this.btnLastRow.Size = new System.Drawing.Size(96, 35);
            this.btnLastRow.TabIndex = 8;
            this.btnLastRow.Text = "Last Row";
            this.btnLastRow.Click += new System.EventHandler(this.btnLastRow_Click);
            // 
            // btnBalance
            // 
            this.btnBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBalance.Location = new System.Drawing.Point(845, 3);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(72, 35);
            this.btnBalance.TabIndex = 9;
            this.btnBalance.Text = "Balance";
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.83431F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.16569F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 329F));
            this.tableLayoutPanel4.Controls.Add(this.lblStartTime, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblGetData, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbCurrencyPair, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(920, 31);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(3, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(208, 31);
            this.lblStartTime.TabIndex = 0;
            // 
            // lblGetData
            // 
            this.lblGetData.AutoSize = true;
            this.lblGetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGetData.Location = new System.Drawing.Point(593, 0);
            this.lblGetData.Name = "lblGetData";
            this.lblGetData.Size = new System.Drawing.Size(324, 31);
            this.lblGetData.TabIndex = 1;
            this.lblGetData.Text = "label2";
            // 
            // cmbCurrencyPair
            // 
            this.cmbCurrencyPair.DisplayMember = "Name";
            this.cmbCurrencyPair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCurrencyPair.FormattingEnabled = true;
            this.cmbCurrencyPair.Location = new System.Drawing.Point(217, 3);
            this.cmbCurrencyPair.Name = "cmbCurrencyPair";
            this.cmbCurrencyPair.Size = new System.Drawing.Size(258, 21);
            this.cmbCurrencyPair.TabIndex = 2;
            this.cmbCurrencyPair.ValueMember = "Value";
            this.cmbCurrencyPair.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencyPair_SelectedIndexChanged);
            // 
            // txtOrderbook
            // 
            this.txtOrderbook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOrderbook.Location = new System.Drawing.Point(3, 40);
            this.txtOrderbook.Name = "txtOrderbook";
            this.txtOrderbook.Size = new System.Drawing.Size(920, 20);
            this.txtOrderbook.TabIndex = 7;
            this.txtOrderbook.Text = "https://bittrex.com/api/v1.1/public/getorderbook?market=USDT-XRP&type=both";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 500);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Infragistics.Win.Misc.UltraButton btnStop;
        private Infragistics.Win.Misc.UltraButton btnStart;
        private Infragistics.Win.Misc.UltraButton btnAuto;
        private Infragistics.Win.Misc.UltraButton btnClear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtTickTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblGetData;
        private Infragistics.Win.Misc.UltraButton btnLastRow;
        private System.Windows.Forms.TextBox txtOrderbook;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolumePercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeltaOrderBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeltaOrderBookPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxBuyQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxSellQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatetime;
        private System.Windows.Forms.ComboBox cmbCurrencyPair;
        private System.Windows.Forms.Button btnBalance;
    }
}

