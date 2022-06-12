using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson12_2
{
    public class Info : IComparable<Info>
    {
        internal char[] delimiter = new char[] { '\t' };
        public Info(string str)
        {
            string[] columns = str.Split(delimiter);
            this.filetype = columns[0];
            this.filename = columns[1];
            this.filedata = Convert.ToDateTime(columns[2]);
        }
        public string filename { get; set; }
        public string filetype { get; set; }
        public DateTime filedata { get; set; }

        public int CompareTo(Info? other)
        {
            return filedata.CompareTo(other.filedata);
        }
    }
}
