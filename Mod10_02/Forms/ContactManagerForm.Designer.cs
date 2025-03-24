using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Mod10_02.Models;
using Mod10_02.Presenters;
using Mod10_02.Reports;
using Mod10_02.Interfaces;


namespace Mod10_02;

public class ContactManagerForm : Form
{
    private BindingList<Contact> contacts = new BindingList<Contact>();
    private BindingSource bindingSource = new BindingSource();
    private DataGridView contactGrid = new DataGridView();
    private ToolStripTextBox searchBox = new ToolStripTextBox();
    private ToolStripComboBox categoryFilter = new ToolStripComboBox();
    private ToolStripStatusLabel statusLabel = new ToolStripStatusLabel();
    private ContactPresenter presenter;

    public ContactManagerForm()
    {
        Text = "Contact Manager";
        Size = new Size(800, 500);
        presenter = new ContactPresenter(new ContactViewWrapper(this));
        InitializeComponents();
        LoadTestData();
    }

    private void InitializeComponents()
    {
        // Toolstrip for search and category filtering
        var toolStrip = new ToolStrip();
        toolStrip.Items.Add(new ToolStripLabel("Search:"));
        toolStrip.Items.Add(searchBox);
        toolStrip.Items.Add(new ToolStripLabel("Category:"));
        categoryFilter.Items.AddRange(new string[] { "All", "Family", "Friend", "Work", "Other" });
        categoryFilter.SelectedIndex = 0;
        toolStrip.Items.Add(categoryFilter);

        // Export button
        var exportButton = new ToolStripButton("Export");
        exportButton.Click += (s, e) => ContactReportExporter.ExportToFile(contacts, "ContactReport.txt");
        toolStrip.Items.Add(exportButton);

        // Status bar
        var statusStrip = new StatusStrip();
        statusStrip.Items.Add(statusLabel);

        // Contact grid
        contactGrid.Dock = DockStyle.Fill;
        contactGrid.AutoGenerateColumns = true;
        contactGrid.DataSource = bindingSource;

        contactGrid.CellFormatting += (s, e) =>
        {
            if (contactGrid.Rows[e.RowIndex].DataBoundItem is Contact contact)
            {
                e.CellStyle.BackColor = contact.CategoryColor;
            }
        };

        contactGrid.CellToolTipTextNeeded += (s, e) =>
        {
            if (e.RowIndex >= 0 && contactGrid.Rows[e.RowIndex].DataBoundItem is Contact c)
            {
                e.ToolTipText = $"{c.FullName}\n{c.Email}\n{c.Phone}";
            }
        };

        Controls.Add(contactGrid);
        Controls.Add(toolStrip);
        Controls.Add(statusStrip);
        toolStrip.Dock = DockStyle.Top;
        statusStrip.Dock = DockStyle.Bottom;

        // Event handlers
        searchBox.TextChanged += (s, e) => presenter.FilterContacts(searchBox.Text, categoryFilter.Text);
        categoryFilter.SelectedIndexChanged += (s, e) => presenter.FilterContacts(searchBox.Text, categoryFilter.Text);

        bindingSource.DataSource = contacts;
    }

    private void LoadTestData()
    {
        contacts.Add(new Contact { FirstName = "John", LastName = "Doe", Email = "john@example.com", Phone = "123-456", Category = "Work" });
        contacts.Add(new Contact { FirstName = "Jane", LastName = "Smith", Email = "jane@family.com", Phone = "789-012", Category = "Family" });
        contacts.Add(new Contact { FirstName = "Tom", LastName = "Lee", Email = "tom@friend.com", Phone = "456-789", Category = "Friend" });
        presenter.UpdateStatus();
    }

    private class ContactViewWrapper : Interfaces.IContactView
    {
        private readonly ContactManagerForm form;
        public ContactViewWrapper(ContactManagerForm form) => this.form = form;

        public BindingList<Contact> Contacts => form.contacts;
        public Contact SelectedContact => form.bindingSource.Current as Contact;
        public void RefreshContactList() => form.bindingSource.ResetBindings(false);
        public void ShowMessage(string message) => MessageBox.Show(message);
        public void UpdateStatusBar(string text) => form.statusLabel.Text = text;
    }
}
