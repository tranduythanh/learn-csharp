namespace ex04
{
    class Classroom
    {
        private Student[] _students;
        private int _n = 0;

        public Classroom(int n)
        {
            this._n = n;
            this._students = new Student[] { };
        }

        private void swap(int i, int j)
        {
            Student s = this._students[i];
            this._students[i] = this._students[j];
            this._students[j] = s;
        }

        private void sort(Func<Student, Student, bool> less)
        {
            for (int i = this._students.Length - 1; i >= 0; i--)
            {
                for (int k = 0; k < i; k++)
                {
                    if (!less(this._students[k], this._students[k + 1]))
                    {
                        this.swap(k, k + 1);
                    }
                }
            }
        }

        private bool LessByName(Student s1, Student s2)
        {
            if (String.Compare(s1.FName, s2.FName) < 0)
            {
                return true;
            }
            if (String.Compare(s1.FName, s2.FName) == 0)
            {
                return String.Compare(s1.GName, s2.GName) < 0;
            }
            return false;
        }

        private bool LessByAvgAndName(Student s1, Student s2)
        {
            if (s1.Avg == s2.Avg)
            {
                return this.LessByName(s1, s2);
            }
            return s1.Avg < s2.Avg;
        }

        public void AddStudent(string fName, string gName, int math, int literature)
        {
            if (this._students.Length >= this._n)
            {
                return;
            }

            Student s = new Student(fName, gName, math, literature);
            this._students = this._students.Concat(new Student[] { s }).ToArray();
        }

        public float ClassAvgLiterature()
        {
            float avg = 0;
            foreach (Student s in this._students)
            {
                avg += s.Literature;
            }
            return avg / (float)this._students.Length;
        }

        public float ClassAvgMath()
        {
            float avg = 0;
            foreach (Student s in this._students)
            {
                avg += s.Math;
            }
            return avg / (float)this._students.Length;
        }

        public Student[] CloneStudentList()
        {
            Student[] ss = new Student[] { };
            foreach (Student s in this._students)
            {
                ss = ss.Concat(new Student[] { s.Clone() }).ToArray();
            }
            return ss;
        }

        public void SortByName()
        {
            this.sort(this.LessByName);
        }

        public void SortByAvgAndName()
        {
            this.sort(this.LessByAvgAndName);
        }

        public void Print()
        {
            foreach (Student s in this._students)
            {
                s.Print();
            }
        }

        public void Swap(int i, int j)
        {
            this.swap(i, j);
        }
    }

    class Student
    {
        public string FName { get; private set; }
        public string GName { get; private set; }
        public float Math { get; private set; }
        public float Literature { get; private set; }
        public float Avg { get; private set; }

        public Student(string fName, string gName, float math, float literature)
        {
            this.FName = fName;
            this.GName = gName;
            this.Math = math;
            this.Literature = literature;
            this.Avg = (this.Math + this.Literature) / 2;
        }

        public Student Clone()
        {
            return new Student(this.FName, this.GName, this.Math, this.Literature);
        }

        public void Print()
        {
            Console.WriteLine(
                "{0,20} {1,20}: Math: {2,3}   Literature: {3,3}   Avg: {4,3}",
                this.FName, this.GName, this.Math, this.Literature, this.Avg
            );
        }
    }
}