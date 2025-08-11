namespace ClassArrayModifiers
{
    class Student
    {
        // access modifiers
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        private double grade;

        // method public để truy cập grade
        public void SetGrade(double g)
        {
            if (g >= 0 && g <= 100)
                grade = g;
        }

        // method public để hiển thị thông tin
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Ten: {Name}, Tuoi: {Age}, Khoa: {grade}");
        }
    }
}