using System;

namespace CombatCycle1 {
    class Program {
        public static bool dead = false;
        public static bool intro = true;
        public static int act = 0;
        public static int playerHP = 100;
        public static int spiderHP = 100;
        public static string youdid = null;
        public static int lucky = 3;


        public static string action() {
            
            switch(act) {
                case 1:
                    //attack
                    attack();
                break;
                case 2:
                    //flee
                    youdid = "You ran away! What a scaredy cat.";
                    dead = true;
                    break;
                case 3:
                    //dodge
                    dodge();
                    break;
            }
            return youdid;
        }
        public static void attack() {
            //random
            Random ran = new Random();
            int damageP = ran.Next(10, 25);
            int damageS = ran.Next(5, 50);
            int luck = ran.Next(1, lucky);

            if (luck != 1) spiderHP -= damageP;
            else playerHP -= damageS;
            if (playerHP <= 0) {

                dead = true;
                youdid = "Oh no you died, big L";

            } else if(spiderHP <= 0) {

                dead = true;
                youdid = "you killed the spider, big W";

            } else if (luck == 1) youdid = "The spider attacked you for " + damageS + "HP.";
            else youdid = "You attacked the spider for " + damageP + "HP.";
            

        }
        public static void dodge() {
            Random ran = new Random();

            int damageS = ran.Next(20, 40);

            int luck = ran.Next(1, lucky);

            if (luck != 1) lucky++;
            else playerHP -= damageS;
            //if player hp is less than 0 you dieee
            if (playerHP <= 0) {

                dead = true;
                youdid = "Oh no you fell over and died, what an idiot LOL" ;

            } else if (luck == 1) youdid = "You couldn't dodge that spiders attack! The spider deals " + damageS + "HP of damage.";
            else youdid = "You dodged the spider! close one!";
            

        }
        static void Main(string[] args) {
                game();
        }

        static void game() {
            while (dead == false) {
                spider();
            }
        }
        
        static void spider() {

            if (intro == true) {
                Console.WriteLine("There is an enemy spider! would you like to fight it? or flee (fight, flee)");
                
            } else {
                Console.Clear();
                Console.WriteLine(action());
                Console.WriteLine();

                if (dead == false) {
                                    
                    Console.WriteLine("Player HP: " +playerHP);
                    Console.WriteLine("Spider HP:" + spiderHP);
                    Console.WriteLine();
                    Console.WriteLine("Now would you like to attack, dodge or flee? (attack, dodge, flee)");
                }
            }
           

            bool returnError = true;
            while(returnError == true && dead == false) {
                returnError = false;
                Console.Write("input > ");
                string userInput = Console.ReadLine().ToLower();
                if (
                    userInput == "fight" ||
                    intro == false && userInput == "attack"
                ) act = 1;
                else if (userInput == "flee")   act = 2;
                else if (userInput == "dodge" && intro == false)  act = 3; 
                else { 
                    act = 0;
                    returnError = true;
                    //error messages
                    if(intro == true) Console.WriteLine("Hey! that's not a valid option, please choose from fight or flee.");
                    else Console.WriteLine("Hey! that's not a valid option, please choose from attack, dodge or flee");
                }
            }
            intro = false;

        }
    }
}