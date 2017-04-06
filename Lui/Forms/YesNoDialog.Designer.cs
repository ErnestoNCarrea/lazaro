namespace Lui.Forms
{
	partial class YesNoDialog
	{
		#region Código generado por el Diseñador de Windows Forms

		private void InitializeComponent()
		{
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YesNoDialog));
                        this.DialogCaption = new Lui.Forms.Label();
                        this.pctQuestion = new System.Windows.Forms.PictureBox();
                        this.DialogText = new Lui.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.pctQuestion)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // DialogCaption
                        // 
                        this.DialogCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.DialogCaption.Location = new System.Drawing.Point(96, 24);
                        this.DialogCaption.Name = "DialogCaption";
                        this.DialogCaption.Size = new System.Drawing.Size(472, 56);
                        this.DialogCaption.TabIndex = 0;
                        this.DialogCaption.Text = "Pregunta";
                        this.DialogCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                        this.DialogCaption.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // pctQuestion
                        // 
                        this.pctQuestion.Image = ((System.Drawing.Image)(resources.GetObject("pctQuestion.Image")));
                        this.pctQuestion.Location = new System.Drawing.Point(24, 24);
                        this.pctQuestion.Name = "pctQuestion";
                        this.pctQuestion.Size = new System.Drawing.Size(56, 56);
                        this.pctQuestion.TabIndex = 52;
                        this.pctQuestion.TabStop = false;
                        // 
                        // DialogText
                        // 
                        this.DialogText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.DialogText.AutoSize = true;
                        this.DialogText.Location = new System.Drawing.Point(88, 80);
                        this.DialogText.MaximumSize = new System.Drawing.Size(480, 0);
                        this.DialogText.Name = "DialogText";
                        this.DialogText.Size = new System.Drawing.Size(0, 20);
                        this.DialogText.TabIndex = 51;
                        // 
                        // YesNoDialog
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(594, 372);
                        this.Controls.Add(this.DialogText);
                        this.Controls.Add(this.DialogCaption);
                        this.Controls.Add(this.pctQuestion);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "YesNoDialog";
                        this.Text = "Pregunta";
                        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.YesNoDialogForm_KeyDown);
                        this.Controls.SetChildIndex(this.pctQuestion, 0);
                        this.Controls.SetChildIndex(this.DialogCaption, 0);
                        this.Controls.SetChildIndex(this.DialogText, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.pctQuestion)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

		}

		#endregion

                private Lui.Forms.Label DialogCaption;
                private Lui.Forms.Label DialogText;
                private System.Windows.Forms.PictureBox pctQuestion;
	}
}
