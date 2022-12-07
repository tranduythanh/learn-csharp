using System.Collections;

public class XE {
    protected string hoten;
    protected int giothue;
    public virtual int TienThue {
          get {return 0;}
    }
    public virtual void Xuat() {}
    public virtual string ID() {
        return "X";
    }
}

public class XEDAP:XE {
    
    public XEDAP(string ht,int gt) {
        hoten = ht;
        giothue = gt;
    }
    public override string ID() {
        return "XD";
    }
    public override int TienThue {
        get {
            int T = 10000;
            if (giothue > 0) T = T+ 8000*(giothue-1);
            return T; 
        }
    }
    
    public override void Xuat() {
        Console.WriteLine(hoten + "\t" + giothue +"\t" + TienThue);
    }
}

public class XEMAY:XE {
    string loaixe;
    string bienso;
    public XEMAY(string ht,int gt,string lx,string bs) {
        hoten = ht;
        giothue = gt;
        loaixe=lx;
        bienso=bs;
    }
    public override string ID() {
        if (loaixe=="100")return "XM_100";
        else return "XM_250";
    }
    public override int TienThue {
        get {
            int T;
            if (loaixe == "100")T = 15000;
            else T = 20000;
            if (giothue > 0) T = T + 10000*(giothue- 1);
                return T;
        }
    }
    public override void Xuat() {
        Console.WriteLine("Xe may: " + hoten + "\t" + giothue +"\t" + loaixe + "\t" + bienso +"\t"+ TienThue);
    }
}
public class CUAHANG {
    public int n;
    ArrayList XTs;  //Xe cho thue
    public CUAHANG(int size) {
        n = size;
        XTs = new ArrayList();
    }
    public int menu() {
        int chon;
        do {
            Console.WriteLine("******Bang Chon Nha");
            Console.WriteLine("1. Nhap Xe Dap");
            Console.WriteLine("2. Nhap Xe May");
            chon=int.Parse(Console.ReadLine());
        } while((chon!=1) && (chon!=2));
        return chon;
    }
    public void NhapDSXeChoThue() {
        int chon;
        for(int i=0;i<n;i++) {
            chon=menu();
            if(chon==1) {
                Console.WriteLine("***** Ban chon nhap");
                Console.WriteLine("Ho ten nguoi thue");
                string ht=Console.ReadLine();
                Console.WriteLine("So gio thue?");
                int gt=int.Parse(Console.ReadLine());
                XTs.Add(new XEDAP(ht,gt));
            } else {
                Console.WriteLine("***** Ban chon nhap xe may ********");
                Console.WriteLine("Nguoi thue?");
                string ht=Console.ReadLine(); 
                Console.WriteLine("So gio thue?");
                int gt=int.Parse(Console.ReadLine()); 
                Console.WriteLine("Ban nhap vao loai xe (100 hoac 125) phan khoi:");
                string lx=Console.ReadLine();
                Console.WriteLine("Bien so:");
                string bs=Console.ReadLine();
                XTs.Add(new XEMAY(ht,gt,lx,bs));
            }
        }
    }

    public void XuatDSXeThue() {
        foreach(XE xe in this.XTs) {
            xe.Xuat();
        }
    }
    public long TongTienChoThue() {
        long ts=0;
        foreach(XE xe in this.XTs) {
            ts += xe.TienThue;
        }
        return ts;
    }
    public void XuatXeDap() {
        foreach(XE xe in this.XTs) {
            if (xe.ID() != "XD") continue;
            xe.Xuat();
        }
    }
    public long TongTienXeMay250() {
        long T = 0;
        foreach(XE xe in XTs) {
            if (xe.ID() == "XM_250") T += xe.TienThue;
        }
        return T;
    }
}

public class App {
    public static void Main() {
        CUAHANG ch=new CUAHANG(3);
        ch.NhapDSXeChoThue();
        Console.WriteLine("Xuat tat ca nhung thong tin thue xe:");
        ch.XuatDSXeThue();
        Console.WriteLine("Tong tien thue xe: " + ch.TongTienChoThue());
        Console.WriteLine("Thong tin ve xe dap cho thue:");
        ch.XuatXeDap();
        Console.WriteLine("Tong tien thue xe may 250 phan khoi: " + ch.TongTienXeMay250());
        Console.ReadLine();
    }
}