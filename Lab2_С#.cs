using System;

namespace LabC_2
{

    class Transport
    {
        private bool Access = false;

        public virtual void getAccess()
        {
            Access = true;
        }

        public virtual void StartEngine()
        {
            if (!Access)
            {
                Console.WriteLine($"Нужно заправить ТС");
                Console.WriteLine($"Заправляю ТС....");
                getAccess();
                Console.WriteLine($"ТС заправленно....");

            }

            Console.WriteLine($"Вы завели ТС ...");
            Access = false;
        }

        public virtual void StartEngineElectric()
        {
            if (!Access)
            {
                Console.WriteLine($"Нужно зарядить ТС");
                Console.WriteLine($"Заряжаю ТС....");
                getAccess();
                Console.WriteLine($"ТС заряжено....");

            }

            Console.WriteLine($"Вы завели ТС ...");
            Access = false;
        }
    }

    class Auto:Transport
    {
        public string CompanyName_Car { get; set; }
        public string Model_Car { get; set; }
        public int Force_Engine { get; set; }
        public int Year_Of_Release { get; set; }


        public virtual void Info()
        {
            Console.WriteLine($"\n------------------ {CompanyName_Car} {Model_Car} -------------------------");
            Console.WriteLine($"Марка атомобиля: {CompanyName_Car}");
            Console.WriteLine($"Модель атомобиля: {Model_Car}");
            Console.WriteLine($"Мощность двигателя атомобиля: {Force_Engine} л.с");
            Console.WriteLine($"Год выпуска атомобиля: {Year_Of_Release} год");

        }

    }

        class Oil_Auto : Auto
        {
            public int Volume_GasTank { get; set; }

            public override void Info()
            {
                base.Info();
                Console.WriteLine($"Объем топливного бака атомобиля: {Volume_GasTank} л.");
            }

            public override void StartEngine()
            {
                Console.WriteLine($"\nВы пытаетель завести автомобиль {CompanyName_Car} {Model_Car}") ;
                base.StartEngine();
                Console.WriteLine("Слышно, как работает двигатель авто...");
            }
        }

        class Electric_Auto : Auto
        {

            public int Volume_Battery { get; set; }

            public override void Info()
            {
                base.Info();
                Console.WriteLine($"Объем аккумуляторной батареи атомобиля: {Volume_Battery} кВ/ч.");
            }

            public override void StartEngine()
            {
                Console.WriteLine($"\nВы пытаетель завести автомобиль {CompanyName_Car} {Model_Car}");
                base.StartEngineElectric();
                Console.WriteLine("Машина точно завелась??? Не слышу двигатель...");
            }

        }

        class Oil_Cargo : Auto
        {
            public int Volume_GasTank { get; set; }
            public override void Info()
            {
                base.Info();
                Console.WriteLine($"Объем топливного бака атомобиля: {Volume_GasTank} л.");
            }

            public override void StartEngine()
            {
                Console.WriteLine($"\nВы пытаетель завести грузовик {CompanyName_Car} {Model_Car}");
                base.StartEngine();
                Console.WriteLine("Очень громко...");
            }

        }


    class Ship:Transport
    {
        public string CompanyName_Ship { get; set; }
        public string Model_Ship { get; set; }
        public int Force_Engine { get; set; }
        public int Year_Of_Release { get; set; }
        public int Volume_GasTank { get; set; }

        public override void StartEngine()
        {
            Console.WriteLine($"\nВы пытаетель завести судно {CompanyName_Ship} {Model_Ship}");
            base.StartEngine();
            Console.WriteLine($"Корабль {CompanyName_Ship} {Model_Ship} готовится к отправлению... ...");

        }

        public virtual void Info()
        {

            Console.WriteLine($"\n------------------ {CompanyName_Ship} {Model_Ship} -------------------------");
            Console.WriteLine($"Марка судна: {CompanyName_Ship}");
            Console.WriteLine($"Модель судна: {Model_Ship}");
            Console.WriteLine($"Мощность двигателя судна: {Force_Engine} л.с");
            Console.WriteLine($"Год выпуска судна: {Year_Of_Release} год");

        }
    }

    class CruiseLainer : Ship
    {

        public int Capacity { get; set; }

        public override void StartEngine()
        {
            base.StartEngine();
            Console.WriteLine("Всем пассажирам на борт...");
            
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Количество мест для пассажиров: {Capacity} мест");
        }

    }

    class CargoShip : Ship
    {
        public int Tonnage { get; set; }

        public override void StartEngine()
        {
            base.StartEngine();
            Console.WriteLine("Загружаем контейнеры...");
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Вместимость судна: {Tonnage} тонн(ы)");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Auto car1 = new Oil_Auto { CompanyName_Car = "BMW", Model_Car = "M5", Force_Engine = 425, Volume_GasTank = 45, Year_Of_Release = 2011 };
            Auto car2 = new Oil_Auto { CompanyName_Car = "Toyota", Model_Car = "Yaris", Force_Engine = 95, Volume_GasTank = 35, Year_Of_Release = 2001 };
            Auto car3 = new Electric_Auto { CompanyName_Car = "Tesla", Model_Car = "Model X", Force_Engine = 247, Year_Of_Release = 2020, Volume_Battery = 4555 };
            Auto car4 = new Oil_Cargo { CompanyName_Car = "Iveco", Model_Car = "Eurocargo", Force_Engine = 837, Volume_GasTank = 237, Year_Of_Release = 2006 };

            car1.StartEngine();
            car2.Info();
            car3.Info();
            car4.Info();
            car3.StartEngine();
            car4.StartEngine();

            Ship ship1 = new CargoShip { CompanyName_Ship = "Emma", Model_Ship = "Emma Mеrsk", Force_Engine = 2415, Volume_GasTank = 3001, Year_Of_Release = 2006, Tonnage = 123 };
            Ship ship2 = new CruiseLainer { CompanyName_Ship = "Oasis", Model_Ship = "Oasis of the Seas", Force_Engine = 1205, Volume_GasTank = 5001, Year_Of_Release = 2019, Capacity = 5412 };

            ship1.StartEngine();
            ship1.Info();

            ship2.StartEngine();
            ship2.Info();
        }
    }
}
