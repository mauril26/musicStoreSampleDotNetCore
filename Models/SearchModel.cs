using System.Runtime.Serialization;

namespace musicStoreSampleModels
{
    [DataContract]
    public class SearchModel
    {
        [DataMember(Name = "Albums", EmitDefaultValue = false)]
        public Albums Albums { get; set; }
        
        [DataMember(Name = "Artists", EmitDefaultValue = false)]
        public Artists Artists { get; set; }

        [DataMember(Name = "Tracks", EmitDefaultValue = false)]
        public Tracks Tracks { get; set; }
    }
}