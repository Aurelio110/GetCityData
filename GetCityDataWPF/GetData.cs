using GetCityDataWPF;
using GTranslatorAPI;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace GetCityData
{
    public class GetData
    {

        string cityName;


        public GetData(string cityName)
        {
            this.cityName = cityName;
        }
        public async Task<string> PromptCityData()
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
               return "Das Feld darf nicht leer sein!";
            }
            string apiUrl = "https://geocoding-api.open-meteo.com/v1/search";

            RestClient client = new RestClient(apiUrl);
            RestRequest request = new RestRequest();
            request.AddParameter("name", cityName);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful && response.Content != null)
            {

                var deserializedResponse = JsonConvert.DeserializeObject<DataModel.Rootobject>(response.Content);

                if (deserializedResponse?.results != null && deserializedResponse.results.Any())
                {
                    TranslateMethods translateMethods = new TranslateMethods();

                    if (deserializedResponse.results.Length > 1)
                    {
                        byte index = 0;                        
                        Results resultsWindow = new Results();

                        foreach (var result in deserializedResponse.results)
                        {
                            
                            string translationOfCountry = await translateMethods.GetTranslatedCountry(deserializedResponse.results[index].country);
                            string translationOfState = await translateMethods.GetTranslatedState(deserializedResponse.results[index].admin1);
                            index++;
                            resultsWindow.cityName.Text += $"\nName: {result.name}\nStaat: {translationOfCountry}\nBundesland: {translationOfState}\nLandkreis: {result.admin3}\nEinwohnerzahl: {result.population}\nHöhe: {result.elevation} Meter über NN\nLängengrad: {result.longitude}\nBreitengrad: {result.latitude}\n\n";
                        }
                        resultsWindow.ShowDialog();
                        
                        return null;
                    }
                    else
                    {
                        foreach (var result in deserializedResponse.results)
                        {
                            string translationOfCountry = await translateMethods.GetTranslatedCountry(deserializedResponse.results[0].country);
                            string translationOfState = await translateMethods.GetTranslatedState(deserializedResponse.results[0].admin1);
                            
                            return $"Name: {result.name}\nStaat: {translationOfCountry}\nBundesland: {translationOfState}\nLandkreis: {result.admin3}\nEinwohnerzahl: {result.population}\nHöhe: {result.elevation} Meter über NN\nLängengrad: {result.longitude}\nBreitengrad: {result.latitude}";
                        }
                    }
                }
            }            
            return("Keine Ergebnisse gefunden.");
        }
    }
}
           
