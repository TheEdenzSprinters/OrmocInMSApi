﻿using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Interfaces
{
    public interface ISubCategoryBusinessLayer
    {
        List<SubCategory> GetAllSubCategories();
    }
}