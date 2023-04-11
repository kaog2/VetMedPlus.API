using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class UserType
{
    public int UserTypeId { get; set; }

    public string UserTypeName { get; set; } = null!;

    public string? UserTypeDescription { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
