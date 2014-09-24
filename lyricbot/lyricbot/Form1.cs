using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Id3;
using Id3.Frames;

namespace lyricbot
{
    public partial class lyricBot : Form
    {
        public lyricBot()
        {
            InitializeComponent();
        }

        private void musicFolder_HelpRequest(object sender, EventArgs e)
        {

        }

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            if (musicFolder.ShowDialog() == DialogResult.OK)
            {
                selectedFolderText.Text = musicFolder.SelectedPath;
                string textToDisplay = "";
                string[] musicFiles = System.IO.Directory.GetFiles(musicFolder.SelectedPath);
                foreach (string song in musicFiles)
                {
                    using (var mp3 = new Mp3File(song))
                    {
                        if (song.Contains(".mp3"))
                        {
                            Console.WriteLine(mp3.GetAllTags());
                            Id3Tag[] second = mp3.GetAllTags();
                            Id3Tag tag = mp3.GetTag(Id3TagFamily.FileStartTag);
                            if (tag != null)
                            {
                                textToDisplay += string.Format("Title: {0} \r\n", tag.Title.Value);
                            }
                        }
                    }
                    
                }
                lyricDisplay.Text = textToDisplay;
            }
        }
    }
}
