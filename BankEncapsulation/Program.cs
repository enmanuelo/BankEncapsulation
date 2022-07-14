using BankEncapsulation;

var myAccount = new BankAccount();

bool keepGoing = true;
while (keepGoing == true)
{
    Console.WriteLine("What would you like to do? Deposit, Withdraw or CheckBalance? \nTo Exit, please enter 'Exit'");
    string userInput = Console.ReadLine().ToLower();

    if (userInput == "deposit")
    {
        Console.WriteLine("How much would you like to deposit?");
        double userAmount;
        bool isNum = double.TryParse(Console.ReadLine(), out userAmount);
        if (isNum == false)
        {
            Console.WriteLine("Invalid input! Must enter a number. Please do not enter letters or special characters such as '$'");
            continue;
        }
        else if (userAmount <= 0)
        {
            Console.WriteLine("Invalid input. Cannot withdraw 0 or less.");
            continue;
        }
            myAccount.Deposit(userAmount);

        Console.WriteLine($"Your new balance is: ${myAccount.GetBalance()}");
    }
    else if (userInput == "withdraw")
    {
        Console.WriteLine("How much would you like to withdraw?");
        double userAmount;
        bool isNum = double.TryParse(Console.ReadLine(), out userAmount);

        if (isNum == false)
        {
            Console.WriteLine("Invalid input! Must enter a number. Please do not enter letters or special characters such as '$'");
            continue;
        }

        if (userAmount > myAccount.GetBalance())
        {
            
            if (myAccount.GetBalance() == 0)
            {
                Console.WriteLine($"Insufficient funds! You have no money in this account.");
            }
            else
            {
                Console.WriteLine($"Insufficient funds! You only have ${myAccount.GetBalance()} available.");
            }
        }
        else if (userAmount <= 0)
        {
            Console.WriteLine("Invalid input. Cannot withdraw 0 or less.");
        }
        else
        {
            myAccount.Withdraw(userAmount);
            Console.WriteLine($"Your new balance is: ${myAccount.GetBalance()}");
        }
        
    }
    else if (userInput == "checkbalance" || userInput == "check balance")
    {
        Console.WriteLine($"Your balance is: ${myAccount.GetBalance()}");
    }
    else if (userInput == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid input! Please enter one of the following options\nDeposit  Withdraw  CheckBalance");
        continue;
    }

    bool anotherTransaction = true;
    while (anotherTransaction == true)
    {
        Console.WriteLine("Would you like to make another transaction?");
        string userChoice = Console.ReadLine().ToLower();
        if (userChoice == "yes")
        {
            Console.WriteLine("");
            anotherTransaction = false;
        }
        else if (userChoice == "no")
        {
            anotherTransaction = false;
            keepGoing = false;
        }
        else
        {
            Console.WriteLine("Invalid Input! Please choose Yes or No");
        }
    }    
}

Console.WriteLine("Thank you for banking with us. Have a nice day!");