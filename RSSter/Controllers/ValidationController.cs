﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.RssReader;
using Services.RssReader.Implementation;

namespace RSSter.Controllers
{
    public class ValidationController : Controller
    {
        private readonly IValidateService _validateService;

        public ValidationController(IValidateService validateService)
        {            
            _validateService = validateService;
        } 
        
        //GET: Validation
        public JsonResult LinkValidation(string link)
        {            
            return Json(_validateService.IsLinkUnique(link), JsonRequestBehavior.AllowGet);
        }
    }
}