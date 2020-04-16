using System;
using System.Collections.Generic;
using System.Net;

public class Image
{
    public string Url { get; set; }


    public bool CheckUrlExist()
    {
        Uri urlCheck = new Uri(Url);
        WebRequest request = WebRequest.Create(urlCheck);
        request.Timeout = 15000;

        WebResponse response;
        try
        {
            response = request.GetResponse();
            return true;
        }
        catch (Exception)
        {
            return false; //url does not exist
        }
    }

    public void SetToDefault()
    {
        List<string> defaultsURL = new List<string>();
        defaultsURL.Add("https://images2.imgbox.com/b8/3b/bL4p8Xuh_o.jpg");
        defaultsURL.Add("https://images2.imgbox.com/de/78/twbNiT95_o.jpg");

        Random random = new Random();
        int newURLId = random.Next(0, 2);

        Url = defaultsURL[newURLId];
    }

}
