using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace OverwatchDataExtraction
{
    class HeroData
    {
        public string HeroName { get; set; }
        public string value { get; set; }
    }

    class Class1
    {

        static string datacaller(string serverid, string username, int userid)
        {
            string sURL = "https://extraction.import.io/query/extractor/5fe41c36-7a60-427b-9ae1-387236ae54ec?_apikey=5a8f35cc8a1a42f1b77c2cf4e2b8c04617c31b325c97d8d3867d163f8196908f5307a7dcce1546a6be5497e3f609f67be66b74e352039c4394dda25163b2e1616271f89a595e0f0395cb990685568477&url=https://playoverwatch.com/en-us/career/pc/" + serverid + "/" + username + "-" + userid;
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(sURL);
            }
        }

        static List<HeroData>[] datahandling(string dat)
        {
            #region variabledefinitions
            JObject o = JObject.Parse(dat);
            var z = o["extractorData"];
            var k = z["data"].First.First.First;
            List<HeroData> dat0 = new List<HeroData>();
            List<HeroData> dat1 = new List<HeroData>();
            List<HeroData> dat2 = new List<HeroData>();
            List<HeroData> dat3 = new List<HeroData>();
            List<HeroData> dat4 = new List<HeroData>();
            List<HeroData> dat5 = new List<HeroData>();
            List<HeroData> dat6 = new List<HeroData>();
            List<HeroData> dat7 = new List<HeroData>();
            int counter = 0;
            #endregion
            foreach (var u in k)
            {
                List<JToken> lst = new List<JToken>();
                HeroData dataa = new HeroData();
                int i = 0;
                foreach (var v in u)
                {
                    if (i == 1)
                    {
                        dataa.HeroName = v.First.First.First.First.ToString();
                    }
                    if (i == 2)
                    {
                        dataa.value = v.First.First.First.First.ToString();
                    }
                    i++;
                }
                #region datasplittinglogic
                if (counter < 21)
                {
                    dat0.Add(dataa);
                }
                else if (counter < 42)
                {
                    dat1.Add(dataa);
                }
                else if (counter < 63)
                {
                    dat2.Add(dataa);
                }
                else if (counter < 84)
                {
                    dat3.Add(dataa);
                }
                else if (counter < 105)
                {
                    dat4.Add(dataa);
                }
                else if (counter < 126)
                {
                    dat5.Add(dataa);
                }
                else if (counter < 147)
                {
                    dat6.Add(dataa);
                }
                else if (counter < 168)
                {
                    dat7.Add(dataa);
                }
                #endregion
                counter++;
            }
            return new List<HeroData>[] { dat0, dat1, dat2, dat3, dat4, dat5, dat6, dat7 };
        }

        static void Main(string[] args)
        {
            var x = datacaller("eu", "kuzma", 21830);
            var m = datahandling(x);
            Console.ReadLine();
        }
    }
}