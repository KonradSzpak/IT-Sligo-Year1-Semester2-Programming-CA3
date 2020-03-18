/*=======================

 * Name: Konrad Szpak

 * Student ID: S00197298

 * Date: 17-03-2020

 * Description: CA3, Use CTRL + 'scrol' to navigate around this easier

=========================*/




using System;
using System.IO;

namespace pCA3
{
    class CA3
    {

        //each method will output their results into these 3 arrays and next each array will be displayed with a for loop
        //choice 1 stuff
        static string[] scoresText = new string[5] { "00000-9999", "10000-19999", "20000-29000", "30000-39999", "40000+" }; //just output 
        static string[] graph = new string[5] { "", "", "", "", "" }; //this is where graph is inputed
        static int[] numberOfPlayers = new int[5]; //this is where number of players are inputed

        //choice 2 stuff
        static string[] locationText = new string[5] { "Europe", "Asia", "America", "South America", "Australia" }; //just output 


        static void Main(string[] args) //main method is used to choose ur choice
        {
            int menuChoice;
            menuChoice = Menu();

            switch (menuChoice)
            {
                case 1:
                    Choice1(); //calls choice method //more methods inside that method to keep this code clean
                    break;

                case 2:
                    Choice2();
                    break;

                case 3:
                    //Choice3();
                    break;

                case 4: //choice 4 is exit
                    break;

                default: //breaks if something else than above
                    break;
            }


        }

        static int Menu()
        {
            int menuChoice;
            Console.Write("\n1. Player Report\n2. Location Analasis Report\n3. Search for a player\n4. Exit\n\nEnter Choice : ");
            menuChoice = int.Parse(Console.ReadLine());
            return menuChoice;
        }













        //================================================================================================================================================================================================================================================================================================================================================================================================================================================
        static void Choice1()
        {
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            GetNumberOfPlayersInEachScoreCategory();
            MakesGraphsCorrespondingToAmountOfPlayersInEachScoreCathegory();
            PlayerReportDisplay();
            
            //VVVVVVVVVVVVVVV CALLS EACH METHOD BELLOW VVVVVVVVVVVVVVVV

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static void GetNumberOfPlayersInEachScoreCategory()
            {
                string[] fields = new string[4]; //this is where ',' slit goes in

                string lineIn; //this is where each line of notepad stuff will be stored 

                int i = 0; //this is just for putting each line of notepad to an array to store amount of players with a specific score

                FileStream fs = new FileStream(@"C:\Users\konra\OneDrive - Institute of Technology Sligo\Modules\Year 1\Semester 2\Programming 2 sem2 yr1\pCA4\GameScores.txt", FileMode.Open, FileAccess.Read); //makes a connection with notepad

                StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

                lineIn = inputStream.ReadLine(); //reads line and goes to next line

                while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
                {
                    fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"
                    numberOfPlayers[i] = int.Parse(fields[3]);  //salery = 4 position of fields //so each time the while loop is here it puts the 3 position of firld into number of players array
                    lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
                    i++;
                }

                inputStream.Close(); //closes the notepad for other programs to use if needed
            }
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static void MakesGraphsCorrespondingToAmountOfPlayersInEachScoreCathegory()
            {
                string graphChar = "#";

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
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static int GetTotalNumberOfPlayers()
            {
                int totalNumberOfPlayers = 0;

                for (int i =0; i<numberOfPlayers.Length;i++)
                {
                    totalNumberOfPlayers = numberOfPlayers[i] + totalNumberOfPlayers;
                }
                return totalNumberOfPlayers;
            }
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static int GetAverageScore()
            {
                int totalScore = 0;
                int averageScore = 0;

                for (int i = 0; i < numberOfPlayers.Length; i++)
                {
                    totalScore = numberOfPlayers[i] + totalScore;
                }

                averageScore = totalScore / GetTotalNumberOfPlayers();

                return averageScore;
            }
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static void PlayerReportDisplay()
            {
                string playerReportTableFormat = "{0,-10}{1,20}{2,30}"; //display format

                Console.WriteLine(playerReportTableFormat, "Scores", "Number of Players", "Graph"); //displays headings

                for (int i = 0; i < scoresText.Length; i++)
                {
                    Console.WriteLine(playerReportTableFormat, scoresText[i], numberOfPlayers[i], graph[i]); //displays each array
                }

                Console.WriteLine(playerReportTableFormat, "\nTotal Players", GetTotalNumberOfPlayers(), null);
                Console.WriteLine(playerReportTableFormat, "Average Score", GetAverageScore(), null);
            }
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        }
        //================================================================================================================================================================================================================================================================================================================================================================================================================================================



































        //================================================================================================================================================================================================================================================================================================================================================================================================================================================
        static void Choice2()
        {
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            GetNumberOfPlayersInEachScoreCategory();
            MakesGraphsCorrespondingToAmountOfPlayersInEachScoreCathegory();
            PlayerReportDisplay();

            //VVVVVVVVVVVVVVV CALLS EACH METHOD BELLOW VVVVVVVVVVVVVVVV

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static void GetNumberOfPlayersInEachScoreCategory()
            {
                string[] fields = new string[4]; //this is where ',' slit goes in

                string lineIn; //this is where each line of notepad stuff will be stored 

                int i = 0; //this is just for putting each line of notepad to an array to store amount of players with a specific score

                FileStream fs = new FileStream(@"C:\Users\konra\OneDrive - Institute of Technology Sligo\Modules\Year 1\Semester 2\Programming 2 sem2 yr1\pCA4\GameScores.txt", FileMode.Open, FileAccess.Read); //makes a connection with notepad

                StreamReader inputStream = new StreamReader(fs); //does something //i think it makes the "filestream fs" a type that reads

                lineIn = inputStream.ReadLine(); //reads line and goes to next line

                while (lineIn != null) //while next line is not null goes to next line //null = "THERE IS NOTHING THERE"
                {
                    fields = lineIn.Split(','); //if there is ',' it splits it parts and puts it into array "fields"
                    numberOfPlayers[i] = int.Parse(fields[3]);  //salery = 4 position of fields //so each time the while loop is here it puts the 3 position of firld into number of players array
                    lineIn = inputStream.ReadLine(); //goes to next line and reads and repeats process
                    i++;
                }

                inputStream.Close(); //closes the notepad for other programs to use if needed
            }
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static void MakesGraphsCorrespondingToAmountOfPlayersInEachScoreCathegory()
            {
                string graphChar = "#";

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
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static int GetTotalNumberOfPlayers()
            {
                int totalNumberOfPlayers = 0;

                for (int i = 0; i < numberOfPlayers.Length; i++)
                {
                    totalNumberOfPlayers = numberOfPlayers[i] + totalNumberOfPlayers;
                }
                return totalNumberOfPlayers;
            }
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static int GetAverageScore()
            {
                int totalScore = 0;
                int averageScore = 0;

                for (int i = 0; i < numberOfPlayers.Length; i++)
                {
                    totalScore = numberOfPlayers[i] + totalScore;
                }

                averageScore = totalScore / GetTotalNumberOfPlayers();

                return averageScore;
            }
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
            static void PlayerReportDisplay()
            {
                string playerReportTableFormat = "{0,-10}{1,20}"; //display format

                Console.WriteLine(playerReportTableFormat, "Location", "Player Count"); //displays headings

                for (int i = 0; i < scoresText.Length; i++)
                {
                    Console.WriteLine(playerReportTableFormat, locationText[i], numberOfPlayers[i]); //displays each array
                }

                Console.WriteLine("playerReportTableFormat, "Totas", GetTotalNumberOfPlayers()null");
                Console.WriteLine("Location with most players : {0}",GetTotalNumberOfPlayers());
            }
            //______________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
        }
        //================================================================================================================================================================================================================================================================================================================================================================================================================================================















    }
}
