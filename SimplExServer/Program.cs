﻿using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.Controls;
using SimplExServer.Forms;
using SimplExServer.Model;
using SimplExServer.Model.Inherited;
using SimplExServer.Presenter;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplExServer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationContext context = new ApplicationContext();
            ApplicationController controller = (ApplicationController)new ApplicationController(new AutofacAdapter())
                .RegisterView<IEditPropertiesView, EditPropertiesControl>()
                .RegisterView<IEditMainView, EditorForm>()
                .RegisterView<IEditTreeView, EditTreeControl>()
                .RegisterView<IEditMarkSystemPropertiesView, EditMarkSystemControl>()
                .RegisterView<IEditFiveStepMarkSystemView, EditFiveStepMarkSystemControl>()
                .RegisterIntstance(context);
            ExamBuilder examBuilder = new ExamBuilder();
            examBuilder.AddTheme("123");
            examBuilder.AddTheme("12345");
            QuestionGroupBuilder questionGroupBuilder = examBuilder.AddTicket("123").AddQuestionGroup("124345");
            QuestionGroupBuilder questionGroupBuilder1 = questionGroupBuilder.AddQuestionGroup("12");
            questionGroupBuilder.AddQuestion(new OneAnswerQuestion()); 
            questionGroupBuilder.AddQuestion(new OneAnswerQuestion());
            questionGroupBuilder1.AddQuestion(new OneAnswerQuestion());
            controller.Run<EditMainPresenter, ExamBuilder>(examBuilder);
            Application.Run(context);
        }
    }
}
