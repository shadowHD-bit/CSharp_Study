using System;
using System.Collections.Generic;

namespace LabC_2
{

    class Transport 
    {
        private bool Access = false;

        public void getAccess()
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

    class Auto:Transport, IYearble
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

        public void transportIsYear()
        {
            if (Year_Of_Release < 1950)
            {
                Console.WriteLine("Такого не может быть! Транспорт изобрели до нашей эры???");
            }
            else if (Year_Of_Release >= 1950 && Year_Of_Release < 2000)
            {
                Console.WriteLine("Транспорт старый");
            }
            else if (Year_Of_Release >= 2000 && Year_Of_Release < 2010)
            {
                Console.WriteLine("Транспорт обычный");
            }
            else if (Year_Of_Release >= 2010 && Year_Of_Release < 2020)
            {
                Console.WriteLine("Транспорт довольно новый");
            }
            else
            {
                Console.WriteLine("Транспорт очень новый");
            }
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

    //------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Лаб3

    //Существующий на платформе .NET интерфейс IComparable
    //public interface IComparable
    //{
    //    int CompareTo(object o);
    //}

    //Существующий на платформе .NET интерфейс ICompare
    //public interface ICompare
    //{
    //    int CompareTo(object o1, object o2);
    //}


    class CompForce<T> : IComparer<T>
        where T : AutoTrans
    {
        // Реализуем интерфейс IComparer (сравнение двух объектов класса Авто и определение объекта с большим параметром мощности двигателя)
        public int Compare(T force1, T force2)
        {
            if (force1.Force_Engine < force1.Force_Engine)
                return 1;
            if (force1.Force_Engine > force2.Force_Engine)
                return -1;
            else return 0;
        }
    }

    interface ISpeedble
    {
        public void autoIsSpeed();
        int Speed { get; set; }

    }

    interface IYearble
    {
        public void transportIsYear();
        int Year_Of_Release { get;}

    }


    class AutoTrans : IComparable<AutoTrans>, ISpeedble, IYearble
    {

        
        public string CompanyName_Car { get; set; }
        public string Model_Car { get; set; }
        public int Force_Engine { get; set; }
        public int Year_Of_Release { get; set; }
        public int Speed { get; set; }



        public AutoTrans() { }
        public AutoTrans(string CompanyName_Car, string Model_Car, int Force_Engine, int Year_Of_Release)
        {

            this.CompanyName_Car = CompanyName_Car;
            this.Model_Car = Model_Car;
            this.Force_Engine = Force_Engine;
            this.Year_Of_Release = Year_Of_Release;
            CreateCar += createCar;
            CreateCar();


        }

        // Реализуем интерфейс IComparable<T>
        public int CompareTo(AutoTrans obj)
        {
            if (this.Year_Of_Release > obj.Year_Of_Release)
                return 1;
            if (this.Year_Of_Release < obj.Year_Of_Release)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return String.Format("Название компании: {0, 10} \tМодель: {1, 10} \tМощнось двигателя: {2, 10} \tГод выпуска: {3, 10}",
                this.CompanyName_Car, this.Model_Car, this.Force_Engine, this.Year_Of_Release);
        }


        public virtual void Info()
        {
            Console.WriteLine($"\n------------------ {CompanyName_Car} {Model_Car} -------------------------");
            Console.WriteLine($"Марка автомобиля: {CompanyName_Car}");
            Console.WriteLine($"Модель автомобиля: {Model_Car}");
            Console.WriteLine($"Мощность двигателя автомобиля: {Force_Engine} л.с");
            Console.WriteLine($"Год выпуска автомобиля: {Year_Of_Release} год");

        }

        public void createInfo()
        {

            Console.WriteLine($"\n------Ты выбрал автомобиль {CompanyName_Car} {Model_Car} -------------------------");
            Console.WriteLine($"Марка автомобиля: {CompanyName_Car}");
            Console.WriteLine($"Модель автомобиля: {Model_Car}");
            Console.WriteLine($"Мощность двигателя автомобиля: {Force_Engine} л.с");
            Console.WriteLine($"Год выпуска автомобиля: {Year_Of_Release} год");

        }




        public void autoIsSpeed()
        {
            if(Speed < 0)
            {
                Console.WriteLine("Такого не может быть! Вы движетесь назад???");
            }
            else if (Speed>=0 && Speed<60)
            {
                Console.WriteLine("Автомобиль медленный");
            }
            else if (Speed >= 60 && Speed < 180)
            {
                Console.WriteLine("Автомобиль обычный");
            }
            else
            {
                Console.WriteLine("Автомобиль быстрый");
            }
        }

        public void transportIsYear()
        {
            if (Year_Of_Release < 1950)
            {
                Console.WriteLine("Такого не может быть! Транспорт изобрели до нашей эры???");
            }
            else if (Year_Of_Release >= 1950 && Year_Of_Release < 2000)
            {
                Console.WriteLine("Транспорт старый");
            }
            else if (Year_Of_Release >= 2000 && Year_Of_Release < 2010)
            {
                Console.WriteLine("Транспорт обычный");
            }
            else if (Year_Of_Release >= 2010 && Year_Of_Release < 2020)
            {
                Console.WriteLine("Транспорт довольно новый");
            }
            else
            {
                Console.WriteLine("Транспорт очень новый");
            }
        }


        public static void StartEngine()
        {
            Console.WriteLine("Запустился двигатель");
        }

        public static void LumpCar()
        {
            Console.WriteLine("Загорелась приборная панель");
        }

        public static void StartRadio()
        {
            Console.WriteLine("Включилось радио");
        }

        public static void CheckCarBelt()
        {
            Console.WriteLine("Пристегните ремень безопасности!");
        }



        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void DisplayRedMessage(string message)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            
            Console.ResetColor();
        }

        private static void DisplayBlueMessage(string message)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);

            Console.ResetColor();
        }

        private static void DisplayGreenMessage(string message)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);

            Console.ResetColor();
        }

        public void ChooseCar()
        {
            CreateCar -= createCar;
            CreateCar += createInfo;
            CreateCar();



            if (Year_Of_Release < 1950)
            {
                YearCarTest += DisplayRedMessage;
                YearCarTest?.Invoke("Где ты откопал такую старую машину");
            }
            else if (Year_Of_Release >= 1950 && Year_Of_Release < 2000)
            {
                YearCarTest += DisplayRedMessage;
                YearCarTest?.Invoke("Ты выбрал старую машину... Зачем?");
            }
            else if (Year_Of_Release >= 2000 && Year_Of_Release < 2010)
            {
                YearCarTest += DisplayBlueMessage;
                YearCarTest?.Invoke("Ты выбрал обычную машину... Ты поехал в офис на работу?");
                
            }


            else if (Year_Of_Release >= 2010 && Year_Of_Release < 2020)
            {
                YearCarTest += DisplayGreenMessage;
                YearCarTest?.Invoke("Ух ты! Ты выбрал новенькую машину... ");
            }
            else
            {
                YearCarTest -= DisplayMessage;
                YearCarTest += DisplayGreenMessage;
                YearCarTest?.Invoke("Да ты серьезно? Ты выбрал очень современную и новую машину... ");
            }

        }

        public void createCar()
        {
            Console.WriteLine($"Ты создал автомобиль {CompanyName_Car} {Model_Car} ...") ;
        }



        public event DifferentMessage YearCarTest;
        public event CarAlert CreateCar;


    }

    public delegate void CarAlert();
    public delegate void DifferentMessage(string Message);




    class Program
    {
        static void Main(string[] args)
        {

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Console.WriteLine("\n ---------------------------------------Лабораторная работа 2-----------------------------------------------\n");

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
            
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
            Console.WriteLine("\n ---------------------------------------Лабораторная работа 3-----------------------------------------------\n");



            CompForce<AutoTrans> comparer = new CompForce<AutoTrans>();

            List<AutoTrans> autoList = new List<AutoTrans>();

            autoList.Add(new AutoTrans ( "BMW", "M5", 425, 2011 ));
            autoList.Add(new AutoTrans ( "Toyota", "Yaris",  95,  2001 ));
            autoList.Add(new AutoTrans ( "Tesla",  "Model X",  247,  2020));
            autoList.Add(new AutoTrans ( "Iveco",  "Eurocargo",  837,  2006 ));

            Console.WriteLine("Исходный каталог добавленных автомобилей: \n");
            foreach (AutoTrans object_auto in autoList)
                Console.WriteLine(object_auto);


            Console.WriteLine("\nТеперь автомобили отсортированны по мощности двигателя (реализация интерфейса IComparer): \n");
            autoList.Sort(comparer);
            foreach (AutoTrans object_auto in autoList)
                Console.WriteLine(object_auto);


            Console.WriteLine("\nТеперь автомобили отсортированны по году выпуска (реализация интерфейса IComparable): \n");
            autoList.Sort();
            foreach (AutoTrans object_auto in autoList)
                Console.WriteLine(object_auto);


            AutoTrans auto5 = new AutoTrans { CompanyName_Car = "BMW", Model_Car = "M5", Force_Engine = 425, Year_Of_Release = 2011, Speed = 181 };

            auto5.autoIsSpeed();

            auto5.transportIsYear();

            car4.transportIsYear();


            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------

            Console.WriteLine("\n ---------------------------------------Лабораторная работа 4-----------------------------------------------\n");

            Console.ReadKey();

            List<AutoTrans> carList = new List<AutoTrans>();

            carList.Add(new AutoTrans("BMW", "M5", 425, 2011));
            carList.Add(new AutoTrans("Toyota", "Yaris", 95, 2001));
            carList.Add(new AutoTrans("Tesla", "Model X", 247, 2020));
            carList.Add(new AutoTrans("Iveco", "Eurocargo", 837, 2006));
            Console.WriteLine();

            Console.WriteLine("Исходный каталог добавленных автомобилей: \n");
            foreach (AutoTrans object_auto in carList)
                Console.WriteLine(object_auto);

            Console.ReadKey();

            AutoTrans testCar = new AutoTrans("Lada", "Kalina", 89, 2015);

            carList.Insert(2, testCar);
            Console.WriteLine("\nОбновленный каталог автомобилей(insert): \n");
            foreach (AutoTrans object_auto in carList)
                Console.WriteLine(object_auto);

            Console.ReadKey();

            carList.Remove(testCar);

            Console.WriteLine("\nОбновленный каталог автомобилей(remove): \n");
            foreach (AutoTrans object_auto in carList)
                Console.WriteLine(object_auto);

            Console.ReadKey();

            carList.RemoveAt(2);
            Console.WriteLine("\nОбновленный каталог автомобилей(removeAt(2)): \n");
            foreach (AutoTrans object_auto in carList)
                Console.WriteLine(object_auto);

            Console.ReadKey();

            carList.Clear();
            Console.WriteLine("\nОчищенный каталог автомобилей: \n");
            foreach (AutoTrans object_auto in carList)
                Console.WriteLine(object_auto);

            Console.WriteLine("Количество элементов списка: {0}", carList.Count);

            Console.ReadKey();

            carList.Add(new AutoTrans("BMW", "M5", 425, 2011));
            carList.Add(new AutoTrans("Toyota", "Yaris", 95, 2001));
            carList.Add(new AutoTrans("Tesla", "Model X", 247, 2020));
            carList.Add(new AutoTrans("Iveco", "Eurocargo", 837, 2006));

            Console.WriteLine("\nСозданный каталог автомобилей: \n");
            foreach (AutoTrans object_auto in carList)
                Console.WriteLine(object_auto);

            Console.ReadKey();

            CompForce<AutoTrans> comparator = new CompForce<AutoTrans>();

            Console.WriteLine("\nТеперь автомобили отсортированны по мощности двигателя (реализация интерфейса IComparer): \n");
            autoList.Sort(comparator);
            foreach (AutoTrans object_auto in autoList)
                Console.WriteLine(object_auto);

            Console.ReadKey();

            Console.WriteLine("\nТеперь автомобили отсортированны по году выпуска (реализация интерфейса IComparable): \n");
            autoList.Sort();
            foreach (AutoTrans object_auto in autoList)
                Console.WriteLine(object_auto);

            Console.WriteLine();





            AutoTrans carTest = new AutoTrans("BMW", "M5", 425, 2011);
            Console.WriteLine();

            CarAlert carTestMess = new CarAlert(AutoTrans.StartEngine);
            carTestMess += AutoTrans.LumpCar;
            carTestMess += AutoTrans.StartRadio;
            carTestMess += AutoTrans.CheckCarBelt;
            carTestMess.Invoke();


            Console.WriteLine();
            Console.ReadKey();


            AutoTrans OldCar = new AutoTrans("BMW", "X5", 478, 1947);
            AutoTrans UsuallyCar = new AutoTrans("Audi", "Q6", 372, 2003);
            AutoTrans NewCar = new AutoTrans("Toyota", "Avensis", 278, 2021);

            OldCar.ChooseCar();
            Console.WriteLine();
            Console.ReadKey();


            UsuallyCar.ChooseCar();
            Console.WriteLine();
            Console.ReadKey();



            NewCar.ChooseCar();
            Console.WriteLine();
            Console.ReadKey();


       
        }
    }
}
