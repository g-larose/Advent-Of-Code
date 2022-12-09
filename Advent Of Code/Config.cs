using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code
{
    internal class Config
    {
        [JsonProperty("secret")]
        public string Secret { get; set; } = string.Empty;
    }
}
