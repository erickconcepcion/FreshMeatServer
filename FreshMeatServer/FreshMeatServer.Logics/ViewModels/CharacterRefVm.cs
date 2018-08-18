using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshMeatServer.Logics
{
    public class CharacterRefVm : IViewModel
    {
        public Guid Id { get; set; }
        public string CharName { get; set; }

        public Guid PlayerId { get; set; }
        public PlayerRefVm Player { get; set; }

    }
}
