
namespace GiftShopView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.DirectoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокПодарковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подаркиСКомпонентамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DirectoriesToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(966, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // DirectoriesToolStripMenuItem
            // 
            this.DirectoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComponentsToolStripMenuItem,
            this.ProductsToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.DirectoriesToolStripMenuItem.Name = "DirectoriesToolStripMenuItem";
            this.DirectoriesToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.DirectoriesToolStripMenuItem.Text = "Справочники";
            // 
            // ComponentsToolStripMenuItem
            // 
            this.ComponentsToolStripMenuItem.Name = "ComponentsToolStripMenuItem";
            this.ComponentsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ComponentsToolStripMenuItem.Text = "Компоненты";
            this.ComponentsToolStripMenuItem.Click += new System.EventHandler(this.ComponentsToolStripMenuItem_Click);
            // 
            // ProductsToolStripMenuItem
            // 
            this.ProductsToolStripMenuItem.Name = "ProductsToolStripMenuItem";
            this.ProductsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ProductsToolStripMenuItem.Text = "Изделия";
            this.ProductsToolStripMenuItem.Click += new System.EventHandler(this.ProductsToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокПодарковToolStripMenuItem,
            this.подаркиСКомпонентамиToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокПодарковToolStripMenuItem
            // 
            this.списокПодарковToolStripMenuItem.Name = "списокПодарковToolStripMenuItem";
            this.списокПодарковToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.списокПодарковToolStripMenuItem.Text = "Список подарков";
            this.списокПодарковToolStripMenuItem.Click += new System.EventHandler(this.списокПодарковToolStripMenuItem_Click);
            // 
            // подаркиСКомпонентамиToolStripMenuItem
            // 
            this.подаркиСКомпонентамиToolStripMenuItem.Name = "подаркиСКомпонентамиToolStripMenuItem";
            this.подаркиСКомпонентамиToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.подаркиСКомпонентамиToolStripMenuItem.Text = "Подарки с компонентами";
            this.подаркиСКомпонентамиToolStripMenuItem.Click += new System.EventHandler(this.ПодаркиСКомпонентамиToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(803, 78);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(150, 27);
            this.buttonCreateOrder.TabIndex = 1;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(803, 137);
            this.buttonTakeOrderInWork.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(150, 27);
            this.buttonTakeOrderInWork.TabIndex = 2;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(803, 193);
            this.buttonOrderReady.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(150, 27);
            this.buttonOrderReady.TabIndex = 3;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(803, 253);
            this.buttonPayOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(150, 27);
            this.buttonPayOrder.TabIndex = 4;
            this.buttonPayOrder.Text = "Заказ выдан";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(803, 312);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(150, 27);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Обновить список";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 31);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(796, 370);
            this.dataGridView.TabIndex = 6;
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(966, 405);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormMain";
            this.Text = "Магазин подарков";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem DirectoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProductsToolStripMenuItem;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonTakeOrderInWork;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокПодарковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подаркиСКомпонентамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
    }
}