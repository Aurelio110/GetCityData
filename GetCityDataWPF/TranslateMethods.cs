using GTranslatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTranslatorAPI;

namespace GetCityDataWPF
{
    public class TranslateMethods
    {
        public async Task<string> GetTranslatedCountry(string country)
        {
            GTranslatorAPIClient translatorClient = new GTranslatorAPIClient();

            Translation translation = await translatorClient.TranslateAsync(Languages.en, Languages.de, country);

            return translation.TranslatedText;

        }
        public async Task<string> GetTranslatedState(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                return "Unbekanntes Bundesland";
            }
            GTranslatorAPIClient translatorClient = new GTranslatorAPIClient();
            Translation translation = await translatorClient.TranslateAsync(Languages.en, Languages.de, state);
            return translation.TranslatedText;
        }


    }
}
