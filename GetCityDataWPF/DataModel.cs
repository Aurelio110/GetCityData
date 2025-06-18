using RestSharp;
using System;
using System.Linq;


namespace GetCityDataWPF
{
    public class DataModel
    {
        public class Rootobject
        {
            public Result[] results { get; set; }
            public float generationtime_ms { get; set; }
        }

        public class Result
        {
            public int id { get; set; }
            public string? name { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public float elevation { get; set; }
            public string? feature_code { get; set; }
            public string? country_code { get; set; }
            public int admin1_id { get; set; }
            public int admin2_id { get; set; }
            public int admin3_id { get; set; }
            public int admin4_id { get; set; }
            public string timezone { get; set; }
            public int population { get; set; }
            public int country_id { get; set; }
            public string? country { get; set; }
            public string? admin1 { get; set; }
            public string? admin2 { get; set; }
            public string? admin3 { get; set; }
            public string? admin4 { get; set; }
            
        }

    }
}

