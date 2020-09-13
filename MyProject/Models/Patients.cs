using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Patients
    {
        public int Id { get; set; }
        public string Title { get; set; }      
        public int Desease { get; set; }
        public int Donates { get; set; }
        public float Price { get; set; }
        public float Money { get; set; }
        public int Views { get; set; }
        public string Date { get; set; }
        public Deseases deseases { get; set; }
        public Category Category { get; set; }
        public AboutTheFund AboutTheFund { get; set; }

    }
}
