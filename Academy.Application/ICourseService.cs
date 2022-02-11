namespace Academy.Application
{
    public interface ICourseService
    {
        int Create(CreateCourseViewModel command);
        void Edit(EditCourseViewModel command);
    }
}
