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
        public string GetTranslatedCountry(string country)
        {
            GTranslatorAPIClient translatorClient = new GTranslatorAPIClient();

            Translation translation = translatorClient.Translate(Languages.en, Languages.de, country);

            return translation.TranslatedText;

        }
        public string GetTranslatedState(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                return "Unbekanntes Bundesland";
            }
            GTranslatorAPIClient translatorClient = new GTranslatorAPIClient();
            Translation translation = translatorClient.Translate(Languages.en, Languages.de, state);
            return translation.TranslatedText;
        }


    }
}
