using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GELive
{
    public partial class GEToolStrip : Component
    {
        public GEToolStrip()
        {
            InitializeComponent();
        }

        public GEToolStrip(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
