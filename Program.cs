using System;
using System.Collections.Generic;

public class Playlist
{
    private readonly List<string> tracks = new List<string>();

    public void Add(string title)
    {
        tracks.Add(title);
    }

    public string this[int position]
    {
        get
        {
            if (position < 0 || position >= tracks.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Позиция выходит за пределы списка.");
            }
            return tracks[position];
        }
        set
        {
            if (position < 0 || position >= tracks.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Позиция выходит за пределы списка.");
            }
            tracks[position] = value;
        }
    }

    public int this[string title]
    {
        get
        {
            return tracks.IndexOf(title);
        }
    }

    public override string ToString()
    {
        List<string> result = new List<string>();
        for (int i = 0; i < tracks.Count; i++)
        {
            result.Add($"{i}: {tracks[i]}");
        }
        return string.Join(", ", result);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var playlist = new Playlist();
        playlist.Add("Track A");
        playlist.Add("Track B");
        playlist.Add("Track C");

        Console.WriteLine(playlist[1]);
        Console.WriteLine(playlist["Track C"]);
        Console.WriteLine(playlist["Track Z"]);

        playlist[0] = "New Track A";
        Console.WriteLine(playlist);
    }
}