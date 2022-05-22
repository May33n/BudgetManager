
namespace BudgetManager2
{
    partial class FormNew
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxAmount = new System.Windows.Forms.TextBox();
            this.txtBoxNotes = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(262, 348);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 58);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "button1";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(587, 50);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(297, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(40, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "New";
            // 
            // txtBoxName
            // 
            this.txtBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtBoxName.Location = new System.Drawing.Point(93, 81);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(167, 41);
            this.txtBoxName.TabIndex = 2;
            this.txtBoxName.Text = "Name";
            // 
            // txtBoxAmount
            // 
            this.txtBoxAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBoxAmount.Location = new System.Drawing.Point(301, 154);
            this.txtBoxAmount.Name = "txtBoxAmount";
            this.txtBoxAmount.Size = new System.Drawing.Size(208, 28);
            this.txtBoxAmount.TabIndex = 3;
            // 
            // txtBoxNotes
            // 
            this.txtBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBoxNotes.Location = new System.Drawing.Point(301, 203);
            this.txtBoxNotes.Multiline = true;
            this.txtBoxNotes.Name = "txtBoxNotes";
            this.txtBoxNotes.Size = new System.Drawing.Size(208, 50);
            this.txtBoxNotes.TabIndex = 5;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAmount.Location = new System.Drawing.Point(111, 153);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(94, 29);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Amount";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNotes.Location = new System.Drawing.Point(111, 203);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(77, 29);
            this.lblNotes.TabIndex = 7;
            this.lblNotes.Text = "Notes";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDate.Location = new System.Drawing.Point(111, 266);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(63, 29);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date";
            // 
            // dt
            // 
            this.dt.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dt.Location = new System.Drawing.Point(301, 269);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(208, 26);
            this.dt.TabIndex = 9;
            // 
            // FormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 447);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtBoxNotes);
            this.Controls.Add(this.txtBoxAmount);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.btnSubmit);
            this.Name = "FormNew";
            this.Text = "FormNew";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxAmount;
        private System.Windows.Forms.TextBox txtBoxNotes;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dt;
    }
}