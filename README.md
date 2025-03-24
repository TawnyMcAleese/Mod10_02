Exercises 2: Enhance Contact Manager
Add functionality to the Contact Manager application to improve user experience and data management.

Requirements:
Add Contact Categories:
Add Category field (ComboBox)
Predefined categories: Family, Friend, Work, Other
Ability to filter contacts by category
Implement Search Features:
Add search box at the top of contact list
Real-time filtering as user types
Search across all fields (name, email, phone)
Add Basic Reporting:
"Export" button that generates a simple text report
Show total number of contacts in status bar
Display contact count by category
Enhance Contact List:
Sort contacts by clicking column headers
Show contact categories with different background colors
Add tooltip showing contact summary on hover
Implementation Tips:
Use ToolStrip for search controls
Implement INotifyPropertyChanged for Contact class
Use StringBuilder for report generation
Handle null/empty values appropriately
Example Implementation Structure:
public class ContactManagerForm : Form, IContactView
{
    // New controls
    private TextBox searchBox;
    private ComboBox categoryFilter;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel contactCountLabel;

    // Enhanced contact model
    public class Contact
    {
        // Existing properties...
        public string Category { get; set; }
        public Color CategoryColor => GetCategoryColor(Category);
    }

    // New methods
    private void InitializeSearchControls()
    {
        // Initialize search box and category filter
    }

    private void FilterContacts(string searchText, string category)
    {
        // Implement filtering logic
    }

    private void ExportContactReport()
    {
        // Generate and save report
    }
}  
