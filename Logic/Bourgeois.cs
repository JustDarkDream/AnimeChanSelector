using Model;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Logic
{
    public class BourgeoisLogic
    {
        static List<AnimeChan> animeChanList = new List<AnimeChan>() { };
        static List<Skills> skills = new List<Skills>();
        static int temporaryID = 0;

        public List<AnimeChan> CreateAnimeChan()
        {
            animeChanList.Add(new AnimeChan("Цукико", "Амано", 22, 1, 165, 53, 2, new List<Skills> {Skills.Cleaning, Skills.Cooking, Skills.Dancing }));
            animeChanList.Add(new AnimeChan("Амане", "Хосино", 19, 2, 168, 51, 3, new List<Skills> { Skills.Music, Skills.Dancing, Skills.Singing }));
            animeChanList.Add(new AnimeChan("Миюки", "Кирисава", 15, 3, 159, 57, 4, new List<Skills> { Skills.Jumping, Skills.FireballCast }));
            return animeChanList;
        }

        public AnimeChan FindForId(int id)
        {
            AnimeChan animeChan = animeChanList.Where(f => f.Id == id).FirstOrDefault();
            return animeChan;
            //if (id >= 0)
            //{
            //    AnimeChan animeChan = animeChanList.Where(f => f.Id == id).FirstOrDefault();
            //    return animeChan;
            //}
            //else
            //{
            //    AnimeChan animeChan = animeChanList.OrderByDescending(f => f.Id).FirstOrDefault();
            //    return animeChan;
            //}
        }

        public void SaveSkills(List<Skills> list) 
        {
            skills = list;
        }

        public List<Skills> LoadSkills()
        {
            return skills;
        }

        public void AddAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<Skills> skills)
        {
            int id = 1;

            while (animeChanList.Where(x => x.Id == id).ToList().Count != 0)
            {
                Debug.WriteLine((animeChanList.Where(x => x.Id == id).ToList().Count != 0));
                id++;
            }
            temporaryID = id;

            animeChanList.Add(new AnimeChan(firstName, lastName, age, id, height, weight, size, skills));
        }

        public void DeleteAnimeChan(int id)
        {
            animeChanList.Remove(animeChanList.Where(f => f.Id == id).FirstOrDefault());
        }

        public void SaveChangeAnimeChan(string firstName, string lastName, int age, int height, int weight, int size, List<Skills> skills, int id)
        {
            AnimeChan animeChan = FindForId(id);
            animeChan.Age = age;
            animeChan.Height = height;
            animeChan.Weight = weight;
            animeChan.FirstName = firstName;
            animeChan.LastName = lastName;
            animeChan.Size = size;
            animeChan.Skills = skills;
            temporaryID = animeChan.Id;
        }

        public int LoadId()
        {
            return temporaryID;
        }
    }
}
