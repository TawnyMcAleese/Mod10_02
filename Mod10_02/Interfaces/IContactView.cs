using System;
using System.ComponentModel;
using Mod10_02.Models;

namespace Mod10_02.Interfaces
{
    public interface IContactView
    {
        BindingList<Contact> Contacts { get; }
        Contact SelectedContact { get; }
        void RefreshContactList();
        void ShowMessage(string message);
        void UpdateStatusBar(string text);
    }
}
