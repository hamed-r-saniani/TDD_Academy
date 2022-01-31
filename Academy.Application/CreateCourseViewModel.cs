namespace Academy.Application
{
    public class CreateCourseViewModel
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public bool IsOnline { get;  set; }
        public double Tuition { get;  set; }
        public string Instructor { get; set; }
    }
}
