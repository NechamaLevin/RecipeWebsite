using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Conversation
{
    public int ConversationId { get; set; }

    public int UserId1 { get; set; }

    public int UserId2 { get; set; }

    public string Text { get; set; }

    public DateTime Time { get; set; }

    public virtual User UserId1Navigation { get; set; }

    public virtual User UserId2Navigation { get; set; }
}
