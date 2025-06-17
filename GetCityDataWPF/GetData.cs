using GetCityDataWPF;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;

namespace GetCityData
{
    public class GetData
    {
        string cityName;
        public GetData(string cityName)
        {
            this.cityName = cityName;
        }
        public string PromptCityData()
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return "Das Feld darf nicht leer sein!";
            }
            string apiUrl = "https://geocoding-api.open-meteo.com/v1/search";

            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            request.AddParameter("name", cityName);
            var response = client.Execute(request);

            if (response.IsSuccessful && response.Content != null)
            {
                var deserializedResponse = JsonConvert.DeserializeObject<DataModel.Rootobject>(response.Content);
                if (deserializedResponse?.results != null && deserializedResponse.results.Any())
                {
                    if (deserializedResponse.results.Length > 1)
                    {
                        Results resultsWindow = new Results();
                        foreach (var result in deserializedResponse.results)
                        {
                            resultsWindow.cityName.Text += $"\nName: {result.name}\nStaat: {result.country}\nBundesland: {result.admin1}\nLandkreis: {result.admin3}\nEinwohnerzahl: {result.population}\nHöhe: {result.elevation} Meter über NN\n\n";
                        }
                        resultsWindow.ShowDialog();
                        return "";
                    }
                    else
                    {
                        foreach (var result in deserializedResponse.results)
                        {
                            return $"\nName: {result.name}\nStaat: {result.country}\nBundesland: {result.admin1}\nLandkreis: {result.admin3}\nEinwohnerzahl: {result.population}\nHöhe: {result.elevation} Meter über NN\n";
                        }
                    }
                }
            }
            return "";
        }
    }
}
