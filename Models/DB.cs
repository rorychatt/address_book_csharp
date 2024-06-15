namespace webapiDotNetTrainingGround.Models
{
    public class DB
    {
        public DB()
        {
            Developers = new List<Developer>() {
            new() { Id = 1, Name = "Marcus", Email = "marcus@salt.dev" },
            new() { Id = 2, Name = "Beatrice", Email = "bea@salt.dev" },
        };
        }
        public List<Developer> Developers { get; set; }
    }
}