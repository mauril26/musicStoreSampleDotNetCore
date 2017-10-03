using System.Collections.Generic;
using System.Runtime.Serialization;

namespace musicStoreSampleModels
{
    [DataContract]
    public class Artists
    {
        int Total { get; set; }
        [DataMember(Name = "items", EmitDefaultValue = false)]
        List<Artist> ArtistsList = new List<Artist>();
    }

    [DataContract]
    public class Artist
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        string Name { get; set; }
        
        [DataMember(Name = "popularity", EmitDefaultValue = false)]
        int Popularity { get; set; }
        
        [DataMember(Name = "genres", EmitDefaultValue = false)]
        string[] Genres { get; set; }
        
        [DataMember(Name = "id", EmitDefaultValue = false)]
        string Id { get; set; }
        
        [DataMember(Name = "images", EmitDefaultValue = false)]
        JsonImage[] Images { get; set; }
    }

    [DataContract]
    public class ArtistLite
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        string Name { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        string Id { get; set; }
    }

    [DataContract]
    public class JsonImage
    {
        [DataMember(Name = "width", EmitDefaultValue = false)]
        int width { get; set; }
        
        [DataMember(Name = "height", EmitDefaultValue = false)]
        int height { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false)]
        string url { get; set; }
    }
}