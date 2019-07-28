using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;

namespace CleanGuruApp.Controllers
{
    public class AssignCleanerController : Controller
    {
        private readonly IAppointmentRepository appointmentRepository;
        public AssignCleanerController(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }


        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Returns Closes Cleaner to the Customer
        /// </summary>
        /// <param name="aCustomer"></param>
        /// <returns></returns>
        public int ChooseClosestCleaner(Customer aCustomer, List<Cleaner> cleaners)
        {
            int distance = 0;
            int shortestDistance = 50000000;
            int closestCleanerID = 0;
            foreach (Cleaner aCleaner in cleaners)
            {
                distance = getDistance(aCustomer.CustomerAddresss.ToString(), aCleaner.ClAddress);
                if (distance <= shortestDistance)
                {
                    shortestDistance = distance;
                    closestCleanerID = aCleaner.IdCleaner;
                }
            }

            return closestCleanerID;
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
            string key = "KEY";

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


        //method to decline a service

        //[HttpGet("{id}")]
        //public IActionResult Decline(int id)
        //{
        //    var appointment = appointmentRepository.GetAppointment(id);

        //    List<Cleaner> cleanerList = new List<Cleaner>();

        //    appointment.IdCleaner = ChooseClosestCleaner(appointment.Customer, cleanerList);

        //    appointmentRepository.Update(appointment);
        //    TempData["message"] = "[ID " + id + "] Appointment was declined.";
        //    return View();
        //}
    }
}