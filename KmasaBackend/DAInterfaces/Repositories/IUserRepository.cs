namespace DAInterfaces.Repositories
{
    public interface IUserRepository
    {
        
        /// <summary>
        /// Updates student's avatar.
        /// </summary>
        /// <param name="studentId">Id of the student</param>
        /// <param name="pictureLink">Link to picture storage.</param>
        /// <returns>True, if the link was updated, otherwise, false</returns>
        Task<bool> UpdatePicture(int studentId, string pictureLink);
    }
}
