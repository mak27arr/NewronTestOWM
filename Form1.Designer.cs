
namespace NewronTestOWM
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nButton1 = new Nevron.UI.WinForm.Controls.NButton();
            this.nRichTextLabel1 = new Nevron.UI.WinForm.Controls.NRichTextLabel();
            this.nChartControl1 = new Nevron.Chart.WinForm.NChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // nButton1
            // 
            this.nButton1.Location = new System.Drawing.Point(13, 13);
            this.nButton1.Name = "nButton1";
            this.nButton1.Size = new System.Drawing.Size(75, 23);
            this.nButton1.TabIndex = 1;
            this.nButton1.Text = "GetData";
            this.nButton1.Click += new System.EventHandler(this.nButton1_Click);
            // 
            // nRichTextLabel1
            // 
            this.nRichTextLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nRichTextLabel1.Location = new System.Drawing.Point(94, 13);
            this.nRichTextLabel1.Name = "nRichTextLabel1";
            this.nRichTextLabel1.Size = new System.Drawing.Size(694, 23);
            this.nRichTextLabel1.TabIndex = 2;
            // 
            // nChartControl1
            // 
            this.nChartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nChartControl1.AutoRefresh = false;
            this.nChartControl1.BackColor = System.Drawing.SystemColors.Control;
            this.nChartControl1.InputKeys = new System.Windows.Forms.Keys[0];
            this.nChartControl1.Location = new System.Drawing.Point(13, 42);
            this.nChartControl1.Name = "nChartControl1";
            this.nChartControl1.Size = new System.Drawing.Size(775, 396);
            this.nChartControl1.State = ((Nevron.Chart.WinForm.NState)(resources.GetObject("nChartControl1.State")));
            this.nChartControl1.TabIndex = 3;
            this.nChartControl1.Text = "nChartControl1";
            this.nChartControl1.Click += new System.EventHandler(this.nChartControl1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nChartControl1);
            this.Controls.Add(this.nRichTextLabel1);
            this.Controls.Add(this.nButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nRichTextLabel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Nevron.UI.WinForm.Controls.NButton nButton1;
        private Nevron.UI.WinForm.Controls.NRichTextLabel nRichTextLabel1;
        private Nevron.Chart.WinForm.NChartControl nChartControl1;
    }
}

