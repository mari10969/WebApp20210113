using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HigLabo.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;


namespace WebAppHW.Controllers
{
    public class HomeController:Controller
    {
        [HttpGet("/")]
        public IActionResult Root()
        {
            return this.View();

        }
        [HttpGet("/Signup")]
        public IActionResult Signup()
        {
            return this.View();
        }
        [HttpPost("/Api/Signup")]
        public async Task<Object> Api_Signup()
        {
            var json = await GetRequestBodyText();
            var rPlayer = JsonConvert.DeserializeObject<PlayerRecord>(json);

            var db = new SqlServerDatabase(WebAppHW.Current.Config.ConnectionString);

            var cm = new SqlCommand();
            cm.CommandText = "insert into [Player] (PlayerCD,PlayerName,ID,AppName)"
             + "values(@PlayerCD,@PlayerName,@ID,@AppName)";
            cm.Parameters.AddWithValue("@PlayerCD", Guid.NewGuid());
            cm.Parameters.AddWithValue("@PlayerName",rPlayer.PlayerName);
            cm.Parameters.AddWithValue("@ID",rPlayer.ID);
            cm.Parameters.AddWithValue("@rAppName",rPlayer.AppName);

            var insertCount = db.ExecuteCommand(cm);

            return "実行完了";

        }
        private async Task<String>GetRequestBodyText()
        {
            Request.EnableBuffering();
            Request.Body.Position = 0;
            var m = new MemoryStream();
            await Request.Body.CopyToAsync(m);
            var bb = m.ToArray();
            var text = Encoding.UTF8.GetString(bb);
            return text;

        }
    }
}
