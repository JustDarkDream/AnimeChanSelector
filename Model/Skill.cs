using Azure;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Skill: IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; internal set; }
        public int AnimeChanId { get; internal set; }

        /// <summary>
        /// Конструктор объекта класса Skill
        /// </summary>
        /// <param name="repo">репозиторий полей записи из БД</param>
        public Skill(DataAccessLayer.SkillRepo repo)
        {
            Id = repo.Id;
            Name = repo.Name;
            AnimeChanId = repo.AnimeChanRepoId;
        }
        public Skill()
        {
        }
    }
}
