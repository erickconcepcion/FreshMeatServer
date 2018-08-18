using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshMeatServer.Logics
{
    public class CharacterVm : IViewModel
    {
        public Guid Id { get; set; }
        public string CharName { get; set; }

        public ICollection<ParentAttributeSelectionVm> ParentAttributeSelections { get; set; }

        public ICollection<MatcherVm> Matchers { get; set; }

        public Guid PlayerId { get; set; }
        public PlayerVm Player { get; set; }

    }
}
