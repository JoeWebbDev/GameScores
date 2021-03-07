using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameScores.DAL.Models
{
    public class UserAccount
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string emailAddress { get; set; }      
    }
}
