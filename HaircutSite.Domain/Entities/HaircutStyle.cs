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

        // Constructor to fix CS1729 error
        private HaircutStyle(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static Result<HaircutStyle> FromId(int id)
        {
            var style = All.SingleOrDefault(x => x.Id == id);

            if (style == null)
            {
                return Result.Failure<HaircutStyle>($"No HaircutStyle with id {id}");
            }
            return style;
        }
    }
}
