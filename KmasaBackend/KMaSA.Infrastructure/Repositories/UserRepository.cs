using AutoMapper;
using DAInterfaces.Repositories;
using KMaSA.Infrastructure.EF;
using KMaSA.Models.DTO;
using KMaSA.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KMaSA.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
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

        ///// <inheritdoc/>
        ///// <exception cref="ArgumentOutOfRangeException">Throws, if the limit is less than zero.</exception>
        //public async Task<PagedModel<UserDto>> GetAsync(int page, int limit)
        //{
        //    if (limit < 0)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(limit), "Count of students must be non-negative.");
        //    }

        //    var entityPagedModel = await this.dbContext.Students
        //        .Include(s => s.Course)
        //        .PaginateAsync(page, limit, new CancellationToken());

        //    return new PagedModel<StudentDto>
        //    {
        //        PageSize = entityPagedModel.PageSize,
        //        CurrentPage = entityPagedModel.CurrentPage,
        //        TotalCount = entityPagedModel.TotalCount,
        //        Items = this.autoMapper
        //            .Map<IEnumerable<StudentEntity>, IEnumerable<StudentDto>>(entityPagedModel.Items),
        //    };
        //}

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

            //entity.PhotoUrl = photoUrl;

            await this.dbContext.SaveChangesAsync();

            return true;
        }

        private static void Update(UserEntity entity, UserDto userDto)
        {
            entity.FirstName = userDto.FirstName;
            entity.LastName = userDto.LastName;
            entity.MiddleName = userDto.MiddleName;
            entity.Email = userDto.Email;
            entity.DateOfBirth = userDto.DateOfBirth;
        }
    }
}
