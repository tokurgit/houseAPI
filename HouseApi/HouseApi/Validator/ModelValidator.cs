using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseApi.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SQLitePCL;

namespace HouseApi.Validator
{
    public class ModelValidator
    {
        private readonly HouseApiDbContext _ctx;
        public ModelValidator(HouseApiDbContext context)
        {
            _ctx = context;
        }

        public bool EntityExists(int id, object obj)
        {
            return _ctx.Houses.Any(e => e.Id == id);
        }
    }
}
