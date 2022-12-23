using Model.Custom;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.ViewModels
{
    public class CreateContactPerAccount
    {
        public ContactCard ContactCard { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}