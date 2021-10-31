using System;

namespace LabsLanguageC
{
    class FlowerShop
    {
        static void Main(string[] args)
        {

            int quantityClientsOnMonday = 2;   //Переменная количества посетителей  магазина в понедельник
            int quantityClientsOnTuesday = 4;   //Переменная количества посетителей  магазина в вторник
            int quantityClientsOnWednesday = 0; //Переменная количества посетителей  магазина в среду
            int quantityClientsOnThursday = 4;  //Переменная количества посетителей  магазина в четверг
            int quantityClientsOnFriday = 9;    //Переменная количества посетителей  магазина в пятницу
            int quantityClientsOnSaturday = 8;  //Переменная количества посетителей  магазина в субботу
            int quantityClientsOnSunday = 14;   //Переменная количества посетителей  магазина в воскресенье

            int normQuantityClients = 5; //Переменная нормы посетителей  в день

            double averagequantityClientsOnWeek = (double) (quantityClientsOnMonday + //Переменная среднего количества посетителей  в день
                quantityClientsOnTuesday + 
                quantityClientsOnWednesday +
                quantityClientsOnThursday+
                quantityClientsOnFriday +
                quantityClientsOnSaturday+
                quantityClientsOnSunday
                ) / 7;

            Console.WriteLine("Средние число покупателей в день(тип double) = " + averagequantityClientsOnWeek);

            int averageIntquantityClientsOnWeek = (quantityClientsOnMonday +  //Переменная среднего количества посетителей  в день(в другом типе данных)
                quantityClientsOnTuesday +
                quantityClientsOnWednesday +
                quantityClientsOnThursday +
                quantityClientsOnFriday +
                quantityClientsOnSaturday +
                quantityClientsOnSunday
                ) / 7;

            Console.WriteLine("Средние число покупателей в день(тип int) = " + averageIntquantityClientsOnWeek);

            double priceFlowerРose = 79.99;   //Цена розы
            double priceFlowerРeony = 69.99;   //Цена пиона
            double priceFlowerChrysanthemum = 119.99;   //Цена хризантемы


            bool permissionToSellFlowers;   //Переменная наличия разрешения на продажу цветов

            string firstSellerName = "Анна";  //Имя первого продавца
            string secondSellerName = "Иван";    //Имя второго продавца
            Console.WriteLine("Как зовут менеджера магазина? Введите его имя: ");
            string ManagerName = Console.ReadLine(); //Переменная имя менеджера магазина
            string NewSellerName; //Имя нового продавца

            double procentCommisionManager = 0.2; //Процент комиссии

            int[] arrQuantityClientsEveryDay = new int[7];            //Массив содержащий количество клиентов в каждый день недели
            arrQuantityClientsEveryDay[0] = quantityClientsOnMonday;
            arrQuantityClientsEveryDay[1] = quantityClientsOnTuesday;
            arrQuantityClientsEveryDay[2] = quantityClientsOnWednesday;
            arrQuantityClientsEveryDay[3] = quantityClientsOnThursday;
            arrQuantityClientsEveryDay[4] = quantityClientsOnFriday;
            arrQuantityClientsEveryDay[5] = quantityClientsOnSaturday;
            arrQuantityClientsEveryDay[6] = quantityClientsOnSunday;

            Console.WriteLine("\nСтатистика посещаемости магазина, которым руководит "+ ManagerName);

            for (int i = 0; i < arrQuantityClientsEveryDay.Length; i++)   //Цикл for со вложенным оператором if...else определяющий выполнение нормы посещения клиентов за день
            {
                if(arrQuantityClientsEveryDay[i] > normQuantityClients)
                {
                    Console.WriteLine("Норма клиентов за " + i + " день недели выполнена");
                }
                else
                {
                    Console.WriteLine("Норма клиентов за " + i + " день недели не выполнена");
                }
            }

            int[] arrQuantitySellRose = new int[7] { 5, 1, 0, 5, 0, 7, 7 };
            int[] arrQuantitySellРeony = new int[7] { 0, 7,8,5,6,1,0};
            int[] arrQuantitySellChrysanthemum = new int[7] { 7,4,7,8,10,2,9};

            //Работники работают 1/1

            double AmoundFirstSeller = 0;

            for (int i = 0; i < arrQuantityClientsEveryDay.Length; i += 2) //Цикл for определяющий заработанную сумму первым продавцом
            {
                AmoundFirstSeller += (double)(priceFlowerРose* arrQuantitySellRose[i] + priceFlowerРeony * arrQuantitySellРeony[i] + priceFlowerChrysanthemum * arrQuantitySellChrysanthemum[i]);
            }
            Console.WriteLine("\nПродавец по имени " + firstSellerName + " заработал(а) за неделю: " + AmoundFirstSeller + " рублей");

            double AmoundSecondSeller = 0;

            for (int i = 1; i < arrQuantityClientsEveryDay.Length; i += 2)  //Цикл for определяющий заработанную сумму вторым продавцом
            {
                AmoundSecondSeller += (double)(priceFlowerРose * arrQuantitySellRose[i] + priceFlowerРeony * arrQuantitySellРeony[i] + priceFlowerChrysanthemum * arrQuantitySellChrysanthemum[i]);
            }
            Console.WriteLine("\nПродавец по имени " + secondSellerName + " заработал(а) за неделю: " + AmoundSecondSeller + " рублей");

            double averageCoinOnDay = (AmoundSecondSeller + AmoundFirstSeller) / 2;

            Console.WriteLine("\nПришла проверка магазина. Нужно получить лицензию, чтобы продавать товар.");
            permissionToSellFlowers = false;
            int temp = 1;
            while (permissionToSellFlowers != true)  //Цикл while со вложенным оператором switch определяющий проверку магазина на лицензию
            {
                Console.WriteLine(temp + "-ая попытка получить лицензию...");
                Console.WriteLine("Магазин удовлетворяет требованиям? (Ответьте ДА/НЕТ)");
                string tempAnswer = Console.ReadLine();
                switch (tempAnswer)
                {
                    case "ДА":
                        Console.WriteLine("Вам удалось получить лицензию с " + temp + "-ой попытки");
                        permissionToSellFlowers = true;
                        break;
                    case "НЕТ":
                        Console.WriteLine("Вам неудалось получить лицензию с " + temp + "-ой попытки. Повторите попытку!");
                        temp++;
                        break;
                    default:
                        Console.WriteLine("Ответьте ДА/НЕТ на вопрос. Попробуйте снова...");
                        break;
                }
            }

            Console.WriteLine("\nКлиент попросил букет цветов из одиннакого количества всех позиций в магазине. Нужно собрать букет и расчитать стоимость");
            Console.WriteLine("Клиент: Количество каждого цветка в букете - ");
            int quantitykindflower = Convert.ToInt32(Console.ReadLine());

            int quantitykindflowerRose = 0;
            int quantitykindflowerPeony = 0;
            int quantitykindflowerChrysanthemum = 0;

            do                                                                      //Цикл do определяющий правильность составления букета по заказу клиента
                if (quantitykindflowerPeony != quantitykindflower)
                {
                    quantitykindflowerPeony++;
                }
                else if (quantitykindflowerRose != quantitykindflower)
                {
                    quantitykindflowerRose++;
                }
                else if (quantitykindflowerChrysanthemum != quantitykindflower)
                {
                    quantitykindflowerChrysanthemum++;
                }
            while (quantitykindflowerChrysanthemum != quantitykindflower);

            Console.WriteLine("Получился букет из: "+ quantitykindflowerPeony +" пионов, "+ quantitykindflowerRose +" роз, "+ quantitykindflowerChrysanthemum + " хризантем.");


            static double commisionManager(string mName, double procComm ,double averCoinDay) //Метод со вложенным оператором, проверяющим условие и изменяющим значения внутри метода
            {

                if (mName == "Михаил")
                {
                    procComm = 0.3;
                }

                double coinManager = procComm * averCoinDay;

                return coinManager;
            }

            Console.WriteLine("\n---------------------ОТЧЕТ---------------------");
            Console.WriteLine(ManagerName + " зарабатывает примерно " + commisionManager(ManagerName, procentCommisionManager, averageCoinOnDay) + " в день");


            static void nameNewSellers(out string newseller, string mName) { //Метод с параметром out 

                newseller = "Никто не";

                if (mName == "Михаил")
                {
                    newseller = "Коля";
                }
                else if(mName == "Абрам")
                {
                    newseller = "Ибрагим";
                }
                else if(mName == "Даниил")
                {
                    newseller = "Катя";
                }

                Console.WriteLine(newseller + " устроился(лась) сегодня на работу...");

            }

            static void normQuant(ref int normQuantityClientsManager, string mName) //Метод с параметром ref
            {
                if (mName == "Михаил")
                {
                    normQuantityClientsManager = 3;
                }
                else if (mName == "Абрам")
                {
                    normQuantityClientsManager = 5;
                }
                else if (mName == "Даниил")
                {
                    normQuantityClientsManager = 1;
                }

                Console.WriteLine("Сегодня нужно, чтобы пришло " + normQuantityClientsManager + " и более клиентов в магазин");

            }

            nameNewSellers(out NewSellerName, ManagerName);
            normQuant(ref normQuantityClients, ManagerName);

             //Console.WriteLine(nameNewSellers(out NewSellerName, ManagerName) + " устроился(лась) сегодня на работу...");
             //Console.WriteLine("Сегодня нужно, чтобы пришло "+ normQuant(ref normQuantityClients, ManagerName) + " и более клиентов в магазин");




        }
    }
}
