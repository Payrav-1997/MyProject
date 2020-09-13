using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        //Срочная помощь
        public string EmergencyAssistance { get; set; }
       
        //Помощь детям
        public string HelpingChildren { get; set; }
       
        //Помощь престарелым
        public string HelpingElderly { get; set; }
        
        //Помощь инвалидам
        public string HelpingDisabled { get; set; }
        
        //Другие виды помощи 
        public string OtherTypesOfAssistance { get; set; }
       
        //Мне нужна помощь
        public string INeedHelp { get; set; }
    }
}
