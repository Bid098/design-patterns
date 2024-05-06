using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Ex001
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            VideoPlayer video01 = new VideoPlayer("pippo");
            VideoPlayer video02 = new VideoPlayer("pluto");
            VideoPlayer video03 = new VideoPlayer("paperino");
            AudioPlayer audio01 = new AudioPlayer("qui");
            AudioPlayer audio02 = new AudioPlayer("quo");
            AudioPlayer audio03 = new AudioPlayer("qua");

            //adapter: ho aggiunto gli adattatori delle classi videoplayer e audioplayer, ho aggiunto una classe contenitore che mi lanci il play sy ogni media

            AudioPlayerAdapter audioPlayerAdapter01 = new AudioPlayerAdapter(audio01);
            AudioPlayerAdapter audioPlayerAdapter02 = new AudioPlayerAdapter(audio02);
            AudioPlayerAdapter audioPlayerAdapter03 = new AudioPlayerAdapter(audio03);

            MediaPlayers mediaPlayers = new MediaPlayers();

            mediaPlayers.AddMedia(new VideoPlayerAdapter(video01));
            mediaPlayers.AddMedia(new VideoPlayerAdapter(video02));
            mediaPlayers.AddMedia(new VideoPlayerAdapter(video03));
            
            mediaPlayers.AddMedia(new AudioPlayerAdapter(audio01));
            mediaPlayers.AddMedia(new AudioPlayerAdapter(audio02));
            mediaPlayers.AddMedia(new AudioPlayerAdapter(audio03));
            
            System.Console.WriteLine();
            System.Console.WriteLine("avvio qui:");
            mediaPlayers.playMediasByName("qui");
            System.Console.WriteLine();

            
            System.Console.WriteLine("avvio il resto:");
            mediaPlayers.playAllMedias();
            System.Console.WriteLine();

            //decorator
            LoggingMediaPlayer loggingMediaPlayer = new LoggingMediaPlayer(new AudioPlayerAdapter(audio02));
            loggingMediaPlayer.play();

            
            FilterMediaPlayer filterMediaPlayer = new FilterMediaPlayer(new VideoPlayerAdapter(video02));
            filterMediaPlayer.play_with_filters("filtro 1");
        }
    }

    internal class FilterMediaPlayer : MediaPlayer
    {
        public FilterMediaPlayer(IMedia media) : base(media)
        {
        }

        public void play_with_filters(string filters)
        {
            System.Console.WriteLine($"fa qualcosa con i filtri {filters}");
            base.play();
        }
    }


    internal class LoggingMediaPlayer: MediaPlayer
    {
        public LoggingMediaPlayer(IMedia media) : base(media)
        {

        }

        public override void play()
        {
            base.play();
            System.Console.WriteLine($"log of media named: {base.name}");
        }
    }

    internal class MediaPlayer : IMedia
    {
        private IMedia _media {get;}
        
        public string name => _media.name;

        public virtual void play()
        {
            _media.play();
        }

        public MediaPlayer(IMedia media)
        {
            _media = media;
        }
    }

    internal class MediaPlayers
    {
        private List<IMedia> medias = new List<IMedia>();

        public void AddMedia(IMedia media) => 
            medias.Add(media);

        public void playMediasByName (string name) => 
            medias.ForEach(media => { if(media.name == name) media.play(); } );

        public void playAllMedias() => 
            medias.ForEach(media => media.play());
    }

    internal interface IMedia
    {
        public string name {get;}
        public void play();
    }

    internal class VideoPlayerAdapter : IMedia
    {
        VideoPlayer _videoPlayer;
        public string name => _videoPlayer.getName();

        public void play() => _videoPlayer.start_video();

        public VideoPlayerAdapter(VideoPlayer videoPlayer) =>
            _videoPlayer = videoPlayer;
            
    }

    internal class AudioPlayerAdapter : IMedia
    {
        AudioPlayer _audioPlayer;
        public string name => _audioPlayer.getName();

        public void play() => _audioPlayer.play_audio();

        public AudioPlayerAdapter(AudioPlayer videoPlayer) =>
            _audioPlayer = videoPlayer;
            
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

        public string getName() => _name;
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
        
        public string getName() => _name;
    }
}