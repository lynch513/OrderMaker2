using System.Linq;

namespace OrderMaker.Models.Validators
{
    public class PersonValidator
    {
        private readonly Person _person;

        public PersonValidator(Person person)
        {
            _person = person;
        }

        public bool TryValidate(out string? message)
        {
            message = default;
            var results = _person
                .Posts
                .Select(post => (Result: TryCheckPost(post, out var innerMessage), Message: innerMessage))
                .Where(i => !i.Result)
                .Select(i => i.Message)
                .ToArray();
            if (results.Length > 0)
                message = string.Join(", ", results);

            return results.Length == 0;
        }

        private bool CanBeWatcher() =>
            _person.Group > GroupType.Two;

        private bool CanBeMember() =>
            _person.Group >= GroupType.Two;

        private bool CanBeMaker() =>
            _person.Group > GroupType.Two;

        private bool CanBeSupervisor() =>
            _person.Group > GroupType.Two;

        private bool CanBeAdmitter() =>
            _person.Group > GroupType.Two;

        private bool CanBeDispatcher() =>
            _person.Group > GroupType.Two;

        private bool CanBeIssuer() =>
            _person.Group > GroupType.Three;

        private bool TryCheckPost(PostType postType, out string? message)
        {
            message = postType switch
            {
                PostType.Member when !CanBeMember() => "не может быть участником бригады",
                PostType.Watcher when !CanBeWatcher() => "не может быть наблюдающим",
                PostType.Maker when !CanBeMaker() => "не может быть производителем работ",
                PostType.Admitter when !CanBeAdmitter() => "не может быть допускающим",
                PostType.Supervisor when !CanBeSupervisor() => "не может быть ответственным руководителем работ",
                PostType.Issuer when !CanBeIssuer() => "не может быть выдающим наряд",
                PostType.Dispatcher when !CanBeDispatcher() =>
                    "не может быть выдающим разрешение на подготовку рабочих мест и на допуск",
                _ => default
            };
            return message == default;
        }
    }
}