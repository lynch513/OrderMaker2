using System.Linq;

namespace OrderMaker.Models.Checkers
{
    public class PersonChecker
    {
        private readonly Person _person;

        public bool IsValid { get; private set; }

        public string? ErrorMessage { get; private set; }

        public PersonChecker(Person person)
        {
            _person = person;
            Check();
        }

        protected void Check()
        {
            var results = _person
                .Posts
                .Select(post => (Result: TryCheckPost(post, out var message), Message: message))
                .Where(i => !i.Result)
                .ToArray();
            IsValid = results.Length != 0;
            ErrorMessage = string.Join(", ", results.Select(i => i.Message));
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
            return message != default;
        }
    }
}