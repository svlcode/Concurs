namespace Concurs.BO
{
    public class MnItem
    {
        public string Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class RatedMnItem
    {
        public MnItem MenuItem { get; set; }

        public int SweetScore { get; set; }
        public int CiorbaScore { get; set; }
        public int FructScore { get; set; }
        public int IngredientsScore { get; set; }
    }
}