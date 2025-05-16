using System;
using NAudio.Wave;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            PlayVoiceGreeting();
            Console.ForegroundColor = ConsoleColor.Green;
            DisplayAsciiLogo();
            Console.ResetColor();
            Console.Write("\nEnter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"\nWelcome, {userName}! Let's keep you safe online.");
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                using (var audioFile = new AudioFileReader("voice_greeting.wav"))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing voice greeting: {ex.Message}");
            }
        }

        static void DisplayAsciiLogo()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("  CYBERSECURITY AWARENESS BOT ");
            Console.WriteLine("=============================");
        }
    }
}
