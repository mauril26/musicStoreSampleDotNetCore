using System.Runtime.Serialization;

namespace musicStoreSampleModels
{
    [DataContract]
    public class SpotifyAuthorization
    {
        [DataMember(Name = "access_token", EmitDefaultValue = false)]
        public string AccessToken { get; set; }
        
        [DataMember(Name = "token_type", EmitDefaultValue = false)]
        public string TokenType { get; set; }
    
        [DataMember(Name = "expires_in", EmitDefaultValue = false)]
        public int ExpiresIn { get; set; }
    }

}