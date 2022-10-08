namespace ex06
{
    class Student
    {
        private string _name = "";
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        private double _math;
        public double Math
        {
            get
            {
                return this._math;
            }
            set
            {
                if (this._math < 0 || this._math > 10)
                {
                    throw new Exception("Math score must be in range [0,10]");
                }
                this._math = value;
            }
        }

        private double _info;
        public double Info
        {
            get
            {
                return this._info;
            }
            set
            {
                if (this._info < 0 || this._info > 10)
                {
                    throw new Exception("Info score must be in range [0,10]");
                }
                this._info = value;
            }
        }

        public double Avg
        {
            get
            {
                return (this.Math + this.Info) / 2;
            }

            set
            {
                throw new Exception("Setting Avg value is not allowed");
            }
        }

        public Student(string name, double m, double i)
        {
            this.Name = name;
            this.Math = m;
            this.Info = i;
        }

        public Object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.Name;
                    case 1:
                        return this.Math;
                    case 2:
                        return this.Info;
                    case 3:
                        return this.Avg;
                    default:
                        throw new Exception("Invalid index");
                }
            }

            set
            {
                switch (index)
                {
                    case 0:
                        this.Name = (string)value;
                        return;
                    case 1:
                        this.Math = Convert.ToDouble(value);
                        return;
                    case 2:
                        this.Info = Convert.ToDouble(value);
                        return;
                    case 3:
                        throw new Exception("this value can not be set manually");
                    default:
                        throw new Exception("Invalid index");
                }
            }
        }

        public Object this[string index]
        {
            get
            {
                switch (index)
                {
                    case "name":
                        return this.Name;
                    case "math":
                        return this.Math;
                    case "info":
                        return this.Info;
                    case "avg":
                        return this.Avg;
                    default:
                        throw new Exception("Invalid index");
                }
            }

            set
            {
                switch (index)
                {
                    case "name":
                        this.Name = (string)value;
                        return;
                    case "math":
                        this.Math = Convert.ToDouble(value);
                        return;
                    case "info":
                        this.Info = Convert.ToDouble(value);
                        return;
                    case "avg":
                        throw new Exception("this value can not be set manually");
                    default:
                        throw new Exception("Invalid index");
                }
            }
        }
    }
}