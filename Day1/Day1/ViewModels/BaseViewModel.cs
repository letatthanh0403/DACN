﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1.ViewModels
{
    public class BaseViewModel
    {
        public string UserName { get; set; }
        public FooterViewModel FooterData { get; set; }//New Property
    }
}