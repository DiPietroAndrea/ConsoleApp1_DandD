using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.DandD.BLL.ORM
{
    public class Config
    {
        public Config(string p)
        {
            this.Path = p;
        }
        public string Path { get; set; }

    }
}
