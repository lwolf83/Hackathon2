using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Hackathon2
{
    public class ApiRequest
    {
        private static string _baseUrl = "https://www.superheroapi.com/api.php/10158123939161877/";

        public static Character GetCharacter(int idCharacter)
        {
            string postUrl = _baseUrl + idCharacter + "/" ;
            var request = (HttpWebRequest)WebRequest.Create(postUrl);
            request.Method = "GET";
            request.ContentType = "application/xml";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string returnString = readStream.ReadToEnd();
            Character currentCharacter = JsonConvert.DeserializeObject<Character>(returnString);
            return currentCharacter;
        }

    }
}
