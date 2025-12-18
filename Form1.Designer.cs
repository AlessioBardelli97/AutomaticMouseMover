namespace AutomaticMouseMover
{
  partial class AutomaticMaouseMoverForm
  {
    /// <summary>
    /// Variabile di progettazione necessaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Pulire le risorse in uso.
    /// </summary>
    /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Codice generato da Progettazione Windows Form

    /// <summary>
    /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
    /// il contenuto del metodo con l'editor di codice.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutomaticMaouseMoverForm));
      this.StartMouseMoveBtn = new System.Windows.Forms.Button();
      this.StopMouseMoveBtn = new System.Windows.Forms.Button();
      this.PanelButtons = new System.Windows.Forms.FlowLayoutPanel();
      this.CloseBtn = new System.Windows.Forms.Button();
      this.ScreenBox = new System.Windows.Forms.GroupBox();
      this.PanelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // StartMouseMoveBtn
      // 
      this.StartMouseMoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.StartMouseMoveBtn.Location = new System.Drawing.Point(3, 3);
      this.StartMouseMoveBtn.Name = "StartMouseMoveBtn";
      this.StartMouseMoveBtn.Size = new System.Drawing.Size(110, 23);
      this.StartMouseMoveBtn.TabIndex = 0;
      this.StartMouseMoveBtn.Text = "Muovi Mouse";
      this.StartMouseMoveBtn.UseVisualStyleBackColor = true;
      this.StartMouseMoveBtn.Click += new System.EventHandler(this.StartMouseMoveBtnClick);
      // 
      // StopMouseMoveBtn
      // 
      this.StopMouseMoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.StopMouseMoveBtn.Enabled = false;
      this.StopMouseMoveBtn.Location = new System.Drawing.Point(3, 32);
      this.StopMouseMoveBtn.Name = "StopMouseMoveBtn";
      this.StopMouseMoveBtn.Size = new System.Drawing.Size(110, 23);
      this.StopMouseMoveBtn.TabIndex = 3;
      this.StopMouseMoveBtn.Text = "Stop";
      this.StopMouseMoveBtn.UseVisualStyleBackColor = true;
      this.StopMouseMoveBtn.Click += new System.EventHandler(this.StopMouseMoveBtnClick);
      // 
      // PanelButtons
      // 
      this.PanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PanelButtons.AutoSize = true;
      this.PanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.PanelButtons.Controls.Add(this.StartMouseMoveBtn);
      this.PanelButtons.Controls.Add(this.StopMouseMoveBtn);
      this.PanelButtons.Controls.Add(this.CloseBtn);
      this.PanelButtons.Controls.Add(this.ScreenBox);
      this.PanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.PanelButtons.Location = new System.Drawing.Point(14, 14);
      this.PanelButtons.Margin = new System.Windows.Forms.Padding(5);
      this.PanelButtons.Name = "PanelButtons";
      this.PanelButtons.Size = new System.Drawing.Size(116, 98);
      this.PanelButtons.TabIndex = 4;
      // 
      // CloseBtn
      // 
      this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.CloseBtn.AutoSize = true;
      this.CloseBtn.Location = new System.Drawing.Point(3, 61);
      this.CloseBtn.Name = "CloseBtn";
      this.CloseBtn.Size = new System.Drawing.Size(110, 23);
      this.CloseBtn.TabIndex = 4;
      this.CloseBtn.Text = "Chiudi";
      this.CloseBtn.UseVisualStyleBackColor = true;
      this.CloseBtn.Click += new System.EventHandler(this.CloseBtnClick);
      // 
      // ScreenBox
      // 
      this.ScreenBox.AutoSize = true;
      this.ScreenBox.Location = new System.Drawing.Point(3, 90);
      this.ScreenBox.Name = "ScreenBox";
      this.ScreenBox.Size = new System.Drawing.Size(6, 5);
      this.ScreenBox.TabIndex = 5;
      this.ScreenBox.TabStop = false;
      this.ScreenBox.Text = "Scermo";
      // 
      // AutomaticMaouseMoverForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(144, 159);
      this.ControlBox = false;
      this.Controls.Add(this.PanelButtons);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "AutomaticMaouseMoverForm";
      this.Text = "Automatic Mouse Mover";
      this.PanelButtons.ResumeLayout(false);
      this.PanelButtons.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button StartMouseMoveBtn;
    private System.Windows.Forms.Button StopMouseMoveBtn;
    private System.Windows.Forms.FlowLayoutPanel PanelButtons;
    private System.Windows.Forms.Button CloseBtn;
    private System.Windows.Forms.GroupBox ScreenBox;
  }
}

