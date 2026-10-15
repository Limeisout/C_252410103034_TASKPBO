namespace pbo_sistem_karyawan
{
    public class Perusahaan
    {
        public List<Karyawan> daftarKaryawan { get; set; }

        public Perusahaan()
        {
            daftarKaryawan = new List<Karyawan>();
        }

        public void TambahKaryawan(Karyawan karyawan)
        {
            daftarKaryawan.Add(karyawan);
        }

        public void TampilkanDaftarKaryawan()
        {
            Console.WriteLine("Daftar Karyawan dan Gaji:");
            foreach (var karyawan in daftarKaryawan)
            {
                Console.WriteLine($"- Nama : {karyawan.Nama}, Gaji : {karyawan.Gaji}");
            }
        }
    }

    public class  Karyawan
    {
        public string Nama { get; set; }
        public int Gaji { get; set; }

        public Karyawan(string nama, int Gaji)
        {
            this.Nama = nama;
            this.Gaji = Gaji;
        }

        public virtual void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja");
        }

        public void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji}");
        }
    }

    public class Tetap : Karyawan
    {
        public double Tunjangan { get; set; }

        public Tetap(string nama, int gaji, double tunjangan) : base(nama, gaji)
        {
            this.Tunjangan = tunjangan;
        }

        public void HitungGajiTotal()
        {
            double gajiTotal = Gaji + Tunjangan;
            Console.WriteLine($"Gaji Total {Nama}: {gajiTotal}");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja sebagai karyawan tetap");
        }
    }

    public class Kontrak : Karyawan
    {
        public int Durasi { get; set; }

        public Kontrak(string nama, int gaji, int durasi) : base(nama, gaji)
        {
            this.Durasi = durasi;
        }

        public void CekKontrak()
        {
            Console.WriteLine($"Kontrak {Nama} berlaku selama {Durasi} bulan");
        }

        public virtual void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja sebagai karyawan kontrak");
        }
    }

    public class Manager : Tetap
    {
        public Manager(string nama, int gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public void Memimpin()
        {
            Console.WriteLine($"{Nama} sedang memimpin tim");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja sebagai manager");
        }
    }

    public class Staff : Tetap
    {
        public Staff(string nama, int gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public void KerjakanTugas()
        {
            Console.WriteLine($"{Nama} sedang mengerjakan tugas");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja sebagai staff");
        }
    }

    public class Magang : Kontrak
    {
        public Magang(string nama, int gaji, int durasi) : base(nama, gaji, durasi) { }

        public void Belajar()
        {
            Console.WriteLine($"{Nama} sedang belajar");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja sebagai magang");
        }
    }

    public class Freelancer : Kontrak
    {
        public Freelancer(string nama, int gaji, int durasi) : base(nama, gaji, durasi) { }

        public void AmbilProyek()
        {
            Console.WriteLine($"{Nama} sedang mengerjakan proyek");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja sebagai freelancer");
        }   
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Perusahaan perusahaan = new Perusahaan();
            Tetap karyawanTetap = new Tetap("Budi", 5000000, 1000000);
            Kontrak karyawankontrak = new Kontrak("Siti", 3000000, 12);
            Manager rolemanager = new Manager("Andi", 8000000, 2000000);
            Staff rolestaff = new Staff("Rina", 4000000, 500000);
            Magang rolemagang = new Magang("Dewi", 2000000, 6);
            Freelancer rolefreelancer = new Freelancer("Joko", 2500000, 3);

            perusahaan.TambahKaryawan(karyawanTetap);
            perusahaan.TambahKaryawan(karyawankontrak);
            perusahaan.TambahKaryawan(rolemanager);
            perusahaan.TambahKaryawan(rolestaff);
            perusahaan.TambahKaryawan(rolemagang);
            perusahaan.TambahKaryawan(rolefreelancer);

            perusahaan.TampilkanDaftarKaryawan();

            Console.WriteLine("\n----Demonstrasi Polymorfisme----");
            Karyawan[] daftarPolimorfik = { karyawanTetap, karyawankontrak, rolemanager, rolestaff, rolemagang, rolefreelancer };

            foreach (Karyawan staffkaryawan in daftarPolimorfik)
            {
                staffkaryawan.Kerja();
            }

            Console.WriteLine("\n----Memanggil Method Khusus----");
            Console.WriteLine("\nsoal 1 & 2");
            rolemanager.Kerja();
            rolefreelancer.Kerja();

            rolemanager.Memimpin();

            Console.WriteLine("\nsoal 3");
            rolemanager.InfoKaryawan();
            Console.WriteLine($"Tunjangan: {rolemanager.Tunjangan}");
            rolemanager.HitungGajiTotal();

            Console.WriteLine("\nsoal 4");
            rolemagang.Belajar();

            Console.WriteLine("\nsoal 5");
            Karyawan karyawan = new Staff("Hendra", 4500000, 600000);
            karyawan.Kerja();
        }
    }
}