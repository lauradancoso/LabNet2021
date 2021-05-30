using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica.MVC.MVC.Models
{
    public class ErrorView
    {
        public ErrorView(string Message)
        {
            this.Message = Message;
        }
        public string Message { get; set; }
    }
}