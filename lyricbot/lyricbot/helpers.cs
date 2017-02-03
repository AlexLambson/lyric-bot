using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace lyricbot
{
    partial class lyricBot
    {
        public string parseSongToAZLyricsURL(string Artist, string Song)
        {
            /// AZ Lyrics uses the url as follows
            /// azlyrics.com/lyrics/{Artist lower case}/{Song lower case}.html
            /// all white space and punctuation must be removed
            /// AZ lyrics does NOT use "A" or "The" at the beginning of artist names
            Artist = cleanStringForURL(Artist, true).Replace(" ", "");
            Song = cleanStringForURL(Song).Replace(" ", "");
            return "http://www.azlyrics.com/lyrics/" + Artist + "/" + Song + ".html";
        }
        public string parseSongToPLyricsURL(string Artist, string Song)
        {
            /// AZ Lyrics uses the url as follows
            /// azlyrics.com/lyrics/{Artist lower case}/{Song lower case}.html
            /// all white space and punctuation must be removed
            /// AZ lyrics does NOT use "A" or "The" at the beginning of artist names
            if (Artist == "Destroy Rebuild Until God Shows"){
                Artist = "drugs";
            }
            Artist = cleanStringForURL(Artist, true).Replace(" ", "");
            Song = cleanStringForURL(Song).Replace(" ", "");
            return "http://www.plyrics.com/lyrics/" + Artist + "/" + Song + ".html";
        }
        public string fixSwearing(string bleeped)
        {
            Console.WriteLine(bleeped);
            return bleeped.Replace("f**k", "fuck");
        }
        public string cleanStringForURL(string cleanerInput, bool removePretense = false)
        {
            cleanerInput = fixSwearing(cleanerInput.ToLower());
            string stripped = Regex.Replace(cleanerInput, "\\p{P}", "");
            stripped = stripped.Replace("[explicit]", "");
            //stripped = stripped.ToLower();
            if (removePretense)
            {
                if (stripped.StartsWith("a "))
                {
                    stripped = ReplaceFirst(stripped, "a ", "");
                }
                else if (stripped.StartsWith("the "))
                {
                    stripped = ReplaceFirst(stripped, "the ", "");
                }
            }
            return stripped;
        }
        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        public Tuple<string, bool> downloadLyricsHTML(string URL)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string HTML;
            try
            {
                HTML = client.DownloadString(URL);
                HTML = parseLyricsFromHTML(HTML);
            }
            catch (WebException exception)
            {
                Console.WriteLine(exception);
                HTML = null;
                return Tuple.Create(HTML, false);
            }
            return Tuple.Create(HTML, true);
        }
        public string parseLyricsFromHTML(string rawHTML)
        {
            string extractedLyrics;
            string parsedHTML;
            string startFlag = "<!-- start of lyrics -->";
            int lyricsStart = rawHTML.IndexOf(startFlag) + startFlag.Length;
            int lyricsEnd = rawHTML.IndexOf("<!-- end of lyrics -->");
            int lyricsLength = lyricsEnd - lyricsStart;
            extractedLyrics = rawHTML.Substring(lyricsStart, lyricsLength);
            parsedHTML = extractedLyrics.Replace("<br />", "\r");
            return parsedHTML;
        }
    }
}
