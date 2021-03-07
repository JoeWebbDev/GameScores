using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameScores.DAL.Models;
using GameScores.DAL;
using GameScores.API.ViewModels;
using AutoMapper;

namespace GameScores.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly ILogger<UserAccountController> _logger;
        private ISimpleRepo<UserAccount, int> _dal;
        private IMapper _mapper;

        public UserAccountController(ILogger<UserAccountController> logger, UserAccountRepository dal, IMapper mapper)
        {
            _logger = logger;
            _dal = dal;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<UserAccountViewModel> GetUserAccount(int id)
        {
            var res = await _dal.ReadAsync(id);
            return _mapper.Map<UserAccountViewModel>(res);
        }

        T Map<T, T2>(T2 source) where T2: UserAccount { return T; }

        [HttpPost]
        public async Task<UserAccountViewModel> AddUserAccount(UserAccount userAccount)
        {
            var id = await _dal.CreateAsync(userAccount);
            var res = await _dal.ReadAsync(id);
            return _mapper.Map<UserAccountViewModel>(res);
        }


    }
}
