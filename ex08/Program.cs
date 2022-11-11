using System;


namespace ex08 {
    abstract class IFood {
        public abstract void Print();
    }

    class Food: IFood
    {
        protected String name = "";
        protected Double price = 0.0;

        public Food(String name, Double price) {
            this.name = name; 
            this.price = price;
        }

        public void _InputFromKeyboard() {
            Console.Write("Name: ");
            this.name = Console.ReadLine();
            Console.Write("Price: ");
            this.price = Convert.ToDouble(Console.ReadLine());
        }

        public override void Print(){}
    }

    class FoodWithBox: Food {
        DateTime expiresAt = DateTime.Now;

        public FoodWithBox(String name, Double price, DateTime expiresAt): base(name, price) {
            this.expiresAt = expiresAt; 
        }

        public void InputFromKeyboard() {
            base._InputFromKeyboard();
            Console.Write("Expires At: ");
            this.expiresAt = Convert.ToDateTime(Console.ReadLine());
        }

        public override void Print() {
            Console.WriteLine("Name: {0}, Price: {1}, Exp: {2}", base.name, base.price, this.expiresAt);
        }
    }

    class FoodWithoutBox: Food {
        Double weight = 0.0;
        public FoodWithoutBox(String name, Double price, Double weight): base(name, price) {
            this.weight = weight; 
        }

        public void InputFromKeyboard() {
            base._InputFromKeyboard();
            Console.Write("Weight: ");
            this.weight = Convert.ToDouble(Console.ReadLine());
        }

        public override void Print() {
            Console.WriteLine("Name: {0}, Price: {1}, Weight: {2}", base.name, base.price, this.weight);
        }
    }

    class Program {
        static void Main() {
            Console.WriteLine("Number of FoodWithBox: ");
            Int64 m = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Number of FoodWithoutBox: ");
            Int64 n = Convert.ToInt64(Console.ReadLine());

            List<IFood> ret = new List<IFood>{};

            for (int i = 0; i < m; i++)
            {
                FoodWithBox f = new FoodWithBox("", 0, DateTime.Now);    
                f.InputFromKeyboard();
                ret.Add(f);
            }

            for (int i = 0; i < n; i++)
            {
                FoodWithoutBox f = new FoodWithoutBox("", 0, 0);    
                f.InputFromKeyboard();
                ret.Add(f);
            }

            foreach (var item in ret)
            {
                item.Print();
            }
        }
    }
}
