using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Benchmarks
{
    public class Config
    {
        [JsonPropertyName("secret")]
        public string Secret { get; set; } = string.Empty;
    }
}
