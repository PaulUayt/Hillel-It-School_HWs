namespace HW2_OOP_Principle.Task_2.Musical_Instruments
{
    class Ukulele : MusicalInstrument
    {
        private string size;
        private string numStrings;
        private string material;
        public Ukulele(string size, string numStrings, string material, string nameMusicalInstrument,
            string soundMusicalInstrument, string descMusicalInstrument, string historyMusicalInstrument) :
            base(nameMusicalInstrument, soundMusicalInstrument, descMusicalInstrument, historyMusicalInstrument)
        {
            this.size = size;
            this.numStrings = numStrings;
            this.material = material;
        }
        public string Size { get => size; set { size = value; } }
        public string NumStrings { get => numStrings; set { numStrings = value; } }
        public string Material { get => material; set { material = value; } }

        public void ShowInfoUkulele()
        {
            Console.WriteLine($"\nName: {NameMusicalInstrument}.\nSize: {size}." +
                $"\nNumber of strings: {numStrings}.\nMaterial: {material}.");
        }
    }
}
