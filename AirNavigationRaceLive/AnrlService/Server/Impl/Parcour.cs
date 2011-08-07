using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class Parcour : IDImpl, IParcour
    {
        private List<ILine> _Lines = new List<ILine>();
        internal Parcour(t_Parcour parcour)
            : base(parcour.ID)
        {
            foreach(t_Parcour_Line l in parcour.t_Parcour_Lines)
            {
                _Lines.Add(new Line(l.t_Line));
            }
        }

        public List<ILine> Lines
        {
            get { return _Lines; }
        }
    }
}
