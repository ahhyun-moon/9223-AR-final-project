using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class SearchResponse
    {
        public string status { get; set; }
        public Result result { get; set; }
    }


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Album
    {
        public string name { get; set; }
        public List<Artist> artists { get; set; }
        public string album_group { get; set; }
        public string album_type { get; set; }
        public string id { get; set; }
        public string uri { get; set; }
        public List<string> available_markets { get; set; }
        public string href { get; set; }
        public List<Image> images { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
    }

    public class AppleMusic
    {
        public List<Preview> previews { get; set; }
        public Artwork artwork { get; set; }
        public string artistName { get; set; }
        public string url { get; set; }
        public int discNumber { get; set; }
        public List<string> genreNames { get; set; }
        public int durationInMillis { get; set; }
        public string releaseDate { get; set; }
        public string name { get; set; }
        public string isrc { get; set; }
        public string albumName { get; set; }
        public PlayParams playParams { get; set; }
        public int trackNumber { get; set; }
        public string composerName { get; set; }
    }

    public class Artist
    {
        public string name { get; set; }
        public string id { get; set; }
        public string uri { get; set; }
        public string href { get; set; }
        public ExternalUrls external_urls { get; set; }
    }

    public class Artwork
    {
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
        public string bgColor { get; set; }
        public string textColor1 { get; set; }
        public string textColor2 { get; set; }
        public string textColor3 { get; set; }
        public string textColor4 { get; set; }
    }

    public class ExternalIds
    {
        public string isrc { get; set; }
    }

    public class ExternalUrls
    {
        public string spotify { get; set; }
    }

    public class Image
    {
        public int height { get; set; }
        public int width { get; set; }
        public string url { get; set; }
    }

    public class PlayParams
    {
        public string id { get; set; }
        public string kind { get; set; }
    }

    public class Preview
    {
        public string url { get; set; }
    }

    public class Result
    {
        public string artist { get; set; }
        public string title { get; set; }
        public string album { get; set; }
        public string release_date { get; set; }
        public string label { get; set; }
        public string timecode { get; set; }
        public string song_link { get; set; }
        public AppleMusic apple_music { get; set; }
        public Spotify spotify { get; set; }
    }

    public class Spotify
    {
        public Album album { get; set; }
        public ExternalIds external_ids { get; set; }
        public int popularity { get; set; }
        public object is_playable { get; set; }
        public object linked_from { get; set; }
        public List<Artist> artists { get; set; }
        public List<string> available_markets { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool @explicit { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string uri { get; set; }
    }


