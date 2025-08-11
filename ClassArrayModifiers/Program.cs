using System;

namespace ClassArrayModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            // tạo mảng chứa các đối tượng Student
            Student[] students = new Student[3];

            // khởi tạo đối tượng và gán vào mảng
            students[0] = new Student { Id = 1, Name = "AnhLT", Age = 22 };
            students[1] = new Student { Id = 2, Name = "MinhNPT", Age = 21 };
            students[2] = new Student { Id = 3, Name = "PhongNS", Age = 20 };

            // truy cập và in thông tin từ mảng
            Console.WriteLine("Thong tin sinh vien:");
            foreach (Student student in students)
            {
                student.DisplayInfo();
            }
        }
    }
}