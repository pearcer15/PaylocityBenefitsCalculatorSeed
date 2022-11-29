﻿using Api.Models;

namespace Api.Dtos.Dependent
{    
    public class GetDependentDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Relationship Relationship { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dependent"></param>
        public GetDependentDto(Models.Dependent dependent)
        {
            Id = dependent.Id;
            FirstName = dependent.FirstName;
            LastName = dependent.LastName;
            DateOfBirth = dependent.DateOfBirth;
            Relationship = dependent.Relationship;
        }

        public GetDependentDto() { }
    }
}
