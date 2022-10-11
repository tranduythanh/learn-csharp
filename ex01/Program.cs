namespace ex01
{
    class program
    {
        public static void Main()
        {
            // Bài 1
            Console.WriteLine("\n\n\n¯\\_(ツ)_/¯ Bài 1: Học sinh");
            HocSinh hs = new HocSinh("Trần Duy Thanh", 9.6, 6.9);
            hs.Xuat();
            Console.WriteLine("Điểm trung bình: {0}", hs.DiemTrungBinh());

            // Bài 2
            Console.WriteLine("\n\n\n¯\\_(ツ)_/¯ Bài 2: Phân số");
            PhanSo ps1 = new PhanSo(1, 2);
            PhanSo ps2 = new PhanSo(1, 3);
            PhanSo ps3 = new PhanSo(8, -64);
            PhanSo ps4 = new PhanSo(0, 1);

            Console.WriteLine("{0} + {1} = {2}", ps1.Str(), ps2.Str(), ps1.Cong(ps2).ToiGian().Str());
            Console.WriteLine("{0} - {1} = {2}", ps1.Str(), ps2.Str(), ps1.Tru(ps2).ToiGian().Str());
            Console.WriteLine("{0} * {1} = {2}", ps1.Str(), ps2.Str(), ps1.Nhan(ps2).ToiGian().Str());
            Console.WriteLine("{0} / {1} = {2}", ps1.Str(), ps3.Str(), ps1.Chia(ps3).ToiGian().Str());
            try { ps1.Chia(ps4); } catch (System.Exception e) { Console.WriteLine("{0}", e.Message); } // Không thể chia cho 0

            // Bài 3
            Console.WriteLine("\n\n\n¯\\_(ツ)_/¯ Bài 3: Stack");
            Stack st = new Stack(5);
            try { st.Pop(); } catch (System.Exception e) { Console.WriteLine("{0}", e.Message); } // empty
            try { st.Pop(); } catch (System.Exception e) { Console.WriteLine("{0}", e.Message); } // empty
            st.Push(4);
            st.Push(3);
            st.Push(2);
            st.Push(7);
            st.Push(9);
            try { st.Push(8); } catch (System.Exception e) { Console.WriteLine("{0}", e.Message); }  // full
            Console.WriteLine("{0}", st.Pop());
            Console.WriteLine("{0}", st.Pop());
            Console.WriteLine("{0}", st.Pop());
            Console.WriteLine("{0}", st.Pop());
            Console.WriteLine("{0}", st.Pop());
            try { st.Pop(); } catch (System.Exception e) { Console.WriteLine("{0}", e.Message); }

            // Bài 4
            Console.WriteLine("\n\n\n¯\\_(ツ)_/¯ Bài 4: Queue");
            Queue q = new Queue(5);
            try { q.Out(); } catch (System.Exception e) { Console.WriteLine("{0}", e.Message); } // empty
            try { q.Out(); } catch (System.Exception e) { Console.WriteLine("{0}", e.Message); } // empty
            q.In(4);
            q.Debug();
            q.In(3);
            q.Debug();
            q.In(2);
            q.Debug();
            q.In(7);
            q.Debug();
            q.In(9);
            q.Debug();
            try { q.In(8); } catch (System.Exception e) { Console.WriteLine("{0}", e.Message); }  // full
            Console.WriteLine("{0}", q.Out());
            q.Debug();
            Console.WriteLine("{0}", q.Out());
            q.Debug();
            Console.WriteLine("{0}", q.Out());
            q.Debug();
            Console.WriteLine("{0}", q.Out());
            q.Debug();
            Console.WriteLine("{0}", q.Out());
            q.Debug();
            try { q.Out(); } catch (System.Exception e) { Console.WriteLine("{0}", e.Message); }

            // Bài 5
            Console.WriteLine("\n\n\n¯\\_(ツ)_/¯ Bài 5: Hình chữ nhật");
            HinhChuNhat hcn = new HinhChuNhat(20, 5);
            Console.WriteLine("Chiều Dài : {0}", hcn.Dai);
            Console.WriteLine("Chiều Rộng: {0}", hcn.Rong);
            Console.WriteLine("Chu vi:     {0}", hcn.ChuVi());
            Console.WriteLine("Chiều Rộng: {0}", hcn.DienTich());
            hcn.Ve();
        }
    }

    class HinhChuNhat
    {
        public int Dai { get; } = 0;
        public int Rong { get; } = 0;

        public HinhChuNhat(int dai, int rong)
        {
            this.Dai = dai;
            this.Rong = rong;
        }

        public int ChuVi()
        {
            return (this.Dai + this.Rong) * 2;
        }

        public int DienTich()
        {
            return (this.Dai * this.Rong);
        }

        public void Ve()
        {
            for (int i = 0; i < this.Rong; i++)
            {
                for (int k = 0; k < this.Dai; k++)
                {
                    if (i > 0 && i < this.Rong - 1 && k > 0 && k < this.Dai - 1)
                        Console.Write(" ");
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

class Queue
{
    private int[] _Data;
    private int _Size = 0;
    private int _Head = 0;

    public Queue(int size)
    {
        this._Size = size;
        this._Head = this._Size;
        this._Data = new int[this._Size];
    }

    public void Debug()
    {
        for (int i = 0; i < this._Size; i++)
        {

            if (i < this._Head) Console.Write("* ");
            else Console.Write("{0} ", this._Data[i]);
        }
        Console.WriteLine();
    }

    public void In(int v)
    {
        if (this._Head == 0)
        {
            throw new ArgumentException("Queue is already full");
        }
        this._Head--;
        this._Data[this._Head] = v;
    }

    public int Out()
    {
        if (this._Head == this._Size)
        {
            throw new ArgumentException("Stack is empty");
        }
        int ret = this._Data[this._Size - 1];
        for (int i = this._Size - 1; i > this._Head; i--)
        {
            this._Data[i] = this._Data[i - 1];
        }
        this._Head++;

        return ret;
    }
}

class Stack
{
    private int[] _Data;
    private int _Size = 0;
    private int _Top = 0;

    public Stack(int size)
    {
        this._Size = size;
        this._Top = -1;
        this._Data = new int[this._Size];
    }

    public void Push(int v)
    {
        if (this._Top == this._Size - 1)
        {
            throw new ArgumentException("Stack is already full");
        }
        this._Top++;
        this._Data[this._Top] = v;
    }

    public int Pop()
    {
        if (this._Top < 0)
        {
            throw new ArgumentException("Stack is empty");
        }
        this._Top--;
        return this._Data[this._Top + 1];
    }
}

class PhanSo
{
    private int _TuSo = 0;
    private int _MauSo = 1;

    public PhanSo(int tuSo, int mauSo)
    {
        this._TuSo = tuSo;
        this._MauSo = mauSo;
        if (this._MauSo == 0)
        {
            throw new ArgumentException("Mẫu số phải khác 0");
        }
    }

    public PhanSo ToiGian()
    {
        int sign = Math.Sign(this._TuSo * this._MauSo);
        int pTuSo = Math.Abs(this._TuSo);
        int pMauSo = Math.Abs(this._MauSo);
        Double minValue = Math.Min(pTuSo, pMauSo);

        for (int i = 2; i < Math.Sqrt(minValue) + 1; i++)
        {
            if (pTuSo % i != 0) continue;
            if (pMauSo % i != 0) continue;
            pTuSo /= i;
            pMauSo /= i;
            i--;
        }
        this._TuSo = pTuSo * sign;
        this._MauSo = pMauSo;

        return this;
    }

    public PhanSo Cong(PhanSo ps)
    {
        PhanSo ret = new PhanSo(0, 1);
        ret._TuSo = this._TuSo * ps._MauSo + this._MauSo * ps._TuSo;
        ret._MauSo = this._MauSo * ps._MauSo;
        return ret;
    }

    public PhanSo Tru(PhanSo ps)
    {
        PhanSo ret = new PhanSo(0, 1);
        ret._TuSo = this._TuSo * ps._MauSo - this._MauSo * ps._TuSo;
        ret._MauSo = this._MauSo * ps._MauSo;
        return ret;
    }

    public PhanSo Nhan(PhanSo ps)
    {
        PhanSo ret = new PhanSo(0, 1);
        ret._TuSo = this._TuSo * ps._TuSo;
        ret._MauSo = this._MauSo * ps._MauSo;
        return ret;
    }

    public PhanSo Chia(PhanSo ps)
    {
        if (ps.ToiGian()._TuSo == 0)
        {
            throw new ArgumentException("Không thể chia cho 0");
        }
        PhanSo ret = new PhanSo(0, 1);
        ret._TuSo = this._TuSo * ps._MauSo;
        ret._MauSo = this._MauSo * ps._TuSo;
        return ret;
    }

    public String Str()
    {
        return String.Format("{0}/{1}", this._TuSo, this._MauSo);
    }
}

class HocSinh
{
    private String _HoTen = "";
    private Double _DiemToan = 0;
    private Double _DiemVan = 0;

    public HocSinh(String hoTen, Double diemToan, Double diemVan)
    {
        this._HoTen = hoTen;
        this._DiemToan = diemToan;
        this._DiemVan = diemVan;
    }

    public void Xuat()
    {
        Console.WriteLine("Học Sinh: {0}\nĐiểm Toán: {1}\nĐiểm Văn: {2}", this._HoTen, this._DiemToan, this._DiemVan);
    }

    public Double DiemTrungBinh()
    {
        return (this._DiemToan + this._DiemVan) / 2;
    }
}