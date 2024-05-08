using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace ATM
{
    public class cardHolder
    {
        // CardHolder info
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        double balance;
        //cardHolder Constructor
        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }
        public string getCardNum()
        {
            return cardNum;
        }
        public int getPin()
        {
            return pin;
        }
        public string getFirstName()
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public double getBalance()
        {
            return balance;
        }
        public void setcardNum(string newCardNum)
        {
            cardNum = newCardNum;
        }
        public void setPin(int newPin)
        {
            pin = newPin;
        }
        public void setfirstName(string newfirstName)
        {
            firstName = newfirstName;
        }
        public void setlastName(string newlastName)
        {
            lastName = newlastName;
        }
        public void setbalance(double newbalance)
        {
            balance = newbalance;
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                void printOptions()
                {
                    Console.WriteLine("Please choose from one of the following banking options:");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Show Balance");
                    Console.WriteLine("4. Print Receipt");
                    Console.WriteLine("5. Exit");
                }

                void deposit(cardHolder currentUser)
                {
                    try
                    {
                        Console.WriteLine("How much money would you like to deposit?");
                        double deposit = double.Parse(Console.ReadLine());
                        Console.WriteLine("Processing deposit"); // Display loading message
                                                                 // Simulate processing time
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write(".");
                            System.Threading.Thread.Sleep(500); // Sleep for half a second
                        }
                        currentUser.setbalance(currentUser.getBalance() + deposit);
                        Console.WriteLine("\nYour deposit was successful. Your new balance is: " + currentUser.getBalance());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }

                void withdrawl(cardHolder currentUser)
                {
                    try
                    {
                        Console.WriteLine("How much money would you like to withdraw?");
                        double withdrawal = double.Parse(Console.ReadLine());

                        Console.WriteLine("Processing withdrawal request"); // Display loading message
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write(".");
                            System.Threading.Thread.Sleep(500); // Sleep for half a second
                        }
                        //check if user has enough money in balance
                        if (currentUser.getBalance() < withdrawal)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInsufficient withdrawal Funds. Please try another amount.");
                            Console.ResetColor();
                        }
                        else
                        {
                            currentUser.setbalance(currentUser.getBalance() - withdrawal);
                            Console.WriteLine("\nYour withdrawal was successful. Please collect your cash.");
                            Console.WriteLine("Your remaining balance is: " + currentUser.getBalance());
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");

                    }
                }

                void balance(cardHolder currentUser)
                {
                    try
                    {
                        Console.WriteLine("Retrieving current balance"); // Display loading message
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write(".");
                            System.Threading.Thread.Sleep(500); // Sleep for half a second
                        }

                        Console.WriteLine("\nCurrent balance:" + currentUser.getBalance());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                void receipt(cardHolder currentUser)
                {
                    // Prompt the user if they want a receipt
                    Console.WriteLine("Do you want a receipt? (Y/N)");
                    string response = Console.ReadLine().ToUpper();
                    if (response == "Y")
                    {
                        // Print the receipt
                        Console.WriteLine("*************Receipt:***************");
                        Console.WriteLine($"Name: {currentUser.getFirstName()} {currentUser.getLastName()}");
                        Console.WriteLine($"Balance: {currentUser.getBalance()}");
                    }
                   
                }

                //Database of users and their info
                List<cardHolder> cardHolders = new List<cardHolder>()
            {
                new cardHolder("123456789", 1234, "Luke", "James", 100000.00),
                new cardHolder("987654321", 4321, "Kyle", "Bow", 120000.21),
                new cardHolder("121212121", 6789, "Kat", "Filler", 1000000.14),
                new cardHolder("212121212", 9876, "Sara", "Lowe", 75000.00),
                new cardHolder("741852963", 0123, "Zack", "Gray", 55750.20),
            };
                //prompt user
                Console.WriteLine("------------------Welcome to New world ATM-----------------------");
                Console.WriteLine("Your simple gateway into the banking world!!!!!!!!");
                Console.WriteLine("Please enter your Debit card");
                string debitCardNum = "";
                cardHolder currentUser = null;
                int CardattemptsLeft = 5; // Set the maximum number of attempts
                while (CardattemptsLeft > 0)
                {
                    try
                    {
                        debitCardNum = Console.ReadLine();
                        //Checking user in database
                        currentUser = cardHolders.FirstOrDefault(a => a.getCardNum() == debitCardNum);
                        if (currentUser != null)
                        {
                            break;
                        }
                        else
                        {
                            CardattemptsLeft--; // Decrement attempts left
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Incorrect Debit card number! Please try again. Remaining attempts: {CardattemptsLeft}/{5}");
                            Console.ResetColor();
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Incorrect Debit card number! Please try again. Remaining attempts: {CardattemptsLeft}/{5}");
                        Console.ResetColor();
                    }
                    if (CardattemptsLeft == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have exceeded the maximum number of attempts. Your account is locked.\nPlease contact the nearest branch to assist you");
                        Console.ResetColor();
                        return; // Exit the program or handle account locking logic
                    }
                }
                int userpin = 0;

                int attemptsLeft = 3; // Set the maximum number of attempts

                while (attemptsLeft > 0)
                {
                    Console.WriteLine("Please remember to keep your pin number confidential to avoid scams!!\n");
                    Console.WriteLine("Please enter your pin number:");
                    try
                    {
                        userpin = GetMaskedPin();
                        if (currentUser.getPin() == userpin)
                        {
                            break;
                        }
                        else
                        {
                            attemptsLeft--; // Decrement attempts left
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Incorrect pin! Please try again. Remaining attempts: {attemptsLeft}/{3}");
                            Console.ResetColor();
                        }
                    }
                    catch
                    {
                        attemptsLeft--; // Decrement attempts left
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Incorrect pin! Please try again. Remaining attempts: {attemptsLeft}/{3}");
                        Console.ResetColor();
                    }
                    if (attemptsLeft == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have exceeded the maximum number of attempts. Your account is locked.\nPlease contact the nearest branch to assist you");
                        Console.ResetColor();
                        return; // Exit the program or handle account locking logic
                    }
                    // Method to read masked PIN input
                    static int GetMaskedPin()
                    {
                        string pin = "";
                        ConsoleKeyInfo key;

                        do
                        {
                            key = Console.ReadKey(true);

                            if (char.IsDigit(key.KeyChar))
                            {
                                pin += key.KeyChar;
                                Console.Write("*");
                            }
                            else if (key.Key == ConsoleKey.Backspace && pin.Length > 0)
                            {
                                pin = pin.Remove(pin.Length - 1);
                                Console.Write("\b \b");
                            }
                        } while (key.Key != ConsoleKey.Enter);

                        Console.WriteLine(); // Move to the next line after PIN input
                        return int.Parse(pin);
                    }
                }

                Console.WriteLine("Checking Credentials");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500); // Sleep for half a second
                }

                Console.WriteLine("\nWelcome back " + currentUser.getFirstName() + " " + currentUser.getLastName() + " how can we assist you today?");

                int option = 0;
                bool printReceipt = true;
                do
                {
                    printOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Invalid option! Please try again.");
                    }
                    if (option == 1)
                    {
                        deposit(currentUser);
                    }
                    else if (option == 2)
                    {
                        withdrawl(currentUser);
                    }
                    else if (option == 3)
                    {
                        balance(currentUser);
                    }
                    else if (option == 4)
                    {
                        // Check if the user wants a receipt
                        receipt(currentUser);
                        if (printReceipt)
                        {
                            // Continue the loop
                            continue;
                        }
                    }
                    else if (option == 5)
                    {
                        Console.WriteLine("Thank you for using our ATM");
                        Console.WriteLine("Logging Out");
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write(".");
                            Thread.Sleep(500); // Sleep for half a second
                        }
                        break;
                    }
                    else
                    {
                        option = 0;
                    }
                } while (option != 5);

                Console.ReadKey();
            }

        }

    }
}
