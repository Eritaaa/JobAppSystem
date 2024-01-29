using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JobAppSystem.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Perdoruesi class
public class Perdoruesi : IdentityUser
{

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Emri { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Mbiemri { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Qyteti { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string PhoneNumber { get; set; }
}

