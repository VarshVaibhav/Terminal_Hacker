using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menuHint = "You may type 'menu' at any time.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow", "stolen", "displace", "silence", "decorum", "condition", "labels", "knowledge" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest","criminal","warrant","warden","security","encounter","wanted","weapons","records","jailor" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts", "spacestation", "solarstorm", "meteroids", "planets", "galaxy", "gravity", "atmosphere", "satellites", "revoltuion" };

    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for hacking the local library.");
        Terminal.WriteLine("Press 2 for hacking the Prison.");
        Terminal.WriteLine("Press 3 for hacking the ISRO");
        Terminal.WriteLine("For exit, type 'exit' / 'quit' / 'close'");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if(input =="quit" || input == "close" || input == "exit")
        {
            Application.Quit();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
            Terminal.WriteLine(menuHint);
        }
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter Password. HINT: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;

            default:
                Debug.LogError("Invalid");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
        __..._   _...__
  _..-''      `Y`      ''-._
  \ Once upon |           /
  \\  a time..|          //
  \\\         |         ///
   \\\ _..---.|.---.._ ///
    \\`_..---.Y.---.._`//
     '`               `'
");
                break;
            case 2:
                Terminal.WriteLine("You got a key...");
                Terminal.WriteLine(@"
 _              
| |             
| | _____ _   _ 
| |/ / _ \ | | |
|   <  __/ |_| |
|_|\_\___|\__, |
           __/ |
          |___/ 
");
                Terminal.WriteLine("Play again for Greater Challenge");
                break;
            case 3:
                Terminal.WriteLine("System Hacked...");
                Terminal.WriteLine(
@"
ooOoOOo .oOOOo.  `OooOOo.   .oOOOo.  
   o    O.        O      O O       o 
   O     `OOoo.   o     .O o       O 
   o          `O  OOooOO'  O       o 
   O           o  o    o   o       O 
ooOOoOo  `oooO'   O      o  `OoooO'
");
                Terminal.WriteLine("Wanna Try Again....");
                break;
        }
        
    }
}
