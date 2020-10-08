using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Project
{
    public class BookInfo : INotifyPropertyChanged
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string ISBN { get; set; }
        public int NumberOfPage { get; set; }
        public string PublicationName { get; set; }
        public int PublishYear { get; set; }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
    }
}
