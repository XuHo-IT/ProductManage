using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects;

public class AccountMember
{
    [Key]
    [MaxLength(20)]
    public string MemberID { get; set; } = null!;
    [Required]
    [MaxLength(80)]
    public string MemberPassword { get; set; } = null!;
    [Required]
    [MaxLength(80)]
    public string MemberName { get; set; } = null!;
    [EmailAddress]
    [Required]
    [MaxLength(100)]
    public string EmailAddress { get; set; } = null!;
    [Range(1, 3, ErrorMessage = "MemberRole must be 1, 2, or 3.")]
    public int MemberRole { get; set; }
}
