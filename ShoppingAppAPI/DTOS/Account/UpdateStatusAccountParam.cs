using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS.Account
{
    public class UpdateStatusAccountParam
    {
        public int AccountID { get; set; }
        public int Status { get; set; }
    }
}
