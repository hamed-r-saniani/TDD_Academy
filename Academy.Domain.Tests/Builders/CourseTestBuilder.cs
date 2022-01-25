namespace Academy.Domain.Tests.Unit.Builders
{
    public class CourseTestBuilder
    {
        // Fake Data
        private int id = 1;
        private string name = "Tdd & Bdd";
        private bool isOnline = true;
        private double tuition = 4000;
        private string instructor = "Hamed";

        public Course Build()
        {
            return new Course(id, name, isOnline, tuition, instructor);
        }

        // For Change Fake Data (Chaining Method)
        public CourseTestBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }
        public CourseTestBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public CourseTestBuilder WithIsOnline(bool isOnline)
        {
            this.isOnline = isOnline;
            return this;
        }
        public CourseTestBuilder Withtuition(double tuition)
        {
            this.tuition = tuition;
            return this;
        }
    }
}
