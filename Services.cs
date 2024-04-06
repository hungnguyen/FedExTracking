using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tracking_api
{
    internal static class Services
    {
        public static async Task<IToken?> GetToken(Settings settings)
        {
            Console.WriteLine("Getting token...");
            var client = new HttpClient();

            HttpContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("client_id", settings.ClientId),
                new KeyValuePair<string, string>("client_secret", settings.ClientSecret),
                new KeyValuePair<string, string>("grant_type","client_credentials")
            });

            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            content.Headers.ContentType.CharSet = "UTF-8";
            client.DefaultRequestHeaders.ExpectContinue = false;
            HttpResponseMessage response = await client.PostAsync(new Uri(settings.AuthUrl), content);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                var tokenObj = JsonSerializer.Deserialize<IToken>(jsonStr);
                tokenObj!.createDate = DateTime.Now;
                Console.WriteLine("Get token done!");
                return tokenObj;
            }
            else
            {
                Console.WriteLine("Error:" + response.ReasonPhrase);
                return null;
            }
        }

        public static async Task GetStatus(Settings settings, string token, IEnumerable<string> trackingNumber)
        {
            try
            {
                var client = new HttpClient();

                var listTrakingInfo = trackingNumber
                    .Select(num => new ITrackingInfo
                    {
                        trackingNumberInfo = new ITrackingNumberInfo
                        {
                            trackingNumber = num
                        }
                    }).ToList();

                var data = new ITracking
                {
                    includeDetailedScans = true,
                    trackingInfo = listTrakingInfo
                };

                var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Add("X-locale", "en_US");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                content.Headers.ContentType.CharSet = "UTF-8";
                client.DefaultRequestHeaders.ExpectContinue = false;
                HttpResponseMessage response = await client.PostAsync(new Uri($"{settings.ApiBaseUrl}/trackingnumbers"), content);
                if (response.IsSuccessStatusCode)
                {
                    var trackingObj = JsonSerializer.Deserialize<TrackingModel>(await response.Content.ReadAsStringAsync());
                    var mostRecentDate = trackingObj.output.completeTrackResults.Select(x => x.trackResults[0].scanEvents.OrderByDescending(e => e.date).FirstOrDefault());
                    foreach(var date in mostRecentDate)
                    {
                        Console.WriteLine(JsonSerializer.Serialize(date));
                    }
                }
                else
                {
                    Console.WriteLine("Error:" + response.ReasonPhrase);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
}
