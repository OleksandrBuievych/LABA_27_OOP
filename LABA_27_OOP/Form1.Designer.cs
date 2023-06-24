
namespace LABA_27_OOP
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.propertiesTextBox = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.Security = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCreateArchive = new System.Windows.Forms.Button();
            this.btnExtractArchive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(808, 486);
            this.treeView.TabIndex = 0;
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // propertiesTextBox
            // 
            this.propertiesTextBox.Location = new System.Drawing.Point(682, 548);
            this.propertiesTextBox.Name = "propertiesTextBox";
            this.propertiesTextBox.Size = new System.Drawing.Size(784, 22);
            this.propertiesTextBox.TabIndex = 3;
            // 
            // listView
            // 
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(862, 13);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(604, 476);
            this.listView.TabIndex = 5;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(484, 541);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Властивості";
            // 
            // Security
            // 
            this.Security.Location = new System.Drawing.Point(682, 607);
            this.Security.Name = "Security";
            this.Security.Size = new System.Drawing.Size(784, 22);
            this.Security.TabIndex = 7;
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(100, 607);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(104, 23);
            this.btnMove.TabIndex = 8;
            this.btnMove.Text = "Перемістити";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(266, 606);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(102, 53);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Створити файл";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(104, 541);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(274, 541);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(94, 23);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.Text = "Копіювати";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCreateArchive
            // 
            this.btnCreateArchive.Location = new System.Drawing.Point(489, 663);
            this.btnCreateArchive.Name = "btnCreateArchive";
            this.btnCreateArchive.Size = new System.Drawing.Size(120, 23);
            this.btnCreateArchive.TabIndex = 12;
            this.btnCreateArchive.Text = "Архівувати";
            this.btnCreateArchive.UseVisualStyleBackColor = true;
            this.btnCreateArchive.Click += new System.EventHandler(this.btnCreateArchive_Click);
            // 
            // btnExtractArchive
            // 
            this.btnExtractArchive.Location = new System.Drawing.Point(615, 663);
            this.btnExtractArchive.Name = "btnExtractArchive";
            this.btnExtractArchive.Size = new System.Drawing.Size(122, 23);
            this.btnExtractArchive.TabIndex = 13;
            this.btnExtractArchive.Text = "Розпакувати";
            this.btnExtractArchive.UseVisualStyleBackColor = true;
            this.btnExtractArchive.Click += new System.EventHandler(this.btnExtractArchive_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 745);
            this.Controls.Add(this.btnExtractArchive);
            this.Controls.Add(this.btnCreateArchive);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.Security);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.propertiesTextBox);
            this.Controls.Add(this.treeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox propertiesTextBox;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Security;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCreateArchive;
        private System.Windows.Forms.Button btnExtractArchive;
    }
}

