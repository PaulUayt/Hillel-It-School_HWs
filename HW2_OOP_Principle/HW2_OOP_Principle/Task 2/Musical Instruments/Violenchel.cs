namespace HW2_OOP_Principle.Task_2.Musical_Instruments
{
    class Violenchel : MusicalInstrument
    {
        private string size;
        private string material;
        private string bow;

        public Violenchel(string size, string material, string bow, string nameMusicalInstrument,
            string soundMusicalInstrument, string descMusicalInstrument, string historyMusicalInstrument) :
            base(nameMusicalInstrument, soundMusicalInstrument, descMusicalInstrument, historyMusicalInstrument)
        {
            this.size = size;
            this.material = material;
            this.bow = bow;
        }

        public string Size { get => size; set { size = value; } }
        public string Material { get => material; set { material = value; } }
        public string Bow { get => bow; set { bow = value; } }

        public void ShowInfoViolenchel()
        {
            Console.WriteLine($"\nName: {NameMusicalInstrument}.\nSize: {size}." +
                $"\nMaterial: {material}.\nBow: {bow}.");
        }
    }
}
