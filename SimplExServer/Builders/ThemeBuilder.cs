﻿using SimplExModel.Model;
using System;
using System.Collections.Generic;

namespace SimplExServer.Builders
{
    public class ThemeBuilder : Builder<Theme>
    {
        public string ThemeName { get; set; }
        public ExamBuilder ParentExamBuilder { get; private set; }
        public ThemeBuilder(Theme instance, ExamBuilder examBuilder)
        {
            ParentExamBuilder = examBuilder;
            if (ParentExamBuilder == null)
                throw new ArgumentNullException(nameof(examBuilder));
            Load(instance);
        }
        public override void Reset()
        {
            Instance = new Theme();
            ThemeName = "";
        }

        public override Theme GetBuildedInstance()
        {
            if (!ParentExamBuilder.ThemeBuilders.Contains(this))
                throw new Exception("This builder is not assigned to the parent builder.");
            Instance.ThemeName = ThemeName;
            return Instance;
        }
        public override void Load(Theme instance)
        {
            base.Load(instance);
            ThemeName = instance.ThemeName;
        }
        public override string ToString() => $"{ThemeName}";
    }
}
