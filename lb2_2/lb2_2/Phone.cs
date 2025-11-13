namespace lb2_2;

    public class Phone
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            return $"{Manufacturer} {Name} | Рік: {ReleaseDate.Year} | Ціна: {Price}$";
        }
    }
