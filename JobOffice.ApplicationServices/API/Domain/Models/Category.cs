﻿using JobOffice.DataAcces.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobOffice.ApplicationServices.API.Domain.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        //Foreign key to following higher category, if exists
        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }

        public List<ProductAttributes>? Attributes { get; set; }

        public List<Tag>? Tags { get; set; }

        // field for ordering childrens 
        public int? Order { get; set; }

        public string? ImagePath { get; set; }

        public byte[]? ImageData { get; set; }  // Store image as binary data

        public IEnumerable<Category>? Subcategories { get; set; } = new List<Category>(); // Initialize to avoid null



    }
}
