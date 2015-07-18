using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace lyricbot
{
    public partial class lyricBot : MetroFramework.Forms.MetroForm
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
                    #region I tried but give up for now. I will use taglib while I research
                    //using (var mp3 = new Mp3File(song))
                    //{
                    //    if (song.Contains(".mp3"))
                    //    {
                    //        Console.WriteLine(mp3.GetAllTags());
                    //        Id3Tag[] second = mp3.GetAllTags();
                    //        Id3Tag tag = mp3.GetTag(Id3TagFamily.FileStartTag);
                    //        if (tag != null)
                    //        {
                    //            textToDisplay += string.Format("Title: {0} \r\n", tag.Title.Value);
                    //        }
                    //    }
                    //}
                    //if (song.Contains(".mp3") || song.Contains(".m4a")){
                    //    int numOfBytesToPrint = 80;
                    //    byte[] fullBytes = File.ReadAllBytes(song);
                    //    byte[] printBytes = new byte[numOfBytesToPrint];
                    //    Array.Copy(fullBytes, printBytes, numOfBytesToPrint);
                    //    //heads up to future Alex,
                    //    //the id3v2 version number is stored as hexadecimal
                    //    //which is why there are smiley's and hearts
                    //    //heart = v2.3
                    //    //smiley = v2.2
                    //    //itunes 10 and under encoded with v2.2,
                    //    //so you need to write a function for v2.2, v2.3, and v2.4
                    //    //oh, and .m4a files. 
                    //    //http://id3.org/id3guide
                    //    // byte 0, 1, 2 = "ID3"
                    //    // byte 3 and 4 are hex for the version number, eg. v2.3 shows up as 0x03 then 0x00
                    //    // byte 5 is the flags of the file. must use a binary decoder to view it
                    //    // 6, 7, 8, and 9 are the bytes that indicate the size
                    //    // byte 20 is usually a start of header after the tag
                    //    // size of a header is the four bytes after a header tag
                    //    // if the last one is 41, then that means the header info ends 41 bytes immdietly after the size.
                    //    // size is total frame size -10 (for some reason I am getting -9 in my arrays)
                    //    // after the frame info header, there will be a byte with the value of 1, this means start of header and appears as a smiley
                    //    // after that is the value 255, non-breaking-space, then a byte that specifies the character encoding, most of these will be 254 (0xfe)
                    //    // if I cannot figure this out then I will need to use taglib#

                    //    System.Text.ASCIIEncoding oE = new System.Text.ASCIIEncoding();
                    //    //encoding is an abstract class that uses unicodeencoding class
                    //    System.Text.Encoding encoder = System.Text.Encoding.Unicode;

                        
                    //    Console.WriteLine("\n{0}", song);
                    //    string tempHolder = encoder.GetString(printBytes);
                    //    textToDisplay += tempHolder;
                    //    Console.WriteLine(encoder.GetString(printBytes));
                    //}
                    #endregion

                    if (!song.Contains(".mp3")) {
                        string Warning = "{0} :    Is not an MP3\r\n";
                        Warning = String.Format(Warning, song);
                        textToDisplay += Warning;
                        continue;
                    }
                    TagLib.File file = TagLib.File.Create(song);
                    string title = file.Tag.Title;
                    string artist = file.Tag.FirstPerformer;
                    string lyrics = file.Tag.Lyrics;
                    if (true)//lyrics == null || lyrics.Length < 1)
                    {
                        List<string> links = new List<string>();
                        links.Add(parseSongToAZLyricsURL(artist, title));
                        links.Add(parseSongToPLyricsURL(artist, title));
                        Tuple<String, bool> returnedHTML = new Tuple<string,bool>("", false);

                        foreach(string link in links){
                            Console.WriteLine("Trying URL:   {0}", link);
                            var temp = downloadLyricsHTML(link);
                            if (temp.Item2)
                            {
                                returnedHTML = temp;
                                break;
                            }
                        }

                        if (returnedHTML.Item2)
                        {
                            lyrics = returnedHTML.Item1;
                        }
                        else
                        {
                            Console.WriteLine("\r\nCould not find lyrics for {0}\r\n", title);
                            continue;
                        }
                    }
                    else
                    {
                        ///Already has lyrics, skip this song
                        Console.WriteLine("Skipping");
                        continue;
                    }

                    ///TODO: Add a background worker to refresh the gui thread from input
                    ///Use a class variable to store all of the info to print, or an array of strings
                    ///then make a function to print the array
                    ///then make a function to refresh it
                    file.Tag.Lyrics = lyrics;
                    file.Save();
                    lyricDisplay.Text += lyrics;
                    lyricDisplay.Refresh();
                }
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void lyricBot_Load(object sender, EventArgs e)
        {

        }
    }
}
