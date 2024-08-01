using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Game
{
    internal class Program
    {
        /*  public static void PlaySound(string filePath)
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
        */

        public static void intro()
        {
            Console.WriteLine("You are Harry Potter. Born on July 31, 1980, you’ve had a pretty tough start. Your parents, James and Lily Potter, were well-respected wizards who died tragically in a car accident when you were a kid." +
                "\n\nAfter that, you were sent to live with your Aunt Petunia and Uncle Vernon Dursley. They’ve never been fond of magic and have treated you poorly, making you live in a cupboard under the stairs and ignoring you as much as they can." +
                "\n\nBut now, things are about to change. You’ve just received a letter from Hogwarts School of Witchcraft and Wizardry. You’re finally going to step into the magical world you’ve always heard whispers about," +
                "\n\nlearn about your true heritage, and discover what adventures await you at Hogwarts. Get ready to embark on a magical journey like no other!\n\n");
                NoletterReply();


        }
        public static void NoletterReply()
        {
            Console.WriteLine("But even after getting the letter from school your aunt is not letting you to go there because she don't want to let you know about magic because she hate the magicians.");
            Console.WriteLine("The letters kept coming thats why your aunt and your uncle decided to move to a different place.");
            //Thunder sound effect here
            Console.WriteLine("Its Thundering...");
            Console.WriteLine("Also It's 12:00 AM and its your birthday today...");
            Console.WriteLine("");
            Console.WriteLine("You're sad because no one is here to celebrate with you.");
            Console.WriteLine("");
            //Knocking sound effect here
            Console.WriteLine("Main door \n knock... knock... knock...");
            Console.WriteLine("");
            Console.WriteLine("Your uncle woke up scared with a gun in his hand and your aunt is standing behind him.");
            Console.WriteLine("");
            Console.WriteLine("Uncle Shouts!!!\n Who is that? Go away or I'll shoot you.");
            Console.WriteLine("");
            //Door break sound here
            Console.WriteLine("Loud Bang!!\n Door Broke and fell down. \n\n your aunt is yelling.");
            Console.WriteLine("");
            Console.WriteLine("A Big giant 8' foot 6\" inch tall. with long hairs and beard. ");
            Console.WriteLine("");
            Console.WriteLine("He says 'I am Hagrid. we are sending the letters to harry that he's been selected for Hogwarts School of Magic.\n\nbut we got no reply.'");
            Console.WriteLine("");
            Console.WriteLine("Your aunt reply I did not let Harry see that because i hate magicians because after going to Hogwarts They change too much like my sister(Your Mother) did.");
            Console.WriteLine("");
            Console.WriteLine("Hagrid got grumpy...\n\nhe told you about the school and you shared your experience of staying with your aunt then you both decided to go together.");
        }
       /* static void Typing_Ani()
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(i);
                Thread.Sleep(1000);
            }

        }
       */
       
        static void Main(string[] args)
        {
           intro();
        }
    }
}
