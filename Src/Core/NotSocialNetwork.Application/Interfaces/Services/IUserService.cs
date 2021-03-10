﻿using NotSocialNetwork.Application.Entities;
using System;
using System.Collections.Generic;

namespace NotSocialNetwork.Application.Interfaces.Services
{
    public interface IUserService
    {
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(Guid id);
        UserEntity Add(UserEntity user);
        UserEntity Update(UserEntity user);
        UserEntity Delete(Guid id);
    }
}