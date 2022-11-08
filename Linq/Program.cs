using Linq.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace Linq.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            //============ creating text files ===========================================
            // string hoodPath = "../new-neighborhood-data.txt";

            string newHoodPath = "../new-neighborhood-data.txt";

            // fileCreateNewFile(newHoodPath, hoodResult);



            //============================================================================
            string fileName = "data.json";
            string jsonString = File.ReadAllText(fileName);
            JObject hoodFile = JObject.Parse(jsonString);

            IList<JToken> listResults = hoodFile["features"].Children().ToList();

            IList<Features> searchResults = new List<Features>();

            List<string?> hoodResult = new List<string?>();
            // List<string?> boroughResult = new List<string?>();
            // List<string?> cityResult = new List<string>();
            // List<string?> stateResult = new List<string?>();
            // List<string?> zipResult = new List<string>();

            foreach (JToken result in listResults)
            {
                Features searchResult = result.ToObject<Features>();
                hoodResult.Add(searchResult.Properties.Neighborhood);
                // cityResult.Add(searchResult.Properties.City);
                // stateResult.Add(searchResult.Properties.State);
                // boroughResult.Add(searchResult.Properties.Borough);
                // zipResult.Add(searchResult.Properties.Zip);


            }//foreach jTOKEN

            Console.WriteLine(hoodResult.Count);

            //no duplicates, no missing neighboorhoods
            // IEnumerable<string> neighborhoods = hoodResult;
            // IEnumerable<string> neighborhoods = hoodResult.Distinct(); //this is the one

            // //Linq 
            // IEnumerable<string> neighborhoods = (from result in hoodResult
            //                                      select result).Distinct();

            // // IEnumerable<string> zips = zipResult.Distinct();
            // int hoodCount = 0; // this is the one

            // foreach (var neighborhood in neighborhoods)
            // {
            //     if (neighborhood == "")
            //     {
            //         continue;
            //     }
            //     hoodCount++;
            //     Console.WriteLine($"{hoodCount}: {neighborhood}");
            // }


            // string[] arrHoodResult = new string[hoodResult.Count];
            
            fileCreateNewFile(newHoodPath, hoodResult);

            void fileCreateNewFile(string file, List<string> hoodResult)
            {

                IEnumerable<string> neighborhoods = hoodResult.Distinct();

                int hoodCount = 0; // this is the one

                try
                {
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        try
                        {
                            foreach (var neighborhood in neighborhoods)
                            {
                                if (neighborhood == "")
                                {
                                    continue;
                                }
                                hoodCount++;
                                sw.WriteLine($"{hoodCount}: {neighborhood}");
                            }//foreach
                        }//try
                        catch (Exception e)
                        {
                            throw;
                        }//catch
                        finally
                        {
                            sw.Close();
                        }
                    }//using
                }//try
                catch (System.Exception)
                {

                    throw;
                }
            }//fileCreateNewFile


            // foreach (var zip in zips)
            // {
            //     zipCount++;
            //     Console.WriteLine($"{zipCount}: {zip}");
            // }

        }//main
    }//class Program
}//namespace Linq.Classes






// namespace Linq.Classes
// {
//     class Program
//     {

//         static void Main(string[] args)
//         {
//             string fileName = "theatre.json";
//             string jsonString = File.ReadAllText(fileName);
//             JObject theatreFile = JObject.Parse(jsonString);
//             // Console.WriteLine(theatreFile.ToString());

//             JToken[] actorToken = theatreFile["actors"].Children().ToArray();
//             Actors actors = new Actors();
//             actors.names = new List<string>();

//             IList<JToken> crewToken = theatreFile["crew"].Children().ToList();
//             Crew crew = new Crew();
//             crew.position = new List<string>();


//             foreach (JToken actor in actorToken)
//             {
//                 //    Console.WriteLine($"{actor.ToString()}\n");
//                 actors.names.Add(actor.ToString());
//             }

//             foreach (JToken member in crewToken){
//                 crew.position.Add(member.ToString());
//             }

//             var actorQuery = from person in actors.names select person;

//             var crewQuery = from member in crew.position select member;


//             foreach (var item in actorQuery)
//             {
//                 Console.WriteLine(item);
//             }

//             foreach(var item in crewQuery){
//                 Console.WriteLine(item);
//             }
//         }
//     }
// }





// using System.Text.Json;

// namespace SerializeExtra
// {

//     public class WeatherForecast
//     {
//         public DateTime Date { get; set; }
//         public int TempFarenheit { get; set; }
//         public string? Summary { get; set; }
//         public Dictionary<string, HighLowTemps>? TempRanges { get; set; }

//     }

//     public class HighLowTemps
//     {
//         public int High { get; set; }
//         public int Low { get; set; }
//     }


//     class Program
//     {

//         static void Main(string[] args)
//         {

//             string fileName = "WeatherForecast.json";
//             string jsonFile = File.ReadAllText(fileName);
//             WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonFile)!;

//             Console.Clear();

//             Console.WriteLine($"Date: {weatherForecast.Date}");
//             Console.WriteLine($"Temperature: {weatherForecast.TempFarenheit}");
//             Console.WriteLine($"Summary: {weatherForecast.Summary}");

//         }



//     }
// }


// using System.Text.Json;

// namespace Whatever
// {
//     public class WeatherForecast
//     {
//         public DateTime Date { get; set; }
//         public int TempFarenheit { get; set; }
//         public string? Summary { get; set; }
//         public Dictionary<string, HighLowTemps>? TempRanges{get; set; }
//     }
//     public class HighLowTemps
//     {
//         public int High { get; set; }
//         public int Low { get; set; }
//     }
//     public class Program
//     {

//         static void Main(string[] args)
//         {

//             var weather = new WeatherForecast
//             {
//                 Date = DateTime.Parse("2022-10-31"),
//                 TempFarenheit = 61,
//                 Summary = "Chill in the air.",
//                 TempRanges = new Dictionary<string, HighLowTemps>
//                 {
//                     ["Cold"] = new HighLowTemps { High = 50, Low = 10 },
//                     ["Cool"] = new HighLowTemps { High = 69, Low = 51 },
//                     ["Hot"] = new HighLowTemps { High = 100, Low = 70 },
//                 }


//             };// Weather

//             //CREATES A JSON FILE
//             string fileName = "WeatherForecast.json";
//             var options = new JsonSerializerOptions{WriteIndented = true};
//             string weatherJSON = JsonSerializer.Serialize(weather, options);
//             string anotherWeatherJSON = JsonSerializer.Serialize(weather, options);
//             File.WriteAllText(fileName, weatherJSON);

//             Console.WriteLine(File.ReadAllText(weatherJSON));

//         }//Main

//     }//Program
// }//namespace Whatever

