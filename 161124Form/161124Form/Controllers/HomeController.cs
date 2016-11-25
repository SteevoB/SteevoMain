using _161124Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace _161124Form.Controllers
{
    public class HomeController : Controller
    {

        private CloudStorageAccount storageAccount;
        private CloudTableClient tableClient;
        private CloudTable table;

        public HomeController()
        {

            storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;");
            tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference("LocalTable");
            table.CreateIfNotExists();

        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ViewResult RSVP()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RSVP(GuestResponse g)
        {
            if (ModelState.IsValid == true)
            {
                GuestResponse person = new GuestResponse(Guid.NewGuid().ToString()) { Name = g.Name, Phone = g.Phone };

                // Create the TableOperation object that inserts the customer entity.
                TableOperation insertOperation = TableOperation.Insert(person);

                // Execute the insert operation.
                table.Execute(insertOperation);
                return View("Thanks", g);
            }
            //Om inte valid, dvs namn saknas, visa formuläret igen
            return View();
        }

        [HttpGet]
        public ActionResult info()
        {
            return View(PrintInformation());
        }

        [NonAction]
        public List<GuestResponse> PrintInformation()
        {
            List<GuestResponse> PeopleList = new List<GuestResponse>();

            TableQuery<GuestResponse> query = new TableQuery<GuestResponse>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "spamPerson"));

            foreach (GuestResponse item in table.ExecuteQuery(query))
            {
               PeopleList.Add(item);
            }

            return PeopleList;

        }
    }
}