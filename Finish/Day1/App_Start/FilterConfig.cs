﻿using Day1.Filters;
using System.Web;
using System.Web.Mvc;

namespace Day1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            //filters.Add(new HandleErrorAttribute());//Old line
            //filters.Add(new AuthorizeAttribute());//New Line
            filters.Add(new EmployeeExceptionFilter());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
