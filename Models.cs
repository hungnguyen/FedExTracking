using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tracking_api
{
    public class ITrackingNumberInfo
    {
        public string trackingNumber { get; set; }
    }
    public class ITrackingInfo
    {
        public ITrackingNumberInfo trackingNumberInfo { get; set; }
    }

    public class ITracking
    {
        public List<ITrackingInfo> trackingInfo { get; set; }
        public bool includeDetailedScans { get; set; }
    }

    public class IToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        public DateTime createDate { get; set; }
    }

    public class Settings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthUrl { get; set; }
        public string ApiBaseUrl { get; set; }
        public int MaxLimit { get; set; }
    }
}
