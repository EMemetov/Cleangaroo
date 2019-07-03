using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CleanGuruApp.Models;

namespace CleanGuruApp.Controllers
{
    public class AssignCleanerController : Controller
    {
     

        public IActionResult Index()
        {
            return View();
        }



        
        /// <summary>
        /// Calculates driving distance between Origin and destination address 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public int getDistance(string origin, string destination)
        {
            System.Threading.Thread.Sleep(1000);
            int distance = 0;
            string key = "key";

            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&key=" + key;
            url = url.Replace(" ", "+");
            string content = fileGetContents(url);
            JObject o = JObject.Parse(content);

            try
            {
                distance = (int)o.SelectToken("routes[0].legs[0].distance.value");
                return distance;
            }
            catch
            {
                return distance;
            }
        }

        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("https:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);

                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }
    }
}