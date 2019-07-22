﻿using System;
using System.Collections.Generic;

namespace restgyak.Dal
{
    public partial class FizetesMod
    {
        public FizetesMod()
        {
            Megrendeles = new HashSet<Megrendeles>();
        }

        public int Id { get; set; }
        public string Mod { get; set; }
        public int? Hatarido { get; set; }

        public ICollection<Megrendeles> Megrendeles { get; set; }
    }
}
