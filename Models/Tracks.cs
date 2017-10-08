using System.Collections.Generic;
using System.Runtime.Serialization;

namespace musicStoreSampleModels
{
    [DataContract]
    public class Tracks
    {
        int Total { get; set; }

        [DataMember(Name = "Items", EmitDefaultValue = false)]
        List<Track> TracksList = new List<Track>();
    }

    [DataContract]
    public class TopTracks
    {
        int Total { get; set; }

        [DataMember(Name = "Tracks", EmitDefaultValue = false)]
        List<TopTrack> TopTracksList = new List<TopTrack>();
    }

    [DataContract]
    public class Track
    {
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        string Name { get; set; }

        [DataMember(Name = "Id", EmitDefaultValue = false)]
        string Id { get; set; }

        [DataMember(Name = "Items", EmitDefaultValue = false)]
        string PreviewLink { get; set; }

        [DataMember(Name = "Popularity", EmitDefaultValue = false)]
        int Popularity { get; set; }

        [DataMember(Name = "Duration_ms", EmitDefaultValue = false)]
        int DurationIsMs { get; set; }

        [DataMember(Name = "Track_number", EmitDefaultValue = false)]
        int TracknNumber { get; set; }

        [DataMember(Name = "Disc_number", EmitDefaultValue = false)]
        int DiscNumber { get; set; }

        [DataMember(Name = "Explicit", EmitDefaultValue = false)]
        bool IsExplicit { get; set; }

        [DataMember(Name = "Album", EmitDefaultValue = false)]
        Album Album { get; set; }
    }

    [DataContract]
    public class TopTrack : Track
    {
        [DataMember(Name = "Album", EmitDefaultValue = false)]
        Album album { get; set; }

        [DataMember(Name = "Artists", EmitDefaultValue = false)]  
        List<Artist> artists { get; set; }


    }
}