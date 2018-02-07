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
            this.components = new System.ComponentModel.Container();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonEndDrawing = new System.Windows.Forms.Button();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonShowExample = new System.Windows.Forms.Button();
            this.labelAnimation = new System.Windows.Forms.Label();
            this.AnimationProgression = new System.Windows.Forms.ProgressBar();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonClearDrawingArea = new System.Windows.Forms.Button();
            this.LabelAnimationSpeed = new System.Windows.Forms.Label();
            this.ScrollBarAnimationSpeed = new System.Windows.Forms.HScrollBar();
            this.labelMainMessage = new System.Windows.Forms.Label();
            this.DrawingAreaComponent = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DrawingAreaComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDraw
            // 
            this.buttonDraw.Font = new System.Drawing.Font("Source Sans Pro Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDraw.Location = new System.Drawing.Point(31, 368);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(119, 28);
            this.buttonDraw.TabIndex = 0;
            this.buttonDraw.Text = "Narisi omrežje";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonEndDrawing
            // 
            this.buttonEndDrawing.Enabled = false;
            this.buttonEndDrawing.Font = new System.Drawing.Font("Source Sans Pro Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEndDrawing.Location = new System.Drawing.Point(31, 402);
            this.buttonEndDrawing.Name = "buttonEndDrawing";
            this.buttonEndDrawing.Size = new System.Drawing.Size(119, 28);
            this.buttonEndDrawing.TabIndex = 1;
            this.buttonEndDrawing.Text = "Končaj z risanjem";
            this.buttonEndDrawing.UseVisualStyleBackColor = true;
            this.buttonEndDrawing.Click += new System.EventHandler(this.buttonEndDrawing_Click);
            // 
            // buttonSolve
            // 
            this.buttonSolve.Enabled = false;
            this.buttonSolve.Font = new System.Drawing.Font("Source Sans Pro Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSolve.Location = new System.Drawing.Point(212, 368);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(119, 28);
            this.buttonSolve.TabIndex = 2;
            this.buttonSolve.Text = "Reši problem";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonShowExample
            // 
            this.buttonShowExample.Font = new System.Drawing.Font("Source Sans Pro Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonShowExample.Location = new System.Drawing.Point(391, 368);
            this.buttonShowExample.Name = "buttonShowExample";
            this.buttonShowExample.Size = new System.Drawing.Size(119, 28);
            this.buttonShowExample.TabIndex = 3;
            this.buttonShowExample.Text = "Pokaži zgled";
            this.buttonShowExample.UseVisualStyleBackColor = true;
            this.buttonShowExample.Click += new System.EventHandler(this.buttonShowExample_Click);
            // 
            // labelAnimation
            // 
            this.labelAnimation.AutoSize = true;
            this.labelAnimation.Font = new System.Drawing.Font("Source Sans Pro Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAnimation.Location = new System.Drawing.Point(141, 444);
            this.labelAnimation.Name = "labelAnimation";
            this.labelAnimation.Size = new System.Drawing.Size(65, 18);
            this.labelAnimation.TabIndex = 5;
            this.labelAnimation.Text = "Animacija:";
            this.labelAnimation.Visible = false;
            // 
            // AnimationProgression
            // 
            this.AnimationProgression.Location = new System.Drawing.Point(212, 444);
            this.AnimationProgression.Name = "AnimationProgression";
            this.AnimationProgression.Size = new System.Drawing.Size(119, 18);
            this.AnimationProgression.TabIndex = 6;
            this.AnimationProgression.Visible = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Source Sans Pro Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(28, 29);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(365, 18);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "Aplikacija reši problem maksimalnega pretoka za dano omrežje.";
            // 
            // buttonClearDrawingArea
            // 
            this.buttonClearDrawingArea.Enabled = false;
            this.buttonClearDrawingArea.Font = new System.Drawing.Font("Source Sans Pro Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClearDrawingArea.Location = new System.Drawing.Point(212, 402);
            this.buttonClearDrawingArea.Name = "buttonClearDrawingArea";
            this.buttonClearDrawingArea.Size = new System.Drawing.Size(119, 28);
            this.buttonClearDrawingArea.TabIndex = 10;
            this.buttonClearDrawingArea.Text = "Pobriši";
            this.buttonClearDrawingArea.UseVisualStyleBackColor = true;
            this.buttonClearDrawingArea.Visible = false;
            this.buttonClearDrawingArea.Click += new System.EventHandler(this.buttonClearDrawingArea_Click);
            // 
            // LabelAnimationSpeed
            // 
            this.LabelAnimationSpeed.AutoSize = true;
            this.LabelAnimationSpeed.Font = new System.Drawing.Font("Source Sans Pro Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelAnimationSpeed.Location = new System.Drawing.Point(101, 408);
            this.LabelAnimationSpeed.Name = "LabelAnimationSpeed";
            this.LabelAnimationSpeed.Size = new System.Drawing.Size(105, 18);
            this.LabelAnimationSpeed.TabIndex = 11;
            this.LabelAnimationSpeed.Text = "Hitrost animacije:";
            this.LabelAnimationSpeed.Visible = false;
            // 
            // ScrollBarAnimationSpeed
            // 
            this.ScrollBarAnimationSpeed.LargeChange = 100;
            this.ScrollBarAnimationSpeed.Location = new System.Drawing.Point(212, 408);
            this.ScrollBarAnimationSpeed.Maximum = 3000;
            this.ScrollBarAnimationSpeed.Minimum = 300;
            this.ScrollBarAnimationSpeed.Name = "ScrollBarAnimationSpeed";
            this.ScrollBarAnimationSpeed.Size = new System.Drawing.Size(119, 18);
            this.ScrollBarAnimationSpeed.TabIndex = 13;
            this.ScrollBarAnimationSpeed.Value = 300;
            this.ScrollBarAnimationSpeed.Visible = false;
            // 
            // labelMainMessage
            // 
            this.labelMainMessage.AutoSize = true;
            this.labelMainMessage.Font = new System.Drawing.Font("Source Sans Pro Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMainMessage.Location = new System.Drawing.Point(28, 52);
            this.labelMainMessage.Name = "labelMainMessage";
            this.labelMainMessage.Size = new System.Drawing.Size(434, 18);
            this.labelMainMessage.TabIndex = 8;
            this.labelMainMessage.Text = "Dodaj svoje omrežje z klikom na gumb \"Nariši omrežje\" ali poglej dani zgled.";
            // 
            // DrawingAreaComponent
            // 
            this.DrawingAreaComponent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DrawingAreaComponent.Location = new System.Drawing.Point(31, 80);
            this.DrawingAreaComponent.Name = "DrawingAreaComponent";
            this.DrawingAreaComponent.Size = new System.Drawing.Size(479, 266);
            this.DrawingAreaComponent.TabIndex = 9;
            this.DrawingAreaComponent.TabStop = false;
            this.DrawingAreaComponent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingAreaComponent_MouseDown);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(537, 498);
            this.Controls.Add(this.ScrollBarAnimationSpeed);
            this.Controls.Add(this.LabelAnimationSpeed);
            this.Controls.Add(this.buttonClearDrawingArea);
            this.Controls.Add(this.DrawingAreaComponent);
            this.Controls.Add(this.labelMainMessage);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.AnimationProgression);
            this.Controls.Add(this.labelAnimation);
            this.Controls.Add(this.buttonShowExample);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.buttonEndDrawing);
            this.Controls.Add(this.buttonDraw);
            this.Font = new System.Drawing.Font("Source Sans Pro Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMainMessage;
        private System.Windows.Forms.PictureBox DrawingAreaComponent;
        private System.Windows.Forms.Button buttonClearDrawingArea;
        public System.Windows.Forms.ProgressBar AnimationProgression;
        private System.Windows.Forms.Label LabelAnimationSpeed;
        private System.Windows.Forms.HScrollBar ScrollBarAnimationSpeed;
        public System.Windows.Forms.Timer Timer;
    }
}

