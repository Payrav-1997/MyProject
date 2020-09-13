using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class AboutTheFund
    {
        public int Id { get; set; }
      
        //Публикации и видео
        public string PublicationsAndVideos { get; set; }
       
        //Люди корорые мы помогаем
        public string PeopleWeHelp { get; set; }

        //Как вам помочь
        public string HowCanHelpYou { get; set; }

        //Благодарность
        public string Thanks { get; set; }

        //Отзывы
        public string Reviews { get; set; }

        //Наши контакты
        public string Contacts { get; set; }
    }
}
