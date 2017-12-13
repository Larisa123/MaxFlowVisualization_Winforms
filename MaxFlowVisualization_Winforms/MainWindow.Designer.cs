namespace MaxFlowVisualization_Winforms
{
    partial class MainWindow
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
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonEndDrawing = new System.Windows.Forms.Button();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonShowExample = new System.Windows.Forms.Button();
            this.labelAnimation = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMainMessage = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.DrawingAreaComponent = new System.Windows.Forms.PictureBox();
            this.buttonClearDrawingArea = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingAreaComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(31, 363);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(119, 23);
            this.buttonDraw.TabIndex = 0;
            this.buttonDraw.Text = "Narisi omrežje";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonEndDrawing
            // 
            this.buttonEndDrawing.Enabled = false;
            this.buttonEndDrawing.Location = new System.Drawing.Point(31, 392);
            this.buttonEndDrawing.Name = "buttonEndDrawing";
            this.buttonEndDrawing.Size = new System.Drawing.Size(119, 23);
            this.buttonEndDrawing.TabIndex = 1;
            this.buttonEndDrawing.Text = "Končaj z risanjem";
            this.buttonEndDrawing.UseVisualStyleBackColor = true;
            this.buttonEndDrawing.Click += new System.EventHandler(this.buttonEndDrawing_Click);
            // 
            // buttonSolve
            // 
            this.buttonSolve.Enabled = false;
            this.buttonSolve.Location = new System.Drawing.Point(212, 363);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(119, 23);
            this.buttonSolve.TabIndex = 2;
            this.buttonSolve.Text = "Reši problem";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonShowExample
            // 
            this.buttonShowExample.Location = new System.Drawing.Point(391, 363);
            this.buttonShowExample.Name = "buttonShowExample";
            this.buttonShowExample.Size = new System.Drawing.Size(119, 23);
            this.buttonShowExample.TabIndex = 3;
            this.buttonShowExample.Text = "Pokaži zgled";
            this.buttonShowExample.UseVisualStyleBackColor = true;
            this.buttonShowExample.Click += new System.EventHandler(this.buttonShowExample_Click);
            // 
            // labelAnimation
            // 
            this.labelAnimation.AutoSize = true;
            this.labelAnimation.Location = new System.Drawing.Point(156, 397);
            this.labelAnimation.Name = "labelAnimation";
            this.labelAnimation.Size = new System.Drawing.Size(52, 13);
            this.labelAnimation.TabIndex = 5;
            this.labelAnimation.Text = "Animacija";
            this.labelAnimation.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(212, 392);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(119, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Value = 1;
            this.progressBar1.Visible = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(28, 29);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(303, 13);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "Aplikacija reši problem maksimalnega pretoka za dano omrežje.";
            // 
            // labelMainMessage
            // 
            this.labelMainMessage.AutoSize = true;
            this.labelMainMessage.Location = new System.Drawing.Point(28, 52);
            this.labelMainMessage.Name = "labelMainMessage";
            this.labelMainMessage.Size = new System.Drawing.Size(363, 13);
            this.labelMainMessage.TabIndex = 8;
            this.labelMainMessage.Text = "Dodaj svoje omrežje z klikom na gumb \"Nariši omrežje\" ali poglej dani zgled.";
            // 
            // DrawingAreaComponent
            // 
            this.DrawingAreaComponent.Location = new System.Drawing.Point(31, 80);
            this.DrawingAreaComponent.Name = "DrawingAreaComponent";
            this.DrawingAreaComponent.Size = new System.Drawing.Size(479, 266);
            this.DrawingAreaComponent.TabIndex = 9;
            this.DrawingAreaComponent.TabStop = false;
            this.DrawingAreaComponent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingAreaComponent_MouseDown);
            // 
            // buttonClearDrawingArea
            // 
            this.buttonClearDrawingArea.Enabled = false;
            this.buttonClearDrawingArea.Location = new System.Drawing.Point(212, 421);
            this.buttonClearDrawingArea.Name = "buttonClearDrawingArea";
            this.buttonClearDrawingArea.Size = new System.Drawing.Size(119, 23);
            this.buttonClearDrawingArea.TabIndex = 10;
            this.buttonClearDrawingArea.Text = "Pobriši";
            this.buttonClearDrawingArea.UseVisualStyleBackColor = true;
            this.buttonClearDrawingArea.Visible = false;
            this.buttonClearDrawingArea.Click += new System.EventHandler(this.buttonClearDrawingArea_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(537, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(537, 473);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClearDrawingArea);
            this.Controls.Add(this.DrawingAreaComponent);
            this.Controls.Add(this.labelMainMessage);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelAnimation);
            this.Controls.Add(this.buttonShowExample);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.buttonEndDrawing);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Maksimalni pretok skozi omrežje";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingAreaComponent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonEndDrawing;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonShowExample;
        private System.Windows.Forms.Label labelAnimation;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMainMessage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox DrawingAreaComponent;
        private System.Windows.Forms.Button buttonClearDrawingArea;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
    }
}

