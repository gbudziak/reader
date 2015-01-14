﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.RSS;

namespace Services.RssReader
{
    public interface IRssItemsList
    {
        Channel GetRssFeed(string blogUrl);
    }
}
