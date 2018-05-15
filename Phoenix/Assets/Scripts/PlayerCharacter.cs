using System.Collections.Generic;

namespace Assets.Scripts
{
    public class PlayerCharacter : Character
    {
        Dictionary<string,Skill> _assignedSkills = new Dictionary<string, Skill>();

        protected sealed override void Start()
        {
            base.Start();
            _assignedSkills.Add("A",Skills[0]);
            _assignedSkills.Add("B",Skills[1]);
            CurrentSpeed = BaseSpeed;
        }
        public Dictionary<string, Skill> AssignedSkills
        {
            get { return _assignedSkills; }
            set { _assignedSkills = value; }
        }
    }
}