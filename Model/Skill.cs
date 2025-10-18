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
    public class Skill: IDoMainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnimeChanRepo AnimeChan { get; set; }

        public Skill(DataAccessLayer.SkillRepo repo)
        {

            Id = repo.Id;
            Name = repo.Name;
            AnimeChan = repo.AnimeChanRepo;
        }
        public Skill()
        {
        }
    }
}
