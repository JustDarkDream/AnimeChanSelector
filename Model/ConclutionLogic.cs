using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ConclutionLogic: IConclution
    {
        private Saves saves;
        private IUnitOfWork unitOfWork;
        ConclutionText text = new ConclutionText();
        int stringsCount = 5; //Число возможных текстов в каждом абзаце
        int ageOfConsent = 16;
        int maxPoint = 25;
        double agePointsMultiplier = 2.5;
        double heightPointsMultiplier = 25/30;
        double weightPointsMultiplier = 1;
        double sizePointsMultiplier = 5;
        int animeChanSizeMultiplier = 2;
        int ageDifferense = 2;
        int heightDifferense = 10;
        int weightDifferense = 15;
        int sizeDifferense = 0;

        public ConclutionLogic(Saves savess, IUnitOfWork unitOfWorkk)
        {
            saves = savess;
            unitOfWork = unitOfWorkk;
        }
        
        public string MakeConclution()
        {
            AnimeChan animeChan = new AnimeChan(unitOfWork.AnimeChanRepos.ReadById(saves.TemporaryID));

            string ageString; //Блок текста, связанный с возрастом
            string heightString; //Блок текста, связанный с ростом
            string weightString; //Блок текста, связанный с весом
            string sizeString; //Блок текста, связанный с размером

            int points; //Очки, от которых будет зависеть продолжительность встречи
            int agePoints = GetAgePoints(animeChan);
            int heightPoints = GetHeightPoints(animeChan);
            int weightPoints = GetWeightPoints(animeChan);
            int sizePoints = GetSizePoints(animeChan);
            points = agePoints + heightPoints + weightPoints + sizePoints; //Суммируем в общее значение

            //Все возможные тексты, зависящие от набранных очков за каждый критерий

            ageString = text.ageText[(int)(agePoints-1)/stringsCount];
            heightString = text.heightText[(int)(heightPoints - 1) / stringsCount];
            weightString = text.weightText[(int)(weightPoints - 1) / stringsCount];
            sizeString = text.sizeText[(int)(sizePoints - 1) / stringsCount];

            string yearsStr = GetYearsString(points);

            string str = "ВЫ ВСТРЕЧАЛИСЬ ЦЕЛЫХ " + yearsStr + " лет!\n\n\n\n" + ageString + "\n\n" + heightString + "\n\n" + weightString; //Клепаем результат в один огромным текст
            if (saves.MainPerson.Age >= ageOfConsent && animeChan.Age >= ageOfConsent)
            {
                str += "\n\n" + sizeString;
            }
            return str;
        }
        /// <summary>
        /// Метод подсчета длительности отношений
        /// </summary>
        /// <param name="points">КОбщее кол-во набранных очков</param>
        /// <returns>Строка, представляющая продолжительность отношений</returns>
        private string GetYearsString(int points)
        {
            double years = Math.Pow(points / 100.0, 3) * 50; //Конвертируем очки в годы

            string yearsStr = "";
            int count = -1;
            foreach (char x in years.ToString()) //Сокращаем дробное значение у переменной years до двух запятой
            {
                yearsStr += x;

                if (count >= 0)
                {
                    count++;
                }

                if (count == 2)
                {
                    break;
                }

                if (x == ',')
                {
                    count = 0;
                }
            }
            return yearsStr;
        }
        /// <summary>
        /// Метод подсчета очков соотношения возраста
        /// </summary>
        /// <param name="animechan">Экземпляр тянки</param>
        /// <returns>Целое число очков</returns>
        private int GetAgePoints(AnimeChan animechan)
        {
            int agePoints = maxPoint - (int)Math.Abs((saves.MainPerson.Age - animechan.Age - ageDifferense) * agePointsMultiplier); //Очки за разницу в возрасте
                                                                                                                                    //(чем меньше разница - тем больше очков,
                                                                                                                                    //в идеале тянка должна быть на ageDifferense года младше пользователя)
            if (agePoints < 1)
            {
                agePoints = 1;
            }
            return agePoints;
        }
        /// <summary>
        /// Метод подсчета очков соотношения роста
        /// </summary>
        /// <param name="animechan">Экземпляр тянки</param>
        /// <returns>Целое число очков</returns>
        private int GetHeightPoints(AnimeChan animechan)
        {
            int heightPoints = maxPoint - (int)Math.Abs((saves.MainPerson.Height - animechan.Height - heightDifferense) * heightPointsMultiplier); //Очки за разницу в росте
                                                                                                                                                   //(чем меньше разница - тем больше очков,
                                                                                                                                                   //в идеале тянка должна быть ниже пользователя на heightDifferense)

            if (heightPoints < 1)
            {
                heightPoints = 1;
            }
            return heightPoints;
        }
        /// <summary>
        /// Метод подсчета очков соотношения веса
        /// </summary>
        /// <param name="animechan">Экземпляр тянки</param>
        /// <returns>Целое число очков</returns>
        private int GetWeightPoints(AnimeChan animechan)
        {
            int weightPoints = maxPoint - (int)Math.Abs((saves.MainPerson.Weight - animechan.Weight - weightDifferense) * weightPointsMultiplier); //Очки за разницу в весе
                                                                                                                                                   //(чем меньше разница - тем больше очков,
                                                                                                                                                   //в идеале тянка должна легче пользователя на weightDifferense)
            if (weightPoints < 1)
            {
                weightPoints = 1;
            }
            return weightPoints;
        }
        /// <summary>
        /// Метод подсчета очков размера
        /// </summary>
        /// <param name="animechan">Экземпляр тянки</param>
        /// <returns>Целое число очков</returns>
        private int GetSizePoints(AnimeChan animechan)
        {
            int sizePoints = (int)((saves.MainPerson.Size - (animechan.Size * animeChanSizeMultiplier) - sizeDifferense) * sizePointsMultiplier); //Очки за разницу в размере
                                                                                                                                                  //(чем больше у пользователя - тем больше очков)
            if (sizePoints < 1)
            {
                sizePoints = 1;
            }
            if (sizePoints > maxPoint)
            {
                sizePoints = maxPoint;
            }
            return sizePoints;
        }
    }
}
