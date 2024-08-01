using System.Buffers.Text;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Security.AccessControl;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ZombieGame
{
    internal class Program
    {
        //Inventory string by Samuel B 26/5/2024//
        private static string[] Inventory = new string[10];
        private static string instructions = string.Empty;
        private static string choice = string.Empty;
        private static string currentLocation = "house";
        //global health variable by Samuel B 3/06/2024
        private static int health = 0;

        static void Main()
        {
            int ans;

            // Mustafa - Starting the game
            // Samuel B - Editing Start Menu - 1/06/2024
            Console.ForegroundColor = ConsoleColor.Red;
            //Added Animation - Mustafa
            Console.WriteLine(@"
               .^!?YJJYPJJPJ5YJYJ7^.                            .^7JYJY5JPJJPYJJY?!^.               
            :!J5Y!~~~. :~ ^^.~ ^!7J5J~   :^!7??????????7!^:   ~J5J7!^ ~.^^ ~: .~~~!Y5J!:            
         :?Y5J^.:^  .!  !.:! !  ! ^:755Y5?~~^:........:^~~?5Y557:^ !  ! !:.!  !.  ^:.^J5Y?:         
       ~557. .~: ~^  7. 7.~^.! :!.~.~~:5!7                7!5:~~.~.!: !.^~.7 .7  ^~ :~. .755~       
     ~5J:..~: .! .!  7 .7.7 !: 7.~.~:!.P..                ..P.!:~.~.7 :! 7.7. 7  !. !. :~..:J5~     
   .Y5~:^.  !: ~^ 7 :! 7:!.~^.7:^:^^^^J7                   7J^^^^:^:7.^~.!:7 !: 7.^~ :!  .^:~5Y.   
  :GJ:. .!: .7 ^!.7 7.!~~:~:.!^^^~^^!J7                      7J!^^~^^^!.:~:~~!.7 7.!^ 7. :!. .:JG:  
 :B! .:~. 7: 7.^~~^!7YYY?5???7~^~^~?Y^  WHISPERS OF THE DEAD  ^Y?~^~^~7???5?YYY7!^~~^.7 :7 .~:. !B: 
 GY:^. .!:.7 !.!!5YY?!^^::^~75G7~7J!.     1) START            .!J7~7G57~^::^^!?YY5!!.! 7.:!. .^:YG 
7G. .~~ .7 7.!7GY!.          J&Y!~.       2) START(NO INTRO)     .~!Y&J          .!YG7!.7 7. ~~. .G7
BY^^^ :!.^~~~P5:             P~:.   ...   3) QUIT            ...   .:~P             :5P~~~^.!: ^^^YB
&~  :!^.7.!?#!               P^  ^!!!77??7~^.          .^~7??77!!!^  ^P               !#?!.7.^!:  ~&
&!^^:.^~:!!#~                YJ ?J:.   .:^!?J!   ^^   !J?!^:.   .:J? JY                ~#!!:~^.:^^!&
#7:^~!^^~^GY                 .B^J~           ~?  ~~  ?~           ~J^B.                 YG^~^^!~^:7#
JB:.:^!7!!B^                .7P::J:         .~5:    :5~.         :J::P7.                ^B!!7!^:.:BJ
.BJ^^^^~75&:              ^JY7.  .!~:   ..^~~!~ :~~: ~!!~^..   :~!.  .7YJ^              :&57~^^^^JB.
 ^#!:^~~~?#!             !G~       ^!?7!!~::~: !J..J! :~::~!!7?!^       ~G!             !#?~~~^:!#^ 
  ^B?.^~~~5P             JP       .:::.   .:~ !J    J! ~:.   .:::.       PJ             P5~~~^.?B^  
   .YP!:~!!BJ            .Y5~.  :~~!77!^.  . ?7  :   77 .  .^!77!~~:  .~5Y.            JB!!~:!PY.   
     ~Y5?~!?BY.            ^JYJ7!!5G5?7Y?^. :5. ~Y7. .5: .^?Y7?5G5!!7JYJ^            .YB?!~?5Y~     
       ^J5J??PG?^            .^!77: YJ..J?~. ^7?!.:~!7^ .~JJ..JY :77!^.            ^?GP??J5J^       
         .^7JY5GBG5?~^.              G! !7!?!~^~^^:~~^~!?!7! !G              .^~?5GBG5YJ7^.         
             .:^~7??7~:              ~G ^J!: ^:?:7?:7:^ :!J^ G~              :~7??7~^:.             
                                      P^ 5??!^ : .: : ^!??5 ^P                                      
                                      J7 J?^^?!5!:^!5!?^^?J 7J                                      
                                      7J::7J7:^!~^^~!^:7J7::J7                                      
                                      7Y^  .7??7?77?7??7.  ^57                                      
                                      .^7??!^:::~^^~:::^!??7^.                                      
                                          :~??7^    ^7??~:                                          
                                             .!?7777?!.                                             ");
            Console.ResetColor();

            do
            {
                Console.Write("\n\nEnter your answer > ");
                ans = Convert.ToInt32(Console.ReadLine());

                // Mustafa -Intro to the Game
                switch (ans)
                {
                    case 1:
                    case 2:
                    case 3:
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice");
                        Console.ResetColor();
                        break;
                }
            } while (ans != 1 && ans != 2 && ans != 3);
            Console.Clear();
            switch (ans)
            {

                case 1:
                    string combinedText = "In a world overrun by the Undead, survival is paramount.\n" +
                                              "Welcome to [Whispers of the Dead].\n" +
                                              "Where every shadow could conceal a lurking horror and every step could lead to your doom.\n" +
                                              "As civilization crumbles, you must navigate through the chaos, scavenging for resources, fortifying shelters.\n" +
                                              "But beware, for the infected hordes are relentless, driven by an insatiable hunger for flesh.\n" +
                                              "Will you muster the courage to fight back, or will you join the ranks of the walking dead?\n" +
                                              "The choices are yours in this heart-pounding journey through the apocalypse.";

                    PrintOneByOne(combinedText);
                    break;
                case 2:
                    currentLocation = "input";
                    Console.Write("Press enter to continue...");
                    break;
                case 3:

                    Quit();
                    break;
            }

            Console.ReadLine();

            Console.Clear();
            //Input call by Samuel B 25/5/2024//
            Console.WriteLine("'You hear a voice screaming and you wake up... do you want to wake up?'");
            Input();

            //While loop for location to prevent stack overflow
            while (true)
            {
                switch (currentLocation)
                {
                    case "input":
                        Input();
                        break;
                    case "house":
                        House();
                        break;
                    case "south":
                        South();
                        break;
                    case "east":
                        east();
                        break;
                    case "west":
                        west();
                        break;
                    case "convenience":
                        Conve();
                        break;
                    case "pharmacy":
                        Pharmacy();
                        break;
                    case "factory":
                        factory();
                        break;
                    case "town hall":
                        TownHall();
                        break;
                    case "extendedSouth":
                        extendedSouth();
                        break;
                    case "left":
                        Left();
                        break;
                    case "right":
                        Right();
                        break;
                    case "school":
                        School();
                        break;
                    case "insideSchool":
                        insideSchool();
                        break;
                    case "schoolLeft":
                        schoolLeft();
                        break;
                    case "schoolRight":
                        schoolRight();
                        break;
                    case "beach":
                        Beach();
                        break;
                    case "forest":
                        Forest();
                        break;
                    case "north of forest":
                        fnorth();
                        break;
                    case "south of forest":
                        fsouth();
                        break;
                    case "east of forest":
                        feast();
                        break;
                    case "church":
                        Church();
                        break;
                    case "eastern house":
                        EastHouse();
                        break;
                    case "insideAbandoned":
                        insideAbandoned();
                        break;
                    case "park":
                        Park();
                        break;
                    default:
                        Console.WriteLine("Unknown location.");
                        break;

                }
            }




        }
        //Input method by Samuel B 25/5/2024//
        static void Input()
        {
            //Initialize health counter after death - Samuel B - 11/06/2024
            health = 100;
            //Do while loop by Samuel B 25/5/2024 | If the user types an answer other than yes or no when asked for instructions//
            do
            {
                //Ask for user choice Samuel B 25/5/2024
                Console.Write("Would you like instructions?: ");
                choice = Console.ReadLine();

                if (choice.ToLower() == "yes")
                {

                    instructions = Instructions(instructions);
                    Console.WriteLine(instructions);

                }
                else if (choice.ToLower() == "no")
                {
                    Console.WriteLine("Press enter to continue...");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please type 'yes' or 'no'");
                    Console.ResetColor();
                }
            } while (choice != "yes" && choice != "no");

            Console.ReadLine();
            //Call to Shed method by Samuel B 25/5/2024//
            House();

        }
        //Shed method by Samuel B 26/05/2024//
        static void House()
        {
            Console.Clear();
            //Items array by Samuel B 28/05/2024//
            string[] houseItems = new string[] { "Shotgun", "Bulletproof Vest" };
            //Health counter by Samuel B 3/06/2024
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();

            Console.WriteLine("\nYou are located within a small 2 story house located in the northern outskirts of Dubravica");
            do
            {

                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                //Changed if statement to switch statement by Samuel B 29/05/2024
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "south":
                        //Leave empty
                        break;
                    //Cases for shotgun - Samuel B 3/06/2024
                    case "add shotgun":
                        HandleAddItem("Shotgun", ref houseItems);
                        break;
                    case "drop shotgun":
                        HandleDropItem("Shotgun", ref houseItems);
                        break;
                    //Cases for vest - Samuel B 3/06/2024
                    case "add vest":
                        HandleAddItem("Bulletproof Vest", ref houseItems);
                        break;
                    case "drop vest":
                        HandleDropItem("Bulletproof Vest", ref houseItems);
                        break;
                    //Cases for help - Samuel B 3/06/2024
                    case "?":
                    case "help":
                        Help();
                        Console.WriteLine("'south' - to navigate and proceed south ");
                        break;
                    case "items":
                        ViewItems(houseItems);
                        break;
                    case "location":
                        Console.WriteLine("You are currently located within a 2 story house");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;

                }
                Thread.Sleep(1500);
            } while (choice != "south");
            //Call to South method by Samuel B 26/05/2024//

            currentLocation = "south";
        }


        //Thomas F 28/05/2024 working on the south method
        static void South()
        {
            Console.Clear();
            //South items array by Samuel B 28/05/2024//
            string[] SouthItems = new string[] { "Drugs" };
            //Health counter by Samuel B 3/06/2024
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("\nYou've gone south but not all seems right in the distance whining echo's through what could you could almost distinguish as the whining of children");

            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                //Changed if statement to switch statement by Samuel B 29/05/2024
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "items":
                        ViewItems(SouthItems);
                        break;
                    case "south":
                    case "east":
                    case "west":
                    case "back":
                        break;
                    case "?":
                    case "help":
                        Help();
                        Console.WriteLine("'south' - to navigate and proceed south ");
                        Console.WriteLine("'east' - to navigate and proceed east");
                        Console.WriteLine("'west' - to navigate and proceed west");
                        break;
                    case "add drugs":
                        HandleAddItem("Drugs", ref SouthItems);
                        break;
                    case "drop drugs":
                        HandleDropItem("Drugs", ref SouthItems);
                        break;
                    case "location":
                        Console.WriteLine("You are currently located within the south");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;

                }

                Thread.Sleep(1500);
            } while (choice != "south" && choice != "east" && choice != "west" && choice != "back");
            //If the choices are equal to the south, west and east
            switch (choice)
            {
                case "south":
                    currentLocation = "extendedSouth";
                    break;
                case "east":
                    currentLocation = "east";
                    break;
                case "west":
                    currentLocation = "west";
                    break;
                case "back":
                    currentLocation = "house";
                    break;
            }

        }
        //Extended South room by Samuel B 29/05/2024
        static void extendedSouth()
        {
            Console.Clear();
            string[] extendedSouthItems = new string[0];
            //Health counter by Samuel B 3/06/2024
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("\nYou find yourself standing at the edge of a quiet street, shrouded in the soft glow ");
            Console.WriteLine("of the evening sun. The street is named \"Crescent Way\", but locals refer to it");
            Console.WriteLine("simply as \"The Forgotten Path.\" The air is thick with mystery, and each house along ");
            Console.WriteLine("the road seems to whisper tales of its own.");
            Console.WriteLine("\nYou have two navigation choices \"left\" or \"right\"");
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "left":
                    case "right":
                    case "back":
                        break;
                    case "items":
                        ViewItems(extendedSouthItems);
                        break;
                    case "?":
                    case "help":
                        Help();
                        Console.WriteLine("'left' - to navigate and proceed left ");
                        Console.WriteLine("'right' - to navigate and proceed right");
                        break;
                    case "location":
                        Console.WriteLine("You have gone further south");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;


                }
                Thread.Sleep(1500);
            } while (choice != "left" && choice != "right" && choice != "back");
            switch (choice)
            {
                case "left":
                    currentLocation = "left";
                    break;
                case "right":
                    currentLocation = "right";
                    break;
                case "back":
                    currentLocation = "south";
                    break;
            }
        }
        //Thomas to edit Left method
        static void Left()
        {
            bool ContinueLoop = true;
            Console.Clear();
            //Left items array - Samuel B 6/06/2024
            string[] leftItems = new string[0];
            //Health counter by Samuel B 3/06/2024
            Console.WriteLine("\nThe path Leads to the School would you like to continue?");
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            //Change this - Samuel B 4/06/2024:
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "yes":
                        Console.WriteLine("Proceeding");
                        Thread.Sleep(1000);
                        Console.WriteLine(".");
                        Thread.Sleep(1000);
                        Console.WriteLine(".");
                        Thread.Sleep(1000);
                        break;
                    case "items":
                        ViewItems(leftItems);
                        break;
                        //Testing case for the testing of the health system - Samuel B 11/06/2024
                    case "drop":
                        health -= 100;
                        Health(ref health, ref ContinueLoop);
                        break;
                    case "?":
                    case "help":
                        Console.WriteLine("You can type commands such as: ");
                        Console.WriteLine("'map' - for viewing the map ");
                        Console.WriteLine("'inventory' - for viewing items your inventory ");
                        Console.WriteLine("'items' - view items located within your current location ");
                        Console.WriteLine("'yes' - to navigate and proceed to the school ");
                        break;
                    case "location":
                        Console.WriteLine("You have headed left");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
            } while (choice != "yes" && ContinueLoop);
            switch (choice)
            {
                case "yes":
                    currentLocation = "school";
                    break;
                
            }

        }
        //Made The School Method
        //School -Mustafa
        static void School()
        {
            Console.Clear();
            //School items array by Samuel B - 6/06/2024
            string[] schoolItems = new string[0];
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("You are on your way to the school.");
            Console.WriteLine("Do you wish to Proceed?");
            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "yes":
                        Console.WriteLine("Proceeding");
                        Thread.Sleep(1000);
                        Console.WriteLine(".");
                        Thread.Sleep(1000);
                        Console.WriteLine(".");
                        Thread.Sleep(1000);
                        break;
                    case "items":
                        ViewItems(schoolItems);
                        break;
                    case "?":
                    case "help":
                        Help();
                        Console.WriteLine("'yes' - to navigate and proceed inside the school ");
                        Console.WriteLine("'no' - to navigate and go back to the left room");
                        break;
                    case "location":
                        Console.WriteLine("You are currently located within the school");
                        break;
                    case "no":
                        break;
                    default:

                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "yes" && choice != "no");
            switch (choice)
            {
                case "yes":
                    currentLocation = "insideSchool";
                    break;
                case "no":
                    currentLocation = "left";
                    break;
            }
        }
        static void insideSchool()
        {
            Console.Clear();
            //Local item array by Samuel B - 6/06/2024
            string[] iSchoolItems = new string[0];
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("You are inside the School building.");
            Console.WriteLine("YOU HEAR A VOICE SCREAMING");
            Console.WriteLine("Right");
            Console.WriteLine("Left");
            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "back":
                    case "left":
                    case "right":
                        break;
                    case "help":
                    case "?":
                        Help();
                        Console.WriteLine("'left' - to navigate and proceed to the left of the school ");
                        Console.WriteLine("'right' - to navigate and proceed to the right of the school");
                        break;
                    case "items":
                        ViewItems(iSchoolItems);
                        break;
                    case "location":
                        Console.WriteLine("You are currently inside the school");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back" && choice != "right" && choice != "left");
            switch (choice)
            {
                case "back":
                    currentLocation = "school";
                    break;
                case "right":
                    currentLocation = "schoolRight";
                    break;
                case "left":
                    currentLocation = "schoolLeft";
                    break;
            }

        }
        static void schoolRight()
        {
            Console.Clear();
            //Local item array by Samuel B - 6/06/2024
            string[] rightSchoolItems = new string[] { "Book" };
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("You are inside the Staff room.");
            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "back":
                        break;
                    //Cases for Book - Mustafa
                    case "add book":
                        HandleAddItem("Book", ref rightSchoolItems);
                        break;
                    case "drop book":
                        HandleDropItem("Book", ref rightSchoolItems);
                        break;
                    case "help":
                    case "?":
                        Help();
                        Console.WriteLine("'back' - to navigate and proceed back to the school lobby ");
                        break;
                    case "items":
                        ViewItems(rightSchoolItems);
                        break;
                    case "location":
                        Console.WriteLine("You are currently located within the right-hand side of the school");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back");
            switch (choice)
            {
                case "back":
                    currentLocation = "insideschool";
                    break;
            }
        }
        static void schoolLeft()
        {
            bool ContinueMethod = true;
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.WriteLine("You have turned Left");
            Thread.Sleep(1000);

            // Split the string and highlight the profanity
            string part1 = "";
            string highlightedWord = "*INSERT PROFANITY*!!!";
            string part2 = " You are surrounded by Zombies";

            // Print the first part
            Console.Write(part1);
            // Set the console text color to red for the highlighted word
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(highlightedWord);
            // Reset the console text color to default
            Console.ResetColor();
            // Print the second part
            Console.WriteLine(part2);

            Thread.Sleep(1000);
            string deadSchool = "Amidst the eerie halls of the abandoned school, " +
                "the player's final breath was stolen by the relentless grip of the zombie's decaying hands.";
            PrintOneByOne(deadSchool);
            Console.ReadLine();
            Thread.Sleep(2000);
            // Decrease health
            health -= 100;
            // Direct to the health method
            Health(ref health, ref ContinueMethod);
        }

        //Made the Right Method - Mustafa
        static void Right()
        {
            Console.Clear();
            //Local item array by Samuel B - 6/06/2024
            string[] rightSchoolItems = new string[0];
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("You are inside heading towards the Beach.\nWould you like to proceed?");
            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "back":
                    case "proceed":
                        break;
                    case "help":
                    case "?":
                        Help();
                        Console.WriteLine("'back' - to navigate and proceed back to the school lobby ");
                        break;
                    case "items":
                        ViewItems(rightSchoolItems);
                        break;
                    case "location":
                        Console.WriteLine("You have headed right");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back" && choice != "proceed");
            switch (choice)
            {
                case "back":
                    currentLocation = "extendedSouth";
                    break;
                case "proceed":
                    currentLocation = "beach";
                    break;
            }
        }
        //Made the Beach Method. -Mustafa
        //Thomas to edit beach method
        static void Beach()
        {
            bool ContinueMethod = true;
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("\nYou reach the Beach the smell of the ocean is a bitter");
            Console.WriteLine("yet comforting old smell but as you stand upon that sand");
            Console.WriteLine("You slip and tumble down to the rocky den of leopard seal");
            Thread.Sleep(1200);
            Console.WriteLine(".");
            Thread.Sleep(1200);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Dazed and hurt you have no chance to defend yourself and");
            Console.WriteLine("You've succumb to the leopard seal's might");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(@"&#BGGGPPPPPPPPGGBGPPPPPPPPPPPGPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPGPPPPPPPPPPPPPPPPPGGGGPPGPPPPPPPPG#&
&P5GBGGGGP5YY555PP5555YYYYJJJJJJJJJJ?JJJJJ???????????????JJJYYYJJJJJYJJJJYYYYY5YY5P555YYY5PGGPGBGYG&
&PY#GBGPYYY5YYYYJJ???JYYYYYYYYYJYYJJ???JJ?77777777!77777??J?JJJ?JJYYYJYYYYYYYYJ????JYYYJY55Y5GGG#Y5&
&GJYPB5775BPYJJYYJ7?JJPYJYYJY5555Y?JJJ??777!~!!~~!!~!!!7!!77?JJJ?JY5555Y?JJJYYJ??7?YYJJJ5G5J?YG55J5&
&G?JYPY7J55?7?YPPG5JJY5J?YJ??YYJJJYJ?77!!!!!7!!~^^!~!~~~!7!!!77?YYJ?JJY?7?J??5Y?JYPP5YJ??55Y??PJ7?P&
&PJ?JYYJ?YY5PGGGP5P?!JJJJYJ???J?JY??7!!!~~~~~~~~^^~~^~!7!!!~!7!7JJPG5JJJ?JJJ?JY7?YPPGGGP5JY?J?5J?YP&
P5YJ?JY55Y?JJYYJJY5?7JY55Y??JJJJJ?7?7!~~~~~!~~^~~^^~~!!!!!~~7777??JYPG5??JJ5YJY7755JYY5YJ7J555YYYYYP
55YJJJP5PP5YYJJY5YYY?J5YJ??J5YYJJJ77!~~~!!!!~~^^:^~!7!!~!!~!!!?J?JJJY5BGJ7?J5YJ775YYYJJJJ5P5Y5YJYYYY
&BYYYYYPGPYYYYJY5PYYJJJ??J55YYJJJ7?!~!!!!!~~~~^^^~~~~!!~!!~!~!7??JYY5PPBG5J?JJY77P55YYYYYYPGPYYYY5G#
&BGY5Y?PPJ777??77Y5J?JYYY5P555YJ?7!~!!7!~~~~!~~^^^~~~!~!!~!!!7777JY5YPPGGGPPYJJ??5Y???JJJJYG5?Y5YGB#
&GGP5Y?55J?77?J7?JJ777YY5555PP5PJ77!!!!777!!!!!~~~!~~!~~~7!777!?7?55Y555555PYJ?77JJ?7JJJ?JJY5?Y55PP#
&P55PY?5555???JJYYYJJJJJYYYYPGGGP?77777!!!!!!!!!!!7!!!!!7?7777???5GGPP555YYYYYYYYYYYYYJ??55P5?J5YPP&
&G5YY??PYJJ5YJJ?JPYJYYYYYYY5GGBBB?777!~~~~!7????7!!7777!~~~~!77?JGBGGGBGP55YYY555PG5JYJJYYJ557JYY5P&
GGPYJ??5YJJYPJJJGB5YJYYYYY5PBGGBY~~~77JJ?7!!!777!!~77~!!7JJ?7!~~!5BGGPB55YYYY5555PBPYJJPYYY557JYJJP&
J555J7?PJJ5Y??JPGGPYY5YYY55B#PY?!!JG#&&&&&#GY?77??7?JYPB&&&&#G5?!7?5GGBB5YYJJ55YYPBBPJ7?Y5Y557?JJJP&
JYJJJJ?P5YY77Y55PPYJ?JJJJYYG#5!!JG&&&&&&&&&&#5JJ^JGYP&&&&&&&&&&#P?7?PGBPJJJJJJJJJYBGG5J77Y5P57?JJJG&
?JJJJ??PPY??YP55GY?????????P&G??B&&&&&&&&&&&&#77^!5J#&&&&&&&&&&&&PJ?GG#5??77????7?GP5YPY?75GP????JG&
JYYJ77?P5J?YGG5P#PYYJ????Y5BBG??G&##&&&&&&#&&G?J^!J?B&&&&&&&&&&&&P?JBGBBY???J?JJJ5BBGPYPY?JG5????JP&
55YJ???5Y7JPY?J5GBBY5JJJ?YBPBB?!P########&&&#Y77^!7??#&&&#######&5??#BBBB???JJJYGBGBG5JYPJ7Y5?JJJJP&
PYJJ???5?75P7Y55PGBYY77?J5BPB#?~Y&#####&&&BP?!!7??7!??P#&&######&Y7?##G5B5???JYJPG5P555JYY77YJ?JYJP&
#PYJJ?JY!?P5Y5P55GGJ577?5PGPBP!!!JGGGBGP5?7!7?P#&&#Y777?JYPGGBBB5!?75#PYG577???JGGGPY55YYP?7YJ?JJJP&
&G???JYY!JPYY555PGGJ57!?55PPG?!!!!~~!7?J?JY77B&&&&&&G!5Y???7!!!~!!7!?P5JGY?!7??JPGPP5J?55GY7YJ?JJJP&
#GJ???JY7JGJYYY5PP5JY7!?YYY5G???J?7JYYJYJYY~J&&&&&&&&7?JYYYJY?7?????YYPJGY?!7??YPGPP5JJY5YJ7JJJ???P#
BPP?7JJJJYG55555PPPJY7!?YJYGBJJ5YYJJJ??5J?J~5&&&&&&&&777JY???7?JJJJJJGGPGJ7!7?JY5GG55YJY5YJ?JYY7?PPG
BPP???J5?JPB5BP55P5Y5YJYYJPPBBP5YY5PP5JJ57?!?G&&&&&&P7Y?5?5GGGP5555PBBPG5YJ???YY5GGP5YJYPYJJYY???PPG
#PP??YYPY?Y5YYY55PYJJ????JPGGB##BG#&##B??7??P~JJ!?JJ7BY?JB&&&&BGGG##BGPP55JJ77Y55GPP5YJY5J?J5YJ?JP5#
#PPJJJYPP7??YY5555YYJ7!7JYPBBB##BP5##B#5!77?J^~~^~~!75J75###B#YY5G#BGGPP55?777JP5GP555?JY??J5YJ?JPP#
#55YYYJPGJ!7J55555?JY7!7?J5BGGBB#PJP&#BPJJ!7!^~!!!~!?Y5?5BBB&B?YYBBGGPPGYJ?7??JJJPG55JJJ???Y5JJJJ5G&
&5JJJYJPG5?7?J5PP5?5Y?77?JYGPPPGBPY?&&&#5J?JJJ7JY?JJJJ5J5B##&?J55BGGPPPY???JJYJJ?YGP5YYJ??J55JJJJ5P#
&5JJJJJGB5PJ7?J5P5????7???YGPPGGBGY75&&GJ??J7J7Y~5~YJ55YYG##P!55PBGGGGPYJJJJJJJJY5PYYYJ??J555JJJYY5#
&5YJJ??PBPPPJ?JY5GYJJYYYYY5GPPPGBGJ?!P#G?!7~!~~!^7~?JJYY5BBP??55PBGGGGGJ???77?JJJ55YYJ??YG5YYJJJYJY#
&P5YJJJ55YY5PY??55YJJ?7??JYPGPPG#GY?!?GGYJJ7?7J?JYYJJYJ55BGJ7J5YGBGGGPGYJ???????JYP5Y?7YGPY55JJJJYY#
&P55YJJYJJYY5PY??YJ??7!777?5GPPPBG!7!~JY55YYYYJJYYYY55PPP5J77JJY#BGGPPPYJJ??J?JJJYP5J75BP5Y55YJJJYY#
&P5YJJJY?JJY55GY?JY??????JJ5BP5GGB5J!~~7???7777?JJ??JJJYY?7?JYPB#BGGPPGJ??J???YYYYYYYPBPY??J5JJJYYY#
&GP5J?JY?JYY55Y5J?J????????JYGG55PGBBGJ!777!!!~!77!7!7?Y??5GBBBPPP555PY??????????JJ?YY55YYJJYJJJY55#
&P5GJJ5YJ55YYJ?JJJ?JJJYYJJJYJPGYJYY5GBBGPJ!?7~~!?7777!JJGB#BG5PYY5555P5J??JJJJJJJJJ??J?JY5YYYYJJPP5#
&PY5YJYYYY5YJYYYYYJJY5P55555YYJJJJJJJYPGBBP55Y5PGP5YJ5GBBP5J??JJJJJJJJJJYYY55555P5YYYYJYY555YYJJY55#
&5Y?JJY55P5??JJ?????7JJ?JJJYYJJJJYYYYYYYY555PGGPPGGGGGGP5YYJJYYYYYYY5YJJ??JYJJJJYJ????J??Y555YY??55#
&G5?JJ55JJYYY55YJ???JJJ?77????JJJJ????????JYYYP5YY5PPP5JYJJ????????JJ?JJ??????JJJJJYYYYJJJJJ55YJ?5P#
&P5JJJ5Y????JYYYJ??75YJJJYYYYYYYJ?77777?JJY5YJYJJYYYYYJY5YJJJ???777777?JYYJJJ??J?YYYJJYJJJ??J55JY5P#
&5YJJJJJJ?JYJY5YYYJJYYJYJJJJ?JYJ??JYYY5PPJJJJJJJ5YY5YYJJY?7YYYYJ?J????JJJ???JJJYYJY5Y5YJYY???JYY?JY#
&P5JJYY5YY5YJJYJYYJJJ5Y5PP5J??J?JJJY555PYJJJ?YY55JJYYJYJYJJ5555YYYJJJ???JYPP5Y5YJJYYJYJYYJ?YY5YJYY5#
&GYJ??JJYJJ???JJ?J??JJ?J5PYYYYYYJYJ777??JYY555555YJYJYY5YYYJJJ??J????JY5PYY5YJJJJJJJY???JJYJJYYJYYP#
&GY57?J???YJ?JJ??JJYYJ??JYYYYYY5555YYYJ???JJJJJJYJ?YJ??JJJJJJJJJYY555YYYY5YJ?JJYY?J??JJ?JJJ??JJ?55P#
&PY55YJ77???JJJJJ?Y5YJJYJ??77777777???JJJJJYYYJYYJJYJJJJJYJJJ????????7?7?JJ??JJ5YYJJ?JJJJ???7?J5PYP#
&5JYY55J???JJJJY5GG5PPPP555YJYY55YJJJJJJYJJYYYY55YYYYYYYYYJY55Y5555555555555YY555GP5YJYJJJ??J555JJY#
&BBBBG5YYJ?JY55PGGPYJJJJYJYYJJJYYJ7!!7!7777777?JJJYYJJJJ???JY55YYJ?YYJJJJJJ?J??YYYYY5PPY?Y5555GGGBG&");
            Thread.Sleep(2000);
            //Decrease health
            health -= 100;
            //Direct to the health method - 3/06/2024
            Health(ref health, ref ContinueMethod);
        }

        //Trevor's duty to edit east method
        static void east()
        {
            Console.Clear();
            //East Items array - Samuel B 6/06/2024
            string[] eastItems = new string[0];
            Console.WriteLine("You have gone East.");
            Console.WriteLine("You see 4 paths ahead");
            Console.WriteLine("Park\nHouse\nChurch\nForest");
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "park":
                    case "house":
                    case "church":
                    case "forest":
                    case "back":
                        break;
                    case "items":
                        ViewItems(eastItems);
                        break;
                    case "help":
                    case "?":
                        Help();
                        Console.WriteLine("'park' - to navigate and proceed to the park ");
                        Console.WriteLine("'house' - to navigate and proceed to an old clunky 3 story house");
                        Console.WriteLine("'church' - to navigate and proceed to the nearby church");
                        Console.WriteLine("'forest' - to navigate and proceed to the nearby forest");
                        break;
                    case "location":
                        Console.WriteLine("You are currently stationed in the east");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;


                }
                Thread.Sleep(1500);
            } while (choice != "park" && choice != "house" && choice != "church" && choice != "forest" && choice != "back");
            switch (choice)
            {
                case "park":
                    currentLocation = "park";
                    break;
                case "house":
                    currentLocation = "eastern house";
                    break;
                case "church":
                    currentLocation = "church";
                    break;
                case "forest":
                    currentLocation = "forest";
                    break;
                case "back":
                    currentLocation = "south";
                    break;
            }
        }
        //Out side the Abandoned building - Mustafa
        static void EastHouse()
        {
            // Clear the console screen
            Console.Clear();
            // Display the player's current health
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            // Display the current location description
            Console.WriteLine("You are Outside the Abandoned house");

            // Start a loop to get the player's next choice
            do
            {
                // Prompt the player for their next action
                Console.Write("\nWhat's next? > ");
                // Read and convert the player's choice to lowercase
                choice = Console.ReadLine().ToLower();

                // Handle the player's choice using a switch statement
                switch (choice)
                {
                    case "map":
                        // Display the map
                        map();
                        break;
                    case "inventory":
                        // Show the player's inventory
                        ShowInventory();
                        break;
                    case "enter":
                    case "back":
                    case "help":
                        // Do nothing for these choices as they are handled after the loop
                        break;
                    case "?":
                        // Display help information
                        Help();
                        Console.WriteLine("'enter' - to gain access to into the room");
                        break;
                    case "location":
                        // Display the current location description
                        Console.WriteLine("You are within a house that is stationed in the east");
                        break;
                    default:
                        // Display an error message for invalid choices
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                // Wait for 1.5 seconds before continuing
                Thread.Sleep(1500);

                // Continue the loop until the player chooses "back" or "enter"
            } while (choice != "back" && choice != "enter");

            // Handle the player's final choice after exiting the loop
            switch (choice)
            {
                case "back":
                    // Set the current location to "east" if the player chooses to go back
                    currentLocation = "east";
                    break;
                case "enter":
                    // Set the current location to "insideAbandoned" if the player chooses to enter the house
                    currentLocation = "insideAbandoned";
                    break;
            }
        }
        //Abandoned building - Mustafa
        static void insideAbandoned()
        {
            bool ContinueMethod = true;
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("Proceeding");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.WriteLine("You have Entered the Abandoned Building");
            Thread.Sleep(1000);
            Console.WriteLine("YOU HAVE ENOUNTERED A MUTATED ZOMBIE");
            Thread.Sleep(1000);
            Console.WriteLine("Run!!");
            Thread.Sleep(1000);
            string deadHouse = "In a desperate sprint from the relentless zombie," +
                " the player's frantic steps faltered, tripping over unseen debris," +
                " sealing their fate in the cold grasp of the undead.";
            PrintOneByOne(deadHouse);
            Console.ReadLine();
            Console.WriteLine();

            Thread.Sleep(2000);
            //Decrease health
            health -= 100;
            //Direct to the health method - 3/06/2024
            Health(ref health, ref ContinueMethod);
        }
        static void Park()
        {
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            //Park items array - Samuel B 6/06/2024
            string[] parkItems = new string[0];
            Console.Write("\nYou are currently located within a random park in the eastern outskirts of the city");
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "back":
                        break;
                    case "help":
                    case "?":
                        Help();
                        break;
                    case "items":
                        ViewItems(parkItems);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back");
            switch (choice)
            {
                case "back":
                    currentLocation = "east";
                    break;
            }
        }
        //Samuel to edit the west method
        static void west()
        {
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            //Array of items west - Samuel B 6/06/2024
            string[] westItems = new string[0];

            Console.WriteLine("\nYou have gone west. The sun begins to set, casting long shadows over the rugged landscape.");
            Console.WriteLine("The path ahead is overgrown, hinting at long-forgotten secrets waiting to be uncovered.");
            Console.WriteLine("The air is cool, and the sound of rustling leaves fills your ears. In the distance, you notice an old, abandoned cabin.");
            Console.WriteLine("The path ahead is overgrown, hinting at long-forgotten secrets waiting to be uncovered.");
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "convenience":
                    case "pharmacy":
                    case "factory":
                    case "back":
                    case "town hall":
                        break;
                    case "help":
                    case "?":
                        Help();
                        Console.WriteLine("'convenience' - to navigate and proceed to a nearby convenience store ");
                        Console.WriteLine("'pharmacy' - to navigate and proceed to the nearby pharmacy");
                        Console.WriteLine("'factory' - to navigate and proceed to an old chocolate factory");
                        Console.WriteLine("'town hall' - to navigate and proceed to the Dubravica town hall");
                        break;
                    case "items":
                        ViewItems(westItems);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;


                }
                Thread.Sleep(1500);
            } while (choice != "convenience" && choice != "pharmacy" && choice != "factory" && choice != "back" && choice != "town hall");
            switch (choice)
            {
                case "convenience":
                    currentLocation = "convenience";
                    break;
                case "pharmacy":
                    currentLocation = "pharmacy";
                    break;
                case "factory":
                    currentLocation = "factory";
                    break;
                case "back":
                    currentLocation = "south";
                    break;
                case "town hall":
                    currentLocation = "town hall";
                    break;
            }

        }
        //Thomas created factory method 30/05/2024
        static void factory()
        {
            bool ContinueMethod = true;
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("\nAs you enter the dilapidated factory you smell a");
            Console.WriteLine("vile stench and catch whispers of growls as the darkness");
            Console.WriteLine("Creeps in around you as you tiptoe finding a lever you flick it");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Console.WriteLine("You shudder in fear a mega horde of zombies are a alerted to presence");

            Thread.Sleep(2000);
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(@"
                                       :!YGGBGGPPPBB5Y^:....                                       
                                    :^!?5G@@@@@@@@@BJ7!~^!J?7!~~^:..                                
                               :!JPBG5JJP#GY?!^^:!B#7~   .?5PG57^:::^^:                             
                           :7YPG@@5~:~77~.        :#?:!~    .~YB&BJ^..^!!^                          
                        ^7YY?~~YY: ~7~.    ^:      JG  ~7       ~5&@P?: .7J~                        
                     :!?7^.  75~  :!7:    ?Y       !B   7?        :JPJJY~  !?~                      
                   ^7!^    :5?    7!.    !&:       ~G   .B:         :JJ~Y5! .~7:                    
                 ^!~.     ^J^   .Y~      P5        ^P:   Y7   .^      !G^.!^  .!!                   
               :7~.  !J:  :     Y!       B!  .     .!7:  .:   7J       ~B. ^.   :!:                 
              !7.  ^Y7.        75        G~  !.      5^  :J   5P        ?? ?!  .~ ~~                
            :J~   ?Y:    !     P^        P~  7^     .#^  !#   5Y        :! 75   ?^ ^!               
           ^Y:  .5?     ~?    :Y   .   : P?  !~     7&.  P@7  YJ           7B   .J  :!              
          ~P:  .P7      5:    .:  .!   J~PG  ~?     B#  ^@@&: ?5     ..    !#.   ^?  :7.            
         ^G:  .G7      ??   .~    ~Y  :&JB@~ ~G    ^@P  YJ?@G ^B.    ^?    ~&.    ^?. :?            
        .B!   YJ      ^5    77   :BP  5##~JP J@?   J@5 ~Y  ~&Y #?    .B:   ~@^     :J^ ^J           
        5P  ~7P      :5:   ^B:  ^YB&.!Y ^ ~G~PP@J  5@&J#7   ~&^Y@^   !@J   ^@!      .Y7 7J          
       ^@~ ~Y?~     .Y^   ^#Y  77 :GYP~   ?&5. !#B?G#5@@J    PP~@&^  P@@^  ^@5        YY 57         
       5# .B~      :Y^   ?&&.:5~    7G~  :#P.   .?#@@?^PB:   !#!&JB.:@#BB. :&@^     .  55:#~        
      .#P JB      ^5^  ~G@&G^#!       .  G5       .!P&J :.   ~#GP ?5J@! 5G: B@B.    ~:  BYG#:       
      :@5.&5     ?G: ~PBJ^!##5           ^           :!.     !@#:  G@G   ~5!5Y&P    .!  ~&&@~       
      ^@P7@?   .G#:~PP!    B@!   .^^^^:.  ^?^           :~!7 5@~   :#7     7BP^P5    7^ .&@&:       
      :&&B@7   P&JGB!      ~&7    .:^~7?JY#7           :J57:^#!     ::      .!. YY   ^Y ^@@#.       
       B@@@?  !@&@5.        ^!           .:^.          :.   ~7                   ?J  .BPB@@G        
       G@@@J.:PGB5                                                  .^!??!~.      J7  P@@@@P        
       P@@@P?^P?G.  ^7JYYYJ?!^:               .^      :         .~JP#@@@@@@&GJ~:   P^ J@@@@5        
       J@@@@5 :P? !YYJG@@@@@@@&#GY7~:.      :7P!      J57~^^~7YG&@@@@@@@@@@@@#J7~  7P 7@&&@Y        
       ~@@@&^ .#^ :^7P&@@@@@@@@@@@@@&#BGPPPP57:        ~?YB@@@@@&P5PGB@@@@@@@@&5:  :#:^@P5@5        
       :&@@?  ^&~!P&@@@@@@@@@#YJ5#@@@@@@@@@Y:   ...    .^J&@@@@@&##&&@@@@@@@@@GYP7 .#^ #J7@P        
       ^@@P   ~@Y^J&@@@@@@@@@@@@@@@@@@@@@@P!.   :JP.   :^^~J#@@@@@@@@@@@@@@&P!   ^ ~#. Y?:@#.       
       ?@#:   ^@P  :Y#@@@@@@@@@@@@@@#GY5#!  !JY^  :   7GG57..?#Y!?J5PGB#&@B!.      GJ: ^5 G@^       
       B@7  7! B@5:  .!Y#@@@@@#G5?!:. .P^ ?#@@@&^    Y@@@@#7: :~       .:^^^^.   .P5Y:  ?~!@J       
      ?@#?^ ~@7~&&~    .?G5?!^.       .. ~JY@@@@G   ~@@@@@J .                  .7#GGY    ~ G&.      
     ~@@@G. ^@@5?#P^   .:                  .#@@@@^  J@@@@B.                   !5Y^:B^      ^@Y      
    7&#@G.  ?@@#7!55!                       ~@@@@7  J@@@#:   .:.              .  ~##.       7@!     
   ~J!GP.   G@@@&Y^                .!PY~     !&@@J~?J@@P:   .!P#55J7^::......^~?G@&B         J&^    
    :B5 .. !@@&GP@@GJ~:.      .:^75#@&@J~     :P@5!P7#?       77.P@JJ@&B?JG#&5?@@@~Y.  :^   ?75#~   
   ~#? ~Y: G&7.  !@@@@&B5GPPPP~J@@@GJ?5^        ^:.:             !@.Y@@! !@@5 ?@@# 7:  5~   J@#@@?  
  ~#! J?. ~#^    .#@@@@G.5@@@7 .#@@J.!^~            :.           ~#:G@B .#@&: 5@@# ^: :P    .##~Y#P^
 ^#~.5~   Y?     ~@@@@@B  G@@!  Y@&::^:?7  :.    7. Y~ :         ?5?Y@G ?@@B  G@@@^   !?     ?&. .^:
.B7:B!    P^     G@@@@@@^ ~@@G  7@?7  :#~  7~^?  B~^Y  77 ?^..:~5!:BB@B 5@@G  B@@@Y   J^  7! ~#.    
JP~&P .?  P:    ?@&#@@@@J  B@@~ !J GBB&@5~.7?!P.:G?JG^:~P7#Y^7&@@P^@@@&.J@@5  B@@@#.  5.  Y@!55     
#G#@! :&^ Y^   .#G^P@@@@#. ?@@J ^JB@@@@P..5@@@5^~B@&G:^G@@@B ~@@@@&@@@@^^@&^  G@@@@~ ^B.  P@@@^     
@&!#!  #5 ^:   .7 .&@@@@@! .5G^ :@@@@@@P 7@@@@! .#@@J  G@@@@5B@@@@@@@@@~ ?~   J@@@#: Y@^ ~@YP!      
@P BJ  !&^   .     P@@@@@?      .#@@@@@@!#@@@@7 P@@@#.7@@@@@@@@@@@@@@@&:      ?@@#~ ^&&.^B?         
P? !#:  JB.  5:    .P@@@@7       G@@@BB@@@@@@@PJ@@@@@5&@@@@@@@@&!#@PJ@?     ^P@&Y. ^#@BJP~          
..  ?P.  JP  G: .~   !G@@&J.     7@@@!~@@@@@@@@@@@@@@@@@@&5@@@@B !@5^~     7&@5: ^Y&@@#?            
     !5^  JP 5J  J!    ~P&@B~     55@^ B@@GY@@@@@YP@@@@@@B 5@@@5 ^G:      Y@&7^JB&@@@Y:             
      :JJ: YGY@?  Y!     :J#@?    .:Y!!#@@?:@@@@&.!@@@@@@J ^@@@P^!^     .P@@&B@@JY@B~               
        ~55!B@@&5: 5?       7#5     :::G7@!.#@@@5 :&@@@@@~ ?#&~.       :B@@@@@B:^@P.                
          7#@@@J!P7:&G^   YY:.5P       5:55 5@@@P :&@@B&B!J7.5.       ^P&@&?GG. JB                  
           .5@@Y .J55@&5: BBY?^PG.     ^.~G75J##!YY5&Y ^P.   7       ~J:G@! :.  ^^                  
             J@P   ~P@75&5&J :7PGY:       J^  ~P .. 5:  ~~          !?  BJ                          
              PP    .~. ?@@!   ..:J^           .    Y~             ??   ^                           
              ~7        .&#.      .J!               ^^           :5?                
                         !^         ?J:                        .?B7                   
                                     ~P?.          ...    .? .?#B^                  
                                      .?PY~.  .~YG#&&#GPY5#B5##?                                    
                                        .75PJ?JYYJ?77!!!!!!!!~.                                     ");
            Console.ResetColor();
            Console.WriteLine("The Consumes your vision as all hope leaves, Doing what little you can the fight");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("turns nasty with a zombie managing to grab your arm.");
            Console.WriteLine("Tearing flesh you scream in terror and give what hopeless resistance you can kick back hard and bit your teeth. Trying to point you gun at");
            Console.WriteLine("it but fortunately you manage to rustle loose just before the rest of the horde can catch you.");
            Console.Clear();
            Thread.Sleep(3000);
            Console.Write(".");
            Thread.Sleep(900);
            Console.Write(".");
            Thread.Sleep(900);
            Console.Write(".");
            //Basically just filler for a instead of combat because mustafa is not confident in it
            Thread.Sleep(4000);
            //Decrease health "it's already for decreasing"
            health -= 150;
            //Direct to the health method - 11/06/2024
            Health(ref health, ref ContinueMethod);
            //Could make this a combat method - Samuel B 4/06/2024
            //Not sure we got time mate got so much more to do.

        }
        //Created Convenience store, Pharmacy and Town Hall methods
        static void Conve()
        {
            Console.Clear();
            //Local Items Array to the Inventory
            string[] conveItems = new string[] { "Water", "Chocolate Bar", "Gloves" };
            //Health Counter in the Conve -Mustafa
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            //Convenience store Entry - Mustafa
            string combinedText = "You have stepped into the dead convenience store, the door creaking as it opened.\n" +
                 "The air was thick with dust, and the once-bright fluorescent lights flickered dimly.\n" +
                 "Shelves were bare or toppled, their contents scattered on the floor.\n" +
                 "A faint smell of stale air and decay hung in the atmosphere.\n" +
                 "The store, once bustling with life, now stood eerily silent, a forgotten relic of the past.\n";
            //Printing it one by one -Mustafa
            PrintOneByOne(combinedText);

            //Choices to the user in Conve - Mustafa
            Console.WriteLine("Look Around?");
            Console.WriteLine("Exit");
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "add water":
                        HandleAddItem("Water", ref conveItems);
                        break;
                    case "add chocolate bar":
                        HandleAddItem("Chocolate Bar", ref conveItems);
                        break;
                    case "add gloves":
                        HandleAddItem("Gloves", ref conveItems);
                        break;
                    case "drop water":
                        HandleDropItem("Water", ref conveItems);
                        break;
                    case "drop chocolate bar":
                        HandleDropItem("Chocolate Bar", ref conveItems);
                        break;
                    case "drop gloves":
                        HandleDropItem("Gloves", ref conveItems);
                        break;
                    case "?":
                    case "help":
                        Help();
                        break;
                    case "items":
                        ViewItems(conveItems);
                        break;
                    case "back":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back");
            switch (choice)
            {
                case "back":
                    currentLocation = "west";
                    break;
            }
        }
        static void Pharmacy()
        {
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            string[] pharmacyItems = new string[] { "Pain Killerrr", "Bandages" };
            Console.WriteLine("You have entered the Pharmacy");
            Console.WriteLine("Bang!!");
            Console.WriteLine(" :) You have shot a dead Zombie..");
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "add painkiller":
                        HandleAddItem("Pain Killerrr", ref pharmacyItems);
                        break;
                    case "drop pain killer":
                        HandleDropItem("Pain Killerrr", ref pharmacyItems);
                        break;
                    case "use pain killer":
                        health = health + 20;
                        break;
                    case "add bandage":
                        HandleAddItem("Bandages", ref pharmacyItems);
                        break;
                    case "drop bandage":
                        HandleDropItem("Bandages", ref pharmacyItems);
                        break;
                    case "use bandage":
                        health = health + 30;
                        break;
                    case "items":
                        ViewItems(pharmacyItems);
                        break;
                    case "back":
                        break;
                    case "?":
                    case "help":
                        Help();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back");
            switch (choice)
            {
                case "back":
                    currentLocation = "west";
                    break;
            }
        }

        static void TownHall()
        {
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            //Town hall items array - Samuel B 6/06/2024
            string[] townHallItems = new string[0];
            Console.WriteLine("You are outside the Town Hall.");

            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "enter":
                        ending("Key", Inventory);
                        break;
                    case "back":
                        break;
                    case "items":
                        ViewItems(townHallItems);
                        break;
                    case "?":
                    case "help":
                        Help();
                        Console.WriteLine("'enter' - to gain access to town hall");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back");
            switch (choice)
            {
                case "back":
                    currentLocation = "west";
                    break;
            }
        }

        static void Forest()
        {
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            //Forest items array - Samuel B 6/06/2024
            string[] forestItems = new string[0];

            //Mustafa but Thomas is fixed 30/05/24
            Console.WriteLine("\nYou are Wondering through the forest");
            Console.WriteLine("You see 3 Paths Ahead");
            Console.WriteLine("Which way do you choose to go?");
            Console.WriteLine("North\nSouth\nEast\nGo Back");
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "north":
                    case "south":
                    case "east":
                    case "back":
                        break;
                    case "items":
                        ViewItems(forestItems);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "south" && choice != "east" && choice != "north" && choice != "back");
            switch (choice)
            {
                case "south":
                    currentLocation = "south of forest";
                    break;
                case "east":
                    currentLocation = "east of forest";
                    break;
                case "north":
                    currentLocation = "north of forest";
                    break;
                case "back":
                    currentLocation = "east";
                    break;
            }

        }

        /*
         * edited the fnorth method changed from horde to a dead end where only option is back 
         * Trevor 12/06/2024
         */
        static void fnorth()
        {

            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("\nOH NO A DEAD END nothing to be seen here");
            Console.ReadLine();

            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                    break;
                    case "north":
                    case "south":
                    case "east":
                    case "back":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back");
            switch (choice)
            {
                case "back":
                    currentLocation = "forest";
                    break;
            }

        }
        //Player choosing South in the forest and falls Over the cliff -Mustafa
        static void fsouth()
        {
            bool ContinueMethod = true;
            //Mustafa
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            Console.WriteLine("\nYou see a an old bridge and you start passing through it.");
            Console.WriteLine("Player: What's the sound...?");
            Console.WriteLine("creeeek");
            Console.WriteLine("The bridge starts falling apart..");
            Thread.Sleep(2000);
            
            //Declare health decrease when falling off cliff by Samuel B - 3/06/2024
            health -= 100;
            //Direct to the health method - 3/06/2024
            Health(ref health, ref ContinueMethod);

        }
        static void feast()
        {
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            string[] feastItems = new string[] { "Radio" };

            //Samuel
            Console.WriteLine("\nYou have walked into the east of the forest and have you have found a Non-Functioning Radio");


            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "add radio":
                        //Adding item to inv
                        AddItemInv("Radio");
                        //remove item from item list
                        feastItems = RemoveItem(feastItems, "Radio");
                        break;
                    case "drop radio":
                        //Dropping item from inv
                        DropItemInv("Radio");
                        //Adding item back to house items
                        feastItems = AddItem(feastItems, "Radio");
                        break;
                    case "items":
                        ViewItems(feastItems);
                        break;
                    case "back":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back");
            switch (choice)
            {
                case "back":
                    currentLocation = "forest";
                    break;
            }
        }

        //Church -Mustafa (Made a bit story here :) ) 
        static void Church()
        {
            Console.Clear();
            // Set the console text color to green
            Console.ForegroundColor = ConsoleColor.Green;
            // Display the player's current health
            Console.WriteLine("Health: " + health);
            // Reset the console text color to default
            Console.ResetColor();
            string[] churchItem = new string[] { "Key" };
            int key = 0;
            Console.WriteLine("\nYou are heading inside the church..");
            Console.WriteLine("You open the door.. Creeeekk");
            Console.WriteLine("You find 2 Survivors that were recently infected");
            string TalkingPart1 = "Survivor 1 : Please Don't Kill us\n" +
                                  "Survivor 2 : It's a survivor\n";
            string highlightedWord = "Survivor 1: FUCKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK!! DAMN IT!";
            string TalkingPart2 = "\nPlayer : What happened?\n" +
                                  "Survivor 2 : You have to find the point of Evacuation and return back to save us..\n" +
                                  "\t We found a hint but we couldn't solve it and before we knew it, it was too late.\n" +
                                  "\t The hint is Within these walls, a haven waits, Where safety beckons, beyond the gates.\n" +
                                  "\t to find ... what was after it?\n" +
                                  "Survivor 1 : Within these walls, a haven waits, Where safety beckons, beyond the gates.\n" +
                                  "To find salvation, heed this call, In the heart of governance, stands tall.\n" +
                                  "Survivor 2: And we found this key..\n" +
                                  "Player : I'll try..";

            PrintOneByOne(TalkingPart1);

            // Set the console text color to red for the highlighted word
            Console.ForegroundColor = ConsoleColor.Red;
            PrintOneByOne(highlightedWord);
            // Reset the console text color to default
            Console.ResetColor();

            PrintOneByOne(TalkingPart2);

            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "add key":
                        HandleAddItem("Key", ref churchItem);
                        break;
                    case "drop key":
                        Console.WriteLine("The key cannot be dropped.");
                        break;
                    case "help":
                    case "?":
                        Help();
                        break;
                    case "items":
                        ViewItems(churchItem);
                        break;
                    case "back":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);
            } while (choice != "back");

            switch (choice)
            {
                case "back":
                    currentLocation = "east";
                    break;
            }
        }


        //BELOW THIS LINE ARE METHODS THAT AREN'T ROOMS by Sam B 30/5/2024 ---------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        static void ending(string item, string[] inventory)
        {
            //Will think of what to do here.. -Mustafa
            //For the game ending.

            bool keyInTownHall = Array.Exists(inventory, i => i == item);

            if (keyInTownHall)
            {
                //could add inventory to this 'room'? thomas at midnight lol
                string combinedtext = "You return to the door that once held you back with a smirk as you grab the key you retrieved from the church inserting it and it's a flawless fit\n" +
                "with a resounding turn. The door pops open in room the atmosphere golden as rays sun illuminate the room from the skylight above you're eyes\n" +
                "are drawn by the Croatian flag of nation you've fought so hard to protect. Snapping back to the mission at hand you quickly notice the plaque on the\n" +
                "desk clearly labeled mayor realizing this the mayor office you search around. Then you stumble upon it a combination lock safe behind a mayoral painting\n" +
                "thinking quickly of a combination you think of what could possibly be the combination then it strikes you, remember the national day of celebration on June 7th every celebration\n" +
                "the Croatian revolution of 879. I hit you like an ocean breeze you enter 7879 and the safe opens inside there is a device with antenna and a note next to it\n" +
                "saying 'evacuation' plunging the button down you hear a beep and then wonder if it worked after sometime passes, you step outside and hear droning in the distance.\n" +
                "Moments later there's a helicopter over your head and zombies swarming all around you and you see the helicopter landing on the roof and without a second thought you race toward it\n" +
                "your heart pounds as you race the zombies and fear. A voice yells out at you and you jump into helicopter gun fire all around suppresses the heat of the moment\n" +
                "Congratulations you've achieved victory over zombie game.\n\n" +
                "You have completed the game. Thank you for playing!";
                PrintOneByOne(combinedtext);
                Console.ReadLine();
                Environment.Exit(0); // Exits the console application
            }
            else
            {
                Console.WriteLine("It appears you currently don't have the key to the town hall in your inventory.");
                Console.WriteLine("Please go back and find the key to unlock and gain access to the town hall.");
                Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press ENTER to continue...");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                Console.Write("Please head back and go and retrieve the key.");
                Console.Write("\nCurrent Location: Town Hall");
                // Redirect to back to Town Hall method
            }
        }

        static void ViewItems(string[] Items)
        {
            // Check if the Items array is empty or has no elements
            if (Items.Length <= 0)
            {
                // Display a message indicating no items are present
                Console.WriteLine("No items are in this location.");
            }
            else
            {
                // Display the current items in the location
                Console.Write("\nCurrent items within the current location:");
                // Iterate through each item in the Items array
                foreach (string item in Items)
                {
                    // Display each item in the array
                    Console.WriteLine("\n- " + item);
                }
            }
        }

        //Instructions method by Sam B
        static string Instructions(string inst)
        {
            inst = @"INSTRUCTIONS:
             You will be stationed within the haunted village, known as Dubravica
             located in the European country of Croatia.When exploring through
             the haunted village, stay alert and avoid zombies by staying out of sight
             and moving quietly.Explore different areas of the village and search for
             supplies such as food, medical kits etc.Your final objective is to locate
             the final evacuation point, your final score will be based on time taken,
             resources gathered and zombies defeated.
             Good luck, and stay safe out there!. 
             (If you get stuck, type 'help' or '?' for some general hints)

             Press enter to continue....";
            return inst;
        }

        static void map()
        {        //Mustafa 25/05/2024 - Adding a basic map to be used for now will make a better one..
            //Samuel 28/05/2024 - Updated map
            //Changed the color to blue..
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine(@"





                                                                             HOUSE
                                                   Convenience Store           |                   Park
                                         Pharmacy      |                       |                     |     House
                                                  \    |                     South                   |    /
                                                   \   |                       |                     |   /
                                                      West    <----------------|---------------->   East           North
                                                   /   |                       |                     |   \        /
                                                  /    |                       |                     |    \      /
                                        Town Hall      |                       |                     |     Forest ----- East
                                                     Street                    |                   Church        \
                                                                               |                                  \
                                                                             South                                  South
                                                                            /     \
                                                                           /       \
                                                                       Left         Right
                                                                        |             |
                                                                      School          Beach

      N
      |
   W<--->E
      |
      S
");
            Console.ResetColor();
        }
        
        static void PrintOneByOne(string text)
        {
            //Mustafa - Making the characters one by one
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(5); 
            }
            Console.ReadLine();
        }
        //Methods regarding Item Arrays by Samuel B 27/05/2024----------------------
        static string[] RemoveItem(string[] array, string itemToRemove)
        {
            int index = Array.IndexOf(array, itemToRemove);
            //If the item is not found, return the original array
            if (index < 0)
            {
                return array;
            }
            //New array length is lesser than original
            string[] newArray = new string[array.Length - 1];
            //Array, Start Index, NewArray, Start Index, Num of Elements to copy to (exclusive)
            Array.Copy(array, 0, newArray, 0, index);
            Array.Copy(array, index + 1, newArray, index, newArray.Length - index);
            return newArray;
        }
        //Method for add items back to the item array by Samuel B 29/05/2024
        static string[] AddItem(string[] array, string itemToAdd)
        {
            //create new array
            string[] newArray = new string[array.Length + 1];
            Array.Copy(array, newArray, array.Length);
            newArray[newArray.Length - 1] = itemToAdd;
            return newArray;
        }


        //Methods regarding the inventory array by Samuel B 27/05/2024-----------------------
        //Method for Adding items to inv  by Samuel B 29/05/2024
        //Edited this method Samuel B - 1/06/2024
        static bool AddItemInv(string item)
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                //if the item is initially found in the inventory
                if (Inventory[i] == null)
                {
                    Inventory[i] = item;
                    Console.WriteLine($"{item} added to inventory.");
                    return true;
                }
            }
            //If the inventory is full
            Console.WriteLine("Inventory full. Cannot add more items.");
            return false;

        }
        //Method for removing items to inv  by Samuel B 29/05/2024
        //Edited this method Samuel B - 1/06/2024
        static bool DropItemInv(string item)
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] == item)
                {
                    //if the item is initially found in the inventory
                    // item removed
                    Inventory[i] = null;
                    Console.WriteLine($"{item} removed from inventory.");
                    return true;
                }
            }
            //If item isn't found in the inventory
            Console.WriteLine($"{item} not found in inventory.");
            return false;

        }
        //Inventory method by Samuel B 27/05/2024//
        static void ShowInventory()
        {
            int i = 0;
            if (Inventory[i] != null)
            {
                Console.WriteLine("Items in Inventory: ");
                foreach (string item in Inventory)
                {
                    Console.WriteLine("- " + item);
                }
            }
            else
            {
                Console.WriteLine("Inventory is empty");
            }
        }
        //-------------------------------------------------------
        //New methods for handling items by Samuel B 1/06/2024
        static void HandleAddItem(string item, ref string[] houseItems)
        {
            //Booleans for testing if item is in house and inv - Samuel B 1/06/2024
            bool itemnInLocation = Array.Exists(houseItems, i => i == item);
            bool itemInInventory = Array.Exists(Inventory, i => i == item);

            if (itemnInLocation && !itemInInventory)
            {
                //if statement for adding item to inv
                if (AddItemInv(item))
                {
                    //Removes item from items array when added to inv
                    houseItems = RemoveItem(houseItems, item);
                }
            }
            else if (itemInInventory)
            {
                Console.WriteLine($"You already have {item} in your inventory.");
            }
            else if (!itemnInLocation)
            {
                Console.WriteLine($"{item} is not in your current location.");
            }

        }
        static void HandleDropItem(string item, ref string[] houseItems)
        {

            //Calls method dropping item out of inv
            if (DropItemInv(item))
            {
                //Add item to items array
                houseItems = AddItem(houseItems, item);
            }
            else
            {
                Console.WriteLine($"The item you want to drop cant be dropped");
            }


        }
        static void Quit()
        {

            // Mustafa - Quiting the game
            Console.WriteLine("Quiting the game.");
            Console.ReadLine();
            //Exit the program - Sam B 1/06/2024
            Environment.Exit(0);
        }
        //Help method by Samuel B - 3/06/2024
        static void Help()
        {
            Console.WriteLine("You can type commands such as: ");
            Console.WriteLine("'map' - for viewing the map ");
            Console.WriteLine("'inventory' - for viewing items your inventory ");
            Console.WriteLine("'add (item)' - to add an item to your inventory ");
            Console.WriteLine("'drop (item)' - to drop an item from your inventory ");
            Console.WriteLine("'use (item)' - to use an item in your inventory ");
            Console.WriteLine("'items' - view items located within your current location ");
            Console.WriteLine("'location' - to view current location");
            Console.WriteLine("'back' - to head back to previous location");
        }
        //Health method by Samuel B - 3/06/2024
        static void Health(ref int health, ref bool ContinueLoop)
        {
            // Check if health is greater than 0
            if (health > 0)
            {
                // Display current health
                Console.WriteLine($"Health is now {health}");
                // Wait for 1.5 seconds
                Thread.Sleep(1500);
                // Clear the console
                Console.Clear();
                // Display current health again
                Console.WriteLine("Health: " + health);
            }
            else
            {
                // If health is 0 or less, clear the console
                Console.Clear();
                // Set console text color to red
                Console.ForegroundColor = ConsoleColor.Red;
                // Display "GAME OVER" message
                Console.WriteLine("GAME OVER");
                // Reset console text color to default
                Console.ResetColor();
                // Wait for 2 seconds
                Thread.Sleep(2000);
                // Clear the console
                Console.Clear();
                // Set the current location to "input" (this may need to be handled elsewhere in your code)
                currentLocation = "input";
                // Stop the main loop by setting ContinueLoop to false
                ContinueLoop = false;
            }
        }

    }
    //--------------------------------
}