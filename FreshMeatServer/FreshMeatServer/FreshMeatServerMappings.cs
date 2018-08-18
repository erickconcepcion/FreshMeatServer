using AutoMapper;
using FreshMeatServer.DataModel;
using FreshMeatServer.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshMeatServer
{
    public class FreshMeatServerMappings : Profile
    {
        public override string ProfileName => "FreshMeatServerMappings";
        public FreshMeatServerMappings()
        {
            CreateMap<ApplicationUser, ApplicationUserVm>()
                .ReverseMap();
            CreateMap<Character, CharacterVm>()
                .ReverseMap();
            CreateMap<ChildAttribute, ChildAttributeVm>()
                .ReverseMap();
            CreateMap<ChildAttributeSelection, ChildAttributeSelectionVm>()
                .ReverseMap();
            CreateMap<Inventory, InventoryVm>()
                .ReverseMap();
            CreateMap<Item, ItemVm>()
                .ReverseMap();
            CreateMap<Master, MasterVm>()
                .ReverseMap();
            CreateMap<Match, MatchVm>()
                .ReverseMap();
            CreateMap<Matcher, MatcherVm>()
                .ReverseMap();
            CreateMap<ParentAttribute, ParentAttributeVm>()
                .ReverseMap();
            CreateMap<ParentAttributeSelection, ParentAttributeSelectionVm>()
                .ReverseMap();
            CreateMap<Player, PlayerVm>()
                .ReverseMap();
            CreateMap<Status, StatusVm>()
                .ReverseMap();
        }
    }
}
