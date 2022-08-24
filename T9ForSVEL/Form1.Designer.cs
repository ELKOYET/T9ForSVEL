
namespace T9ForSVEL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.словарьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.созданиеСловаряToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновлениеСловаряToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очисткаСловаряToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListWords = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(345, 137);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.словарьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(583, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // словарьToolStripMenuItem
            // 
            this.словарьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.созданиеСловаряToolStripMenuItem,
            this.обновлениеСловаряToolStripMenuItem,
            this.очисткаСловаряToolStripMenuItem});
            this.словарьToolStripMenuItem.Name = "словарьToolStripMenuItem";
            this.словарьToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.словарьToolStripMenuItem.Text = "Словарь";
            // 
            // созданиеСловаряToolStripMenuItem
            // 
            this.созданиеСловаряToolStripMenuItem.Name = "созданиеСловаряToolStripMenuItem";
            this.созданиеСловаряToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.созданиеСловаряToolStripMenuItem.Text = "Создание словаря";
            this.созданиеСловаряToolStripMenuItem.Click += new System.EventHandler(this.созданиеСловаряToolStripMenuItem_Click);
            // 
            // обновлениеСловаряToolStripMenuItem
            // 
            this.обновлениеСловаряToolStripMenuItem.Name = "обновлениеСловаряToolStripMenuItem";
            this.обновлениеСловаряToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.обновлениеСловаряToolStripMenuItem.Text = "Обновление словаря";
            this.обновлениеСловаряToolStripMenuItem.Click += new System.EventHandler(this.обновлениеСловаряToolStripMenuItem_Click);
            // 
            // очисткаСловаряToolStripMenuItem
            // 
            this.очисткаСловаряToolStripMenuItem.Name = "очисткаСловаряToolStripMenuItem";
            this.очисткаСловаряToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.очисткаСловаряToolStripMenuItem.Text = "Очистка словаря";
            this.очисткаСловаряToolStripMenuItem.Click += new System.EventHandler(this.очисткаСловаряToolStripMenuItem_Click);
            // 
            // ListWords
            // 
            this.ListWords.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListWords.FormattingEnabled = true;
            this.ListWords.ItemHeight = 25;
            this.ListWords.Location = new System.Drawing.Point(402, 25);
            this.ListWords.Name = "ListWords";
            this.ListWords.Size = new System.Drawing.Size(120, 129);
            this.ListWords.TabIndex = 2;
            this.ListWords.Click += new System.EventHandler(this.ListWords_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 188);
            this.Controls.Add(this.ListWords);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Текстовый процессор";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem словарьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem созданиеСловаряToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновлениеСловаряToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очисткаСловаряToolStripMenuItem;
        private System.Windows.Forms.ListBox ListWords;
    }
}

