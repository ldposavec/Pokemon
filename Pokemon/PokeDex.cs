namespace Pokemon
{
    public class PokeDex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PokeType Type { get; set; }
        public int Level { get; set; }
    }

    public enum PokeType
    {
        Grass = 0,
        Fire = 1,
        Water = 2
    }
}
