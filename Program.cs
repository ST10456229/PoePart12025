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
        static string lastTopic = null;
        List<string> topicsList = new List<string>(keywordResponses.Keys);

        // -- DICTIONARY DEFINITIONS --
        static Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
        {
            { "antivirus", new List<string> {
                "Monitors files, downloads, and programs in real time to block threats.",
                "Isolates infected files and removes or repairs them.",
                "Consider using a password manager to keep track of complex passwords.",
                "Blocks malicious websites and phishing attempts."
            }},
            { "cloud", new List<string> {
                "Don’t make sensitive files \"public\" unless necessary.",
                "Use passwords and expiration dates when sharing links.",
                "Choose reputable cloud providers (like Google Drive, OneDrive, Dropbox).",
                "Regularly review who has access to your files."
            }},
            { "privacy", new List<string> {
                "Regularly review privacy settings on social media.",
                "Limit what personal information you share online.",
                "Use encrypted messaging apps for sensitive communication.",
                "Avoid sharing personal information in public forums or unsecured forms."
            }},
            { "browsing", new List<string> {
                "Browsing refers to the act of exploring and navigating the internet using a web browser (e.g., Chrome, Firefox)." +
                " It involves visiting websites, clicking links," +
                " searching for information, watching videos, shopping, " +
                "and interacting with online content.",
                "Always check for \"https://\" and a padlock icon in the address bar before entering sensitive information.",
                "Use the latest version of your browser, OS, and antivirus to patch security flaws.",
                "Avoid logging into banking or sensitive accounts on open networks."
            }},
            { "ransomware", new List<string> {
                "Ransomware encrypts your files and demands payment for their release. Always keep your backups secure.",
                "Never pay the ransom. Instead, restore your data from a reliable backup if affected.",
                "Keep your software updated and use reputable antivirus tools to prevent ransomware attacks."
            }},
            { "malware", new List<string> { 
                "Malware is software designed to harm or exploit your computer. Always use updated antivirus software.",
                "Avoid downloading files or clicking on links from unknown sources to prevent malware infection.",
                "Be cautious when installing software. Only download from trusted, verified sources.",
                "Look for signs of phishing: misspellings, urgency, fake addresses."
            }},
            { "two-factor authentication", new List<string> {
                "Enable two-factor authentication (2FA) on your accounts to add an extra layer of security.",
                "With 2FA, even if your password is compromised, an attacker cannot access your account without the second factor.",
                "Many services offer 2FA through apps like Google Authenticator or via SMS. Always enable it.",
                "Don’t use the same device for both factors (e.g., password and SMS on the same phone) if possible."
            }},
            { "encryption", new List<string> {
                "Encryption protects your data by converting it into unreadable text, only accessible with a decryption key.",
                "Always encrypt sensitive information like emails, files, and communications to prevent unauthorized access.",
                "End-to-end encryption ensures that your messages are read only by the intended recipient.",
                "Regularly backup encrypted data with secure password storage."
            }},
            { "firewall", new List<string> {
                "A firewall monitors and controls incoming and outgoing network traffic, helping to block unauthorized access.",
                "Make sure your firewall is enabled and properly configured to protect your devices from external threats.",
                "There are both hardware and software firewalls. A good firewall is essential for online security.",
                "In businesses, use layered security (firewall + antivirus + encryption)."
            }},
            { "vpn", new List<string> {
                "A Virtual Private Network (VPN) encrypts your internet connection, keeping your data safe from hackers.",
                "Use a VPN when browsing on public Wi-Fi to protect your sensitive data from being intercepted.",
                "A VPN also helps you access content that's restricted in certain regions by masking your IP address.",
                "Websites can't track your real location or identity using your IP address."
            }},
            { "data breach", new List<string> {
                "A data breach occurs when sensitive information is accessed or stolen by unauthorized individuals.",
                "If your personal information is compromised in a data breach, change your passwords immediately and monitor your accounts.",
                "To reduce the risk of a data breach, use strong passwords, enable two-factor authentication, and stay vigilant.",
                "Use trusted VPNs on public Wi-Fi."
            }},
            { "social engineering", new List<string> {
                "Social engineering is when attackers manipulate individuals into divulging confidential information.",
                "Be cautious of unsolicited requests for personal information, even if they seem legitimate.",
                "Don't give out sensitive information over the phone or email unless you're certain about the requester.",
                "Train employees regularly on social engineering tactics"
            }},
        };

        static Dictionary<string, string> emotionResponses = new Dictionary<string, string>()
        {
            { "worried", "It's completely understandable to feel that way. Let me help you stay safe." },
            { "wonder", "I admire your sense of wonder! Let's explore more about this topic together." },
            { "annoyed", "I know it can be confusing, but don't worry - you're doing great learning this stuff." },
            { "happy", "I'm glad you're feeling good! Cybersecurity can be empowering." },
            { "sad", "I'm here to support you. Let's focus on learning how to stay secure." },
            { "angry", "It's okay to be upset. Let's figure out how to prevent issues together." },
        };

        static Dictionary<string, string> emotionKeywords = new Dictionary<string, string>()
        {
            { "uneasy", "worried" },
            { "bothered", "worried" },
            { "confused", "annoyed" },
            { "irritated", "annoyed" },
            { "mad", "angry" },
            { "angry", "angry" },
            { "sad", "sad" },
            { "unhappy", "sad" },
            { "happy", "happy" },
            { "excited", "happy" },
            { "interested", "wonder" },
            { "curious", "wonder" },
            { "worried", "worried" },
            { "annoyed", "annoyed" },
            { "wonder", "wonder" }
        };

        static void Main()
        {
            try
            {
                SoundPlayer MyMusic = null;
                if (OperatingSystem.IsWindows())
                {
                    MyMusic = new SoundPlayer("POEaudio.wav");
                    MyMusic.Load();
                    MyMusic.PlayLooping();
                }

                DisplayPerfectFitAsciiArt("Encryption pic.jpg");

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome! Please enter your name: ");
                string userName = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Hello, {userName}! How can I assist you today?");
                Console.ResetColor();


                List<string> topicsList = new List<string>(keywordResponses.Keys);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nHere are some topics you can ask me about:");
                for (int i = 0; i < topicsList.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {topicsList[i]}");
                }
                Console.WriteLine("\nYou can also tell me how you’re feeling (e.g., 'worried', 'happy'), or type a topic name.\n");
                Console.ResetColor();

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("You: ");
                    string userInput = Console.ReadLine().ToLower();

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("...thinking...");
                    Thread.Sleep(2000);

                    if (userInput == "exit")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bot: Goodbye!");
                        break;
                    }

                    bool responseGiven = false;

                    foreach (var kvp in emotionKeywords)
                    {
                        if (userInput.Contains(kvp.Key))
                        {
                            string emotion = kvp.Value;
                            if (emotionResponses.ContainsKey(emotion))
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"Bot: {emotionResponses[emotion]}");
                                responseGiven = true;
                                break;
                            }
                        }
                    }
                    if (!responseGiven && userInput == "more")
                    {
                        if (lastTopic != null && keywordResponses.ContainsKey(lastTopic))
                        {
                            List<string> responses = keywordResponses[lastTopic];
                            Console.ForegroundColor = ConsoleColor.Green;

                            for (int i = 2; i < responses.Count; i++)
                            {
                                Console.WriteLine($"Bot: {responses[i]}");
                                Thread.Sleep(1000);
                            }

                            Console.ResetColor();
                            responseGiven = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Bot: There’s nothing more to add yet. Try asking about a new topic!");
                            responseGiven = true;
                        }
                    }

                    if (!responseGiven && int.TryParse(userInput, out int topicNumber))
                    {
                        if (topicNumber >= 1 && topicNumber <= topicsList.Count)
                        {
                            string selectedTopic = topicsList[topicNumber - 1];
                            List<string> responses = keywordResponses[selectedTopic];
                            Console.ForegroundColor = ConsoleColor.Green;

                            for (int i = 0; i < Math.Min(2, responses.Count); i++)
                            {
                                Console.WriteLine($"Bot: {responses[i]}");
                                Thread.Sleep(1000);
                            }

                            lastTopic = selectedTopic;
                            responseGiven = true;
                        }
                    }

                    if (!responseGiven)
                    {
                        foreach (var kvp in keywordResponses)
                        {
                            if (userInput.Contains(kvp.Key))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;

                                int maxResponses = Math.Min(2, kvp.Value.Count);
                                for (int i = 0; i < maxResponses; i++)
                                {
                                    Console.WriteLine($"Bot: {kvp.Value[i]}");
                                    Thread.Sleep(1000);
                                }

                                lastTopic = kvp.Key;
                                responseGiven = true;
                                break;
                            }
                        }
                    }
                    if (!responseGiven)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Bot: I don't understand that. Try asking about cybersecurity topics or how you feel.");
                    }

                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        static void DisplayPerfectFitAsciiArt(string imagePath)
        {
            try
            {
                Console.Clear();

                int consoleWidth = Console.WindowWidth - 2;
                int consoleHeight = (Console.WindowHeight - 5) * 2;

                using Bitmap originalImage = new Bitmap(imagePath);

                double widthRatio = (double)consoleWidth / originalImage.Width;
                double heightRatio = (double)consoleHeight / originalImage.Height;
                double scale = Math.Min(widthRatio, heightRatio);

                int newWidth = (int)(originalImage.Width * scale);
                int newHeight = (int)(originalImage.Height * scale / 2.0);

                newWidth = Math.Max(newWidth, 10);
                newHeight = Math.Max(newHeight, 10);

                using Bitmap resizedImage = new Bitmap(originalImage, new Size(newWidth, newHeight * 2));
                using Bitmap grayscaleImage = ConvertToGrayscale(resizedImage);

                const string asciiChars = "@%#*+=-:. ";

                int leftPadding = (Console.WindowWidth - newWidth) / 2;
                int topPadding = (Console.WindowHeight - newHeight) / 2;

                Console.ForegroundColor = ConsoleColor.Cyan;

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
