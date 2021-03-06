﻿using DomainObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IJsonContext
    {
        string JsonFolderName { get; set; }
        IJsonSet<Phone> Phones { get; set; }
    }
}
