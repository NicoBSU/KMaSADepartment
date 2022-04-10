﻿namespace KMaSA.Models.DTO;

public class StudyResourceDto : IDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Link { get; set; }

    public ICollection<SubjectDto> Subjects { get; set; }

    public ICollection<MentorDto> TaggedMentors { get; set; }
}