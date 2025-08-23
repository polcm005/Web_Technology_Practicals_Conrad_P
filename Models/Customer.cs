using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AOWebApp2.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    [Display(Name = "Main Phone Number")]
    public string MainPhoneNumber { get; set; } = null!;

    [Display(Name = "Secondary Phone Number")]
    public string? SecondaryPhoneNumber { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [NotMapped][Display(Name = "Customer Name")] public string FullName => FirstName + " " + LastName;

    [NotMapped]
    [Display(Name = "Contact Number")]
    public string ContactNumber
    {
        get
        {
            if (!MainPhoneNumber.IsNullOrEmpty() && SecondaryPhoneNumber.IsNullOrEmpty())
            {
                return MainPhoneNumber;
            }
            else if (!MainPhoneNumber.IsNullOrEmpty() && !SecondaryPhoneNumber.IsNullOrEmpty())
            {
                return MainPhoneNumber + " : " + SecondaryPhoneNumber;
            }
            else if (MainPhoneNumber.IsNullOrEmpty() && !SecondaryPhoneNumber.IsNullOrEmpty())
            {
                return SecondaryPhoneNumber;
            }
            else
            {
                return "";
            }
        }
    }

}
