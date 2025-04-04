// See https://aka.ms/new-console-template for more information
using System;
using System.Drawing;
using System.Media;
using System.Collections.Generic;
using System.Threading;

namespace PoePart1
{
    class SoundPlayerProgram
    {
        static List<string> modules = new List<string>();
        static List<string> courses = new List<string>();

        static void Main()
        {
            
            DisplayLogo();

            
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer MyMusic = new SoundPlayer("POEaudio.wav");
                MyMusic.Load();
                MyMusic.PlayLooping();
            }

            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome! Please enter your name: ");
            string userName = Console.ReadLine();

            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Hello, {userName}! How can I assist you today?");
            Console.ResetColor();

            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("You: ");
                string userInput = Console.ReadLine().ToLower();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("...thinking...");
                Thread.Sleep(1000);

                if (userInput == "how are you?")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Program: I'm just a program, but thanks for asking! :)");
                }
                else if (userInput == "what's your purpose?" || userInput == "what is your purpose?")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Program: My purpose is to assist you with various tasks and provide information on cybersecurity.");
                }
                else if (userInput == "what is a phishing email?")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: A phishing email is a fraudulent email designed to trick you into providing sensitive information, such as passwords or banking details.");
                }
                else if (userInput == "how to protect against phishing?")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: Avoid clicking on suspicious links, verify sender identities, enable two-factor authentication, and use email filtering tools.");
                }
                else if (userInput == "importance of strong passwords")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: Strong passwords protect your accounts from unauthorized access by making it harder for attackers to guess your credentials.");
                }
                else if (userInput == "how to create a strong password?")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: Use a mix of letters, numbers, and special characters, avoid common words, and make it at least 12 characters long.");
                }
                else if (userInput == "how often should i change my password?")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: It's recommended to change your passwords every 3-6 months or immediately if you suspect a security breach.");
                }
                else if (userInput == "how can i identify safe and suspicious emails?")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: Be cautious of emails with urgent requests, unexpected attachments, spelling errors, or unfamiliar senders. Always verify links before clicking.");
                }
                else if (userInput == "what is malware?")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: Malware is malicious software designed to damage, disrupt, or gain unauthorized access to computer systems. Examples include viruses, worms, and ransomware.");
                }
                else if (userInput == "how to see malware?")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: Malware can be detected using antivirus software, unusual system behavior, slow performance, unexpected pop-ups, or unauthorized access to files.");
                }
                else if (userInput == "how to protect against malware?")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: Keep your software updated, use reliable antivirus software, avoid suspicious downloads, and enable firewalls.");
                }
                else if (userInput == "how to see phishing?")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Program: Phishing can be spotted through suspicious emails, fake login pages, urgent requests for personal information, and links that lead to fraudulent websites.");
                }
                else if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Program: Goodbye!");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Program: I don't understand that. Try asking something else or type 'exit' to quit.");
                }

                Console.ResetColor();
            }
        }

        static void DisplayLogo()
        {
            Console.Clear();
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            string logoText = "CyberSecurity Awareness Bot";
            int repeatCount = consoleWidth / logoText.Length;
            string logoLine = new string('*', consoleWidth);

            for (int i = 0; i < consoleHeight; i++)
            {
                if (i == consoleHeight / 2)
                {
                    int padding = (consoleWidth - logoText.Length) / 2;
                    string centeredLogo = new string(' ', padding) + logoText;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(centeredLogo);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(logoLine);
                }
            }

            System.Threading.Thread.Sleep(4000);
            Console.ResetColor();
        }
    }
}

