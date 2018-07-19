namespace TreeViewApplication
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeViewData = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьНовуюВеткуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВТекущуюВеткуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовуюВеткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВТекущуюВеткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewData
            // 
            this.treeViewData.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewData.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewData.HideSelection = false;
            this.treeViewData.Location = new System.Drawing.Point(0, 24);
            this.treeViewData.Name = "treeViewData";
            this.treeViewData.Size = new System.Drawing.Size(228, 316);
            this.treeViewData.TabIndex = 0;
            this.treeViewData.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewData_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьНовуюВеткуToolStripMenuItem1,
            this.добавитьВТекущуюВеткуToolStripMenuItem1,
            this.изменитьToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.удалитьToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(221, 98);
            // 
            // добавитьНовуюВеткуToolStripMenuItem1
            // 
            this.добавитьНовуюВеткуToolStripMenuItem1.Name = "добавитьНовуюВеткуToolStripMenuItem1";
            this.добавитьНовуюВеткуToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.добавитьНовуюВеткуToolStripMenuItem1.Text = "Добавить новую ветку";
            this.добавитьНовуюВеткуToolStripMenuItem1.Click += new System.EventHandler(this.добавитьНовуюВеткуToolStripMenuItem1_Click);
            // 
            // добавитьВТекущуюВеткуToolStripMenuItem1
            // 
            this.добавитьВТекущуюВеткуToolStripMenuItem1.Name = "добавитьВТекущуюВеткуToolStripMenuItem1";
            this.добавитьВТекущуюВеткуToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.добавитьВТекущуюВеткуToolStripMenuItem1.Text = "Добавить в текущую ветку";
            this.добавитьВТекущуюВеткуToolStripMenuItem1.Click += new System.EventHandler(this.добавитьВТекущуюВеткуToolStripMenuItem1_Click);
            // 
            // изменитьToolStripMenuItem1
            // 
            this.изменитьToolStripMenuItem1.Name = "изменитьToolStripMenuItem1";
            this.изменитьToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.изменитьToolStripMenuItem1.Text = "Изменить";
            this.изменитьToolStripMenuItem1.Click += new System.EventHandler(this.изменитьToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 6);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(228, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 316);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Аттрибуты";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(765, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьНовуюВеткуToolStripMenuItem,
            this.добавитьВТекущуюВеткуToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.toolStripMenuItem2,
            this.удалитьToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // добавитьНовуюВеткуToolStripMenuItem
            // 
            this.добавитьНовуюВеткуToolStripMenuItem.Name = "добавитьНовуюВеткуToolStripMenuItem";
            this.добавитьНовуюВеткуToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.добавитьНовуюВеткуToolStripMenuItem.Text = "Добавить новую ветку";
            this.добавитьНовуюВеткуToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовуюВеткуToolStripMenuItem_Click);
            // 
            // добавитьВТекущуюВеткуToolStripMenuItem
            // 
            this.добавитьВТекущуюВеткуToolStripMenuItem.Name = "добавитьВТекущуюВеткуToolStripMenuItem";
            this.добавитьВТекущуюВеткуToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.добавитьВТекущуюВеткуToolStripMenuItem.Text = "Добавить в текущую ветку";
            this.добавитьВТекущуюВеткуToolStripMenuItem.Click += new System.EventHandler(this.добавитьВТекущуюВеткуToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 6);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeViewData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TreeViewApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовуюВеткуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьВТекущуюВеткуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовуюВеткуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьВТекущуюВеткуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
    }
}

