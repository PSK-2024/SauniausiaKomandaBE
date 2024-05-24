﻿using SauniausiaKomanda.DAL.Data.Abstractions;
using SauniausiaKomanda.DAL.Entities;
using SauniausiaKomanda.DAL.Repositories.Abstractions;

namespace SauniausiaKomanda.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base(context)
        {
        }
    }
}
