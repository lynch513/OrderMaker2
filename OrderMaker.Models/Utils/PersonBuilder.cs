using System.Collections.Generic;
using System.Linq;

namespace OrderMaker.Models
{
    public class PersonBuilder
    {
        private Person _person;

        public PersonBuilder()
        {
            _person = new Person();
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

        public PersonBuilder SetPost(PostType post)
        {
            AddPost(post);
            return this;
        }

        public PersonBuilder IsMember
        {
            get
            {
                AddPost(PostType.Member);
                return this;
            }
        }
        
        public PersonBuilder IsWatcher
        {
            get
            {
                AddPost(PostType.Watcher);
                return this;
            }
        }

        public PersonBuilder IsMaker
        {
            get
            {
                AddPost(PostType.Maker);
                return this;
            }
        }

        public PersonBuilder IsAdmitter
        {
            get
            {
                AddPost(PostType.Admitter);
                return this;
            }
        }

        public PersonBuilder IsSupervisor
        {
            get
            {
                AddPost(PostType.Supervisor);
                return this;
            }
        }

        public PersonBuilder IsIssuer
        {
            get
            {
                AddPost(PostType.Issuer);
                return this;
            }
        }

        public PersonBuilder IsDispatcher
        {
            get
            {
                AddPost(PostType.Issuer);
                return this;
            }
        }

        public Person Build()
        {
            return _person;
        }

        private void AddPost(PostType post)
        {
            var posts = _person.Posts == null ? 
                new HashSet<PostType>() { post } : new HashSet<PostType>(_person.Posts) { post };
            _person.Posts = posts.ToArray();
        }
    }
}