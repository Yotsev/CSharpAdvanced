namespace _07.RawData
{
    class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string mode, Engine engine,Cargo cargo, Tire[]tires)
        {
            Model = mode;
            Engine = new Engine();
            Engine = engine;
            Cargo = new Cargo();
            Cargo = cargo;
            Tires = new Tire[4];
            Tires = tires;
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }

    }
}
