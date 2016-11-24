using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161124Form.Models
{
    public class GuestResponse : TableEntity
    {

        public GuestResponse()
        {
        }

        public GuestResponse(string rowKey)
        {
            this.PartitionKey = "spamPerson";
            this.RowKey = rowKey;
        }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ange ditt mobilnummer")]
        public string Phone { get; set; }
    }
}