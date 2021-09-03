namespace _08.CarSalesman
{
    class Car
    {
        private string model;
        private Engine engine;
        private string weight;
        private string color;

        public Car()
        {
            Weight = "n/a";
            Color = "n/a";
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

    }
}
