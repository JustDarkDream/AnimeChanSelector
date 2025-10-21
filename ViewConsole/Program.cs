using Model;

namespace ViewConsole
{
    internal class Program
    {
        static BourgeoisLogic logic = new BourgeoisLogic();
        static bool isFiltered = false;

        static void Main(string[] args)
        {
            Registration();
            MainMenu();
        }

        ///<summary>Создает пользователя</summary>
        static void Registration()
        {
            //-1 означает, что переменная не содержит подходящее значение
            string firstName = "";
            string lastName = "";
            int size = -1;
            int age = -1;
            int height = -1;
            int weight = -1;
            while (size == -1) //После корректного введения size регистрация заканчивается
            {
                Console.Clear();
                Console.WriteLine("Привет! А теперь введи свои данные!\n\n");
                Console.Write("Имя: ");
                if (firstName.Length > 0) //Если пользователь что-либо ввёл, то подгружается сохранившееся значение
                {
                    Console.WriteLine(firstName);
                }
                else
                {
                    firstName = Console.ReadLine();
                    if (firstName.Length == 0) //Если пользователь ничего не ввёл
                    {
                        Console.WriteLine("\nНичего не введено в строку \"Имя\". Введите что-нибудь");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Фамилия: ");
                if (lastName.Length > 0) //Если пользователь что-либо ввёл, то подгружается сохранившееся значение
                {
                    Console.WriteLine(lastName);
                }
                else
                {
                    lastName = Console.ReadLine();
                    if (lastName.Length == 0) //Если пользователь ничего не ввёл
                    {
                        Console.WriteLine("\nНичего не введено в строку \"Фамилия\". Введите что-нибудь");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Возраст: ");
                if (age != -1) //Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(age);
                }
                else
                {

                    if (!(int.TryParse(Console.ReadLine(), out age) && age >= 0)) //Если пользователь ввёл некорректное значение
                    {
                        age = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Возраст\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Рост: ");
                if (height != -1) //Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(height);
                }
                else
                {
                    if (!(int.TryParse(Console.ReadLine(), out height) && height >= 0)) //Если пользователь ввёл некорректное значение
                    {
                        height = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Рост\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Вес: ");
                if (weight != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(weight);
                }
                else
                {
                    if (!(int.TryParse(Console.ReadLine(), out weight) && weight >= 0))//Если пользователь ввёл некорректное значение
                    {
                        weight = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Вес\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Размер: ");
                if (!(int.TryParse(Console.ReadLine(), out size) && size >= 0)) //Так как значение последнее, его невозможно подгрузить автоматически
                {
                    size = -1;
                    Console.WriteLine("\nВведено некорректное значение в \"Размер\". Введите неотрицательно число");
                    Console.ReadKey();
                    continue;
                }
            }
            Console.WriteLine("\nРегистрация прошла успешно!");
            Console.ReadKey();
            logic.SaveMainPerson(firstName, lastName, age, height, weight, size);
        }

        ///<summary>Главное меню, которое выводит таблицу с тянками и дает возможность что-либо делать с этой таблицей</summary>
        static void MainMenu()
        {
            logic.CreateAnimeChan();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать! Развлекайся))\n");
                Console.WriteLine("".PadLeft(151, '_')); //Создает линию верхушки таблицы
                Console.WriteLine("||" + "ИМЯ".PadLeft(18, ' ') + "".PadLeft(19, ' ') + "||" + "ФАМИЛИЯ".PadLeft(16, ' ') +
                    "".PadLeft(17, ' ') + "||" + "ВОЗРАСТ".PadLeft(16, ' ') + "".PadLeft(17, ' ') + "||" + "ID".PadLeft(19, ' ')
                    + "".PadLeft(19, ' ') + "||"); //Разбивает таблицу на колонки и именует их
                Console.WriteLine("".PadLeft(151, '_')); //Создаёт линию под названиями колонок
                if (isFiltered)
                {
                    List<AnimeChan> chan = logic.LoadFilterAnimeChanList();
                    int i = 0;
                    foreach (AnimeChan anime in chan)
                    {
                        Console.WriteLine("|| " + anime.FirstName + "|| ".PadLeft(40 - anime.FirstName.Length - 1, ' ') + anime.LastName +
"|| ".PadLeft(40 - anime.LastName.Length - 5, ' ') + anime.Age + "|| ".ToString().PadLeft(40 - anime.Age.ToString().Length - 5, ' ') +
anime.Id + "|| ".ToString().PadLeft(40 - anime.Id.ToString().Length, ' ')); //Пишет характеристики из отфильтрованного листа с Аниме Тян
                        Console.WriteLine("".PadLeft(151, '_')); //Создаёт линию под характеристиками тян
                    }
                }
                else
                {
                    List<AnimeChan> chan = logic.LoadAnimeChanList().ToList();
                    int i = 0;
                    foreach (AnimeChan anime in chan)
                    {
                        Console.WriteLine("|| " + anime.FirstName + "|| ".PadLeft(40 - anime.FirstName.Length - 1, ' ') + anime.LastName +
"|| ".PadLeft(40 - anime.LastName.Length - 5, ' ') + anime.Age + "|| ".ToString().PadLeft(40 - anime.Age.ToString().Length - 5, ' ') +
anime.Id + "|| ".ToString().PadLeft(40 - anime.Id.ToString().Length, ' ')); //Пишет характеристики из отфильтрованного листа с Аниме Тян
                        Console.WriteLine("".PadLeft(151, '_')); //Создаёт линию под характеристиками тян

                    }
                }
                Console.WriteLine("\n1. Создать Тян");
                Console.WriteLine("2. Найти Тян");
                Console.WriteLine("3. Редактировать Тян");
                Console.WriteLine("4. Удалить Тян");
                Console.WriteLine("5. Показать Тян");
                Console.WriteLine("6. Отфильтровать");
                Console.WriteLine("7. Убрать фильтр");
                Console.Write("\n\nВведите значениие: ");

                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    switch (n)
                    {
                        case 1: //Пользователь сам создает Тян руками
                            CreateOrChangeAnimeChan(null);
                            break;
                        case 2: //Создаёт тян автоматически
                            logic.FindAnimeChan();
                            Console.WriteLine("\nТян была найдена!!!");
                            break;
                        case 3: //Позволяет пользователю редактировать тян с определенным id
                            Console.WriteLine("\nВведите ID Тянки, которую хотите редактировать");
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                AnimeChan animeChan = logic.FindForId(id); //Проверяет на существование тян с таким id
                                if (animeChan == null)
                                {
                                    Console.WriteLine("\nТянки с таким ID не существует!");
                                }
                                else
                                {
                                    CreateOrChangeAnimeChan(animeChan);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)");
                            }
                            break;
                        case 4: //Удаляет тян с определенным пользователем id
                            Console.WriteLine("\nВведите ID Тянки, которую хотите удалить");
                            if (int.TryParse(Console.ReadLine(), out int id2))
                            {
                                AnimeChan animeChan = logic.FindForId(id2);//Проверяет на существование тян с таким id
                                if (animeChan == null)
                                {
                                    Console.WriteLine("\nТянки с таким ID не существует!");
                                }
                                else
                                {
                                    logic.DeleteAnimeChan(id2);
                                    Console.WriteLine("\nУдаление прошло успешно!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)");
                            }
                            break;
                        case 5: //Показывет пользователю характеристики какой-либо тян, выбранной с помощью id
                            Console.WriteLine("\nВведите ID Тянки, которую хотите увидеть");
                            if (int.TryParse(Console.ReadLine(), out int id3))
                            {
                                AnimeChan animeChan = logic.FindForId(id3);//Проверяет на существование тян с таким id
                                if (animeChan == null)
                                {
                                    Console.WriteLine("\nТянки с таким ID не существует!");
                                }
                                else
                                {
                                    ShowAnimeChan(animeChan);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)");
                            }
                            break;
                        case 6://Отфильтровывает таблицу с тянками
                            Filter(logic.LoadFilterStats());
                            break;
                        case 7://Убирает фильтрацию таблицы с тянками
                            isFiltered = false;
                            logic.DestroyFilter();
                            Console.WriteLine("\nФильтр отключен!");
                            break;
                        default:
                            Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nНекорректная запись. Введите число!");
                }
                Console.ReadKey();
            }
        }

        ///<summary>Позволяет создать новую тянку или редактировать параметры существующей</summary>
        /// <param name="animeChan">Тянка, чьи параметры могут быть изменены</param>
        static void CreateOrChangeAnimeChan(AnimeChan animeChan)
        {
            //-1 означает, что переменная не содержит подходящее значение
            string firstName = "";
            string lastName = "";
            int size = -1;
            int age = -1;
            int height = -1;
            int weight = -1;
            int endChoise = -1; //Финальный выбор пользователя, связанный с навыками

            string firstNameText = "Имя: ";
            string lastNameText = "Фамилия: ";
            string ageText = "Возраст: ";
            string heightText = "Рост: "; //Показывается этот текст, если пользователь добавляет новую тянку
            string weightText = "Вес: ";
            string sizeNameText = "Размер: ";
            string statusText = "Создай свою Аниме-Тян!\n";

            List<Skill> skills = new List<Skill>();
            if (animeChan != null)
            {
                skills = animeChan.Skills; //Подгружает скиллы для тянки
                firstNameText = "Имя (было " + animeChan.FirstName + "): ";
                lastNameText = "Фамилия (было " + animeChan.LastName + "): ";
                ageText = "Возраст (было " + animeChan.Age + "): ";
                heightText = "Рост (было " + animeChan.Height + "): "; //Показывается этот текст, если пользователь редактирует определенную тян
                weightText = "Вес (было " + animeChan.Weight + "): ";
                sizeNameText = "Размер (было " + animeChan.Size + "): ";
                statusText = "Редактируй свою Тян!\n";
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(statusText); //Вводит текст статуса (создавать или редактировать тян)
                Console.Write(firstNameText); //Вводит текст с Именем
                if (firstName.Length > 0) //Если пользователь что-либо ввёл, то подгружается сохранившееся значение
                {
                    Console.WriteLine(firstName);
                }
                else
                {
                    firstName = Console.ReadLine();
                    if (firstName.Length == 0)//Если пользователь ничего не ввёл
                    {
                        Console.WriteLine("\nНичего не введено в строку \"Имя\". Введите что-нибудь");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write(lastNameText);//Вводит текст с Фамилией
                if (lastName.Length > 0)//Если пользователь что-либо ввёл, то подгружается сохранившееся значение
                {
                    Console.WriteLine(lastName);
                }
                else
                {
                    lastName = Console.ReadLine();
                    if (lastName.Length == 0)//Если пользователь ничего не ввёл
                    {
                        Console.WriteLine("\nНичего не введено в строку \"Фамилия\". Введите что-нибудь");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write(ageText);//Вводит текст с Возрастом
                if (age != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(age);
                }
                else
                {

                    if (!(int.TryParse(Console.ReadLine(), out age) && age >= 0)) //Если пользователь ввёл некорректное значение
                    {
                        age = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Возраст\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write(heightText);//Вводит текст с Ростом
                if (height != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(height);
                }
                else
                {
                    if (!(int.TryParse(Console.ReadLine(), out height) && height >= 0))//Если пользователь ввёл некорректное значение
                    {
                        height = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Рост\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write(weightText);//Вводит текст с Весом
                if (weight != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(weight);
                }
                else
                {
                    if (!(int.TryParse(Console.ReadLine(), out weight) && weight >= 0))//Если пользователь ввёл некорректное значение
                    {
                        weight = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Вес\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write(sizeNameText);//Вводит текст с Размером
                if (size != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(size);
                }
                else
                {
                    if (!(int.TryParse(Console.ReadLine(), out size) && size >= 0))//Если пользователь ввёл некорректное значение
                    {
                        size = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Размер\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Навыки: ");
                for (int i = 0; i < skills.Count; i++)//Перечисляет все заданные навыки
                {
                    if (i != 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(skills[i].Name);
                }
                Console.WriteLine("\n\nРедактировать Навыки?\n");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Нет");
                Console.Write("\nВведите значение: ");
                if (int.TryParse(Console.ReadLine(), out endChoise))
                {
                    switch (endChoise)
                    {
                        case 1: //Позволяет пользователю изменить содержание списка с элементами Skills
                            ChooseSkills(skills);
                            List<Skill> skill = logic.LoadSkills();
                            break;
                        case 2: //Завершает создание/редактирование тянки
                            Console.WriteLine("\nСохранение прошло успешно!");
                            break;
                        default:
                            Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)");
                            break;
                    }
                    if (endChoise == 2) //Выходит из бесконечного цикла
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nНекорректная запись. Введите число!");
                }
                Console.ReadKey();
            }
            if (animeChan == null) //Проверка, создает ли он тян или редактирует
            {
                logic.AddAnimeChan(firstName, lastName, age, height, weight, size, skills); //Создаёт новую тян
            }
            else
            {
                logic.SaveChangeAnimeChan(firstName, lastName, age, height, weight, size, skills, animeChan.Id); //Редактирует тян с определенным id
            }
        }

        ///<summary>Позволяет редактировать какой-либо список с элементами Skills</summary>
        /// <param name="skills">Сам список, который будет редактирован</param>
        static void ChooseSkills(List<Skill> skills)
        {
            //-1 означает, что переменная не содержит подходящее значение
            int n = -1; //Выбор элемента Skills или выбор выхода
            while (true)
            {
                Console.Clear();
                Console.Write("Ваш список навыков: ");
                for (int i = 0; i < skills.Count; i++) //Перечисляет навыки, которые есть в списке
                {
                    if (i != 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(skills[i].Name);
                }
                Console.Write("\n\nВыберите навык (или выход): \n\n");
                int k = 1; //Переменная для визуального оформления выбора
                foreach (Skills skill in Enum.GetValues(typeof(Skills))) //Перечисляет все возможные навыки
                {
                    Console.WriteLine(k + ". " + skill);
                    k++;
                }
                Console.WriteLine(k + ". Выход"); //Добавляет строчку с выходом
                Console.Write("\nВведите значение: ");
                if ((n > 0 && Enum.GetValues(typeof(Skills)).Length + 1 >= n)) //Загружает значение, если пользователь уже выбрал навык и не решил, что с ним сделать
                {
                    Console.WriteLine(n);
                }
                if ((n > 0 && Enum.GetValues(typeof(Skills)).Length + 1 >= n) || int.TryParse(Console.ReadLine(), out n))
                {
                    if (Enum.GetValues(typeof(Skills)).Length >= n) //Если пользователь выбрал какой-либо навык и ввёл правильно
                    {
                        int j = 0; //Хранит результат выбора, связанный с судьбой навыка
                        Console.WriteLine("\nДобавить или удалить?: \n"); //Вопрос, связанный с судьбой навыка
                        Console.WriteLine("1. Добавить");
                        Console.WriteLine("2. Удалить");
                        Console.Write("\nВведите значение: ");
                        if (int.TryParse(Console.ReadLine(), out j))
                        {
                            switch (j)
                            {
                                case 1: //Добавляет навык в список, если того навыка еще нет
                                    string skillName = ((Skills)Enum.GetValues(typeof(Skills)).GetValue(n - 1)).ToString();
                                    if (!skills.Any(x => x.Name == skillName))
                                    {
                                        skills.Add(logic.CreateSkill(skillName));
                                        Console.WriteLine("\n\nНавык успешно добавлен!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n\nЭтот навык уже есть в вашем списке!");
                                    }
                                    n = -1;
                                    break;
                                case 2: //Удаляет навык из списка, если он в списке есть
                                    string skillName2 = ((Skills)Enum.GetValues(typeof(Skills)).GetValue(n - 1)).ToString();
                                    var skillToRemove = skills.FirstOrDefault(x => x.Name == skillName2);

                                    if (skillToRemove != null)
                                    {
                                        skills.Remove(skillToRemove);
                                        Console.WriteLine("\n\nНавык успешно удален!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n\nЭтого навыка нет в вашем списке!");
                                    }
                                    n = -1;
                                    break;
                                default:
                                    Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)1");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)2");
                        }
                    }
                    else if (Enum.GetValues(typeof(Skills)).Length + 1 == n) //Если пользователь выбрал выход
                    {
                        Console.WriteLine("\nСохранение прошло успешно!");
                        break;
                    }
                    else //Если он ввёл фигню
                    {
                        Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)3");
                    }
                }
                else
                {
                    Console.WriteLine("\nНекорректная запись. Введите число!");
                }
                Console.ReadKey();
            }

            foreach (Skill skill in skills)
            {
                logic.SaveSkills(skill); //Сохраняет навыки
            }
        }

        ///<summary>Показывает параметры Тянки, с которой пользователь может встречаться</summary>
        /// <param name="animeChan">Тянка, чьи параметры будут показаны и с неё может встречаться пользователь</param>
        static void ShowAnimeChan(AnimeChan animeChan)
        {
            string firstName = animeChan.FirstName;
            string lastName = animeChan.LastName;
            int size = animeChan.Size;
            int age = animeChan.Age;
            int height = animeChan.Height;
            int weight = animeChan.Weight;
            List<Skill> skills = animeChan.Skills;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Вот сама Аниме-Тян)\n\n");
                Console.WriteLine("Имя: " + firstName);
                Console.WriteLine("Фамилия: " + lastName);
                Console.WriteLine("Возраст: " + age); //Блок кода, выводящий информацию про аниме тян
                Console.WriteLine("Рост: " + height);
                Console.WriteLine("Вес: " + weight);
                Console.WriteLine("Размер: " + size);

                Console.Write("Навыки: ");
                for (int i = 0; i < skills.Count; i++) //Перечисляет навыки аниме тянки
                {
                    if (i != 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(skills[i].Name);
                }
                Console.WriteLine("\n\nВыбрать её?\n");
                Console.WriteLine("1. Да"); //Влюбиться или не?
                Console.WriteLine("2. Нет");
                Console.Write("\nВведите значение: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    switch (n)
                    {
                        case 1: //Выбирает её и пишет результат
                            logic.SaveId(animeChan.Id);
                            Conclution();
                            break;
                        case 2: //Прекращает просмотр этой тянки
                            Console.WriteLine("\nНу как хочешь...");
                            break;
                        default:
                            Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)");
                            break;
                    }
                    if (n == 2) //Выходит из бесконечного цикла
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nНекорректная запись. Введите число!");
                }
                Console.ReadKey();
            }
        }

        ///<summary>Выводит итог отношений с Тянкой</summary>
        static void Conclution()
        {
            Console.Clear();
            Console.WriteLine(logic.Conclution()); //Выходит огромный текст с итогом
            Console.ReadKey();
            Environment.Exit(0); //Закрывает консольку
        }

        ///<summary>Позволяет отфильтровать таблицу с тянками</summary>
        /// <param name="filterStats">Содержит все сохранения пользователя для фильтрации</param>
        static void Filter(FilterStats filterStats)
        {
            //-1 означает, что переменная не содержит подходящее значение
            int ageFrom = -1;
            int ageTo = -1;
            int heightFrom = -1;
            int heightTo = -1;
            int weightFrom = -1;
            int weightTo = -1;
            int sizeFrom = -1;
            int sizeTo = -1;
            string result = "";

            int skillsChange = -1; //Сохраняет выбор человека по поводу редактирования навыков

            List<Skill> skills = filterStats.Skills; //Загружает сохраненные навыки, которые пользователь выбрал ранее

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Филтрация!!!!!\n");
                Console.Write("Возраст От (было " + filterStats.AgeFrom + "): "); //Добавляет в скобках ранее значение Возраста ОТ
                if (ageFrom != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(ageFrom);
                }
                else
                {
                    result = Console.ReadLine();
                    if (result == "")
                    {
                        Console.WriteLine("\nОкей, сохраню");
                        break;
                    }
                    if (!(int.TryParse(result, out ageFrom) && ageFrom >= 0))//Если пользователь ввёл некорректное значение
                    {
                        ageFrom = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Возраст От\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Возраст До (было " + filterStats.AgeTo + "): ");//Добавляет в скобках ранее значение Возраста До
                if (ageTo != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(ageTo);
                }
                else
                {
                    result = Console.ReadLine();
                    if (result == "")
                    {
                        Console.WriteLine("\nОкей, сохраню");
                        break;
                    }
                    if (!(int.TryParse(result, out ageTo) && ageTo >= 0))//Если пользователь ввёл некорректное значение
                    {
                        ageTo = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Возраст До\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                    else if (ageTo < ageFrom)//Не позволяет, чтобы значение ОТ было больше значения ДО
                    {
                        ageTo = -1;
                        Console.WriteLine("\nЗначение \"Возраст ОТ\" не может быть больше значения \"Возраст ДО\"");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Рост От (было " + filterStats.HeightFrom + "): ");//Добавляет в скобках ранее значение Роста От
                if (heightFrom != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(heightFrom);
                }
                else
                {
                    result = Console.ReadLine();
                    if (result == "")
                    {
                        Console.WriteLine("\nОкей, сохраню");
                        break;
                    }
                    if (!(int.TryParse(result, out heightFrom) && heightFrom >= 0))//Если пользователь ввёл некорректное значение
                    {
                        heightFrom = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Рост От\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Рост До (было " + filterStats.HeightTo + "): ");//Добавляет в скобках ранее значение Роста До
                if (heightTo != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(heightTo);
                }
                else
                {
                    result = Console.ReadLine();
                    if (result == "")
                    {
                        Console.WriteLine("\nОкей, сохраню");
                        break;
                    }
                    if (!(int.TryParse(result, out heightTo) && heightTo >= 0))//Если пользователь ввёл некорректное значение
                    {
                        heightTo = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Рост До\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                    else if (heightTo < heightFrom)//Не позволяет, чтобы значение ОТ было больше значения ДО
                    {
                        heightTo = -1;
                        Console.WriteLine("\nЗначение \"Рост ОТ\" не может быть больше значения \"Рост ДО\"");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Вес От (было " + filterStats.WeightFrom + "): ");//Добавляет в скобках ранее значение Веса От
                if (weightFrom != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(weightFrom);
                }
                else
                {
                    result = Console.ReadLine();
                    if (result == "")
                    {
                        Console.WriteLine("\nОкей, сохраню");
                        break;
                    }
                    if (!(int.TryParse(result, out weightFrom) && weightFrom >= 0))//Если пользователь ввёл некорректное значение
                    {
                        weightFrom = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Вес От\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Вес До (было " + filterStats.WeightTo + "): ");//Добавляет в скобках ранее значение Веса До
                if (weightTo != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(weightTo);
                }
                else
                {
                    result = Console.ReadLine();
                    if (result == "")
                    {
                        Console.WriteLine("\nОкей, сохраню");
                        break;
                    }
                    if (!(int.TryParse(result, out weightTo) && weightTo >= 0))//Если пользователь ввёл некорректное значение
                    {
                        weightTo = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Вес До\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                    else if (weightTo < weightFrom)//Не позволяет, чтобы значение ОТ было больше значения ДО
                    {
                        weightTo = -1;
                        Console.WriteLine("\nЗначение \"Вес ОТ\" не может быть больше значения \"Вес ДО\"");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Размер От (было " + filterStats.SizeFrom + "): ");//Добавляет в скобках ранее значение Размера От
                if (sizeFrom != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(sizeFrom);
                }
                else
                {
                    result = Console.ReadLine();
                    if (result == "")
                    {
                        Console.WriteLine("\nОкей, сохраню");
                        break;
                    }
                    if (!(int.TryParse(result, out sizeFrom) && sizeFrom >= 0))//Если пользователь ввёл некорректное значение
                    {
                        sizeFrom = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Размер От\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Размер До (было " + filterStats.SizeTo + "): ");//Добавляет в скобках ранее значение Размера До
                if (sizeTo != -1)//Если пользователь ввёл подходящее значение ранее, то оно заполняется автоматически
                {
                    Console.WriteLine(sizeTo);
                }
                else
                {
                    result = Console.ReadLine();
                    if (result == "")
                    {
                        Console.WriteLine("\nОкей, сохраню");
                        break;
                    }
                    if (!(int.TryParse(result, out sizeTo) && sizeTo >= 0))//Если пользователь ввёл некорректное значение
                    {
                        sizeTo = -1;
                        Console.WriteLine("\nВведено некорректное значение в \"Размер До\". Введите неотрицательно число");
                        Console.ReadKey();
                        continue;
                    }
                    else if (sizeTo < sizeFrom)//Не позволяет, чтобы значение ОТ было больше значения ДО
                    {
                        sizeTo = -1;
                        Console.WriteLine("\nЗначение \"Размер ОТ\" не может быть больше значения \"Размер ДО\"");
                        Console.ReadKey();
                        continue;
                    }
                }
                Console.Write("Навыки: ");
                for (int i = 0; i < skills.Count; i++) //Перечисляет все навыки из списка
                {
                    if (i != 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(skills[i].Name);
                }
                Console.WriteLine("\n\nРедактировать Навыки?\n");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Нет");
                Console.Write("\nВведите значение: ");
                if (skillsChange == 2 || int.TryParse(Console.ReadLine(), out skillsChange)) //Если пользователь ранее выбрал ответ НЕТ, то введение значения пропускается
                {
                    if (skillsChange != 2) //Работает код, если пользователь не вводил ранее НЕТ
                    {
                        switch (skillsChange)
                        {
                            case 1: //Если пользователь выбрал редактировать навыки
                                ChooseSkills(skills);
                                List<Skill> skill = logic.LoadSkills();
                                skillsChange = -1;
                                break;
                            case 2: //Если пользователь выбрал НЕТ
                                break;
                            default:
                                Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)");
                                break;
                        }
                    }
                    if (skillsChange == 2) //Работает код, если пользователь решил ранее ответил НЕТ
                    {
                        Console.WriteLine("\nУчитывать все элементы?\n");
                        Console.WriteLine("1. Да");
                        Console.WriteLine("2. Нет");
                        Console.Write("\nВведите значение: ");
                        if (int.TryParse(Console.ReadLine(), out int n))
                        {
                            switch (n)
                            {
                                case 1: //Если навыки должны полностью совпадать
                                    logic.FilterAnimeChanList(ageFrom, ageTo, heightFrom, heightTo, weightFrom, weightTo, sizeFrom, sizeTo, skills, true);
                                    break;
                                case 2: //Если хотя бы один навык должен совпадать
                                    logic.FilterAnimeChanList(ageFrom, ageTo, heightFrom, heightTo, weightFrom, weightTo, sizeFrom, sizeTo, skills, false);
                                    break;
                                default:
                                    Console.WriteLine("\nНекорректная запись. Выбери подходящее число, чтобы заработало)");
                                    break;
                            }
                            if (n == 2 || n == 1) //Если выбрано хоть что-то, то выходит из бесконечного цикла
                            {
                                isFiltered = true;
                                Console.WriteLine("\nСохранения засчитаны!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nНекорректная запись. Введите число!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nНекорректная запись. Введите число!");
                    }
                    Console.ReadKey();
                }
            }
            if (result == "")
            {
                if (ageFrom == -1)
                {
                    ageFrom = filterStats.AgeFrom;
                }
                if (ageTo == -1)
                {
                    ageTo = filterStats.AgeTo;
                }
                if (heightFrom == -1)
                {
                    heightFrom = filterStats.HeightFrom;
                }
                if (heightTo == -1)
                {
                    heightTo = filterStats.HeightTo;
                }
                if (weightFrom == -1)
                {
                    weightFrom = filterStats.WeightFrom;
                }
                if (weightTo == -1)
                {
                    weightTo = filterStats.WeightTo;
                }
                if (sizeFrom == -1)
                {
                    sizeFrom = filterStats.SizeFrom;
                }
                if (sizeTo == -1)
                {
                    sizeTo = filterStats.SizeTo;
                }
                isFiltered = true;
                logic.FilterAnimeChanList(ageFrom, ageTo, heightFrom, heightTo, weightFrom, weightTo, sizeFrom, sizeTo, skills, false);
            }
        }
    }
}
