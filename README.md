# Solitaire  
## Game made in C# language runnable on console  
## Game mechanics:  
Your aim is place cards in four stack from the smallest to the highest card  
You can pick cards from the stack with have been shuffled every time where cards run off  
You can move cards from collumns and stack it with correct order  
You can undo the moves (maximum 3 moves)  
Your score after win have been saved to application folder as leaderboard, which game read it and shows  
## Run project:  
You must download and install 8 .NET version to run this game  
Clone this repository  
Enter to the game folder and write *dotnet run* command to run 
I recommend to resise console window to correct size because game element can be display wrong (after resing where game is running,  just enter a key to refresh all components)  
## Controls:  
Navigate using *WSAD* keys and *enter* to action  
Where you want to pick multiple cards, you must click on collumn and using *W* and *S* choose the amount of cards  
## Example classes:  
Content Manager  static class which stores a data and scene management  
LeaderBoardManager static class which is responsible for leaderboard logic  
ScoreCOmparator class which implements a Comparator to sort a leaderBoard scores with correct order  
Vector struct with represent a two values *X* and *Y*  
Card class which represented the card for exaple Diamond 10  
ChooseWindow class which is represented a window to choose option for example do you want leave? YES or NO  
DrawableObject class which represent a drawable object with text data, using to extends other classes to draw things  
ScoreObject basic class which store data about score from leaderboard parsed from json  
SelectPanel2d class which represent a panel which you can select options  
StateManager/StateObject class which saving state to list. This is needed for undo moves  
IPanel interface which is applied to objects that are options in SelectPanel2d, for example *ActionPerformed()* method which is  executed where player click Enter on element from selectPanel2d  
ICardContainer interface which is applied to objects that player can integrate to move cards to this card container  