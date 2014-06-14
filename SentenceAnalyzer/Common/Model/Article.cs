﻿using Common.Model.Enum;

namespace Common.Model
{
    public class Article : Word
    {
        public Article(string text) : base(text)
        { }

        public override string Key(string form)
        {
            return KEY;
        }

        public override WordType WordType
        {
            get { return WordType.Article; }
        }

        public const string KEY = @"A";
    }
}