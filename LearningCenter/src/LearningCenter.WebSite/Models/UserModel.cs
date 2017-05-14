﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningCenter.WebSite.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CourseModel[] Classes { get; set; }
    }
}