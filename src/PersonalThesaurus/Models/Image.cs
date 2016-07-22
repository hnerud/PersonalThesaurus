//using System.Web;

namespace PersonalThesaurus.Models
{
    public class Image
    {
        public int ID { get; set; }
        public int size { get; set; }
        public string fileName { get; set; }
        public byte[] data { get; set; }
        //public HttpPostedFileBase file { get; set; }
    }
}