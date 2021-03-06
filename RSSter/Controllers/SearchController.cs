﻿using System;
using System.Linq;
using System.Web.Mvc;
using Services.RssReader;
using Models.Models;
namespace RSSter.Controllers
{
    public class SearchController : Controller
    {
        private readonly IChannelService _channelService;
        private readonly IItemService _itemService;
        private readonly ISearchResultsBuilder _searchResultBuilder;
        //private ApplicationUserManager _userManager;


        public SearchController(IChannelService channelService, IItemService itemService, ISearchResultsBuilder searchResultBuilder)
        {
            _channelService = channelService;
            _itemService = itemService;
            _searchResultBuilder = searchResultBuilder;
            //UserManager = userManager;
        }


        //public ActionResult SearchItems(string searchString)
        //{
        //    if (!String.IsNullOrEmpty(searchString))
        //    {


        //        _channelService.AddChannel(searchString);
              
        //            var results = _searchResultBuilder.SearchForString(searchString);
        //            //var r = new { results = results };
        //            //string jsonResult1 = JsonConvert.SerializeObject(r);
        //            //return Json(r, JsonRequestBehavior.AllowGet);
        //            return View(results);
        //    }

        //    return Json(null);

        //}
        //}
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {

                if (searchString.Contains("."))
                {
                    _channelService.AddChannel(searchString);
                }

                var result = _searchResultBuilder.MainSearch(searchString);
                return View(result);
            }

            return View();
        }
            
        }
    }
