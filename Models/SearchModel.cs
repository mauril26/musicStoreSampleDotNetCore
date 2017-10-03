using System.Runtime.Serialization;

namespace musicStoreSampleModels
{
    [DataContract]
    public class SearchModel
    {
        [DataMember(Name = "albums", EmitDefaultValue = false)]
        public Albums Albums { get; set; }
        
        [DataMember(Name = "artists", EmitDefaultValue = false)]
        public Artists Artists { get; set; }

        [DataMember(Name = "tracks", EmitDefaultValue = false)]
        public Tracks Tracks { get; set; }
    }
}