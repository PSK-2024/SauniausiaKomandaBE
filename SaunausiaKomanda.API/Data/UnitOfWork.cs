﻿using Microsoft.EntityFrameworkCore.Storage;
using SaunausiaKomanda.API.Abstractions;
using SaunausiaKomanda.API.Abstractions.Repositories;

namespace SaunausiaKomanda.API.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IApplicationDbContext _context;

        public UnitOfWork(
            IApplicationDbContext context,
            IRecipeRepository recipeRepository,
            ITagRepository tagRepository,
            IUserRepository userRepository,
            IImageRepository imageRepository)
        {
            _context = context;
            Recipes = recipeRepository;
            Tags = tagRepository;
            Users = userRepository;
            Images = imageRepository;
        }

        public IRecipeRepository Recipes { get; }
        public ITagRepository Tags { get; }
        public IUserRepository Users { get; }
        public IImageRepository Images { get; }


        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
