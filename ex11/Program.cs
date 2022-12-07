using System.Collections;

public class Insurance {
    public string Buyer {get; private set;} = "";
    public int Months {get; private set;}
    public double Cost {get; private set;}
    public double CostPerMonth {get; private set;}
    public bool IsLongTerm {
        get => this.Months > 12;
    }
    public double Commission {
        get {
            if (this.IsLongTerm) return this.CostPerMonth/2;
            return this.Cost *5/100;
        }
    }

    public Insurance(string buyer, int months, double cost) {
        this.Buyer = buyer;
        this.Months = months;
        this.Cost = cost;
        if (this.IsLongTerm) 
            this.CostPerMonth = this.Cost/this.Months;
    }

    public override string ToString()
    {
        return String.Format("{0}\t{1}\t{2}", this.Buyer, this.Months, this.Cost);
    }
}

public class Staff : IComparable {
    public string Name {get; private set;} = "";
    public double SalaryRate {get; private set;}
    public ArrayList Insurances = new ArrayList();
    public double TotalCost {
        get {
            double s = 0;
            foreach(Insurance i in this.Insurances) {
                s += i.Cost;
            }
            return s;
        }
    }
    public double Reward {
        get {
            foreach(Insurance i in this.Insurances) {
                if (i.Cost > 10000) return 100;
            }
            return 0;
        }
    }
    public double Penalty {
        get {
            if (this.TotalCost < 10000) return 30;
            return 0;
        }
    }
    public double Salary {
        get => 40*this.SalaryRate+this.TotalCost/100.0;
    }

    public double Commission {
        get {
            double t = 0;
            foreach(Insurance i in this.Insurances) {
                t += i.Commission;
            }
            return t;
        }
    }

    public Staff(string name, double salaryRate) {
        this.Name = name;
        this.SalaryRate = salaryRate;
    }

    public override string ToString()
    {
        return String.Format("{0}\t{1}\t{2}", this.Name, this.Salary, this.Insurances.Count);
    }

    public int CompareTo(object y) {
        if (this.TotalCost > ((Staff)y).TotalCost) {
            return 0;
        }
        return 1;
    }
}

public class Program {
    public static void Main() {
        ArrayList staffs = new ArrayList();

        Staff staff1 = new Staff("Thanh",  400);
        Staff staff2 = new Staff("Tín",    500);
        Staff staff3 = new Staff("Hưng",   600);

        staff1.Insurances.Add(new Insurance("Như", 10, 1000));
        staff1.Insurances.Add(new Insurance("Châu", 11, 10000));
        staff1.Insurances.Add(new Insurance("Quyên", 12, 300));
        staff1.Insurances.Add(new Insurance("Nguyên", 18, 20000));

        staff2.Insurances.Add(new Insurance("Như", 20, 100));
        staff2.Insurances.Add(new Insurance("Châu", 11, 900000));
        staff2.Insurances.Add(new Insurance("Quyên", 12, 10000));

        staff3.Insurances.Add(new Insurance("Châu", 11, 100));
        staff3.Insurances.Add(new Insurance("Quyên", 12, 700));

        staffs.Add(staff1);
        staffs.Add(staff2);
        staffs.Add(staff3);

        Console.WriteLine("Toàn bộ thông tin nhân viên và bảo hiểm:");
        foreach(Staff s in staffs) {
            Console.WriteLine(s.ToString());
            foreach(Insurance i in s.Insurances) {
                Console.Write("\t\t\t");
                Console.WriteLine(i.ToString());
            }
        }

        Console.WriteLine("\n\nDanh sách nhân viên có hoa hồng trên 50$:");
        foreach(Staff s in staffs) {
            if (s.Commission > 50) Console.WriteLine(s.Name);
        }

        Console.WriteLine("\n\nDanh sách nhân viên bị phạt tiền:");
        foreach(Staff s in staffs) {
            if (s.Penalty > 0) Console.WriteLine(s.Name);
        }

        Console.WriteLine("\n\nDanh sách nhân viên được thưởng 100$:");
        foreach(Staff s in staffs) {
            if (s.Reward >= 100) Console.WriteLine(s.Name);
        }

        Console.WriteLine("\n\nDanh sách nhân viên theo doanh số:");
        staffs.Sort();
        foreach(Staff s in staffs) {
            Console.WriteLine(String.Format("{0}\t{1}", s.Name, s.TotalCost));
        }
    }
}