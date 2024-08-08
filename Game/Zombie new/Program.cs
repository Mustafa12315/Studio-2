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
namespace Zombie_new
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
            Console.WriteLine("                                     \r\n __      __  ___ ___ .___  ________________________________________  _________   ________  ___________   ______________ ______________   ________  ___________   _____  ________   \r\n/  \\    /  \\/   |   \\|   |/   _____/\\______   \\_   _____/\\______   \\/   _____/   \\_____  \\ \\_   _____/   \\__    ___/   |   \\_   _____/   \\______ \\ \\_   _____/  /  _  \\ \\______ \\  \r\n\\   \\/\\/   /    ~    \\   |\\_____  \\  |     ___/|    __)_  |       _/\\_____  \\     /   |   \\ |    __)       |    | /    ~    \\    __)_     |    |  \\ |    __)_  /  /_\\  \\ |    |  \\ \r\n \\        /\\    Y    /   |/        \\ |    |    |        \\ |    |   \\/        \\   /    |    \\|     \\        |    | \\    Y    /        \\    |    `   \\|        \\/    |    \\|    `   \\\r\n  \\__/\\  /  \\___|_  /|___/_______  / |____|   /_______  / |____|_  /_______  /   \\_______  /\\___  /        |____|  \\___|_  /_______  /   /_______  /_______  /\\____|__  /_______  /\r\n       \\/         \\/             \\/                   \\/         \\/        \\/            \\/     \\/                       \\/        \\/            \\/        \\/         \\/        \\/ \r\n\r\n\r\n\r\n\r\n\r\n                                                   .^!?YJJYPJJPJ5YJYJ7^.                            .^7JYJY5JPJJPYJJY?!^.               \r\n                                                :!J5Y!~~~. :~ ^^.~ ^!7J5J~   :^!7??????????7!^:   ~J5J7!^ ~.^^ ~: .~~~!Y5J!:            \r\n                                             :?Y5J^.:^  .!  !.:! !  ! ^:755Y5?~~^:........:^~~?5Y557:^ !  ! !:.!  !.  ^:.^J5Y?:         \r\n                                           ~557. .~: ~^  7. 7.~^.! :!.~.~~:5!7                7!5:~~.~.!: !.^~.7 .7  ^~ :~. .755~       \r\n                                         ~5J:..~: .! .!  7 .7.7 !: 7.~.~:!.P..                ..P.!:~.~.7 :! 7.7. 7  !. !. :~..:J5~     \r\n                                       .Y5~:^.  !: ~^ 7 :! 7:!.~^.7:^:^^^^J7                   7J^^^^:^:7.^~.!:7 !: 7.^~ :!  .^:~5Y.   \r\n                                      :GJ:. .!: .7 ^!.7 7.!~~:~:.!^^^~^^!J7                      7J!^^~^^^!.:~:~~!.7 7.!^ 7. :!. .:JG:  \r\n                                     :B! .:~. 7: 7.^~~^!7YYY?5???7~^~^~?Y^                        ^Y?~^~^~7???5?YYY7!^~~^.7 :7 .~:. !B: \r\n                                     GY:^. .!:.7 !.!!5YY?!^^::^~75G7~7J!.                          .!J7~7G57~^::^^!?YY5!!.! 7.:!. .^:YG \r\n                                    7G. .~~ .7 7.!7GY!.          J&Y!~.                              .~!Y&J          .!YG7!.7 7. ~~. .G7\r\n                                    BY^^^ :!.^~~~P5:             P~:.   ...                      ...   .:~P             :5P~~~^.!: ^^^YB\r\n                                    &~  :!^.7.!?#!               P^  ^!!!77??7~^.          .^~7??77!!!^  ^P               !#?!.7.^!:  ~&\r\n                                    &!^^:.^~:!!#~                YJ ?J:.   .:^!?J!   ^^   !J?!^:.   .:J? JY                ~#!!:~^.:^^!&\r\n                                    #7:^~!^^~^GY                 .B^J~           ~?  ~~  ?~           ~J^B.                 YG^~^^!~^:7#\r\n                                    JB:.:^!7!!B^                .7P::J:         .~5:    :5~.         :J::P7.                ^B!!7!^:.:BJ\r\n                                    .BJ^^^^~75&:              ^JY7.  .!~:   ..^~~!~ :~~: ~!!~^..   :~!.  .7YJ^              :&57~^^^^JB.\r\n                                     ^#!:^~~~?#!             !G~       ^!?7!!~::~: !J..J! :~::~!!7?!^       ~G!             !#?~~~^:!#^ \r\n                                      ^B?.^~~~5P             JP       .:::.   .:~ !J    J! ~:.   .:::.       PJ             P5~~~^.?B^  \r\n                                       .YP!:~!!BJ            .Y5~.  :~~!77!^.  . ?7  :   77 .  .^!77!~~:  .~5Y.            JB!!~:!PY.   \r\n                                         ~Y5?~!?BY.            ^JYJ7!!5G5?7Y?^. :5. ~Y7. .5: .^?Y7?5G5!!7JYJ^            .YB?!~?5Y~     \r\n                                           ^J5J??PG?^            .^!77: YJ..J?~. ^7?!.:~!7^ .~JJ..JY :77!^.            ^?GP??J5J^       \r\n                                             .^7JY5GBG5?~^.              G! !7!?!~^~^^:~~^~!?!7! !G              .^~?5GBG5YJ7^.         \r\n                                                 .:^~7??7~:              ~G ^J!: ^:?:7?:7:^ :!J^ G~              :~7??7~^:.             \r\n                                                                          P^ 5??!^ : .: : ^!??5 ^P                                      \r\n                                                                          J7 J?^^?!5!:^!5!?^^?J 7J                                      \r\n                                                                          7J::7J7:^!~^^~!^:7J7::J7                                      \r\n                                                                          7Y^  .7??7?77?7??7.  ^57                                      \r\n                                                                          .^7??!^:::~^^~:::^!??7^.                                      \r\n                                                                              :~??7^    ^7??~:                                          \r\n                                                                                 .!?7777?!.     \r\n\r\n\r\n                                        1) START\r\n                                        2) START\r\n                                        3) QUIT                                                ");
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
            string startstory = "You wake up groggy, sunlight streaming through the gaps in your blinds. It's a Saturday, or at least it should be.\n" +
                "you stretch and glance at the clock—it's later than you intended to sleep. Something feels off, though.\n" +
                "The usual hum of your neighborhood is conspicuously absent. No cars rumbling down the street, no distant chatter.\n" +
                "As you get out of bed, you hear nothing but the faint creak of floorboards. You peer out the window and are\n" +
                "met with an unsettling sight: empty streets. Abandoned cars are scattered around, their doors ajar.\n" +
                "A few people are wandering aimlessly, but they move in a slow, disjointed manner that doesn’t fit with the usual hustle of a weekend morning.\n" +
                "Confusion turns to concern. You step outside, the air feels thick, almost oppressive. The eerie silence is punctuated by distant,\n" +
                "unsettling noises—muffled cries, distant groans. You quickly realize the gravity of the situation. \n" +
                "Your neighborhood, once bustling with life, is now a ghost town.\n" +
                "Your heart races as you try to piece together what’s happened. This isn’t some elaborate prank or a temporary power outage;\n" +
                "something serious has occurred.\n" +
                "You need to understand this new reality and figure out how to protect yourself and find any other survivors.\n";
            PrintOneByOne(startstory);
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
                      //  east();
                        break;
                    case "west":
                      //  west();
                        break;
                    case "convenience":
                      //  Conve();
                        break;
                    case "pharmacy":
                       // Pharmacy();
                        break;
                    case "factory":
                       // factory();
                        break;
                    case "town hall":
                        TownHall();
                        break;
                    case "extendedSouth":
                      //  extendedSouth();
                        break;
                    case "left":
                     //   Left();
                        break;
                    case "right":
                      //  Right();
                        break;
                    case "school":
                      //  School();
                        break;
                    case "insideSchool":
                      //  insideSchool();
                        break;
                    case "schoolLeft":
                      //  schoolLeft();
                        break;
                    case "schoolRight":
                      //  schoolRight();
                        break;
                    case "beach":
                      //  Beach();
                        break;
                    case "forest":
                      //  Forest();
                        break;
                    case "north of forest":
                     //   fnorth();
                        break;
                    case "south of forest":
                      //  fsouth();
                        break;
                    case "east of forest":
                     //   feast();
                        break;
                    case "church":
                        Church();
                        break;
                    case "eastern house":
                     //   EastHouse();
                        break;
                    case "insideAbandoned":
                     //   insideAbandoned();
                        break;
                    case "park":
                      //  Park();
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

            Console.WriteLine("\nYou are in your room");
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
        static void South()
        {
            Console.Clear();
            //Items available in the room
            string[] SouthItems = new string[] { "Drugs" };
            //Display health
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            string outstory = "As you step outside, the reality of the situation starts to sink in." +
                "You notice of few people wandering aimlessly, their movements sluggish and unnatural," +
                "they are not reacting to you or to each other their eyes glazed over.Instinctively," +
                "you back away, trying to make sense of the scene before you";

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
                        Console.WriteLine("'add drugs' - to add drugs to inventory");
                        Console.WriteLine("'drop drugs' - to drop drugs from inventory");

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
        static void extendedSouth()
        {
            Console.Clear();

            //Items available
            string[] extendedSouthItems = new string[0];

            // Display the player's current health
            Console.ForegroundColor = ConsoleColor.Green;  
            Console.WriteLine("Health: " + health);
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
            Console.ForegroundColor = ConsoleColor.Blue;
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