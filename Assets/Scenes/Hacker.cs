using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

    // Game state 
    int level;
    string passkey;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Ben");
    }

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for police station");
        Terminal.WriteLine("Enter your selection: ");
    }


    void OnUserInput(string input)
    {
        if (input == "Menu")
        {
            ShowMainMenu("Hello Ben");
        }

        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        
        else if(currentScreen == Screen.Password)
        {
            PasswordCheck(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPass();
        }

        else
        {
            Terminal.WriteLine("Please choose correct option");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPass()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + passkey.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                passkey = level1Passwords[index1];
                break;

            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                passkey = level2Passwords[index2];
                break;

            default:
                Debug.LogError("I dont know you!");
                break;
        }
    }

    void PasswordCheck(string password)
    {
     
        if (password == passkey)
        {
            DisplayWinScreen();
            Terminal.WriteLine(menuHint);
        }
        else
        {
            AskForPass();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
      __________
     /         //
    / Book of //
   /  Love   //
  /_________//
 (_________(/
");
                                
                break;

            case 2:
                Terminal.WriteLine("You got the prison key...");
                Terminal.WriteLine(@"

 __
/0 \________
\__/-=' = '/
"
);
                break;

            default:
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
