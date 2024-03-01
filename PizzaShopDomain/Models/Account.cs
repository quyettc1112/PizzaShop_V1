using System;
using System.Collections.Generic;

namespace QuyetTC_ASS2_Repository.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
    }
}
