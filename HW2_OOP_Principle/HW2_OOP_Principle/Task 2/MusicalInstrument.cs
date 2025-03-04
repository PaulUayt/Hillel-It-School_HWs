namespace HW2_OOP_Principle.Task_2
{
    interface IMusicalInstrument
    {
        void Sound();
        void Show();
        void Desc();
        void History();
    }

    class MusicalInstrument: IMusicalInstrument
    {
        private string nameMusicalInstrument;
        private string soundMusicalInstrument;
        private string descMusicalInstrument;
        private string historyMusicalInstrument;

        public MusicalInstrument(string nameMusicalInstrument, string soundMusicalInstrument, 
            string descMusicalInstrument, string historyMusicalInstrument)
        {
            this.nameMusicalInstrument = nameMusicalInstrument;
            this.soundMusicalInstrument = soundMusicalInstrument;
            this.descMusicalInstrument = descMusicalInstrument;
            this.historyMusicalInstrument = historyMusicalInstrument;
        }

        public string NameMusicalInstrument
        {
            get => nameMusicalInstrument;
            set { nameMusicalInstrument = value; }
        }

        public string SoundMusicalInstrument
        {
            get => soundMusicalInstrument;
            set { soundMusicalInstrument = value; }
        }

        public string DescMusicalInstrument
        {
            get => descMusicalInstrument;
            set { descMusicalInstrument = value; }
        }

        public string HistoryMusicalInstrument
        {
            get => historyMusicalInstrument;
            set { historyMusicalInstrument = value; }
        }

        public void Sound() => Console.WriteLine(soundMusicalInstrument);
        public void Show() => Console.WriteLine(nameMusicalInstrument);
        public void Desc() => Console.WriteLine(descMusicalInstrument);
        public void History() => Console.WriteLine(historyMusicalInstrument);
    }
}
