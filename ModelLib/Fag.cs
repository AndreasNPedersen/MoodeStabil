using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class Fag
    {
        private FagEnum Navn { get; set; }

        private DateTime StartTid { get; set; }

        public Fag()
        {

        }

        public Fag(FagEnum navn, DateTime starttid)
        {
            Navn = navn;
            StartTid = starttid;
        }
        public override string ToString()
        {
            return $"{nameof(Navn)}: {Navn}, {nameof(StartTid)}: {StartTid}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            try
            {
                var otherFag = (Fag)obj;
                if (this.Navn.Equals(otherFag.Navn) &&
                    this.StartTid.Equals(otherFag.StartTid)) return true;
                return false;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }

    }

    public enum FagEnum
    {
        Teknologi,
        Systemudvikling,
        Programmering
    };

}
