using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class UserRight
{
    public Guid UserRightsId { get; set; }

    public int UserId { get; set; }

    public Guid RightsId { get; set; }

    public virtual Right Rights { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
