﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace SevenHabits.Models
{
	public class TaskForm
	{
        //Class for the form with required fields and error messages
        [Key]
        [Required]
        public int TaskID { get; set; }

        [Required]
        public string Task { get; set; }

        public DateTime DueDate { get; set; }

        public int Quadrant { get; set; }

        public bool Completed { get; set; }

        //Build Foreign key relationship
        public int CategoryID { get; set; }

        public Category? Category { get; set; }

    }
}

