using System;
using System.ComponentModel;
using System.Linq;
using Mod10_02.Models;
using Mod10_02.Interfaces;

namespace Mod10_02.Presenters
{
    public class ContactPresenter
    {
        private readonly IContactView _view;

        public ContactPresenter(IContactView view)
        {
            _view = view;
        }

        public void FilterContacts(string searchText, string category)
        {
            var filtered = _view.Contacts.Where(c =>
                (category == "All" || c.Category == category) &&
                $"{c.FirstName} {c.LastName} {c.Email} {c.Phone}".ToLower().Contains(searchText.ToLower())
            ).ToList();

            _view.Contacts.Clear();
            foreach (var contact in filtered)
                _view.Contacts.Add(contact);

            UpdateStatus();
        }

        public void UpdateStatus()
        {
            var counts = _view.Contacts.GroupBy(c => c.Category)
                .Select(g => $"{g.Key}: {g.Count()}");
            _view.UpdateStatusBar($"Total: {_view.Contacts.Count} | {string.Join(" | ", counts)}");
        }
    }
}
