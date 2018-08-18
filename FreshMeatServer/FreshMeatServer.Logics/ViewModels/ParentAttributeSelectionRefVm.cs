﻿using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class ParentAttributeSelectionRefVm : IViewModel
    {
        public Guid Id { get; set; }
        public int Level { get; set; }


        public Guid ParentAttributeId { get; set; }
        public ParentAttributeVm ParentAttribute { get; set; }

        public Guid CharacterId { get; set; }
        public CharacterVm Character { get; set; }
    }
}
