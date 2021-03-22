using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppHW
{
    public class WebAppHW
    {
        //Singleton pattern
        public static WebAppHW Current { get; private set; } = new WebAppHW();

        public MySnsConfig Config { get; set; }

        private WebAppHW() { }
        public void Initialize()
        {
            var json = File.ReadAllText("C:\\Desktop\\MySnsConfig.json");
            this.Config = JsonConvert.DeserializeObject<MySnsConfig>(json);
        }
    }
}
