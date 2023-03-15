namespace GiftShopView
{
    partial class FormReportGiftComponents
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.GiftCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComponentCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сохранить в Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GiftCol,
            this.ComponentCol,
            this.CountCol});
            this.dataGridView.Location = new System.Drawing.Point(1, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(616, 594);
            this.dataGridView.TabIndex = 1;
            // 
            // GiftCol
            // 
            this.GiftCol.HeaderText = "Подарок";
            this.GiftCol.Name = "GiftCol";
            this.GiftCol.Width = 191;
            // 
            // ComponentCol
            // 
            this.ComponentCol.HeaderText = "Компонент";
            this.ComponentCol.Name = "ComponentCol";
            this.ComponentCol.Width = 191;
            // 
            // CountCol
            // 
            this.CountCol.HeaderText = "Количество";
            this.CountCol.Name = "CountCol";
            this.CountCol.Width = 191;
            // 
            // FormReportGiftComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 634);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button1);
            this.Name = "FormReportGiftComponents";
            this.Text = "Подарки с компонентами";
            this.Load += new System.EventHandler(this.FormReportGiftComponents_Load);
            this.Click += new System.EventHandler(this.buttonSave_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountCol;
    }
}