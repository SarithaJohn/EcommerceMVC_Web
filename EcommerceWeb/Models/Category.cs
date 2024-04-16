using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Models
{
	public class Category
	{
		[Key]						//DataAnnotations: primary key
        public int Id { get; set; }
		[Required]                  //DataAnnotations: Not null
        public string Name { get; set; }
		public int DisplayOrder { get; set; }
	}
}

