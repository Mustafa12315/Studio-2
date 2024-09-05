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
        public static string userName;
        private static string instructions = string.Empty;
        private static string choice = string.Empty;
        private static string currentLocation = "house";
        public static int houseid = 0, outsideid = 0, extendedsouthid = 0, leftid = 0, schoolid = 0, insideid = 0, schoolrightid = 0, schoolleftid = 0, rightid = 0, beachid = 0, eastid = 0;
        public static int easthouseid = 0, insideaban = 0, parkid = 0, westid = 0, factoryid = 0, conveid = 0, pharmacyid = 0, townhallid = 0, forestid = 0, forestnorthid = 0, forestsouthid = 0, foresteastid = 0, churchid = 0;
        //global health variable by Samuel B 3/06/2024
        private static int health = 0;

        static void Main()
        {
            int ans;

                                                              //Ascii art start
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Put the window in full screen. \nPress enter....");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                       \r\n __      __  ___ ___ .___  ________________________________________  _________   ________  ___________   ______________ ______________   ________  ___________   _____  ________   \r\n/  \\    /  \\/   |   \\|   |/   _____/\\______   \\_   _____/\\______   \\/   _____/   \\_____  \\ \\_   _____/   \\__    ___/   |   \\_   _____/   \\______ \\ \\_   _____/  /  _  \\ \\______ \\  \r\n\\   \\/\\/   /    ~    \\   |\\_____  \\  |     ___/|    __)_  |       _/\\_____  \\     /   |   \\ |    __)       |    | /    ~    \\    __)_     |    |  \\ |    __)_  /  /_\\  \\ |    |  \\ \r\n");
            Thread.Sleep(300);
            Console.Write(" \\        /\\    Y    /   |/        \\ |    |    |        \\ |    |   \\/        \\   /    |    \\|     \\        |    | \\    Y    /        \\    |    `   \\|        \\/    |    \\|    `   \\\r\n  \\__/\\  /  \\___|_  /|___/_______  / |____|   /_______  / |____|_  /_______  /   \\_______  /\\___  /        |____|  \\___|_  /_______  /   /_______  /_______  /\\____|__  /_______  /\r\n       \\/         \\/             \\/                   \\/         \\/        \\/            \\/     \\/                       \\/        \\/            \\/        \\/         \\/        \\/ \r\n");
            Thread.Sleep(300);
            Console.Write("\r\n\r\n\r\n\r\n\r\n                                                   .^!?YJJYPJJPJ5YJYJ7^.                            .^7JYJY5JPJJPYJJY?!^.               \r\n                                                :!J5Y!~~~. :~ ^^.~ ^!7J5J~   :^!7??????????7!^:   ~J5J7!^ ~.^^ ~: .~~~!Y5J!:            \r\n                                             :?Y5J^.:^  .!  !.:! !  ! ^:755Y5?~~^:........:^~~?5Y557:^ !  ! !:.!  !.  ^:.^J5Y?:         \r\n                                           ~557. .~: ~^  7. 7.~^.! :!.~.~~:5!7                7!5:~~.~.!: !.^~.7 .7  ^~ :~. .755~       \r\n");
            Thread.Sleep(300);
            Console.Write("                                         ~5J:..~: .! .!  7 .7.7 !: 7.~.~:!.P..                ..P.!:~.~.7 :! 7.7. 7  !. !. :~..:J5~     \r\n                                       .Y5~:^.  !: ~^ 7 :! 7:!.~^.7:^:^^^^J7                   7J^^^^:^:7.^~.!:7 !: 7.^~ :!  .^:~5Y.   \r\n                                      :GJ:. .!: .7 ^!.7 7.!~~:~:.!^^^~^^!J7                      7J!^^~^^^!.:~:~~!.7 7.!^ 7. :!. .:JG:  \r\n                                     :B! .:~. 7: 7.^~~^!7YYY?5???7~^~^~?Y^                        ^Y?~^~^~7???5?YYY7!^~~^.7 :7 .~:. !B: \r\n                                     GY:^. .!:.7 !.!!5YY?!^^::^~75G7~7J!.                          .!J7~7G57~^::^^!?YY5!!.! 7.:!. .^:YG \r\n");
            Thread.Sleep(300);
            Console.Write("                                    7G. .~~ .7 7.!7GY!.          J&Y!~.                              .~!Y&J          .!YG7!.7 7. ~~. .G7\r\n                                    BY^^^ :!.^~~~P5:             P~:.   ...                      ...   .:~P             :5P~~~^.!: ^^^YB\r\n                                    &~  :!^.7.!?#!               P^  ^!!!77??7~^.          .^~7??77!!!^  ^P               !#?!.7.^!:  ~&\r\n                                    &!^^:.^~:!!#~                YJ ?J:.   .:^!?J!   ^^   !J?!^:.   .:J? JY                ~#!!:~^.:^^!&\r\n                                    #7:^~!^^~^GY                 .B^J~           ~?  ~~  ?~           ~J^B.                 YG^~^^!~^:7#\r\n                                    JB:.:^!7!!B^                .7P::J:         .~5:    :5~.         :J::P7.                ^B!!7!^:.:BJ\r\n                                    .BJ^^^^~75&:              ^JY7.  .!~:   ..^~~!~ :~~: ~!!~^..   :~!.  .7YJ^              :&57~^^^^JB.\r\n");
            Thread.Sleep(300);
            Console.Write("                                     ^#!:^~~~?#!             !G~       ^!?7!!~::~: !J..J! :~::~!!7?!^       ~G!             !#?~~~^:!#^ \r\n                                      ^B?.^~~~5P             JP       .:::.   .:~ !J    J! ~:.   .:::.       PJ             P5~~~^.?B^  \r\n                                       .YP!:~!!BJ            .Y5~.  :~~!77!^.  . ?7  :   77 .  .^!77!~~:  .~5Y.            JB!!~:!PY.   \r\n                                         ~Y5?~!?BY.            ^JYJ7!!5G5?7Y?^. :5. ~Y7. .5: .^?Y7?5G5!!7JYJ^            .YB?!~?5Y~     \r\n                                           ^J5J??PG?^            .^!77: YJ..J?~. ^7?!.:~!7^ .~JJ..JY :77!^.            ^?GP??J5J^       \r\n                                             .^7JY5GBG5?~^.              G! !7!?!~^~^^:~~^~!?!7! !G              .^~?5GBG5YJ7^.         \r\n                                                 .:^~7??7~:              ~G ^J!: ^:?:7?:7:^ :!J^ G~              :~7??7~^:.             \r\n");
            Thread.Sleep(300);
            Console.Write("                                                                          P^ 5??!^ : .: : ^!??5 ^P                                      \r\n                                                                          J7 J?^^?!5!:^!5!?^^?J 7J                                      \r\n                                                                          7J::7J7:^!~^^~!^:7J7::J7                                      \r\n                                                                          7Y^  .7??7?77?7??7.  ^57                                      \r\n                                                                          .^7??!^:::~^^~:::^!??7^.                                      \r\n                                                                              :~??7^    ^7??~:                                          \r\n                                                                                 .!?7777?!.     \r\n");
            Thread.Sleep(300);
            Console.Write("\r\n\r\n                                        1) START\r\n                                        2) QUIT    ");
            Thread.Sleep(300);
            Console.ResetColor();
                                                              //Ascii art start

            bool falseinput; //this bool is to confirm if there is any invalid input in the loop below
            do
            {
                Console.Write("\n\nEnter your input > ");
                ans = Convert.ToInt32(Console.ReadLine());

                switch (ans)
                {

                    case 1:
                        falseinput = false;
                        bool inputOverviewLoop=false; //this bool is to confirm if there is any invalid input in the loop below
                        do
                        {
                            Console.WriteLine("do you need the overview of game? (yes/no)");
                            string userinput = Console.ReadLine();
                            if (userinput.ToLower().Contains('y'))
                            {
                                string combinedText = "In a world overrun by the Undead, survival is paramount.\n" +
                                                          "Welcome to [Whispers of the Dead].\n" +
                                                          "Where every shadow could conceal a lurking horror and every step could lead to your doom.\n" +
                                                          "As civilization crumbles, you must navigate through the chaos, scavenging for resources, fortifying shelters.\n" +
                                                          "But beware, for the infected hordes are relentless, driven by an insatiable hunger for flesh.\n" +
                                                          "Will you muster the courage to fight back, or will you join the ranks of the walking dead?\n" +
                                                          "The choices are yours in this heart-pounding journey through the apocalypse.";

                                PrintOneByOne(combinedText);
                            }
                            else if (userinput.ToLower().Contains('n'))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("invalid input");
                                inputOverviewLoop = true;
                            }
                        } while (inputOverviewLoop==true);

                        break;

                    case 2:
                        falseinput = false;
                        break;
                    case 3:
                        falseinput = false;
                        Quit();
                        break;

                        default: 
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Invalid input.");
                        Console.ResetColor();
                        falseinput = true;
                        break;
                }
            }while(falseinput==true);

            currentLocation = "input";

            Console.Clear();
            Thread.Sleep(300);
           
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
                    case "outside":
                        Outside();
                        break;
                    case "east":
                        east();
                        break;
                    case "west":
                        west();
                        break;
                    case "convenience store":
                        Conve();
                        break;
                    case "pharmacy":
                        Pharmacy("Shotgun", Inventory);
                        break;
                    case "factory":
                        //factory();
                        break;
                    case "town hall":
                        TownHall("Key", Inventory);
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
                        schoolLeft("Shotgun", Inventory);
                        break;
                    case "schoolRight":
                        schoolRight();
                        break;
                    case "beach":
                        Beach("Chocolate Bar", Inventory);
                        break;
                    case "forest":
                        Forest();
                        break;
                    case "north of forest":
                      //  fnorth();
                        break;
                    case "south of forest":
                       // fsouth();
                        break;
                    case "east of forest":
                        feast();
                        break;
                    case "church":
                        Church("painkiller", Inventory);
                        break;
                    case "eastern house":
                        EastHouse();
                        break;
                    case "insideAbandoned":
                        insideAbandoned("shotgun", Inventory);
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
        static void Input()
        {
            health = 100;

            bool invalidIntroChoice = false;
            do
            {
                Console.Write("Would you like instructions?: ");
                choice = Console.ReadLine();

                if (choice.ToLower().Contains('y'))
                {

                    instructions = Instructions(instructions);
                    Console.WriteLine(instructions);

                }
                else if (choice.ToLower().Contains('n'))
                {
                    Console.WriteLine("Press enter to continue...");
                }
                else
                {
                    invalidIntroChoice = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please type 'yes' or 'no'");
                    Console.ResetColor();
                }
            } while (invalidIntroChoice==true);

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Press Enter to continue.....");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Please enter your name.....");
            userName = Console.ReadLine();

            string b = $"Cool {userName} Let's Start the game.";
            Thread.Sleep(2000);
            Console.Clear() ;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press Enter to continue.....");
            Console.ResetColor();
            Console.ReadLine();

            House();

        }
        static void House()
        {
            Console.Clear();
            string[] houseItems = new string[] { "Shotgun", "Bulletproof Vest"};
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            if (houseid == 0)
            {
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
                                    "\n" +
                                    "                                         SOMETHING SERIOUS HAS OCCURRED\n" +
                                    "\n" +
                                    "You need to understand this new reality and figure out how to protect yourself and find any other survivors.\n";
                PrintOneByOne(startstory);
            }
            else
            {
                Console.WriteLine("You are Back to your room");
            }
            houseid = houseid + 1;
            do
            {

                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.Write("You see the shotgun in the gun rack,");
                        Console.Write("You hear the sound of water dripping");
                        Console.Write("And the cupboard door creaking and a vest inside");
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "outside":
                        //Leave empty
                        break;
                    case "add shotgun":
                        HandleAddItem("Shotgun", ref houseItems);
                        break;
                    case "drop shotgun":
                        HandleDropItem("Shotgun", ref houseItems);
                        break;
                    case "add bulletproof vest":
                        HandleAddItem("Bulletproof Vest", ref houseItems);
                        break;
                    case "drop bulletproof vest":
                        HandleDropItem("Bulletproof Vest", ref houseItems);
                        break;
                    case "?":
                    case "help":
                        Help();
                        Console.WriteLine("'outside' - to navigate and proceed outside the house ");
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
            } while (choice != "outside");

            currentLocation = "outside";
        }


        static void Outside()
        {
            Console.Clear();
            string[] SouthItems = new string[] { "Drugs" };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            if (outsideid == 0)
            {
                string outstory = "As you step outside, the reality of the situation starts to sink in. " +
                                  "You notice of few people wandering aimlessly, their movements sluggish and unnatural,\n" +
                                  "they are not reacting to you or to each other their eyes glazed over.Instinctively," +
                                  "you back away, trying to make sense of the scene before you";
                PrintOneByOne(outstory);

            }
            else
            {
                Console.WriteLine("You are outside of your house");
            }
            outsideid = outsideid + 1;

            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                Console.WriteLine("");
                switch (choice)
                {
                    case "look around":
                        Console.Write("You see some drugs hidden behind the garbage bin,");
                        Console.Write("You hear the sound of police siren");
                        break;
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
            string[] extendedSouthItems = new string[0];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            if (extendedsouthid == 0)
            {
                string southstory = "\nYou find yourself standing at the edge of a quiet street, shrouded in the soft glow "+
                "of the evening sun. The street is named \"Crescent Way\", but locals refer to it"+
                "simply as \"The Forgotten Path.\" The air is thick with mystery, and each house along "+
                "the road seems to whisper tales of its own.";
                PrintOneByOne(southstory);
            }
            else
            {
                Console.WriteLine("You are back to the Crescent street");
            }
            extendedsouthid = extendedsouthid + 1;
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "look around":
                        Console.Write("You see the wrecked ambulance crashed into a police car\nAnd 2 ways ahead.");
                        break;
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
                    currentLocation = "outside";
                    break;
            }
        }
        static void Left()
        {
            Console.Clear();

            string[] leftItems = new string[0];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            if (leftid == 0)
            {
                string onwaySchool = "You see a board fallen 'The School is Safe' and become a bit curious and impatient";
                PrintOneByOne(onwaySchool);
            }
            else
            {
                Console.WriteLine("This path leads to the school");
            }
            leftid = leftid + 1;

            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.WriteLine("You see a board which says 'The School is S#f3'");
                        break;
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
                    case "back":
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
            } while (choice != "yes" && choice!= "back");
            switch (choice)
            {
                case "yes":
                    currentLocation = "school";
                    break;
                case "back":
                    currentLocation = "extendedSouth";
                    break;
                
            }

        }
        static void School()
        {
            Console.Clear();
            string[] schoolItems = new string[0];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();

            if (schoolid == 0)
            {
                Console.WriteLine("You hear a gunshot sound from the school building");
                Console.WriteLine("Do you want to proceed?");
            }
            else
            {
                Console.WriteLine("You are in the front-gate of the school");
            }
            schoolid = schoolid + 1;
            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.WriteLine("Yous see a puddle of blood in-front of the school front gate add some bullet shelsl");
                        break;
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
            string[] iSchoolItems = new string[0];
            // Display the player's current health
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();

            if (insideid == 0)
            {
                Console.WriteLine("You are inside the School building.");
                Console.WriteLine("YOU HEAR A VOICE SCREAMING");
            }
            else
            {
                Console.WriteLine("You are back to the school reception");
            }
            insideid = insideid + 1;

            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.WriteLine("You see a human skull and dirty school uniform in the ground");
                        break;
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
            string[] rightSchoolItems = new string[] { "Book" };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor(); 

            if (schoolrightid == 0)
            {
                string  temp = "You are inside the Staff room.";
                PrintOneByOne(temp);
            }
            else
            {
                Console.WriteLine("You are back to the Staff room");
            }
            schoolrightid = schoolrightid + 1;

            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        string books = "You see bloody papers covering the floor" +
                                       "and some untouched book in the shelf";
                        PrintOneByOne(books);
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "back":
                        break;
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
                    currentLocation = "insideSchool";
                    break;
            }
        }
        static void schoolLeft(string item, string[] inventory)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            string[] schoolLeftItem = new string[0];
            bool shotgunInSchool = Array.Exists(Inventory, i => i == item);
            if (schoolleftid == 0)
            { 
                if (shotgunInSchool)
                {
                    Console.WriteLine("You have entered the Classroom\nA Zombie jumps out at you, in a panicked state you reach for your weapon...");
                    Thread.Sleep(2000);
                    schoolleftid = schoolleftid + 1; 
                    fight();
                }
                else
                {
                    bool ContinueMethod = true;
                    Console.WriteLine("You have entered the Classroom\nA Zombie jumps out at you, in a panicked state you reach for your weapon...");
                    Thread.Sleep(2000);
                    Console.WriteLine("you reach for a random book off the book shelf and throw");
                    Thread.Sleep(2000);
                    Console.WriteLine("It has no effect against the undead menace, the zombie rips you to shreds, you perish.");
                    Thread.Sleep(2000);
                    health -= 100;
                    Health(ref health, ref ContinueMethod);
                }
            }
            else
            {
                Console.WriteLine("You are back to the classroom");
               
            }
            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.Write("You see the dead zombie you killed");
                        break;
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
                        Console.WriteLine("'back' - to navigate and proceed back to the school lobby");
                        break;
                    case "items":
                        ViewItems(schoolLeftItem);
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
            } while (choice != "back" && choice != "yes");
            switch (choice)
            {
                case "back":
                    currentLocation = "insideSchool";
                    break;
            }


        }

        static void Right()
        {
            Console.Clear();
            string[] rightSchoolItems = new string[0];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor(); 

            if (rightid == 0)
            {
            Console.WriteLine("You are heading towards the Beach.\nWould you like to proceed?");
            }
            else
            {
                Console.WriteLine("This path lead to the beach");
            }
            rightid = rightid + 1;

            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.Write("You see a body covered with sea weed and a cross mark painted on the body");
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "back":
                    case "yes":
                        break;
                    case "help":
                    case "?":
                        Help();
                        Console.WriteLine("'back' - to navigate and proceed back to the  lobby ");
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
            } while (choice != "back" && choice != "yes");

            switch (choice)
            {
                case "back":
                    currentLocation = "extendedSouth";
                    break;
                case "yes":
                    currentLocation = "beach";
                    break;
            }
        }
        static void Beach(string item, string[] inventory)
        { 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            string[] beachItems = new string[] {"seaweed"};
            bool ChocolateInBeach = Array.Exists(inventory, i => i == item);
            if (beachid == 0)
            {
                if (ChocolateInBeach)
                {
                    string sea= "You are in the beach and take some fresh air as you see a group of Sea-leopard\n"+
                             "You take the chocolate bar from your pocket and give it to the sea leopards\n";
                    PrintOneByOne(sea);
                    HandleDropItem("Chocolate Bar", ref beachItems);
                    beachid = beachid + 1;
                    Thread.Sleep(1000);
                        string seazombie ="You see a herd of\nA Zombie jumps out at you, in a panicked state you reach for your weapon...\n"+
                                          "Before you know it the group of Sea-leopards\n"+
                                          "bites the zombies to shreds\n";
                        PrintOneByOne(seazombie);
                    Console.WriteLine("You take a bath in the waters...");

                }
                else
                {
                    bool ContinueMethod = true;
                    string deathbeach = "You are in the beach and take some fresh air and see some Sea-Leopard\n" +
                                        "You ignore them and walk forward towards the waters\n" +
                                        "You sense some shadows behind you\n" +
                                        "as you turn you tumble down in-front of the group of Sea-Leopards\n" +
                                        "And get torn into shreds of meat";
                    PrintOneByOne(deathbeach);
                    health -= 100;
                    Health(ref health, ref ContinueMethod);
                }
            }
            else
            {
                Console.WriteLine("You are back to the beach");
            }
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "look around":
                        Console.WriteLine("You see the nice sunrise across the sea");
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "back":
                        break;
                    case "items":
                        ViewItems(beachItems);
                        break;
                    case "help":
                    case "?":
                        Help();
                        Console.WriteLine("'back' - to navigate and proceed to the beach path");
                        break;
                    case "location":
                        Console.WriteLine("You are currently in the beach");
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
                    currentLocation = "right";
                    break;

            }

        }


        static void east()
        {
            Console.Clear();
            string[] eastItems = new string[0];
            if (eastid == 0)
            {
                string eaststory = "As you walk east you find yourself to a once lively and most crowded place of the town" +
                                   "named as the 'Joy street'"+
                                   "now abandoned and destroyed..."+
                                   "park which is not green anymore, houses and church abandoned"+
                                   "and the forest which shows no sign of life";
                PrintOneByOne(eaststory);

            }
            else
            {
                Console.WriteLine("You arre back to the 'Joy street'");
            }
            eastid = eastid + 1;
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "look around":
                        Console.WriteLine("You see a fallen ice cream truck and find youself mesmerizing about the past");
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
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
                        currentLocation = "outside";
                        break;
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
        }

        static void EastHouse()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();

                string abanstory = "As you approach the abandoned house you get a eerie feeling" +
                                   "which is not the same as the one you have encountered yet" +
                                   "You get hesitant for a moment" +
                                   "and think again if you want to check the house";
                PrintOneByOne(abanstory);


            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        //Add
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "enter":
                    case "back":
                        break;
                    case "help":
                        break;
                    case "?":
                        Help();
                        Console.WriteLine("'enter' - to gain access to into the room");
                        break;
                    case "location":
                        Console.WriteLine("You are within a house that is stationed in the east");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe path you seek does not exist in this forsaken place. \nChoose wisely, for each misstep might be your last. Dare to try again, and may the shadows guide you.");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(1500);

            } while (choice != "back" && choice != "enter");

            switch (choice)
            {
                case "back":
                    currentLocation = "east";
                    break;
                case "enter":
                    currentLocation = "insideAbandoned";
                    break;
            }
        }

        static void insideAbandoned(string item, string[] inventory)
        {
            bool ContinueMethod = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            string[] abanItems = new string[0];
            bool shotgunInInvenvo = Array.Exists(Inventory, i=> i == item);
            if (insideaban == 0)
            {
                string insideabadn = "You enter the abandoned house mustering your courage to seek the mystery\n" +
                                     "behind the house as you open the door of the kitchen you see a machete which is rusted because of blood\n" +
                                     "you a body behind the cupboard and try not to make any sound as you approach it\n" +
                                     "you kicked a bucket which flew right at the door\n" +
                                     "panicking you walk back out of the house and you see a scene never thought of\n" +
                                     "a mutated zombie with 2 heads";
                PrintOneByOne(insideabadn);
                fight();
            }
            else
            {
                Console.WriteLine("You are back inside the abandoned building");
            }

            insideaban = insideaban + 1;
            do
            {
                Console.WriteLine("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.Write("You see the dead zombie you killed");
                        break;
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
                        Console.WriteLine("'back' - to navigate and proceed out of the abandoned house");
                        break;
                    case "items":
                        ViewItems(abanItems);
                        break;
                    case "location":
                        Console.WriteLine("You are inside the abandoned house");
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
                    currentLocation = "eastern house";
                    break;
            }


        }

        static void Park()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            string[] parkItems = new string[] {"Flowers"};
            if (parkid == 0)
            {
                string parkstory= "As you walk through the park, the wind softly tousling your hair \nand the sunlight warming your face, you feel a deep sense of contentment.";
                PrintOneByOne(parkstory);
            }
            else
            {

                Console.WriteLine("You are back to the park");
            }
            parkid = parkid + 1;  
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {

                    case "look around":
                        Console.WriteLine("You see some beautiful flowers and wind gusting through");
                        break;
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
                    case "add flower":
                        HandleAddItem("Flowers", ref parkItems);
                        break;
                    case "drop book":
                        HandleDropItem("Flowers", ref parkItems);
                        break;
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
        static void west()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();

            string[] westItems = new string[0];

            if (westid == 0)
            {

                string weststory = "You have gone west. The sun begins to set, casting long shadows over the rugged landscape.\n"+
                "The path ahead is overgrown, hinting at long-forgotten secrets waiting to be uncovered.\n"+
                "The air is cool, and the sound of rustling leaves fills your ears. In the distance, you notice an old, abandoned cabin.\n"+
                "The path ahead is overgrown, hinting at long-forgotten secrets waiting to be uncovered.\n";
                PrintOneByOne(weststory);
            }
            else
            {
                Console.WriteLine("You are back to the west");
            }
            westid = westid + 1;
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {

                    case "look around":
                        Console.WriteLine("You hears voices screen and have the urge to rush things and seek safety"); 
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "convenience store":
                    case "pharmacy":
                    case "factory":
                    case "back":
                    case "town hall":
                        break;
                    case "help":
                    case "?":
                        Help();
                        Console.WriteLine("'convenience store' - to navigate and proceed to a nearby convenience store ");
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
            } while (choice != "convenience store" && choice != "pharmacy" && choice != "factory" && choice != "back" && choice != "town hall");
            switch (choice)
            {
                case "convenience store":
                    currentLocation = "convenience store";
                    break;
                case "pharmacy":
                    currentLocation = "pharmacy";
                    break;
                case "factory":
                    currentLocation = "factory";
                    break;
                case "back":
                    currentLocation = "outside";
                    break;
                case "town hall":
                    currentLocation = "town hall";
                    break;
            }

        }
        //Factory Denomination Vote..
        /*
        static void factory()
        {
            bool ContinueMethod = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();

            if (factoryid == 0)
            {

            }
            else
            {

            }
            factoryid = factoryid + 1;


            health -= 150;
            Health(ref health, ref ContinueMethod);

        }
        //Created Convenience store, Pharmacy and Town Hall methods
        */
        static void Conve()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();

            //Local Items Array to the Inventory
            string[] conveItems = new string[] { "Water", "Chocolate Bar", "Gloves" };
            if (conveid == 0)
            {
            string combinedText = "You have stepped into the dead convenience store, the door creaking as it opened.\n" +
                 "The air was thick with dust, and the once-bright fluorescent lights flickered dimly.\n" +
                 "Shelves were bare or toppled, their contents scattered on the floor.\n" +
                 "A faint smell of stale air and decay hung in the atmosphere.\n" +
                 "The store, once bustling with life, now stood eerily silent, a forgotten relic of the past.\n";
            PrintOneByOne(combinedText);
            }
            else
            {
                Console.WriteLine("You are back ton the Convenience store");
            }
            conveid = conveid + 1;


            Console.WriteLine("Look Around?");
            Console.WriteLine("Exit");
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.WriteLine("You see instant and canned food all over the floor most of them crushed, with a little things remaining intact");
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
        static void Pharmacy(string item, string[] inventory)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            if (pharmacyid == 0)
            {

            }
            else
            {

            }
            string[] pharmacyItems = new string[] { "painkiller", "Bandages" };
            bool shotgunInPharmacy = Array.Exists(inventory, i => i == item);
            if (shotgunInPharmacy)
            {
                if (pharmacyid <= 0) { pharmacyid = pharmacyid + 1; Console.WriteLine("You have entered the Pharmacy\nA Zombie jumps out at you, in a panicked state you reach for your weapon..."); Thread.Sleep(2000); fight(); }
                else { }
            }
            else
            {
                if (pharmacyid <= 0)
                {
                    bool ContinueMethod = true;
                    Console.WriteLine("You have entered the Pharmacy\nA Zombie jumps out at you, in a panicked state you reach for your weapon...");
                    Thread.Sleep(2000);
                    Console.WriteLine("you reach for a random box of medicine off the pharmacy shelf...");
                    Thread.Sleep(2000);
                    Console.WriteLine("It has no effect against the undead menace, the zombie rips you to shreds, you perish.");
                    Thread.Sleep(2000);
                    health -= 100;
                    Health(ref health, ref ContinueMethod);
                }
                else { }
            }
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {

                    case "look around":
                        Console.WriteLine("You see pills all over the place and bandage rolls all over the counter area..");
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "add painkiller":
                        HandleAddItem("painkiller", ref pharmacyItems);
                        break;
                    case "drop painkiller":
                        HandleDropItem("painkiller", ref pharmacyItems);
                        break;
                    case "add bandages":
                        HandleAddItem("Bandages", ref pharmacyItems);
                        break;
                    case "drop bandages":
                        HandleDropItem("Bandages", ref pharmacyItems);
                        break;
                    case "use bandages":
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

        static void TownHall(string item, string[] inventory)
        {

            bool ContinueMethod=true;
            Console.Clear();
            bool keyInTownHall = Array.Exists(Inventory, i => i == item);
            Console.ForegroundColor = ConsoleColor.Green;
  
            Console.WriteLine("Health: " + health);
          
            Console.ResetColor();
            string[] townHallItems = new string[0];
            Console.WriteLine("You are outside the Town Hall.");

            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {

                    case "look around":
                        //Add
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "enter":

                        if (keyInTownHall)
                        {
                            string a = "You're in TownHall";
                            PrintOneByOne(a);
                            Thread.Sleep(200);
                            string b = "“HEY, WATCH OUT! \nLAY DOWN ON THE GROUND AND PUT YOUR HANDS ON YOUR BACK!”";
                            PrintOneByOne(b);
                            Thread.Sleep(200);
                            string c = $"Are you infected with the virus?";
                            PrintOneByOne(c);

                            string isthatyou=Console.ReadLine();
                          
                            if (isthatyou.Contains('y'))
                            {
                                string z = "BANG!!!!!!";
                                health -= 100;
                                Health(ref health, ref ContinueMethod);
                            }
                            else if (isthatyou.Contains('n'))
                            {
                                ending();
                            }
                            else
                            {
                                Console.WriteLine("invalid input.");
                            }

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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            string[] forestItems = new string[0];
            if (forestid == 0)
            {
                string foreststory = "You are wondering through the forest\n" +
                                     "You smell thick stench of blood and dried blood almost everywhere\n" +
                                     "You see scratches and gun shots holes made in the tree barks and a huge dead bear";
                PrintOneByOne(foreststory);
            }
            else
            {
                Console.WriteLine("You are back to the forest");
            }
            forestid = forestid + 1;
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        Console.WriteLine("You see the huge dead body of a bear and a lot of insects near it");
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
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
            } while (choice != "east" && choice != "back");
            switch (choice)
            {
                case "east":
                    currentLocation = "east of forest";
                    break;
                case "back":
                    currentLocation = "east";
                    break;
            }

        }

        static void feast()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            string[] feastItems = new string[] { "Radio" };
            if (foresteastid == 0)
            {

            }
            else
            {

            }
            foresteastid = foresteastid + 1;
            Console.WriteLine("\nYou have walked into the east of the forest and have you have found a Non-Functioning Radio");


            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        //Add
                        break;
                    case "map":
                        map();
                        break;
                    case "inventory":
                        ShowInventory();
                        break;
                    case "add radio":
                        AddItemInv("Radio");
                        feastItems = RemoveItem(feastItems, "Radio");
                        break;
                    case "drop radio":
                        DropItemInv("Radio");
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

        static void Church(string item, string[] inventory)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            if (churchid == 0)
            {

            }
            else
            {

            }
            churchid = churchid + 1;
            string[] churchItem = new string[] { "Key" };
            int key = 0;
            Console.WriteLine("TEMPORARY\nPleae get us some painkillers to help soothe our pain, if you do this we will provide you with information you may find useful if you want to escape this wretched place.");
            bool painkillerInHouse = Array.Exists(inventory, i => i == item);
            if (painkillerInHouse)
            {

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

                Console.ForegroundColor = ConsoleColor.Red;
                PrintOneByOne(highlightedWord);
                Console.ResetColor();

                PrintOneByOne(TalkingPart2);
            }
            else
            {
                Console.WriteLine("TEMPORARY\nPlease press enter to continue");
                Console.ReadLine();
                east();
            }
            do
            {
                Console.Write("\nWhat's next? > ");
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "look around":
                        //Add
                        break;
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
























        //\-\-\-\-\\-\-\\-\-\\-\-\-\\-\-\-\\-\-\-\-\-below this line there are functions not locations-\-\-\-\-\\-\-\\-\-\\-\-\-\\-\-\-\\-\-\-\-\
















        static void ending()
        {
            string RightPin = "2622";
            string userinput;
          
            bool solved = false;
          
            string a = $"Ohh! No! i am not infected. its me {userName}. Is that you George (George used to work as a gardener in the town park)? \nGeorge: Yes it's me. \n I just wanted to confirm if " +
                $"you are infected or not don't mind but i have to check if you are saying truth. \n {userName}: Its ok you can.";
            PrintOneByOne(a);
            string b = "CHecking...................................................";
            PrintOneByOne(b);
            string c = $"George: you're fine. \nI got to know that it is the Evacuation point but on radio it says that we should contact army with the help of a telly device." +
                $"but its in the shireff's Room but there is a 4 Digit PIN on his door.\n{userName}: did you tried to break the door? \nGeorge: Yes but its very strong because its made" +
                $" up of metal.";
            PrintOneByOne(c);
            Console.WriteLine(" but in emergency file there is a weird thing which says.\n the code of the room is  is 'Z' 'V' But the lock on door is digits.\nyou should try it {userName}.");
            while (solved != true)
            {
                Console.WriteLine("\n\nEnter the code:");
                userinput = Console.ReadLine();
                if (userinput == RightPin)
                {
                  
                    solved = true;
                  
                }
                else
                {
                    Console.WriteLine("INCORRECT PIN!");
                }
            }

            string d = $"George:Awesome {userName} you did it. Luckily i know how to use telly i'll inform army.\n{userName}: Make sure to tell them that more people are stuck in church as well.";
            PrintOneByOne(d);

            int[] frequencies = { 800, 900, 1000, 1100, 1200 };
            int duration = 200;
            foreach (int freq in frequencies)
            {
                Console.Beep(freq, duration);
                Thread.Sleep(100);
            }
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(1200, duration + i * 100);
                Thread.Sleep(100);
            }
            Console.Beep(1500, 800);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  _____  .__              .__                  _________                                          _____     .__   \r\n  /     \\ |__| ______ _____|__| ____   ____    /   _____/__ __   ____  ____  ____   ______ _______/ ____\\_ __|  |  \r\n /  \\ /  \\|  |/  ___//  ___/  |/  _ \\ /    \\   \\_____  \\|  |  \\_/ ___\\/ ___\\/ __ \\ /  ___//  ___/\\   __\\  |  \\  |  \r\n/    Y    \\  |\\___ \\ \\___ \\|  (  <_> )   |  \\  /        \\  |  /\\  \\__\\  \\__\\  ___/ \\___ \\ \\___ \\  |  | |  |  /  |__\r\n\\____|__  /__/____  >____  >__|\\____/|___|  / /_______  /____/  \\___  >___  >___  >____  >____  > |__| |____/|____/\r\n        \\/        \\/     \\/               \\/          \\/            \\/    \\/    \\/     \\/     \\/                   ");
            Console.ResetColor();
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
        {       
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine(@"
                                                _________             _________________________________
                         ___________           |  House  |           |                                 |
|--------,              |Convenience|      ____|___   ___|_____      |                Park             |                          _____________
|        |________      |   Store   |     |    Front Yard      |     |                                 |                         |             |
|Pharmacy ________\     |___________|     |____________________|     |_________________________________|                         |   Abandoned |
|        |        \\          ||                    ||                                               ||                          |    House    |
|--------'         \\         ||                    ||                                               ||                          |_____________|
                    \\        ||                    ||                                               ||                         //
                     \\       ||                    ||                                               ||                        //
                      \\      ||                    ||                                               ||                       //
                       \\     ||                    ||                                               ||                      //
                        \\____/\____________________/\_______________________________________________/\_____________________//
                          ____  ______________________________  _____________________________________  _____________________ |
                        //    \/                              \/                                     \/                     \\
                       //     ||                              ||                                     ||                      \\
                      //      ||                              ||                                     ||                       \\ 
|---------------,    //       ||                             / \                                _____||_____                   \\
|               |   //        ||                            /   \                              |            |                   \\
|               |__//         ||                           /     \                             |            |                    \\ ⠀⠀ ⠀⠀⠀⠀⠀
|   Town Hall    __/          ||                          /       \                            |  Church    |                    ⠀\\        _⠀ ⠀
|               |        _____||____                     /         \                         __|            |__                            / \      _-'
|               |       |           |             ______|_____      \                       |                  |                ⠀ ⠀      _/|  \-''- _ /
|---------------'       |           |            |            |      __ _.--..--._ _        |__________________|              ⠀⠀    __-' { |          \
                        |  Factory  |            |            |   .-' _/   _/\_   \_'-.                                      ⠀⠀        /               \
                        |___________|       _____|            |  |__ /   _/\__/\_   \__|                                               /       ""o.  |o }
                                           |        School    |      |___/\_\__/  \___|                                                 |            \ ;
                                           |__________________|              \__/                                           Forest                    ',
                                                                            \__/    Beach                                                  \_       __ \
                                                                             \__/                                                          ''-_    \.//
                                                                          ____\__/___                                                         / '-____'
                                                                     . - '             ' -.                                                  /
                                                              ~~~~~~~  ~~~~~ ~~~~~  ~~~ ~~~  ~~~~~                                         _'     


                                                                                                                                                                    N
                                                                                                                                                                   / \
                                                                                                                                                                    | 
                                                                                                                                                                    |
                                                                                                                                                                    |
                                                                                                                                                                    |
                                                                                                                                                         W<------------------->E
                                                                                                                                                                    | 
                                                                                                                                                                    |
                                                                                                                                                                    |
                                                                                                                                                                    |
                                                                                                                                                                   \ /
                                                                                                                                                                    S
");
            Console.ResetColor();
        }
        
        static void PrintOneByOne(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(5); 
            }
            Console.ReadLine();
        }
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
        static string[] AddItem(string[] array, string itemToAdd)
        {
            //create new array
            string[] newArray = new string[array.Length + 1];
            Array.Copy(array, newArray, array.Length);
            newArray[newArray.Length - 1] = itemToAdd;
            return newArray;
        }


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
        static void HandleAddItem(string item, ref string[] houseItems)
        {
            //Booleans for testing if item is in house and inv
            bool itemnInLocation = Array.Exists(houseItems, i => i == item);
            bool itemInInventory = Array.Exists(Inventory, i => i == item);

            if (itemnInLocation && !itemInInventory)
            {
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
            Console.WriteLine("Quiting the game.");
            Console.ReadLine();
            Environment.Exit(0);
        }

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

        static void Health(ref int health, ref bool ContinueLoop)
        {
            // Check if health is greater than 0
            if (health > 0)
            {
                // Display current health
                Console.WriteLine($"Health is now {health}");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Health: " + health);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER");
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
        static void Afight()
        {
            bool ContinueMethod = true;
            int enemyHealth = 100;
            int playerHealth = 100;
            Random random = new Random();
            do
            {
                int runChance = random.Next(0, 2);
                int hitchance = random.Next(30,55);
                int nothit = random.Next(0,5);
                Console.WriteLine($"You have {playerHealth} health left");
                Console.WriteLine($"Mutated zombie has {enemyHealth} health left");
                Console.WriteLine("'attack' or 'run'");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "attack":
                        Console.WriteLine("You fire upon the Zombie..");
                        Thread.Sleep(1500);
                        if (nothit == 0)
                        {
                            Console.WriteLine("You have missed");
                        }
                        else
                        {
                            Console.WriteLine("You tear off chunks of flesh from the zombie");
                            enemyHealth = enemyHealth - hitchance;
                        }
                        break;
                    case "run":
                        Console.WriteLine("You attempt to flee");
                        if (runChance == 0)
                        {
                            Console.WriteLine("You were successful in running away");
                            Thread.Sleep(2000);
                            House();
                        }
                        if (runChance == 1)
                        {
                            Console.WriteLine("You were unsuccessful");
                            string deadHouse = "In a desperate sprint from the relentless zombie," +
    " the player's frantic steps faltered, tripping over unseen debris," +
    " sealing their fate in the cold grasp of the undead.";
                            PrintOneByOne(deadHouse);
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;

                }
                if (enemyHealth > 0)
                {
                    int enemyAtack = random.Next(30);
                    int enemyhit = random.Next(0, 5);
                    switch (enemyhit)
                    {
                        case 0:
                            Console.WriteLine("The zombie scraches you");
                            playerHealth = playerHealth - enemyAtack;
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                            Console.WriteLine("The zombie misses");
                            break;
                        default:
                            Console.WriteLine("Enemy attack isn't working");
                            break;
                    }
                }

            } while(enemyHealth <= 0 || playerHealth <= 0);
            if (playerHealth <= 0)
            {
                health -= 100;
                //Direct to the health method
                Health(ref health, ref ContinueMethod);
            }
            else if (enemyHealth <= 0)
            {
                Console.WriteLine("You killed the zombie");
                Console.WriteLine("Please click enter to continue");
                Console.ReadLine();
            }
        }



        static void fight()
        {
            bool Continueloop = true;
            int enemyHealth = 100;
            int playerHealth = 100;
            Random random = new Random();
            do
            {
                int runChance = random.Next(1);
                int damage = random.Next(65);
                Console.WriteLine("'attack' or 'run'");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "attack":
                        enemyHealth = enemyHealth - damage;
                        Console.WriteLine("You fire upon the Zombie...");
                        Thread.Sleep(2000);
                        Console.WriteLine("The shotgun shells tear off chunks of flesh from the Zombie");
                        Thread.Sleep(2000);
                        break;
                    case "run":
                        Console.WriteLine("You attempt to flee...");
                        Thread.Sleep(2000);
                        if (runChance == 1) { Console.WriteLine("You were successful MOVING BACK TO HOUSE, TEMPORARY"); Thread.Sleep(2000); House(); }
                        if (runChance == 0) { Console.WriteLine("You were unsuccessful"); Thread.Sleep(2000); }
                        break;
                }
                Console.WriteLine("The Zombie charges you!");
                Thread.Sleep(2000);
                int enemyAtkChance = random.Next(1);
                int enemyAtkDamage = random.Next(45);
                if (enemyAtkChance == 1)
                {
                    playerHealth = playerHealth - enemyAtkDamage;
                    Console.WriteLine("The Zombie's attack connects with your body!");
                    Thread.Sleep(2000);
                }
                Console.WriteLine($"You have {playerHealth} points of health left");
                Thread.Sleep(2000);
                if (playerHealth <= 0) { health = 0; Health(ref health, ref Continueloop); }
                Console.Clear();
            } while (enemyHealth >= 1);
            Console.WriteLine("You defeated the Zombie");
            Thread.Sleep(2000);
            if (pharmacyid == 1) { Pharmacy("Shotgun", Inventory); }
            else { Console.WriteLine("Fight code not working properly please close game"); Console.ReadLine(); }
            
        }

    }
}