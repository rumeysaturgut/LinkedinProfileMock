using System;
using System.Collections.Generic;

namespace LinkedinProfile.Models
{
    public partial class Connection
    {
        public int ConnectionId { get; set; }
        public int UserId { get; set; }
        public int ConnectionUserId { get; set; }
        public string ConnectionStatus { get; set; } = null!;

        public virtual User ConnectionUser { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
