namespace DiningManagementSystem.com.infy.presentation.UI
{
    partial class BorderMealInfoUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.memberInformationDataGridView = new System.Windows.Forms.DataGridView();
            this.SNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.individualMealCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountToBePaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountToBeGiven = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.searchMemeberIdTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.perMealCostLabel = new System.Windows.Forms.Label();
            this.totalNoOfMealsLabel = new System.Windows.Forms.Label();
            this.totalBazarCostLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberInformationDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.memberInformationDataGridView);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(965, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Member Information At a Glance";
            // 
            // memberInformationDataGridView
            // 
            this.memberInformationDataGridView.AllowUserToAddRows = false;
            this.memberInformationDataGridView.AllowUserToDeleteRows = false;
            this.memberInformationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memberInformationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNO,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.individualMealCost,
            this.amountToBePaid,
            this.amountToBeGiven});
            this.memberInformationDataGridView.Location = new System.Drawing.Point(10, 18);
            this.memberInformationDataGridView.Name = "memberInformationDataGridView";
            this.memberInformationDataGridView.ReadOnly = true;
            this.memberInformationDataGridView.Size = new System.Drawing.Size(944, 225);
            this.memberInformationDataGridView.TabIndex = 0;
            // 
            // SNO
            // 
            this.SNO.HeaderText = "Serial No";
            this.SNO.Name = "SNO";
            this.SNO.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Member Id";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Border Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Room No";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "No Of Meals";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Balance";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // individualMealCost
            // 
            this.individualMealCost.HeaderText = "Individual Cost";
            this.individualMealCost.Name = "individualMealCost";
            this.individualMealCost.ReadOnly = true;
            // 
            // amountToBePaid
            // 
            this.amountToBePaid.HeaderText = "Amount To Be Paid";
            this.amountToBePaid.Name = "amountToBePaid";
            this.amountToBePaid.ReadOnly = true;
            // 
            // amountToBeGiven
            // 
            this.amountToBeGiven.HeaderText = "Amount To Be Given";
            this.amountToBeGiven.Name = "amountToBeGiven";
            this.amountToBeGiven.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search By Member Id";
            // 
            // searchMemeberIdTextBox
            // 
            this.searchMemeberIdTextBox.Location = new System.Drawing.Point(118, 15);
            this.searchMemeberIdTextBox.Name = "searchMemeberIdTextBox";
            this.searchMemeberIdTextBox.Size = new System.Drawing.Size(186, 20);
            this.searchMemeberIdTextBox.TabIndex = 3;
            this.searchMemeberIdTextBox.TextChanged += new System.EventHandler(this.searchMemeberIdTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchMemeberIdTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 48);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 397);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(970, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.perMealCostLabel);
            this.groupBox3.Controls.Add(this.totalNoOfMealsLabel);
            this.groupBox3.Controls.Add(this.totalBazarCostLabel);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(376, 305);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 85);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bill Calculation";
            // 
            // perMealCostLabel
            // 
            this.perMealCostLabel.AutoSize = true;
            this.perMealCostLabel.ForeColor = System.Drawing.Color.Red;
            this.perMealCostLabel.Location = new System.Drawing.Point(115, 60);
            this.perMealCostLabel.Name = "perMealCostLabel";
            this.perMealCostLabel.Size = new System.Drawing.Size(66, 13);
            this.perMealCostLabel.TabIndex = 5;
            this.perMealCostLabel.Text = "perMealCost";
            // 
            // totalNoOfMealsLabel
            // 
            this.totalNoOfMealsLabel.AutoSize = true;
            this.totalNoOfMealsLabel.Location = new System.Drawing.Point(113, 42);
            this.totalNoOfMealsLabel.Name = "totalNoOfMealsLabel";
            this.totalNoOfMealsLabel.Size = new System.Drawing.Size(80, 13);
            this.totalNoOfMealsLabel.TabIndex = 4;
            this.totalNoOfMealsLabel.Text = "totalNoOfMeals";
            // 
            // totalBazarCostLabel
            // 
            this.totalBazarCostLabel.AutoSize = true;
            this.totalBazarCostLabel.Location = new System.Drawing.Point(113, 23);
            this.totalBazarCostLabel.Name = "totalBazarCostLabel";
            this.totalBazarCostLabel.Size = new System.Drawing.Size(75, 13);
            this.totalBazarCostLabel.TabIndex = 3;
            this.totalBazarCostLabel.Text = "totalBazarCost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Per Meal Cost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total No of Meals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Bazar Cost";
            // 
            // BorderMealInfoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 419);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BorderMealInfoUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Border Meal Info UI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BorderMealInfoUI_FormClosing);
            this.Load += new System.EventHandler(this.BorderMealInfoUI_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memberInformationDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView memberInformationDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchMemeberIdTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label perMealCostLabel;
        private System.Windows.Forms.Label totalNoOfMealsLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn individualMealCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountToBePaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountToBeGiven;
        private System.Windows.Forms.Label totalBazarCostLabel;
    }
}