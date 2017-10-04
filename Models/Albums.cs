using System.Collections.Generic;
using System.Runtime.Serialization;

namespace musicStoreSampleModels
{
    [DataContract]
    public class Albums
    {
        int Total { get; set; }
 
        [DataMember(Name = "items", EmitDefaultValue = false)]
        List<Album> AlbumList = new List<Album>();
    }

    [DataContract]
    public class Album
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        string Name { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        string Id { get; set; }

        [DataMember(Name = "images", EmitDefaultValue = false)]
        JsonImage[] Images { get; set; }

        int TracksAmount { get; set; }

        [DataMember(Name = "artists", EmitDefaultValue = false)]
        ArtistLite[] ArtistsId { get; set; }
    }
}