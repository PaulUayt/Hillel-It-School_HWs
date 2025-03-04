namespace HW2_OOP_Principle.Task_2.Musical_Instruments
{
    class Skripka : MusicalInstrument
    {
        private string size;
        private string weight;
        private string material;

        public Skripka(string size, string weight, string material, string nameMusicalInstrument, 
            string soundMusicalInstrument, string descMusicalInstrument, string historyMusicalInstrument) : 
            base(nameMusicalInstrument, soundMusicalInstrument, descMusicalInstrument, historyMusicalInstrument)
        {
            this.size = size;
            this.weight = weight;
            this.material = material;
        }

        public string Size { get; set; }
        public string Weight { get; set; }
        public string Material { get; set; }

        public void ShowInfoSkripka()
        {
            Console.WriteLine($"\nName: {NameMusicalInstrument}.\nSize: {size}." +
                $"\nWeight: {weight}.\nMaterial: {material}.");
        }
    }
}
