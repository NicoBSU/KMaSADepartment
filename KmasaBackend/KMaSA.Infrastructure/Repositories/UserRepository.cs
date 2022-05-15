using AutoMapper;
using KMaSA.Infrastructure.EF;
using KMaSA.Models.DTO;
using KMaSA.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KMaSA.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly KmasaContext dbContext;
        private readonly IMapper autoMapper;

        /// <summary>
        /// Initializes a new instance of <see cref="StudentsRepository"/>.
        /// </summary>
        /// <param name="dbContext">Database context.</param>
        /// <param name="autoMapper">Mapper for mapping users's ef entity into dto and vice versa.</param>
        /// <exception cref="ArgumentNullException">Throws, if the dbContext or autoMapper is null.</exception>
        public UserRepository (KmasaContext dbContext, IMapper autoMapper)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentOutOfRangeException">Throws, if the student's id is less than zero.</exception>
        /// <exception cref="ArgumentException">Throws, picture link is null or empty or whitespace.</exception>
        public async Task<bool> UpdatePicture(int userId, string photoUrl)
        {
            if (userId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), "Users identifier must be positive.");
            }

            if (string.IsNullOrWhiteSpace(photoUrl))
            {
                throw new ArgumentException("Picture link is null or empty or whitespace.");
            }

            var entity = await this.dbContext.Users
                .SingleOrDefaultAsync(s => s.Id == userId);

            if (entity is null)
            {
                return false;
            }

            entity.PhotoUrl = photoUrl;

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        private static void Update(UserEntity entity, UpdateUserDto userDto)
        {
            entity.FirstName = userDto.FirstName;
            entity.LastName = userDto.LastName;
            entity.MiddleName = userDto.MiddleName;
            entity.Email = userDto.Email;
            entity.City = userDto.City;
            entity.Country = userDto.Country;
            entity.DateOfBirth = userDto.DateOfBirth;
            entity.Gender = userDto.Gender;
        }
    }
}
