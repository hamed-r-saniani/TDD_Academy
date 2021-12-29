using System;

namespace Academy.Domain.Exceptions
{
    public class CourseNameIsInvalidException : Exception
    {
        public CourseNameIsInvalidException(string Message) : base(Message)
        {
        }
        public CourseNameIsInvalidException()
        {
        }
    }
}