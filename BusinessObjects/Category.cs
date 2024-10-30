using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects;

public class Category
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryID { get; set; }
    [Required]
    [MaxLength(15)]
    public string CategoryName { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = null!;
}
