﻿using System;

namespace Academy.Domain
{
    public class CourseNameIsInvalidException : Exception
    {
        public CourseNameIsInvalidException(string Message): base(Message)
        {
        }
        public CourseNameIsInvalidException()
        {
        }
    }
}