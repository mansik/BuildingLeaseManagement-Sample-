
namespace BuildingLeaseUI.UI.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.oKButton = new DevExpress.XtraEditors.SimpleButton();
            this.ResetPasswordHyperlinkLabel = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.loginInfoLabel = new DevExpress.XtraEditors.LabelControl();
            this.userNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.passwordTextEdit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // oKButton
            // 
            this.oKButton.Appearance.BackColor = System.Drawing.Color.White;
            this.oKButton.Appearance.Options.UseBackColor = true;
            this.oKButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.oKButton.Location = new System.Drawing.Point(237, 118);
            this.oKButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.oKButton.Name = "oKButton";
            this.oKButton.Size = new System.Drawing.Size(78, 78);
            this.oKButton.TabIndex = 2;
            this.oKButton.Text = "로그인";
            this.oKButton.Click += new System.EventHandler(this.oKButton_Click);
            // 
            // ResetPasswordHyperlinkLabel
            // 
            this.ResetPasswordHyperlinkLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ResetPasswordHyperlinkLabel.Appearance.Options.UseFont = true;
            this.ResetPasswordHyperlinkLabel.Location = new System.Drawing.Point(227, 94);
            this.ResetPasswordHyperlinkLabel.Margin = new System.Windows.Forms.Padding(4);
            this.ResetPasswordHyperlinkLabel.Name = "ResetPasswordHyperlinkLabel";
            this.ResetPasswordHyperlinkLabel.Size = new System.Drawing.Size(88, 15);
            this.ResetPasswordHyperlinkLabel.TabIndex = 3;
            this.ResetPasswordHyperlinkLabel.Text = "비밀번호 재설정";
            this.ResetPasswordHyperlinkLabel.Click += new System.EventHandler(this.ResetPasswordHyperlinkLabel_Click);
            // 
            // loginInfoLabel
            // 
            this.loginInfoLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.loginInfoLabel.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.loginInfoLabel.Appearance.Options.UseFont = true;
            this.loginInfoLabel.Appearance.Options.UseForeColor = true;
            this.loginInfoLabel.Location = new System.Drawing.Point(22, 202);
            this.loginInfoLabel.Name = "loginInfoLabel";
            this.loginInfoLabel.Size = new System.Drawing.Size(132, 15);
            this.loginInfoLabel.TabIndex = 4;
            this.loginInfoLabel.Text = "사용자 및 비밀번호 확인";
            // 
            // userNameTextEdit
            // 
            this.userNameTextEdit.EditValue = "";
            this.userNameTextEdit.EnterMoveNextControl = true;
            this.userNameTextEdit.Location = new System.Drawing.Point(22, 118);
            this.userNameTextEdit.Name = "userNameTextEdit";
            this.userNameTextEdit.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.userNameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.userNameTextEdit.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("userNameTextEdit.Properties.ContextImageOptions.SvgImage")));
            this.userNameTextEdit.Size = new System.Drawing.Size(208, 36);
            this.userNameTextEdit.TabIndex = 0;
            // 
            // passwordTextEdit
            // 
            this.passwordTextEdit.EditValue = "";
            this.passwordTextEdit.EnterMoveNextControl = true;
            this.passwordTextEdit.Location = new System.Drawing.Point(22, 160);
            this.passwordTextEdit.Name = "passwordTextEdit";
            this.passwordTextEdit.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("passwordTextEdit.Properties.ContextImageOptions.SvgImage")));
            this.passwordTextEdit.Properties.UseSystemPasswordChar = true;
            this.passwordTextEdit.Size = new System.Drawing.Size(208, 36);
            this.passwordTextEdit.TabIndex = 1;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(647, 237);
            this.Controls.Add(this.loginInfoLabel);
            this.Controls.Add(this.userNameTextEdit);
            this.Controls.Add(this.passwordTextEdit);
            this.Controls.Add(this.ResetPasswordHyperlinkLabel);
            this.Controls.Add(this.oKButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("LoginForm.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            ((System.ComponentModel.ISupportInitialize)(this.userNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton oKButton;
        private DevExpress.XtraEditors.HyperlinkLabelControl ResetPasswordHyperlinkLabel;
        private DevExpress.XtraEditors.LabelControl loginInfoLabel;
        private DevExpress.XtraEditors.TextEdit userNameTextEdit;
        private DevExpress.XtraEditors.TextEdit passwordTextEdit;
    }
}

