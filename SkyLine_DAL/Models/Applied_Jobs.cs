using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkyLine_DAL.Models
{
      public enum ApplicationStatus
        {
            Pending,
            Approved,
            Rejected
        }

    public class Applied_Jobs
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]

        public ApplicationStatus? IsApproved { get; set; }=ApplicationStatus.Pending;

    }
}
