﻿using AutoMapper;
using Business.Abstract;
using Business.Configuration.Auth;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation;
using DAL.Abstract;
using DTO.User;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<User2> GetAll()
        {
            return _userRepository.GetAll(); 
        }

        public CommandResponse Register(CreateUserRegisterRequest register)
        {
            //validasyonlar yazılacak
            var validator = new CreateUserRegisterRequestValidator();
            validator.Validate(register).ThrowIfException();

            var entity = _userRepository.Get(x => x.Email == register.Email);
           
            //var mappedEntity = _mapper.Map(register, entity);

            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(register.UserPassword, out passwordHash, out passwordSalt);

            var user = _mapper.Map(register, entity);

            user.Password = new UserPassword()
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _userRepository.Add(user);
            _userRepository.SaveChanges();

            return new CommandResponse()
            {
                Messsage = "Kullanıcı başarılı şekilde kaydedildi",
                Status = true
            };

        }
    }
}
