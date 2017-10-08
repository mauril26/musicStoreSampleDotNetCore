using System.Collections.Generic;
using System.Runtime.Serialization;

namespace musicStoreSampleModels
{
    [DataContract]
    public class Albums
    {
        int Total { get; set; }
 
        [DataMember(Name = "Items", EmitDefaultValue = false)]
        List<Album> AlbumList = new List<Album>();
    }

    [DataContract]
    public class Album
    {
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        string Name { get; set; }

        [DataMember(Name = "Id", EmitDefaultValue = false)]
        string Id { get; set; }

        [DataMember(Name = "Images", EmitDefaultValue = false)]
        JsonImage[] Images { get; set; }

        int TracksAmount { get; set; }

        [DataMember(Name = "Artists", EmitDefaultValue = false)]
        ArtistLite[] ArtistsId { get; set; }
    }
}