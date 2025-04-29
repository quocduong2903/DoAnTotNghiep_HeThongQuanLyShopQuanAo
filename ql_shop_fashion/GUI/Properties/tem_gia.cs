using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class tem_gia
    {
        private int maSP;
        private string tenSP;
        private string tenKT;
        private string tenMau;
        private decimal giaBan;
        private decimal? giaGiam;
        private int? so_tem;

        public int MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string TenKT { get => tenKT; set => tenKT = value; }
        public string TenMau { get => tenMau; set => tenMau = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
        public decimal GiaGiam { get => (decimal)giaGiam; set => giaGiam = value; }
        public int So_tem { get => (int)so_tem; set => so_tem = value; }
    }
}
