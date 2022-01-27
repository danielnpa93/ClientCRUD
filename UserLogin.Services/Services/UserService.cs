using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserLogin.Domain.Entities;
using UserLogin.Domain.Exceptions;
using UserLogin.Infrastructure.Interfaces;
using UserLogin.Services.DTO;
using UserLogin.Services.Interfaces;

namespace UserLogin.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserDTO> Create(UserDTO user)
        {
            var userExists = await _repository.GetByEmail(user.Email);

            if (userExists != null)
            {
                throw new DomainException("User with same email already registered");
            }

            var userEntity = _mapper.Map<User>(user);
            userEntity.Validate();

            var userCreated = await _repository.Create(userEntity);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _repository.GetAll();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _repository.GetByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetById(long id)
        {
            var userEntity = await _repository.GetById(id);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<IEnumerable<UserDTO>> SearchByEmail(string email)
        {
            var users = await _repository.SearchByEmail(email);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<IEnumerable<UserDTO>> SearchByName(string name)
        {
            var users = await _repository.SearchByName(name);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> Update(UserDTO user)
        {
            var userExists = _repository.GetById(user.Id);

            if (userExists == null)
            {
                throw new DomainException("User does not exists");
            }

            var userEntity = _mapper.Map<User>(user);
            userEntity.Validate();

            var updatedUser = await _repository.Update(userEntity);

            return _mapper.Map<UserDTO>(updatedUser);

        }
    }
}
