using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    internal class Program
    {
        public static void PlaySound(string filePath)
        {
            SoundPlayer player = new SoundPlayer(filePath);
            player.Load(); // Loads the .wav file into memory
            player.Play(); // Plays the sound asynchronously
        }
        static void Main(string[] args)
        {
            PlaySound("file_example_WAV_1MG.wav");
            Console.ReadLine();
        }
    }
}
