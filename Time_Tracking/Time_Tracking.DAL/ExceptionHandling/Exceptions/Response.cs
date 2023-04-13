﻿namespace Time_Tracking.DAL.ExceptionHandling.Exceptions;

public class Response
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class SuccessResponse
    {
        public string Message { get; set; }
        public object Data { get; set; }
    }
}