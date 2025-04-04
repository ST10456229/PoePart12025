// See https://aka.ms/new-console-template for more information
using System;
using System.Drawing;
using System.Media;
using System.Collections.Generic;
using System.Threading;

namespace PoePart1
{
    
    //-- MAIN PROGRAM CLASS --
    
    class SoundPlayerProgram
    {
        
        //-- CLASS VARIABLES --
        
        static List<string> modules = new List<string>();
        static List<string> courses = new List<string>();

        
        //-- MAIN PROGRAM ENTRY POINT --
        
        static void Main()
        {
            try
            {
               
                //-- INITIALIZATION SECTION --
               
                // Start audio playback
                SoundPlayer MyMusic = null;
                if (OperatingSystem.IsWindows())
                {
                    MyMusic = new SoundPlayer("POEaudio.wav");
                    MyMusic.Load();
                    MyMusic.PlayLooping();
                }

                // Display ASCII art
                DisplayPerfectFitAsciiArt("Encryption pic.jpg");

                
                //-- USER INTRODUCTION SECTION --
                
                // Clear console properly before user input
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome! Please enter your name: ");
                string userName = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Hello, {userName}! How can I assist you today?");
                Console.ResetColor();

                
                //-- CHATBOT INTERACTION LOOP --
                
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("You: ");
                    string userInput = Console.ReadLine().ToLower();

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("...thinking...");
                    Thread.Sleep(3000);

                    
                    //-- CHATBOT RESPONSE HANDLING --
                    
                    if (userInput == "how are you?")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Program: I'm just a program, but thanks for asking! :)");
                    }
                    else if (userInput == "what's your purpose?" || userInput == "what is your purpose?")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Program: My purpose is to assist you with various tasks and " +
                            "provide information on cybersecurity.");
                    }
                    else if (userInput == "what is a phishing email?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: A phishing email is a fraudulent email" +
                            " designed to trick you into providing sensitive information," +
                            " such as passwords or banking details.");
                    }
                    else if (userInput == "how to protect against phishing?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: Avoid clicking on suspicious links," +
                            " verify sender identities, enable two-factor authentication," +
                            " and use email filtering tools.");
                    }
                    else if (userInput == "importance of strong passwords")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: Strong passwords protect your accounts from" +
                            " unauthorized access by making it harder for attackers to guess your credentials.");
                    }
                    else if (userInput == "how to create a strong password?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: Use a mix of letters, numbers, and special characters," +
                            " avoid common words, and make it at least 12 characters long.");
                    }
                    else if (userInput == "how often should i change my password?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: It's recommended to change your passwords every 3-6 months" +
                            " or immediately if you suspect a security breach.");
                    }
                    else if (userInput == "how can i identify safe and suspicious emails?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: Be cautious of emails with urgent requests, " +
                            "unexpected attachments, spelling errors, or unfamiliar senders. " +
                            "Always verify links before clicking.");
                    }
                    else if (userInput == "what is malware?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: Malware is malicious software designed to damage," +
                            " disrupt, or gain unauthorized access to computer systems." +
                            " Examples include viruses, worms, and ransomware.");
                    }
                    else if (userInput == "how to see malware?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: Malware can be detected using antivirus software," +
                            " unusual system behavior, slow performance, unexpected pop-ups, " +
                            "or unauthorized access to files.");
                    }
                    else if (userInput == "how to protect against malware?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: Keep your software updated, use reliable antivirus software," +
                            " avoid suspicious downloads, and enable firewalls.");
                    }
                    else if (userInput == "how to see phishing?")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Program: Phishing can be spotted through suspicious emails, " +
                            "fake login pages, urgent requests for personal information, " +
                            "and links that lead to fraudulent websites.");
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
                        Console.WriteLine("Program: I don't understand that. " +
                            "Try asking something else or type 'exit' to quit.");
                    }

                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                
                //-- ERROR HANDLING SECTION --
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        
        //-- ASCII ART DISPLAY METHODS --
        
        static void DisplayPerfectFitAsciiArt(string imagePath)
        {
            try
            {
                Console.Clear();

                
                //-- CONSOLE DIMENSION CALCULATION --
                
                // Get console dimensions with safe margins
                int consoleWidth = Console.WindowWidth - 2;
                int consoleHeight = (Console.WindowHeight - 5) * 2; // Account for character aspect ratio

                using Bitmap originalImage = new Bitmap(imagePath);

                
                //-- IMAGE SCALING CALCULATIONS --
                
                // Calculate scaling while maintaining aspect ratio
                double widthRatio = (double)consoleWidth / originalImage.Width;
                double heightRatio = (double)consoleHeight / originalImage.Height;
                double scale = Math.Min(widthRatio, heightRatio);

                int newWidth = (int)(originalImage.Width * scale);
                int newHeight = (int)(originalImage.Height * scale / 2.0); // Divide by 2 for character aspect

                // Ensure minimum size
                newWidth = Math.Max(newWidth, 10);
                newHeight = Math.Max(newHeight, 10);

                using Bitmap resizedImage = new Bitmap(originalImage, new Size(newWidth, newHeight * 2));
                using Bitmap grayscaleImage = ConvertToGrayscale(resizedImage);

                const string asciiChars = "@%#*+=-:. ";

                
                //-- ASCII ART RENDERING --
                
                // Center the image
                int leftPadding = (Console.WindowWidth - newWidth) / 2;
                int topPadding = (Console.WindowHeight - newHeight) / 2;

                Console.ForegroundColor = ConsoleColor.Cyan;

                // -- Display the ASCII art with bounds checking --
                for (int y = 0; y < newHeight; y++)
                {
                    if (topPadding + y >= Console.WindowHeight) break;

                    Console.SetCursorPosition(leftPadding, topPadding + y);

                    for (int x = 0; x < newWidth; x++)
                    {
                        if (x >= Console.WindowWidth) break;
                        Color pixel = grayscaleImage.GetPixel(x, y * 2);
                        double brightness = (pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11) / 255.0;
                        int charIndex = (int)(brightness * (asciiChars.Length - 1));
                        Console.Write(asciiChars[charIndex]);
                    }
                }

                Console.ResetColor();
                Thread.Sleep(3000);
            }
            catch
            {
                DisplayTextLogo();
            }
        }

        
        //-- FALLBACK TEXT LOGO DISPLAY --
        
        static void DisplayTextLogo()
        {
            Console.Clear();
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            string logoText = "CyberSecurity Awareness Bot";
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
            Thread.Sleep(4000);
            Console.ResetColor();
        }

        
        //-- IMAGE PROCESSING HELPER METHOD --
        
        static Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap grayscale = new Bitmap(original.Width, original.Height);
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayscale.SetPixel(x, y, grayColor);
                }
            }
            return grayscale;
        }
    }
}