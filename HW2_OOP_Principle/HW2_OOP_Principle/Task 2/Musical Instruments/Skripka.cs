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

        public string Size { get => size; set { size = value; } }
        public string Weight { get => weight; set { weight = value; } }
        public string Material { get => material; set { material = value; } }

        public void ShowInfoSkripka()
        {
            Console.WriteLine($"\nName: {NameMusicalInstrument}.\nSize: {size}." +
                $"\nWeight: {weight}.\nMaterial: {material}.");
        }
    }
}
