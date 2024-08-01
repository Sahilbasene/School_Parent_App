
namespace School_Parent_App.Models

{

    public class Circular

    {

        public int Id { get; set; }

        public DateTime NotificationDate { get; set; }

        public string InformationText { get; set; }

        public string NotificationPostedBy { get; set; }

        public bool Acknowledged { get; set; }
        public DateTime? AcknowledgeDate { get; set; }


    }

}
