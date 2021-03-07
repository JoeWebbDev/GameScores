using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameScores.API.ViewModels;
using GameScores.DAL.Models;

namespace GameScores.API.Mappers
{
    public class DalRegistry
    {
        public IMapper Register()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserAccount, UserAccountViewModel>());
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
