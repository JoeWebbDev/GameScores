using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameScores.API.ViewModels
{
    public record UserAccountViewModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string emailAddress { get; set; }
        
    }
}
