﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Extensions;

namespace TaskManagement.Application.Core
{
    public class ApiResult<TOutput>
    {
        public TOutput Response { get; set; }
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> ErrorList { get; set; }

        public static ApiResult<TOutput> Ok(TOutput response)
        {
            return new ApiResult<TOutput>()
            {
                Response = response,
                StatusCode = (int)HttpStatusCode.OK,
                Description = "Əməliyyat uğurla tamamlandı.",
                ErrorList = null
            };
        }

        public static ApiResult<TOutput> Error(ErrorCodes errorCode, Dictionary<string, string> errorList = null, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new ApiResult<TOutput>()
            {
                Response = default,
                StatusCode = statusCode,
                ErrorCode = (int)errorCode,
                Description = errorCode.GetEnumDescription(),
                ErrorList = errorList
            };
        }
    }
}
