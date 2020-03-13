﻿using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.View;
using System;
using System.Collections.Generic;
namespace SimplExServer.Presenter
{
    class EditMainPresenter : Presenter<Exam, IEditMainView>
    {
        private Exam exam;
        public EditMainPresenter(IEditMainView view, IApplicationController applicationController) : base(view, applicationController) { }
        public override void Run(Exam argumnet)
        {
            exam = argumnet;
            exam.ExecutionResults = new List<ExecutionResult>();
            ApplicationController.Run<EditPopertiesPresenter, Exam>(exam).Integrate(View.SetEditPropertiesView);
            ApplicationController.Run<EditMarkSystemPropertiesPresenter, Exam>(exam).Integrate(View.SetEditMarkSystemPropertiesView);
            ApplicationController.Run<EditTreePresenter, Exam>(exam).Integrate(View.SetEditTreeView);
            exam.LastChangeDate = DateTime.Now;
            if (exam.CreationDate == null)
            {
                View.EditPropertiesView.Saved = false;
                exam.CreationDate = DateTime.Now;
            }
            View.CreationDate = exam.CreationDate.Value;
            View.LastChangeDate = exam.LastChangeDate.Value;
            View.QuestionCount = 0;
            View.MaxPoints = 0;
            View.Show();
        }
    }
}
