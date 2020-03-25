/*=======================
 
 * Name: Konrad Szpak
 
 * Student ID: S00197298
 
 * Date: 23-03-2020
 
 * Description: CA3, Use CTRL + 'scrol' to navigate around this easier
 
 * "_________________ ..." seperates each method 
 
=========================*/

using System;
using System.IO;

namespace pCA3
{
    class CA3
    {
        //==================================================================================================================================================================================================================================================================================

        static string[] scoresText = new string[5] { "00000-9999", "10000-19999", "20000-29000", "30000-39999", "40000+" }; //just output
        static string[] locationText = new string[5] { "Europe", "Asia", "America", "South America", "Australia" }; //just output 

        static int[] numberOfPlayers = new int[5]; //this is where number of players in each score cathegory are inputed
        static int[] numberOfPlayersInLocations = new int[5]; //this is where the number of players in each location are inputed 

        static string[] graph = new string[5] { "", "", "", "", "" }; //this is where graph coresponding to the amount of players in each score cathegory is inputed

        static string filePath = @"..\..\..\GameScores.txt"; //this is where the inputs are found

        //==================================================================================================================================================================================================================================================================================



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void Main(string[] args)
        {
            int menuChoice;
            string location;
            bool repeatMenu = true;
            bool repeatPlayerNameAnswer = false;
            bool isValid;

            if (ChecksIfFilePathWorks() == true) //checks if file path is valid //if it is it goes into loop //if not displays message and breaks
            {
                GetNumberOfPlayersInEachCathegory();
                GetPlayerScoresAndFindTheAverage();
                GetNumberOfPlayersInEachLocations(); 
                MakesGraphsCorrespondingToAmountOfPlayersInEachScoreCathegory();
                do
                {
                    menuChoice = Menu();
                    switch (menuChoice)
                    {
                        case 1:
                            PlayerReportDisplay(); //displays results choise 1
                            break;

                        case 2:
                            LocationAnalysisReportDisplay(); //displays results choice 2
                            break;

                        case 3:
                            do
                            {
                                try
                                {
                                    isValid = true;
                                    location = SearchForAPlayer(GetPlayerNameAsInput()); //search for player, gets players name, and returns a location coresponding to his name
                                    OutputLocationToTheCorespondingNameOfThePlayer(location); //displays results choice 3
                                }
                                catch (Exception)
                                {
                                    Console.Write("\nThere are no player with this name\n"); //just output
                                    isValid = false;
                                }
                                repeatPlayerNameAnswer = AskToTryAgainIfPlayerNameInvalid(isValid); //asks to try again is name is invalid
                            }
                            while (isValid == false && repeatPlayerNameAnswer != false); //while the name inputed is on the list and the user agrees to stop looping "AskToTryAgain...."
                            break;

                        case 4:
                            repeatMenu = false; //exits the program
                            break;
                    }
                }
                while (repeatMenu == true);
            }
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int Menu()
        {
            int menuChoice = 0;

            bool isValid;

            Console.Write("\n1. Player Report\n2. Location Analasis Report\n3. Search for a player\n4. Exit\n"); //just output

            //this is done untill correct input is not inputed
            do
            {
                try
                {
                    isValid = true;
                    Console.Write("\nEnter Choice : "); //just output 
                    menuChoice = int.Parse(Console.ReadLine()); //reads input of menu
                    menuChoice = ValidateMenu(menuChoice); //calls method that validates this input //checks if its between 1-4
                }
                catch (Exception)
                {
                    Console.Write("\nThats not a choice!\n"); //just output
                    isValid = false;
                }
            }
            while (isValid == false);

            return menuChoice;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int ValidateMenu(int menuChoice)
        {
            if (menuChoice > 4)
                throw new Exception();
            else
                return menuChoice;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void GetNumberOfPlayersInEachCathegory()
        {
            string[] fields = new string[4]; //this is where ',' slit goes in

            string lineIn;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); 

            StreamReader inputStream = new StreamReader(fs); 

            lineIn = inputStream.ReadLine(); 

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"

                if (int.Parse(fields[2]) <= 9999)
                    numberOfPlayers[0]++;
                else if (int.Parse(fields[2]) <= 19999)
                    numberOfPlayers[1]++;
                else if (int.Parse(fields[2]) <= 29999)
                    numberOfPlayers[2]++;
                else if (int.Parse(fields[2]) <= 39999)
                    numberOfPlayers[3]++;
                else
                    numberOfPlayers[4]++;

                lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
            }
            inputStream.Close(); //closes the notepad for other programs to use if needed
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static string SearchForAPlayer(string name) //takes name and looks for a name in notepod thats same
        {
            const string NO_PLAYER_FOUND = "No match found"; //returns this is it goes into the else statement below

            string[] fields = new string[4]; 

            string lineIn; 

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); //makes a connection with notepad

            StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

            lineIn = inputStream.ReadLine().ToLower(); //reads line and goes to next line

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"



                if (name == fields[1]) //takes name and checks if its equal wich fields[1] else it goes to next line and searches there //if it doesnt find it at all it returns the above constant message "no matches found"
                {
                    switch (int.Parse(fields[3])) //when it gets into here that means there is a name == fields[1] so then it returns the location number(code) that is on the same line as the name 
                    {
                        case 1: 
                            inputStream.Close(); 
                            return locationText[0];

                        case 2: 
                            inputStream.Close(); 
                            return locationText[1];

                        case 3: 
                            inputStream.Close();
                            return locationText[2];

                        case 4: 
                            inputStream.Close();
                            return locationText[3];

                        case 5: 
                            inputStream.Close();
                            return locationText[4];
                    }
                }
                else
                {
                    lineIn = inputStream.ReadLine().ToLower(); //goes to next line and reads and repeats process
                }
            }
            inputStream.Close(); //closes the notepad for other programs to use if needed

            return NO_PLAYER_FOUND;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int GetPlayerScoresAndFindTheAverage()
        {
            int averageScore = 0;
            int totalScore = 0;
            int playerScore = 0;

            string[] fields = new string[4]; //this is where ',' slit goes in

            string lineIn; //this is where each line of notepad stuff will be stored 

            int i = 0; //this is just for putting each line of notepad to an array to store amount of players with a specific score

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); //makes a connection with notepad

            StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

            lineIn = inputStream.ReadLine(); //reads line and goes to next line

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"
                playerScore = int.Parse(fields[2]);

                totalScore += GetTotalScore(playerScore);
                averageScore = GetAverageScore(totalScore);//salery = 4 position of fields //so each time the while loop is here it puts the 3 position of firld into number of players array

                lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
                i++;
            }
            inputStream.Close(); //closes the notepad for other programs to use if needed
            return averageScore;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



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



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int GetTotalScore(int playerScore) //dont make me explain this
        {
            int totalScore = 0;

            totalScore += playerScore;

            return totalScore;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int GetAverageScore(int totalScore) //this is self explanetory 
        {
            int averageScore;

            averageScore = totalScore / GetTotalNumberOfPlayers();

            return averageScore;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void GetNumberOfPlayersInEachLocations()
        {
            string[] fields = new string[4]; //this is where ',' slit goes in

            string lineIn; //this is where each line of notepad stuff will be stored 

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); //makes a connection with notepad

            StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

            lineIn = inputStream.ReadLine(); //reads line and goes to next line

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"

                switch (int.Parse(fields[3]))
                {
                    case 1:
                        numberOfPlayersInLocations[0]++;
                        break;

                    case 2:
                        numberOfPlayersInLocations[1]++;
                        break;

                    case 3:
                        numberOfPlayersInLocations[2]++;
                        break;

                    case 4:
                        numberOfPlayersInLocations[3]++;
                        break;

                    case 5:
                        numberOfPlayersInLocations[4]++;
                        break;
                }

                lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process

            }
            inputStream.Close(); //closes the notepad for other programs to use if needed
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void MakesGraphsCorrespondingToAmountOfPlayersInEachScoreCathegory()
        {
            string graphChar = "#"; //this is the character to make the graph

            int[] copyOfNumberOfPlayers = new int[5] { numberOfPlayers[0], numberOfPlayers[1], numberOfPlayers[2], numberOfPlayers[3], numberOfPlayers[4] }; //copy of "numberOfPlayers" so the for loop beflow doesnt interfear with the existing values of the players

            for (int i = 0; i < copyOfNumberOfPlayers.Length; i++) //this will happen for each thing in array
            {
                for (copyOfNumberOfPlayers[i] = copyOfNumberOfPlayers[i]; copyOfNumberOfPlayers[i] > 0; copyOfNumberOfPlayers[i]--) //forloop
                {
                    graph[i] = graph[i].Insert(0, graphChar); // '#' will be inserted for each unit, example 1= #         5= # # # # #  //puts it into an array //class level
                }
            }
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void PlayerReportDisplay()  
        {
            string playerReportTableFormat = "{0,-15}{1,-20}{2,-30}"; //display format

            Console.WriteLine("");
            Console.WriteLine(playerReportTableFormat, "Scores", "Number of Players", "Graph"); //displays headings
            Console.WriteLine("");

            for (int i = 0; i < scoresText.Length; i++)
            {
                Console.WriteLine(playerReportTableFormat, scoresText[i], numberOfPlayers[i], graph[i]); //displays each array
            }

            Console.WriteLine(playerReportTableFormat, "\nTotal Players", GetTotalNumberOfPlayers(), null);
            Console.WriteLine(playerReportTableFormat, "Average Score", GetPlayerScoresAndFindTheAverage(), null);
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void LocationAnalysisReportDisplay() 
        {
            string playerReportTableFormat = "{0,-15}{1,-20}"; //display format

            Console.WriteLine("");
            Console.WriteLine(playerReportTableFormat, "Location", "Player Count"); //displays headings
            Console.WriteLine("");

            for (int i = 0; i < scoresText.Length; i++)
            {
                Console.WriteLine(playerReportTableFormat, locationText[i], numberOfPlayersInLocations[i]); //displays each array
            }

            Console.WriteLine("\nTotals                     : {0}", GetTotalNumberOfPlayers());
            Console.WriteLine("Location with most players : {0}", GetLocationWithMostPlayers());
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static string GetLocationWithMostPlayers() 
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
        static string GetPlayerNameAsInput() 
        {
            string name;

            Console.Write("\nEnter player name : ");
            name = Console.ReadLine().ToLower();

            return name;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void OutputLocationToTheCorespondingNameOfThePlayer(string name) 
        {
            Console.WriteLine("\n\n\nLocation          : {0}", name);
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static bool AskToTryAgainIfPlayerNameInvalid(bool isValid) 
        {
            if (isValid == false)
            {
                bool repeatPlayerNameAnswer = false;
                string repeatPlayerNameInput;

                Console.Write("\nDo you want to try again? (y/n): ");
                repeatPlayerNameInput = Console.ReadLine();
                if (repeatPlayerNameInput == "no" || repeatPlayerNameInput == "n")
                    repeatPlayerNameAnswer = false;
                else
                    repeatPlayerNameAnswer = true;
                return repeatPlayerNameAnswer;
            }
            else
                return true;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static bool ChecksIfFilePathWorks()
        {
            try
            {
                string[] fields = new string[4]; //this is where ',' slit goes in

                string lineIn; //this is where each line of notepad stuff will be stored 

                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); //makes a connection with notepad

                StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

                lineIn = inputStream.ReadLine(); //reads line and goes to next line

                inputStream.Close(); //closes the notepad for other programs to use if needed

                return true;
            }
            catch (Exception)
            {
                Console.Write("\nFile Path Not Found\n"); //just output
                return false;
            }
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
    }
}