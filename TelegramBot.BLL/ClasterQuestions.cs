﻿
using TelegramBot.BL.Questions;

namespace TelegramBot.BL
{
    public class ClasterQuestions
    {
        public string NameClaster { get; set; }

        public List<AbstractQuestion> Questions { get; set; }
        public bool isHasAnswer;

        public ClasterQuestions(string name)
        {
            NameClaster = name;
            Questions = new List<AbstractQuestion>();
    }
        public ClasterQuestions(string name, List<AbstractQuestion> questions)
        {
            NameClaster = name;
            Questions = questions;
        }

        public ClasterQuestions()
        {

        }

        public void Add(AbstractQuestion question)
        {
            Questions.Add(question);
        }

        public void Remove(int index)
        {
            Questions.RemoveAt(index);
        }

        public void Edit(string name, string newName)
        {
            if (newName != "" || newName != " ")
            {
                NameClaster = newName;
            }
        }

        public void ClearQuestions(List<AbstractQuestion> questions)
        {
            Questions.Clear();
        }

        public ClasterQuestions GetClone()
        {
            List<AbstractQuestion> cloneQuestions = new List<AbstractQuestion>();

            foreach(AbstractQuestion question in Questions)
            {
                cloneQuestions.Add(question.Clone());
            }

            return new ClasterQuestions(this.NameClaster, cloneQuestions);
        }
    }
}
