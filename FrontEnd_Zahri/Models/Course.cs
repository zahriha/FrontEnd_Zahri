﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

    }
}
