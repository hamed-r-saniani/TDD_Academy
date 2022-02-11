using System;

namespace Academy.Domain.Exceptions
{
    public class CourseNotExistsException : Exception
    {
        public CourseNotExistsException()
        {
        }
        public CourseNotExistsException(string message) : base(message)
        {
        }
    }
}
