using System.Collections.Generic;
using System.Runtime.Serialization;

namespace musicStoreSampleModels
{
    [DataContract]
    public class Tracks
    {
        int Total { get; set; }
        
        [DataMember(Name = "items", EmitDefaultValue = false)]
        List<Track> TracksList = new List<Track>();
    }

    [DataContract]
    public class Track
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        string Name { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        string Id { get; set; }

        [DataMember(Name = "items", EmitDefaultValue = false)]
        string PreviewLink { get; set; }

        [DataMember(Name = "popularity", EmitDefaultValue = false)]
        int Popularity { get; set; }

        [DataMember(Name = "duration_ms", EmitDefaultValue = false)]
        int DurationIsMs { get; set; }

        [DataMember(Name = "track_number", EmitDefaultValue = false)]
        int TracknNumber { get; set; }

        [DataMember(Name = "disc_number", EmitDefaultValue = false)]
        int DiscNumber { get; set; }

        [DataMember(Name = "explicit", EmitDefaultValue = false)]
        bool IsExplicit { get; set; }

        [DataMember(Name = "album", EmitDefaultValue = false)]
        Album Album { get; set; }
    }
}