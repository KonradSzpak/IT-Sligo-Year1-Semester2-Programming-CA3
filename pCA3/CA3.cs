/*=======================

 * Name: Konrad Szpak

 * Student ID: S00197298
 
 * Date: 17-03-2020
 
 * Description: CA3, Use CTRL + 'scrol' to navigate around this easier
 
 "_________________ ..." seperates each method 

=========================*/




using System;
using System.IO;

namespace pCA3
{
    class CA3
    {

        //

        //each "input" method will output their results into these 3 arrays and next each array will be displayed with a for loop

        static string[] scoresText = new string[5] { "00000-9999", "10000-19999", "20000-29000", "30000-39999", "40000+" };
        static string[] locationText = new string[5] { "Europe", "Asia", "America", "South America", "Australia" }; //just output 


        static int[] numberOfPlayers = new int[5] { 0, 0, 0, 0, 0 }; //this is where number of players are inputed
        static string[] playerNames = new string[5];
        static int[] playerScores = new int[5];
        static int[] numberOfPlayersInLocations = new int[5] { 0, 0, 0, 0, 0 }; //this is where graph is 

        static string[] graph = new string[5] { "", "", "", "", "" }; //this is where graph is inputed





        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void Main(string[] args) //main method is used to choose ur choice
        {

            string again = "yes";
            int menuChoice;

            GetNumberOfPlayersInEachCathegory();
            GetPlayerScores();
            GetLocations();
            MakesGraphsCorrespondingToAmountOfPlayersInEachScoreCathegory();

            do
            {
                menuChoice = Menu();
                switch (menuChoice)
                {
                    case 1:
                        PlayerReportDisplay(); //displays results
                        again = Again(again);
                        break;
                    case 2:
                        LocationAnalysisReportDisplay(); //displays results
                        again = Again(again);
                        break;
                    case 3:
                        string name;
                        name = SearchForAPlayer(InputChoiceThree());
                        OutputChoiceThree(name);
                        again = Again(again);
                        break;

                    default: //breaks if something else than above
                        break;
                }
            }
            while (menuChoice != 4 && again == "yes" || again == "y");

        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //gets choice
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int Menu()
        {
            int menuChoice=0;

            bool isValid;

            //displays menu
            Console.Write("\n1. Player Report\n2. Location Analasis Report\n3. Search for a player\n4. Exit\n");
            do
            {
                try
                {

                    isValid = true;
                    Console.Write("\nEnter Choice : ");
                    menuChoice = int.Parse(Console.ReadLine()); //reads input of menu
                    
                    ValidateMenu(menuChoice);
                }
                catch (Exception)
                {

                    Console.Write("\nThats not a choice!\n");
                    
                    isValid = false;

                }





            }
            while (isValid == false);


            return menuChoice;
             //returnt choice

        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static double ValidateMenu(int menuChoice)
        {
            if (menuChoice > 4)
                throw new Exception();
            else
                return menuChoice;
        }


        //GETS INPUT PROM NOTEPAD FIRLD[0]
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void GetNumberOfPlayersInEachCathegory()
        {

            string[] secoundCharOfNotepadIntoString = new string[5];
            int[] secoundCharOfNotepadIntoStringIntoInt = new int[5];

            string[] fields = new string[4]; //this is where ',' slit goes in

            string lineIn; //this is where each line of notepad stuff will be stored 

            int i = 0;

            FileStream fs = new FileStream(@"C:\Users\konra\OneDrive - Institute of Technology Sligo\Modules\Year 1\Semester 2\Programming 2 sem2 yr1\pCA3\GameScores.txt", FileMode.Open, FileAccess.Read); //makes a connection with notepad

            StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

            lineIn = inputStream.ReadLine(); //reads line and goes to next line

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"

                if (int.Parse(fields[2]) >= 0 && int.Parse(fields[2]) <= 9999)
                {
                    numberOfPlayers[0] = int.Parse(fields[0].Substring(1)) + numberOfPlayers[0];  //.Subtracting removes the first char and then its parsed
                }
                else if (int.Parse(fields[2]) >= 10000 && int.Parse(fields[2]) <= 19999)
                {
                    numberOfPlayers[1] = int.Parse(fields[0].Substring(1)) + numberOfPlayers[1];
                }
                else if (int.Parse(fields[2]) >= 20000 && int.Parse(fields[2]) <= 29999)
                {
                    numberOfPlayers[2] = int.Parse(fields[0].Substring(1)) + numberOfPlayers[2];
                }
                else if (int.Parse(fields[2]) >= 30000 && int.Parse(fields[2]) <= 39999)
                {
                    numberOfPlayers[3] = int.Parse(fields[0].Substring(1)) + numberOfPlayers[3];
                }
                else
                {
                    numberOfPlayers[4] = int.Parse(fields[0].Substring(1)) + numberOfPlayers[4];
                }

                lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
                i++;
            }



            inputStream.Close(); //closes the notepad for other programs to use if needed
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //GETS INPUT PROM NOTEPAD FIRLDS[1]
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static string SearchForAPlayer(string name)
        {
            const string NO_PLAYER_FOUND = "No player was found";

            string[] fields = new string[4]; //this is where ',' slit goes in

            string lineIn; //this is where each line of notepad stuff will be stored 

            int i = 0; //this is just for putting each line of notepad to an array to store amount of players with a specific score

            FileStream fs = new FileStream(@"C:\Users\konra\OneDrive - Institute of Technology Sligo\Modules\Year 1\Semester 2\Programming 2 sem2 yr1\pCA3\GameScores.txt", FileMode.Open, FileAccess.Read); //makes a connection with notepad

            StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

            lineIn = inputStream.ReadLine(); //reads line and goes to next line

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"

                if (name == fields[1])
                {
                    switch (int.Parse(fields[3]))
                    {
                        case 1:
                            return locationText[0];

                        case 2:
                            return locationText[1];

                        case 3:
                            return locationText[2];

                        case 4:
                            return locationText[3];

                        case 5:
                            return locationText[0];

                    }
                }
                else
                {
                    lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
                    i++;
                }

            }


            inputStream.Close(); //closes the notepad for other programs to use if needed
            return NO_PLAYER_FOUND;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //GETS INPUT PROM NOTEPAD FIRLDS[2]
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void GetPlayerScores()
        {
            string[] fields = new string[4]; //this is where ',' slit goes in

            string lineIn; //this is where each line of notepad stuff will be stored 

            int i = 0; //this is just for putting each line of notepad to an array to store amount of players with a specific score

            FileStream fs = new FileStream(@"C:\Users\konra\OneDrive - Institute of Technology Sligo\Modules\Year 1\Semester 2\Programming 2 sem2 yr1\pCA3\GameScores.txt", FileMode.Open, FileAccess.Read); //makes a connection with notepad

            StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

            lineIn = inputStream.ReadLine(); //reads line and goes to next line

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"
                playerScores[i] = int.Parse(fields[2]);  //salery = 4 position of fields //so each time the while loop is here it puts the 3 position of firld into number of players array
                lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
                i++;
            }

            inputStream.Close(); //closes the notepad for other programs to use if needed
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

        //GETS INPUT PROM NOTEPAD FIRLD[3]
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void GetLocations()
        {
            string[] secoundCharOfNotepadIntoString = new string[5];
            int[] secoundCharOfNotepadIntoStringIntoInt = new int[5];

            string[] fields = new string[4]; //this is where ',' slit goes in

            string lineIn; //this is where each line of notepad stuff will be stored 

            int i = 0; //this is just for putting each line of notepad to an array to store amount of players with a specific score

            FileStream fs = new FileStream(@"C:\Users\konra\OneDrive - Institute of Technology Sligo\Modules\Year 1\Semester 2\Programming 2 sem2 yr1\pCA3\GameScores.txt", FileMode.Open, FileAccess.Read); //makes a connection with notepad

            StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

            lineIn = inputStream.ReadLine(); //reads line and goes to next line

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"


                switch (int.Parse(fields[3]))
                {


                    case 1:
                        numberOfPlayersInLocations[0] = int.Parse(fields[0].Substring(1)) + numberOfPlayersInLocations[0]; //.Subtracting removes the 1st char and then its parsed 
                        break;

                    case 2:
                        numberOfPlayersInLocations[1] = int.Parse(fields[0].Substring(1)) + numberOfPlayersInLocations[1];
                        break;

                    case 3:
                        numberOfPlayersInLocations[2] = int.Parse(fields[0].Substring(1)) + numberOfPlayersInLocations[2];
                        break;

                    case 4:
                        numberOfPlayersInLocations[3] = int.Parse(fields[0].Substring(1)) + numberOfPlayersInLocations[3];
                        break;

                    case 5:
                        numberOfPlayersInLocations[4] = int.Parse(fields[0].Substring(1)) + numberOfPlayersInLocations[4];
                        break;

                }

                lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
                i++;
            }


            inputStream.Close(); //closes the notepad for other programs to use if needed
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________







        //Makes graphs
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void MakesGraphsCorrespondingToAmountOfPlayersInEachScoreCathegory()
        {
            string graphChar = "#"; //this is the character to make the graph

            int[] copyOfNumberOfPlayers = new int[5] { numberOfPlayers[0], numberOfPlayers[1], numberOfPlayers[2], numberOfPlayers[3], numberOfPlayers[4] }; //copy of "numberOfPlayers" so the for loop beflow doesnt interfear with the existing values of the players

            for (int i = 0; i < copyOfNumberOfPlayers.Length; i++) //this will happen for each thing in array
            {
                {
                    for (copyOfNumberOfPlayers[i] = copyOfNumberOfPlayers[i]; copyOfNumberOfPlayers[i] > 0; copyOfNumberOfPlayers[i]--) //forloop
                    {
                        graph[i] = graph[i].Insert(0, graphChar); // '#' will be inserted for each unit, example 1= #         5= # # # # #  //puts it into an array //class level
                    }
                }
            }
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //total number of players
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int GetTotalNumberOfPlayers() //literly everyone knows how this works
        {
            int totalNumberOfPlayers = 0;

            for (int i = 0; i < numberOfPlayers.Length; i++)
            {
                totalNumberOfPlayers = numberOfPlayers[i] + totalNumberOfPlayers;
            }
            return totalNumberOfPlayers;


        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //total score
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int GetTotalScore() //dont make me explain this
        {
            int totalScore = 0;


            for (int i = 0; i < playerScores.Length; i++)
            {
                totalScore = playerScores[i] + totalScore;
            }
            return totalScore;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //average score
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int GetAverageScore() //this is self explanetory 
        {
            int averageScore;



            averageScore = GetTotalScore() / GetTotalNumberOfPlayers();

            return averageScore;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //output / display of choice 1
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void PlayerReportDisplay()  //literly just outputs / display
        {
            string playerReportTableFormat = "{0,-10}{1,20}{2,30}"; //display format

            Console.WriteLine(playerReportTableFormat, "\nScores", "Number of Players", "Graph\n"); //displays headings

            for (int i = 0; i < scoresText.Length; i++)
            {
                Console.WriteLine(playerReportTableFormat, scoresText[i], numberOfPlayers[i], graph[i]); //displays each array
            }

            Console.WriteLine(playerReportTableFormat, "\nTotal Players", GetTotalNumberOfPlayers(), null);
            Console.WriteLine(playerReportTableFormat, "Average Score", GetAverageScore(), null);
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________




        //output / display of choice 2
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void LocationAnalysisReportDisplay() //displayyyyyyyyyyyyyy
        {
            string playerReportTableFormat = "{0,-10}{1,20}"; //display format

            Console.WriteLine(playerReportTableFormat, "\nLocation", "Player Count\n"); //displays headings

            for (int i = 0; i < scoresText.Length; i++)
            {

                Console.WriteLine(playerReportTableFormat, locationText[i], numberOfPlayersInLocations[i]); //displays each array
            }

            Console.WriteLine("\nTotals                     : {0}", GetTotalNumberOfPlayers());
            Console.WriteLine("Location with most players : {0}", GetLocationWithMostPlayers());
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________




        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static string GetLocationWithMostPlayers() //displayyyyyyyyyyyyy
        {
            int locationWithMostPlayersInt = 0;
            string locationWithMostPlayersString = "";

            for (int i = 0; i < numberOfPlayers.Length; i++)
            {
                if (numberOfPlayersInLocations[i] > locationWithMostPlayersInt)
                {
                    locationWithMostPlayersInt = numberOfPlayersInLocations[i]; //this is used so the if statement gets updated
                    locationWithMostPlayersString = locationText[i]; //this is updated if it gets into this if statement
                }
            }



            return locationWithMostPlayersString;

        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static string InputChoiceThree() //displayyyyyyyyyyyyy
        {
            string name;
            Console.Write("\nEnter player name : ");
            name = Console.ReadLine();
            return name;

        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void OutputChoiceThree(string name) //displayyyyyyyyyyyyy
        {

            Console.WriteLine("\n\n\nLocation          : {0}", name);


        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static string Again(string name) //displayyyyyyyyyyyyy
        {
            string again;
            Console.Write("\nDo you want to go back to the menu? (yes/no) : ");
            again = Console.ReadLine().ToLower();

            return again;


        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________







































    }
}
