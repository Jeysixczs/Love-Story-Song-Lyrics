using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tesss
{
    public partial class Form1 : Form
    {
        private SoundPlayer musicPlayer;
        private System.Windows.Forms.Timer timer;
        private int lyricIndex = 0;
        private int charIndex = 0;

        private int songStartTime;

        private int[] lyricTimestamps = new int[]
        {
            
            5000, // "I got tired of waiting...."
            0, // "Wondering if you were ever comin' around"
            0, // "My faith in you was fading...."
            0, // "When I met you on outskirts of town"
            0, // "And I said"
            0, // "Romeo, save me, I've been feeling so alone"
            0, // "I keep waiting for you, but you never come"
            0, // "Is this in my head? I don't know what to think"
            0, // "He knelt to the ground and pulled out a ring"
            0, // "And said"
            0, // "Marry me, Juliet, you'll never have to be alone"
            0, // "I love you, and that's all I really know"
            0, // "I talked to your dad, go pick out a white dress"
            0, // "It's a love story, baby, just say yes"
        };

        private string[] lyrics = new string[]
        {
           
            "I got tired of waiting                       \n",
            "Wondering if you were ever comin' around     \n",
            "My faith in you was fading                            \n",
            "When I met you on outskirts of town      \n",
            "And I said      \n\n",

            "Romeo, save me, I've been feeling so alone      \n",
            "I keep waiting for you, but you never come      \n",
            "Is this in my head? I don't know what to thinking  \n",
            "He knelt to the ground and pulled out a ring\n",
            "And said \n\n",

            "Marry me, Juliet, you'll never have to be alone\n",
            "I love you, and that's all I really know     \n",
            "I talked to your dad, go pick out a white dress     \n",
            "It's a love story, baby, just say yes\n",
        };
        public Form1()
        {
            InitializeComponent();
            musicPlayer = new SoundPlayer(@"D:\Download\Taylor Swift - Love Story (Lyrics) (mp3cut.net).wav");
            richTextBox1 = new RichTextBox();
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Times New Roman", 15);
            this.Controls.Add(richTextBox1);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrintLyric(object sender, EventArgs e)
        {
            int currentTime = Environment.TickCount - songStartTime;

            if (lyricIndex < lyrics.Length)
            {
                if (currentTime >= lyricTimestamps[lyricIndex])
                {
                    if (charIndex < lyrics[lyricIndex].Length)
                    {
                        richTextBox1.AppendText(lyrics[lyricIndex][charIndex].ToString());
                        richTextBox1.Refresh();
                        charIndex++;
                    }
                    else
                    {
                        lyricIndex++;
                        charIndex = 0;
                    }
                }
            }
            else
            {
                
                timer.Stop();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            musicPlayer.Play();
            songStartTime = Environment.TickCount;
            timer = new System.Windows.Forms.Timer
            {
                Interval = 77 
            };
            timer.Tick += new EventHandler(PrintLyric);
            timer.Start();
        }
        private int CountSyllables(string word)
        {
            int syllableCount = 0;
            foreach (char c in word)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    syllableCount++;
                }
            }
            return syllableCount;
        }
    }
}