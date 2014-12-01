using System.Collections;
using System;
//using MetroFramework;


namespace lyricbot
{
    partial class lyricBot
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
            this.musicFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.selectedFolderText = new System.Windows.Forms.TextBox();
            this.lyricDisplay = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // musicFolder
            // 
            this.musicFolder.SelectedPath = "C:\\Users\\Alex\\Documents\\lyricsbot\\Identity On Fire";
            this.musicFolder.ShowNewFolderButton = false;
            this.musicFolder.HelpRequest += new System.EventHandler(this.musicFolder_HelpRequest);
            // 
            // openFolderButton
            // 
            this.openFolderButton.Location = new System.Drawing.Point(571, 71);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(111, 32);
            this.openFolderButton.TabIndex = 0;
            this.openFolderButton.Text = "Folder...";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // selectedFolderText
            // 
            this.selectedFolderText.Location = new System.Drawing.Point(12, 78);
            this.selectedFolderText.Name = "selectedFolderText";
            this.selectedFolderText.Size = new System.Drawing.Size(553, 20);
            this.selectedFolderText.TabIndex = 1;
            // 
            // lyricDisplay
            // 
            this.lyricDisplay.Lines = new string[0];
            this.lyricDisplay.Location = new System.Drawing.Point(12, 127);
            this.lyricDisplay.MaxLength = 32767;
            this.lyricDisplay.Multiline = true;
            this.lyricDisplay.Name = "lyricDisplay";
            this.lyricDisplay.PasswordChar = '\0';
            this.lyricDisplay.ReadOnly = true;
            this.lyricDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lyricDisplay.SelectedText = "";
            this.lyricDisplay.Size = new System.Drawing.Size(719, 335);
            this.lyricDisplay.TabIndex = 3;
            this.lyricDisplay.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lyricDisplay.UseSelectable = true;
            this.lyricDisplay.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // lyricBot
            // 
            this.AccessibleDescription = "A bot designed to find lyrics for every song in a folder";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 523);
            this.Controls.Add(this.lyricDisplay);
            this.Controls.Add(this.selectedFolderText);
            this.Controls.Add(this.openFolderButton);
            this.MaximumSize = new System.Drawing.Size(762, 523);
            this.MinimumSize = new System.Drawing.Size(762, 523);
            this.Name = "lyricBot";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Lyric bot for lazies";
            this.Load += new System.EventHandler(this.lyricBot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog musicFolder;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.TextBox selectedFolderText;
        private MetroFramework.Controls.MetroTextBox lyricDisplay;
    }
}

