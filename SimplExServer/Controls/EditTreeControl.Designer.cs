﻿namespace SimplExServer.Controls
{
    partial class EditTreeControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Темы вопросов");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Билеты");
            this.tree = new System.Windows.Forms.TreeView();
            this.searchBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tree.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tree.HideSelection = false;
            this.tree.Location = new System.Drawing.Point(3, 3);
            this.tree.Name = "tree";
            treeNode7.Name = "Themes";
            treeNode7.Text = "Темы вопросов";
            treeNode8.Name = "Tickets";
            treeNode8.Text = "Билеты";
            this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.tree.Size = new System.Drawing.Size(409, 473);
            this.tree.TabIndex = 6;
            this.tree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TreeItemDrag);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeAfterSelect);
            this.tree.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeDragDrop);
            this.tree.DragEnter += new System.Windows.Forms.DragEventHandler(this.TreeDragEnter);
            this.tree.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeDragOver);
            this.tree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TreeMouseClick);
            this.tree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TreeMouseDoubleClick);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBox.FormattingEnabled = true;
            this.searchBox.Location = new System.Drawing.Point(3, 511);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(336, 23);
            this.searchBox.TabIndex = 7;
            this.searchBox.SelectedIndexChanged += new System.EventHandler(this.SearchBoxSelectedTextChanged);
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBoxSelectedTextChanged);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchButton.Enabled = false;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(360, 511);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(52, 23);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Enabled = false;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(342, 511);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(15, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "X";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.upButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.upButton.Enabled = false;
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.upButton.Location = new System.Drawing.Point(3, 482);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(70, 23);
            this.upButton.TabIndex = 12;
            this.upButton.Text = "▲";
            this.upButton.UseVisualStyleBackColor = false;
            this.upButton.Click += new System.EventHandler(this.UpButtonClick);
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.downButton.Enabled = false;
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.downButton.Location = new System.Drawing.Point(342, 482);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(70, 23);
            this.downButton.TabIndex = 13;
            this.downButton.Text = "▼";
            this.downButton.UseVisualStyleBackColor = false;
            this.downButton.Click += new System.EventHandler(this.DownButtonClick);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.backButton.Enabled = false;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(79, 482);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(70, 23);
            this.backButton.TabIndex = 14;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nextButton.Enabled = false;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextButton.Location = new System.Drawing.Point(266, 482);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(70, 23);
            this.nextButton.TabIndex = 15;
            this.nextButton.Text = "Вперед";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.NextButtonClick);
            // 
            // EditTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.tree);
            this.Name = "EditTreeControl";
            this.Size = new System.Drawing.Size(417, 539);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ComboBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button nextButton;
    }
}
