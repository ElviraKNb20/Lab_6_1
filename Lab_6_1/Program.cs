using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6_1
{
    class Students
    {
        string fullName { get; set; }
        int age { get; set; }
        string phoneNum { get; set; }
        string street { get; set; }

        public Students(string fullName, int age, string phoneNum, string street)
        {
            this.fullName = fullName;
            this.age = age;
            this.phoneNum = phoneNum;
            this.street = street;
        }

        public override string ToString()
        {
            return $"ПIБ: {fullName}, Вiк: {age}, Номер телефону: {phoneNum}, Вулиця проживання: {street}";
        }
    }

    class CollectionType<T> : IEnumerable<T> where T : Students
    {
        List<T> list = new List<T>();

        public CollectionType()
        {
            list = new List<T>();
        }

        public int Count
        {
            get { return list.Count; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return list[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                list[index] = value;
            }
        }

        public void Add(T student)
        {
            list.Add(student);
        }

        public T Remove(T student)
        {
            var element = list.FirstOrDefault(h => h == student);
            if (element != null)
            {
                list.Remove(element);
                return element;
            }
            throw new NullReferenceException();
        }

        public void Sort()
        {
            list.Sort();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Students stud1 = new Students("Гавришко В. Є.", 18, "0988651346", "с.Дорогичiвка");
            Students stud2 = new Students("Чижевський Д.В.", 18, "0966937299", "Грушевського, 56");
            Students stud3 = new Students("Сукманюк В.С.", 18, "0677737909", "Тiмiрязєва, 139");
            Students stud4 = new Students("Матраєва Е.М.", 18, "0989939814", "пров.Сторожука, 11");

            CollectionType<Students> collection = new CollectionType<Students>();
            collection.Add(stud1);
            collection.Add(stud2);
            collection.Add(stud3);
            collection.Add(stud4);

            foreach (Students s in collection)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }
}
