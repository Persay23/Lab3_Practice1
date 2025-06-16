using Psotify.DataModel;
using Psotify.DataModel;
using System.Reflection;

using var db = new PsotifyDbContext();

var pinkFloyd = db.Artists.FirstOrDefault(a => a.Name == "Pink Floyd");
var metallica = db.Artists.FirstOrDefault(a => a.Name == "Metallica");
var nirvana = db.Artists.FirstOrDefault(a => a.Name == "Nirvana");

//db.Songs.AddRange(
//    new Song { Title = "Wish You Were Here", Length = "05:40", Artist = pinkFloyd },
//    new Song { Title = "Comfortably Numb", Length = "06:21", Artist = pinkFloyd }
//);

//db.Songs.Add(
//    new Song { Title = "One", Length = "07:26", Artist = metallica }
//);

//db.Songs.Add(
//    new Song
//    {
//        Title = "Smoke on the Water",
//        Length = "05:40",
//        Artist = new Artist { Name = "Deep Purple" }
//    }
//);
//db.Songs.Add(
//    new Song()
//    {
//        Title = "Smells Like Teenn Spirit",
//        Artist = nirvana}
//    );

//FindtheOne



Console.WriteLine("Songs added successfully.");
// Later I create a functions for this stuff

var ToUpdateSong = db.Songs.FirstOrDefault(s => s.Title == "One");
if (ToUpdateSong != null)
{
    ToUpdateSong.Length = "07:30";
    db.SaveChanges();
}

var ToDeleateSong = db.Songs.FirstOrDefault(s => s.Title == "Smoke on the Water");
if (ToDeleateSong != null)
{
    db.Songs.Remove(ToDeleateSong);
    db.SaveChanges();
}


var songs = db.Songs.Select(s => new
{
    Title = s.Title,
    Length = s.Length,
    ArtistName = s.Artist.Name
}).ToList();

foreach (var song in songs)
{
    Console.WriteLine($"\"{song.Title}\" by {song.ArtistName} ({song.Length})");
}

db.SaveChanges();