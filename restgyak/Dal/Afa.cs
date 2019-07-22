﻿using System;
using System.Collections.Generic;

namespace restgyak.Dal
{
    public partial class Afa
    {
        public Afa()
        {
            Termek = new HashSet<Termek>();
        }

        public int Id { get; set; }
        public int? Kulcs { get; set; }

        public ICollection<Termek> Termek { get; set; }
    }
}
