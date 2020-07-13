﻿using System.Collections.Generic;

namespace GraphQLNetCore.Models
{
    public class Person
    {
        public int id { get; set; }
        public int age { get; set; }
        public string eyeColor { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public List<Person> friends { get; set; }
        public List<Skill> skills { get; set; }
        public Skill favSkill { get; set; }
        public int? favSkillId { get; set; }
    }

    public class PersonData
    {
        public string id { get; set; }
        public int age { get; set; }
        public string eyeColor { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public List<string> friends { get; set; }
        public List<string> skills { get; set; }
        public string favSkill { get; set; }

        public static Person ToEntity(PersonData data)
        {
            if (data == default)
                return default;

            return new Person()
            {
                id = int.Parse(data.id),
                age = data.age,
                eyeColor = data.eyeColor,
                email = data.email,
                favSkillId = int.TryParse(data.favSkill, out int parsedValue) ? parsedValue : default(int?),
                name = data.name,
                surname = data.surname
            };
        }
    }
}