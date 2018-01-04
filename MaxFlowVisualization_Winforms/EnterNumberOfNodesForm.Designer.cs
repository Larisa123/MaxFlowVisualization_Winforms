namespace MaxFlowVisualization_Winforms
{
    partial class EnterNumberOfNodesForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.entryNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.entryNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = new System.Drawing.Font("Source Sans Pro Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOK.Location = new System.Drawing.Point(24, 94);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(99, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Potrdi";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Source Sans Pro Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(175, 94);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(99, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Preklici";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Source Sans Pro Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMessage.Location = new System.Drawing.Point(21, 35);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(202, 16);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = "Prosim, Izberi število vozlišč omrežja:";
            // 
            // entryNumber
            // 
            this.entryNumber.Font = new System.Drawing.Font("Source Sans Pro Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryNumber.Location = new System.Drawing.Point(229, 33);
            this.entryNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.entryNumber.Name = "entryNumber";
            this.entryNumber.Size = new System.Drawing.Size(45, 24);
            this.entryNumber.TabIndex = 3;
            this.entryNumber.ValueChanged += new System.EventHandler(this.entryNumber_ValueChanged);
            // 
            // EnterNumberOfNodesForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(302, 142);
            this.Controls.Add(this.entryNumber);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EnterNumberOfNodesForm";
            this.ShowIcon = false;
            this.Text = "Število vozlišč omrežja";
            ((System.ComponentModel.ISupportInitialize)(this.entryNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.NumericUpDown entryNumber;
    }
}