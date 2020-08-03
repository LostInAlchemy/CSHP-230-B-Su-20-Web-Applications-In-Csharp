using System.Web;

namespace TheLearningStore.WebSite.Models
{
    public class GetUser
    {
        public string UserId { get { return HttpContext.Current.User.Identity.Name; } set { } }
        //public int ClassId { get; set; }
    }

    // probably remove ClassId and make this getuser
}