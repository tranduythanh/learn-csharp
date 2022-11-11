namespace ex09 {

    abstract class IEmployee {
        public abstract void Print();
    }

    class Employee: IEmployee 
    {
        public String name = "";

        public Double salary = 0;
        public Double allowanceBase = 2000;
        public Double allowanceRate = 0;

        public Employee(String name) {
            this.name = name; 
            this.salary = 120*20;
            this.allowanceBase = 2000;
            this.allowanceRate = 0;
        }

        public Double income() {
            return this.salary + this.allowanceBase*this.allowanceRate;
        }

        public override void Print(){}
    }

    class Director: Employee
    {
        private List<Manager> managers = new List<Manager>{};
        public Int64 TotalEmployees = 0;

        public Director(String name): base(name) {
            base.allowanceRate = 2.5;
        }

        public Manager AddManager(String name) {
            Manager s = new Manager(name, this);
            this.managers.Add(s);
            this.TotalEmployees += 1;
            return s;
        }

        public override void Print()
        {
            Console.WriteLine("name {0}\t\tincome {1}\t\t\t\ttotal employees {2}", 
                this.name, this.income(), this.TotalEmployees);
        }
    }

    class Manager: Employee
    {
        private List<Staff> staffs = new List<Staff>{};
        private Director boss;

        protected Int64 TotalEmployees = 0;

        public Manager(String name, Director d): base(name) {
            base.allowanceRate = 1;
            this.boss = d;
        }

        public Staff AddStaff(String name) {
            Staff s = new Staff(name, this);
            this.staffs.Add(s);
            this.TotalEmployees += 1;
            this.boss.TotalEmployees += 1;
            return s;
        }

        public override void Print()
        {
            Console.WriteLine("name {0}\tincome {1}\tboss {2}\t\ttotal employees {3}", 
                this.name, this.income(), this.boss.name, this.TotalEmployees);
        }
    }

    class Staff: Employee
    {
        private Manager boss;
        public Staff(String name, Manager m): base(name) {
            this.boss = m;
        }

        public override void Print()
        {
            Console.WriteLine("name {0}\tincome {1}\tboss {2}", 
                this.name, this.income(), this.boss.name);
        }
    }

    class Program
    {
        static void Main() {
            List<IEmployee> es = new List<IEmployee>{};

            Director d1 = new Director("Giám đốc 1");
            Director d2 = new Director("Giám đốc 2");

            Manager m11 = d1.AddManager("Trường phòng 11");
            Manager m12 = d1.AddManager("Trường phòng 12");
            Manager m21 = d2.AddManager("Trường phòng 21");

            Staff s111 = m11.AddStaff("Nhân viên 111");
            Staff s121 = m12.AddStaff("Nhân viên 121");
            Staff s122 = m12.AddStaff("Nhân viên 121");
            Staff s211 = m21.AddStaff("Nhân viên 211");
            Staff s212 = m21.AddStaff("Nhân viên 212");

            es.Add(d1);
            es.Add(d2);
            es.Add(m11);
            es.Add(m12);
            es.Add(m21);
            es.Add(s111);
            es.Add(s121);
            es.Add(s122);
            es.Add(s211);
            es.Add(s212);

            foreach (var e in es)
            {
                e.Print();
            }
        }
    }
}