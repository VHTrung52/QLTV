using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_QLTV.DTO
{
    class KeSach
    {
        private int maKeSach;
        private string tenKeSach;

        public KeSach(int maKeSach, string tenKeSach)
        {
            this.maKeSach = maKeSach;
            this.tenKeSach = tenKeSach;
        }

        public int MaKeSach { get => maKeSach; set => maKeSach = value; }
        public string TenKeSach { get => tenKeSach; set => tenKeSach = value; }
    }
}
