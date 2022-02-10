using System;

namespace Academy.Domain.Exceptions
{
    public class DuplicatedCourseNameException : Exception
    {
        public DuplicatedCourseNameException()
        {
        }
        public DuplicatedCourseNameException(string message) : base(message)
        {
        }
    }
}
