using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalago.Interfaces.Auxiliar;
using ApiCatalago.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalago.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IDbUnitOfWork _uof;        
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthController(IDbUnitOfWork uof, ITokenService tokenService, IMapper mapper)
        {
            _uof = uof;
            _tokenService = tokenService;
            _mapper = mapper;            
        }

        



    }
}