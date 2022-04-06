namespace KMaSA.Models.DTO;

public abstract class PersonDto : IDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string Email { get; set; }

    public string PictureLink { get; set; }
}