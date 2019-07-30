using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CleanGuruApp.Models;
using CleanGuruApp.Models.DB;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;

namespace CleanGuruApp.Controllers
{
    public class AssignCleanerController : Controller
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly ICleanerRepository     cleanerRepository;
        private readonly ICustomerRepository    customerRepository;

        public AssignCleanerController(IAppointmentRepository appointmentRepository,
                                       ICleanerRepository     cleanerRepository,
                                       ICustomerRepository    customerRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.cleanerRepository     = cleanerRepository;
            this.customerRepository    = customerRepository;
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
            //string key = "AIzaSyBLBKgz0zTcj5Fi5ISxzP3QAAv0i-Nsy30";

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
        public IActionResult Decline(int id)
        {
            var appointment = appointmentRepository.GetAppointment(id);
            int idcustomer = appointment.IdCustomer;
            var customer = customerRepository.GetCustomer(idcustomer);

            List<Cleaner> cleanerList = new List<Cleaner>();
            cleanerList = getCleanersList();

            //appointment.IdCleaner = ChooseClosestCleaner(customer, cleanerList);
            appointment.IdCleaner = 1;

            appointmentRepository.Update(appointment);
            TempData["message"] = "[ID " + id + "] Appointment was declined to: "+appointment.Cleaner.FCleanerName +" "+ appointment.Cleaner.LCleanerName;
            //You may need to use this link to give account access
            //https://accounts.google.com/DisplayUnlockCaptcha

            var fromAddress = new MailAddress("cleanguru2019@gmail.com");
            var fromPassword = "12zx09mn";
            var toAddress = new MailAddress(appointment.Customer.CtEmail);

            string subject = "CleanGuru - Service declined";
            string body = "This is an automatic email. Please do not answer.\n" +
                               "Service was declined by cleaner "+
                               appointment.Cleaner.LCleanerName+", "+
                               appointment.Cleaner.FCleanerName;


            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })

                smtp.Send(message);

            return View(appointment);
        }


        //method to decline a service
        public IActionResult Accept(int id)
        {
            var appointment = appointmentRepository.GetAppointment(id);
            int idcustomer = appointment.IdCustomer;
            var customer = customerRepository.GetCustomer(idcustomer);

            List<Cleaner> cleanerList = new List<Cleaner>();
            cleanerList = getCleanersList();

            //appointment.IdCleaner = ChooseClosestCleaner(customer, cleanerList);
            appointment.IdCleaner = 1;

            appointmentRepository.Update(appointment);
            TempData["message"] = "[ID " + id + "] Appointment was reassigned to: " + appointment.Cleaner.FCleanerName + " " + appointment.Cleaner.LCleanerName;
            //You may need to use this link to give account access
            //https://accounts.google.com/DisplayUnlockCaptcha

            var fromAddress = new MailAddress("cleanguru2019@gmail.com");
            var fromPassword = "12zx09mn";
            var toAddress = new MailAddress(appointment.Customer.CtEmail);

            string subject = "CleanGuru - Service declined";
            string body = "This is an automatic email. Please do not answer.\n" +
                               "Service was declined by cleaner " +
                               appointment.Cleaner.LCleanerName + ", " +
                               appointment.Cleaner.FCleanerName;


            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })

                smtp.Send(message);

            return View(appointment);
        }

        private List<Cleaner> getCleanersList()
        {
            List<Cleaner> selectList = new List<Cleaner>();

            foreach (var cleaner in cleanerRepository.Cleaners)
            {
                selectList.Add(cleaner);
            }
            return selectList;
        }
    }
}