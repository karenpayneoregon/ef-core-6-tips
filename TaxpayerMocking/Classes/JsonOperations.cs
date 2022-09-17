using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxpayerLibraryEntityVersion.Models;

namespace TaxpayerMocking.Classes
{
    internal class JsonOperations
    {
        /// <summary>
        /// How to serialize a self-referencing model
        /// * We write the data to a json file do you can examine it
        /// * Deserialize the json back, need to place a breakpoint
        ///   to examine the deserialized data as indicated below.
        /// </summary>
        public static void Convert(List<Taxpayer> taxpayerList)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented

            };

            string json = JsonConvert.SerializeObject(taxpayerList, jsonSerializerSettings);

            File.WriteAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "JsonFiles", "Taxpayer.json"), json);

            List<Taxpayer> taxpayers = JsonConvert.DeserializeObject<List<Taxpayer>>(json);

            // put breakpoint here to examine the list
        }
    }
}
