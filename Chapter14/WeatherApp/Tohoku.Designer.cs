
namespace WeatherApp {
    partial class Tohoku {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.plTohokuMap = new System.Windows.Forms.Panel();
            this.btAomori = new System.Windows.Forms.Button();
            this.tbAomori = new System.Windows.Forms.TextBox();
            this.plTohokuMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(747, 530);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // plTohokuMap
            // 
            this.plTohokuMap.Controls.Add(this.btAomori);
            this.plTohokuMap.Controls.Add(this.button1);
            this.plTohokuMap.Location = new System.Drawing.Point(294, -4);
            this.plTohokuMap.Name = "plTohokuMap";
            this.plTohokuMap.Size = new System.Drawing.Size(260, 564);
            this.plTohokuMap.TabIndex = 1;
            // 
            // btAomori
            // 
            this.btAomori.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btAomori.Location = new System.Drawing.Point(108, 91);
            this.btAomori.Name = "btAomori";
            this.btAomori.Size = new System.Drawing.Size(75, 34);
            this.btAomori.TabIndex = 1;
            this.btAomori.Text = "青森";
            this.btAomori.UseVisualStyleBackColor = true;
            this.btAomori.Click += new System.EventHandler(this.btAomori_Click);
            // 
            // tbAomori
            // 
            this.tbAomori.Location = new System.Drawing.Point(631, 320);
            this.tbAomori.Multiline = true;
            this.tbAomori.Name = "tbAomori";
            this.tbAomori.Size = new System.Drawing.Size(171, 159);
            this.tbAomori.TabIndex = 3;
            this.tbAomori.TextChanged += new System.EventHandler(this.tbAomori_TextChanged);
            // 
            // Tohoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.tbAomori);
            this.Controls.Add(this.plTohokuMap);
            this.Name = "Tohoku";
            this.Text = "Tohoku";
            this.Load += new System.EventHandler(this.Tohoku_Load);
            this.plTohokuMap.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel plTohokuMap;
        private System.Windows.Forms.Button btAomori;
        private System.Windows.Forms.TextBox tbAomori;
    }
}