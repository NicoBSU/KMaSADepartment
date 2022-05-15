namespace KMaSA.Models.DTO;

public abstract class UpdateUserDto : IDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string Email { get; set; }

    public string PhotoUrl { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string City { get; set; }

    public string Country { get; set; }
}