using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Ex001_01
{

    internal class Program1
    {
        private static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    internal class VideoPlayer
    {
        string _name;
        public void start_video()
        {
            System.Console.WriteLine($"video {_name} has been played!");
        }
        
        public VideoPlayer(string name)
        {
            _name = name;
        }
    }

    internal class AudioPlayer
    {
        string _name;
        public void play_audio()
        {
            System.Console.WriteLine($"audio {_name} has been played!");
        }
        
        public AudioPlayer(string name)
        {
            _name = name;
        }
    }
}