/*=======================

 * Name: Konrad Szpak

 * Student ID: S00197298
 
 * Date: 23-03-2020
 
 * Description: CA3, Use CTRL + 'scrol' to navigate around this easier
 
 "_________________ ..." seperates each method 

=========================*/




using System;
using System.IO;

namespace pCA3
{
    class CA3
    {

        //read every coment please...

        //each "input" method will output their results into these arrays and next each array will be displayed with a 'for loop'

        //class level arrays
        //==================================================================================================================================================================================================================================================================================
        static string[] scoresText = new string[5] { "00000-9999", "10000-19999", "20000-29000", "30000-39999", "40000+" };//just output
        static string[] locationText = new string[5] { "Europe", "Asia", "America", "South America", "Australia" }; //just output 


        static int[] numberOfPlayers = new int[5]; //this is where number of players in each score cathegory are inputed
        static int[] playerScores = new int[5]; //this is where the player scored are inputed
        static int[] numberOfPlayersInLocations = new int[5]; //this is where the number of players in each location are inputed 


        static string[] graph = new string[5] { "", "", "", "", "" }; //this is where graph coresponding to the amount of players in each score cathegory is inputed


        static string filePath = @"C:\Users\konra\OneDrive - Institute of Technology Sligo\Modules\Year 1\Semester 2\Programming 2 sem2 yr1\pCA3\GameScores.txt"; //this is where the inputs are found //you can just past your path in here if you need to
        //==================================================================================================================================================================================================================================================================================



        //gets inputs
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void Main(string[] args) //main method is used to choose ur choice
        {

             //just do while loop, if yes or y repeats if anything else breaks
            int menuChoice; //choice 'aka' case 1,2,3...
            string name; //name of player you are searching
            string again = "";
            //gets inputs
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
                        PlayerReportDisplay(); //displays results choise 1
                        again = Again(again); //when finished asks if to go back to menu
                        break;

                    case 2:
                        LocationAnalysisReportDisplay(); //displays results choice 2
                        again = Again(again); //when finished asks if to go back to menu
                        break;

                    case 3:
                        name = SearchForAPlayer(InputChoiceThree()); //inputs and processes choice 3
                        OutputChoiceThree(name); //displays results choice 3
                        again = Again(again); //when finished asks if to go back to menu
                        break;

                    case 4:
                        again = "no";
                        break;
                }
                
            }
            while (again == "yes" || again == "y");
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //gets choice and checks if they are correct format and if they are 1-4
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

                    menuChoice = ValidateMenu(menuChoice); //calls method that validates this input
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

        
        //validated menu input
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static int ValidateMenu(int menuChoice)
        {
            if (menuChoice > 4)
                throw new Exception();
            else
                return menuChoice;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //GETS INPUT PROM NOTEPAD FIRLD[0]
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void GetNumberOfPlayersInEachCathegory()
        {
            string[] fields = new string[4]; //this is where ',' split goes in

            string lineIn; //this is where each line of notepad stuff will be stored 


            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); //makes a connection with notepad

            StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

            lineIn = inputStream.ReadLine(); //reads line and goes to next line

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"

                if (int.Parse(fields[2]) <= 9999)
                    numberOfPlayers[0] += int.Parse(fields[0].Substring(1)); //.Subtracting removes the first char and then its parsed
                else if (int.Parse(fields[2]) <= 19999)         //yea i know u dont need that >= 10000 but just leave it... whatever  
                    numberOfPlayers[1] += int.Parse(fields[0].Substring(1)); 
                else if (int.Parse(fields[2]) <= 29999)         //same here ...
                    numberOfPlayers[2] += int.Parse(fields[0].Substring(1)); 
                else if (int.Parse(fields[2]) <= 39999)         //whatever
                    numberOfPlayers[3] += int.Parse(fields[0].Substring(1)); 
                else
                    numberOfPlayers[4] += int.Parse(fields[0].Substring(1)); 

                lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
            }
            inputStream.Close(); //closes the notepad for other programs to use if needed
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //searches for name inputed in choice 3 then writes the location coresponding to that name 
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static string SearchForAPlayer(string name)//takes name and looks for a name in notepod thats same
        {
            const string NO_PLAYER_FOUND = "No match found"; //returns this is it goes into the else statement below

            string[] fields = new string[4]; //this is where ',' slit goes in

            string lineIn; //this is where each line of notepad stuff will be stored 

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); //makes a connection with notepad

            StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

            lineIn = inputStream.ReadLine(); //reads line and goes to next line

            while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
            {
                fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"

                if (name == fields[1]) //takes name and checks if its equal wich fields[1] else it goes to next line and searches there //if it doesnt find it at all it returns the above constant message "no matches found"
                {
                    switch (int.Parse(fields[3])) //when it gets into here that means there is a name == fields[1] so then it returns the location number(code) that is on the same line as the name 
                    {
                        case 1: //location code 1
                            inputStream.Close(); //closes for other programs to use
                            return locationText[0];  

                        case 2: //location code 2
                            inputStream.Close(); //closes for other programs to use
                            return locationText[1];

                        case 3: //...
                            inputStream.Close();
                            return locationText[2];

                        case 4: //...
                            inputStream.Close();
                            return locationText[3];

                        case 5: //...
                            inputStream.Close();
                            return locationText[4];
                    }
                }
                else
                {
                    lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
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

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read); //makes a connection with notepad

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
                        numberOfPlayersInLocations[0] += int.Parse(fields[0].Substring(1)); //.Subtracting removes the 1st char and then its parsed 
                        break;

                    case 2:
                        numberOfPlayersInLocations[1] += int.Parse(fields[0].Substring(1));  //do i really have to explain...?
                        break;

                    case 3:
                        numberOfPlayersInLocations[2] += int.Parse(fields[0].Substring(1));
                        break;

                    case 4:
                        numberOfPlayersInLocations[3] += int.Parse(fields[0].Substring(1));
                        break;

                    case 5:
                        numberOfPlayersInLocations[4] += int.Parse(fields[0].Substring(1));
                        break;
                }

                lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
           
            }
            inputStream.Close(); //closes the notepad for other programs to use if needed
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //makes graphs
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


        //gets total number of players
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


        //gets total score
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


        //gets average score
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
            string playerReportTableFormat = "{0,-15}{1,-20}{2,-30}"; //display format

            Console.WriteLine("");
            Console.WriteLine(playerReportTableFormat, "Scores", "Number of Players", "Graph"); //displays headings
            Console.WriteLine("");

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


        //gets location with most players
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

        //inputs choice 3
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static string InputChoiceThree() //displayyyyyyyyyyyyy
        {
            string name;

            Console.Write("\nEnter player name : ");
            name = Console.ReadLine();

            return name;
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

        //outputs choice 3
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        static void OutputChoiceThree(string name) //displayyyyyyyyyyyyy
        {
            Console.WriteLine("\n\n\nLocation          : {0}", name);
        }
        //_________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________


        //asks if you want to go back to the menu
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
