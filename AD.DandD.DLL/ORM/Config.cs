using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.DandD.BLL.ORM
{
    public class Config
    {
        private String path;
        public Config(string p)
        {
            path = p;
        }
        public virtual string Path
        { get { return path; }  set { path = @"C:\User\maxidata\Desktop\Elenco_Personaggi"; } }
    }
}
