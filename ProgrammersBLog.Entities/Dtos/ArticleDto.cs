﻿using ProgrammersBLog.Entities.Concrete;
using ProgrammersBLog.Shared.Entitites.Absctract;
using ProgrammersBLog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBLog.Entities.Dtos
{
    public class ArticleDto:DtoGetBase
    {
        public Article Article { get; set; }
       
       

    }
}
