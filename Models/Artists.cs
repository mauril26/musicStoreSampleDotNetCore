using System.Collections.Generic;
using System.Runtime.Serialization;

namespace musicStoreSampleModels
{
    [DataContract]
    public class Artists
    {
        int Total { get; set; }
        [DataMember(Name = "Items", EmitDefaultValue = false)]
        List<Artist> ArtistsList = new List<Artist>();
    }

    [DataContract]
    public class Artist
    {
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        string Name { get; set; }
        
        [DataMember(Name = "Popularity", EmitDefaultValue = false)]
        int Popularity { get; set; }
        
        [DataMember(Name = "Genres", EmitDefaultValue = false)]
        string[] Genres { get; set; }
        
        [DataMember(Name = "Id", EmitDefaultValue = false)]
        string Id { get; set; }
        
        [DataMember(Name = "Images", EmitDefaultValue = false)]
        JsonImage[] Images { get; set; }
    }

    [DataContract]
    public class ArtistLite
    {
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        string Name { get; set; }

        [DataMember(Name = "Id", EmitDefaultValue = false)]
        string Id { get; set; }
    }

    [DataContract]
    public class JsonImage
    {
        [DataMember(Name = "Width", EmitDefaultValue = false)]
        int width { get; set; }
        
        [DataMember(Name = "Height", EmitDefaultValue = false)]
        int height { get; set; }

        [DataMember(Name = "Url", EmitDefaultValue = false)]
        string url { get; set; }
    }
}