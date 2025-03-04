namespace HW2_OOP_Principle.Task_2.Musical_Instruments
{
    class Trombon : MusicalInstrument
    {
        private string material;
        private string length;
        private string diameter;

        public Trombon(string material, string length, string diameter, string nameMusicalInstrument,
            string soundMusicalInstrument, string descMusicalInstrument, string historyMusicalInstrument) :
            base(nameMusicalInstrument, soundMusicalInstrument, descMusicalInstrument, historyMusicalInstrument)
        {
            this.material = material;
            this.length = length;
            this.diameter = diameter;
        }

        public string Material { get; set; }
        public string Length { get; set; }
        public string Diameter { get; set; }

        public void ShowInfoTrombon()
        {
            Console.WriteLine($"\nName: {NameMusicalInstrument}.\nMaterial: {material}." +
                $"\nLength: {length}.\nDiameter: {diameter}.");
        }
    }
}
