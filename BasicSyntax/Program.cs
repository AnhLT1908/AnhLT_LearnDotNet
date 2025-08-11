using System;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            // khai báo biến
            int age = 22;
            string name = "Le Tien Anh";
            double salary = 2000;

            // xuất dữ liệu ra console
            Console.WriteLine($"Xin chao, {name}!");
            Console.WriteLine($"Tuoi: {age}, Luong: {salary:C}");

            // cấu trúc điều kiện
            if (age >= 18)
            {
                Console.WriteLine("Ban da co the di lam");
            }
            else
            {
                Console.WriteLine("Ban chua den tuoi di lam");
            }

            // vòng lặp for
            Console.WriteLine("Count from 1 to 5:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }

            // mảng, vòng lặp for each
            string[] fruits = { "Apple", "Banana", "Orange" };
            Console.WriteLine("List of fruits:");
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            // kiểu tham trị (value type)
            int valueDemo1 = 10;
            int valueDemo2 = valueDemo1;
            valueDemo2 = 20;
            Console.WriteLine($"Value 1: {valueDemo1}, Value 2: {valueDemo2}");

            // kiểu tham chiếu
            MyClass refValue1 = new MyClass { Id = 1 };
            MyClass refValue2 = refValue1;
            refValue2.Id = 2;
            Console.WriteLine($"Id of value 1: {refValue1.Id}, Id of value 2: {refValue2.Id}");

            // nhập dữ liệu từ console
            Console.WriteLine("Nhap tuoi cua ban: ");
            string inputAge = Console.ReadLine();
            int myAge = int.Parse(inputAge);
            Console.WriteLine($"Tuoi cua ban la: {myAge}");

            // chuyển đổi kiểu dữ liệu
            double doubleValue = 99.99;
            int intValue = (int)doubleValue;
            Console.WriteLine($"Original: {doubleValue}, Before converted: {intValue}");
        }
    }

    class MyClass
    {
        public int Id { get; set; }
    }
}