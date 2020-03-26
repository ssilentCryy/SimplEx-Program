﻿using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    class EditTicketsPresenter : IntegrablePresenter<EditArgumnet, IEditTicketsView>
    {
        public EditTicketsPresenter(IEditTicketsView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.TicketAdded += ViewTicketAdded;
        }
        private void ViewTicketAdded(IEditTicketsView sender)
        {
            TicketBuilder builder = Argument.ExamBuilder.AddTicket("Новый Билет");
            Argument.EditTreeView.RefreshTickets();
            Argument.EditTreeView.SelectObject(builder);
        }
    }
}