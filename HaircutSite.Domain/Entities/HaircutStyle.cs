using CSharpFunctionalExtensions;

namespace HaircutSite.Domain.Entities
{
    public class HaircutStyle
    {
        public static readonly HaircutStyle Long = new HaircutStyle(1, "Long", "empty");
        public static readonly HaircutStyle Short = new HaircutStyle(2, "Short", "empty");

        public static readonly HaircutStyle[] All = { Long, Short };

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }

        private HaircutStyle(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
