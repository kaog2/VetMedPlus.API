using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class User
{
    public int UserId { get; set; }

    public int UserTypeId { get; set; }

    public int? AddressId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<UserRight> UserRights { get; } = new List<UserRight>();

    public virtual UserType UserType { get; set; } = null!;
}
