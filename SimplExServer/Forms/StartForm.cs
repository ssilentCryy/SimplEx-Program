﻿using SimplExModel.Model;
using SimplExServer.Service;
using SimplExServer.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SimplExServer
{
    public partial class StartForm : Form, IStartView
    {
        private string currentPath;
        private Exam exam;
        private ApplicationContext context;
        private IList<IExamSaver> examSavers;
        private IPasswordEnterView passwordEnterView;
        public IExamSaver CurrentExamSaver { get => examSavers[examsList.SelectedIndex]; set => examsList.SelectedIndex = examSavers.IndexOf(value); }
        public Ticket CurrentTicket { get => exam.Tickets[ticketsBox.SelectedIndex]; set => ticketsBox.SelectedIndex = exam.Tickets.IndexOf(value); }
        public ExecutionResult CurrentExecutionResult { get => exam.ExecutionResults[resultsList.SelectedIndex]; set => resultsList.SelectedIndex = exam.ExecutionResults.IndexOf(value); }
        public IList<IExamSaver> ExamSavers
        {
            get => examSavers;
            set
            {
                examSavers = value;
                examsList.Items.Clear();
                for (int i = 0; i < examSavers.Count; i++)
                    examsList.Items.Add($"Экзамен '{examSavers[i].SaverName}'");
                if (examSavers.Count == 0)
                    examsList.Items.Add($"Список пуст.");
                else
                    examsList.SelectedIndex = 0;
                hider.Visible = true;
                infoText.Text = "Выберете экзамен для работы";
            }
        }
        public Exam CurrentExam
        {
            get => exam;
            set
            {
                exam = value;
                if (exam == null)
                {
                    hider.Visible = true;
                    return;
                }
                hider.Visible = false;
                nameText.Text = $"Экзамен '{exam.Name}'";
                creatorText.Text = $"Имя автора: {exam.CreatorSurname} {exam.CreatorName} {exam.CreatorPatronymic}";
                disciplineText.Text = $"Дисциплина: {exam.Discipline}";
                descriptionText.Text = $"{exam.Description}";
                creationText.Text = $"Дата создания: {exam.CreationDate}";
                lastChangeText.Text = $"Дата изменнения: {exam.LastChangeDate}";
                firstNumberText.Text = $"Номер первого вопроса: {exam.FirstQuestionNumber}";
                if (exam.Time > 0)
                {
                    DateTime dateTime = new DateTime();
                    dateTime = dateTime.AddSeconds(exam.Time);
                    executionTimeText.Text = $"Время выполнения: {dateTime.Hour} часов, {dateTime.Minute} минут, {dateTime.Minute} секунд";
                }
                else
                {
                    executionTimeText.Text = $"Время выполнения: -- часов, -- минут, -- секунд";
                }
                ticketsBox.Items.Clear();
                RefreshTickets();
                RefreshResults();
            }
        }
        public IPasswordEnterView PasswordEnterView
        {
            get => passwordEnterView; set
            {
                if (passwordEnterView != null)
                {
                    passwordEnterView.Entered -= PasswordEnterViewEntered;
                    passwordEnterView.Canceled -= PasswordEnterViewCanceled;
                }
                passwordEnterView = value;
                passwordEnterView.Canceled += PasswordEnterViewCanceled;
                passwordEnterView.Entered += PasswordEnterViewEntered;
                passwordEnterView.Hide();
            }
        }

        public bool IsExamLoading
        {
            get => loaderExamPanel.Visible; set
            {
                loaderExamPanel.Visible = value;
                connectButton.Enabled = !value;
            }
        }
        public bool IsListLoading { get => loaderListPanel.Visible; set => loaderListPanel.Visible = value; }
        public string DbInfoText { get => dbInfoLabel.Text; set => dbInfoLabel.Text = value; }
        public bool SetRightAnswer { get => setRightAnswerCheck.Checked; set => setRightAnswerCheck.Checked = value; }

        public event ViewActionHandler<IStartView, OpenExamEventArgs> FileOpened;
        public event ViewActionHandler<IStartView> WatchResult;
        public event ViewActionHandler<IStartView> DeleteResult;
        public event ViewActionHandler<IStartView> WatchTask;
        public event ViewActionHandler<IStartView> WatchBlank;
        public event ViewActionHandler<IStartView> SessionStarted;
        public event ViewActionHandler<IStartView> ExamEdited;
        public event ViewActionHandler<IStartView> ExamDeleted;
        public event ViewActionHandler<IStartView> ConnectionAsked;
        public event ViewActionHandler<IStartView> ExamCreated;
        public event ViewActionHandler<IStartView> ViewShown;
        public event ViewActionHandler<IStartView> ViewHiden;
        public event ViewActionHandler<IStartView> ExamSelectionChanged;

        public StartForm(ApplicationContext context)
        {
            InitializeComponent();
            leftPanel.BackColor = Color.FromArgb(171, 31, 47);
            this.context = context;
        }
        public new void Show()
        {
            context.MainForm = this;
            base.Show();
            ViewShown?.Invoke(this);
        }
        private void PasswordEnterViewEntered(IPasswordEnterView sender)
        {
            sender.Hide();
            FileOpened.Invoke(this, new OpenExamEventArgs(currentPath, sender.Password));
        }
        private void PasswordEnterViewCanceled(IPasswordEnterView sender)
        {
            sender.Hide();
        }
        public new void Hide()
        {
            ViewHiden?.Invoke(this);
            base.Hide();
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ConnectButtonClick(object sender, EventArgs e)
        {
            ConnectionAsked?.Invoke(this);
        }

        private void ExamsListMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (examsList.Items.Count > 0 && examsList.Items[0].ToString() != "Список пуст.")
            {
                ExamSelectionChanged?.Invoke(this);
            }
        }
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить экзамен?", "Удаление экзамена", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                hider.Visible = true;
                if (exam != null)
                    ExamDeleted?.Invoke(this);
            }
        }
        private void ChangeButtonClick(object sender, EventArgs e)
        {
            if (exam != null)
                ExamEdited?.Invoke(this);
        }
        private void StartSessionButtonClick(object sender, EventArgs e)
        {
            if (exam != null)
                SessionStarted?.Invoke(this);
        }
        private void PrintBlankButtonClick(object sender, EventArgs e)
        {
            if (ticketsBox.Items.Count > 0)
                WatchBlank?.Invoke(this);
        }
        private void PrintTaskButtonClick(object sender, EventArgs e)
        {
            if (ticketsBox.Items.Count > 0)
                WatchTask?.Invoke(this);
        }
        private void DeleteResultButtonClick(object sender, EventArgs e)
        {
            if (resultsList.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Удалить результат выполнения?", "Удаление результата выполнения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                    DeleteResult?.Invoke(this);
            }
        }
        private void PrintResultClick(object sender, EventArgs e)
        {
            if (resultsList.Items.Count > 0)
                WatchResult?.Invoke(this);
        }
        private void OpenFileButtonClick(object sender, EventArgs e) => openFileDialog.ShowDialog();
        private void OpenFileDialogFileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            currentPath = Path.GetFullPath(openFileDialog.FileName);
            if (!File.ReadAllText(currentPath, Encoding.Unicode).StartsWith("[Password Header]"))
            {
                passwordEnterView.Password = string.Empty;
                passwordEnterView.Show();
            }
            else FileOpened.Invoke(this, new OpenExamEventArgs(currentPath, string.Empty));
        }

        private void CreateButtonClick(object sender, EventArgs e) => ExamCreated?.Invoke(this);

        public void RefreshTickets()
        {
            ticketsBox.Items.Clear();
            for (int i = 0; i < exam.Tickets.Count; i++)
                ticketsBox.Items.Add($"Билет '{exam.Tickets[i].TicketName}'");

            if (exam.Tickets.Count == 0)
            {
                printBlankButton.Enabled = false;
                printTaskButton.Enabled = false;
                ticketsBox.Items.Clear();
                resultsList.Items.Add("Нет билетов.");
            }
            else
            {
                printBlankButton.Enabled = true;
                printTaskButton.Enabled = true;
                ticketsBox.SelectedIndex = 0;
            }
        }
        public void RefreshResults()
        {
            resultsList.Items.Clear();
            for (int i = 0; i < exam.ExecutionResults.Count; i++)
                resultsList.Items.Add($"Резльтат выполнения ({exam.ExecutionResults[i].ExecutorSurname} {exam.ExecutionResults[i].ExecutorName} {exam.ExecutionResults[i].ExecutorPatronymic} [{exam.ExecutionResults[i].ExecutionDate.Value:yyyy MMMM dd h:mm:ss}])");
            if (exam.ExecutionResults.Count == 0)
            {
                deleteResultButton.Enabled = false;
                printResultButton.Enabled = false;
                resultsList.Items.Clear();
                resultsList.Items.Add("Нет результатов.");
            }
            else
            {
                deleteResultButton.Enabled = true;
                printResultButton.Enabled = true;
                resultsList.SelectedIndex = 0;
            }
        }
        public void Invoke(Action action)
        {
            try
            {
                base.Invoke(action);
            }
            catch { }
        }
    }
}
