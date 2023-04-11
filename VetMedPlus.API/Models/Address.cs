using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string AddressFirstName { get; set; } = null!;

    public string AddressLastName { get; set; } = null!;

    public string? AddressPhone { get; set; }

    public string? AddressEmail { get; set; }

    public DateTime AddressBirthdate { get; set; }

    public string? AddressStreet { get; set; }

    public string? AddressPostalCode { get; set; }

    public int? AddressStreetNumber { get; set; }

    public string? AddressCountry { get; set; }

    public string? AddressCity { get; set; }

    public DateTime? AddressCreatedDate { get; set; }

    public DateTime? AddressUpdateDate { get; set; }

    public bool? AddressIsActive { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
