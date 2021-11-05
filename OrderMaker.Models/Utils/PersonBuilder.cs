using System.Collections.Generic;
using System.Linq;

namespace OrderMaker.Models
{
    public class PersonBuilder
    {
        private readonly Person _person;

        public PersonBuilder()
        {
            _person = new Person
            {
                Posts = new HashSet<PostType>()
            };
        }

        public PersonBuilder SetName(string name)
        {
            _person.Name = name;
            return this;
        }

        public PersonBuilder SetAdditionalName(string name)
        {
            _person.AdditionalName = name;
            return this;
        }

        public PersonBuilder SetGroup(GroupType group)
        {
            _person.Group = group;
            return this;
        }

        public PersonBuilder SetSpeciality(string speciality)
        {
            _person.Speciality = speciality;
            return this;
        }

        public PersonBuilder AddPost(PostType post)
        {
            _person.Posts.Add(post);
            return this;
        }

        public PersonBuilder IsMember => AddPost(PostType.Member);

        public PersonBuilder IsWatcher => AddPost(PostType.Watcher);

        public PersonBuilder IsMaker => AddPost(PostType.Maker);

        public PersonBuilder IsAdmitter => AddPost(PostType.Admitter);

        public PersonBuilder IsSupervisor => AddPost(PostType.Supervisor);

        public PersonBuilder IsIssuer => AddPost(PostType.Issuer);

        public PersonBuilder IsDispatcher => AddPost(PostType.Issuer);

        public Person Build()
        {
            return _person;
        }
    }
}