using System.Collections;
using System;

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
            this.lyricDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // musicFolder
            // 
            this.musicFolder.SelectedPath = "C:\\Users\\Alex\\Music";
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
            this.lyricDisplay.Location = new System.Drawing.Point(12, 126);
            this.lyricDisplay.Multiline = true;
            this.lyricDisplay.Name = "lyricDisplay";
            this.lyricDisplay.ReadOnly = true;
            this.lyricDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.lyricDisplay.Size = new System.Drawing.Size(281, 334);
            this.lyricDisplay.TabIndex = 2;
            // 
            // lyricBot
            // 
            this.AccessibleDescription = "A bot designed to find lyrics for every song in a folder";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 485);
            this.Controls.Add(this.lyricDisplay);
            this.Controls.Add(this.selectedFolderText);
            this.Controls.Add(this.openFolderButton);
            this.MaximumSize = new System.Drawing.Size(762, 523);
            this.MinimumSize = new System.Drawing.Size(762, 523);
            this.Name = "lyricBot";
            this.Text = "Lyric bot for lazies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog musicFolder;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.TextBox selectedFolderText;
        private System.Windows.Forms.TextBox lyricDisplay;
    }
}

