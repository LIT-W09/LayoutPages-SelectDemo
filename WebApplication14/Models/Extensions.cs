﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public static class Extensions
    {
        public static T GetOrNull<T>(this SqlDataReader reader, string columnName)
        {
            object value = reader[columnName];
            if(value == DBNull.Value)
            {
                return default(T);
            }

            return (T)value;
        }
    }
}