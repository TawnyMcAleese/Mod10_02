using System;
using System.ComponentModel;
using System.Drawing;

namespace Mod10_02.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }

        private string category = "Other";
        public string Category
        {
            get => category;
            set { category = value; OnPropertyChanged(nameof(Category)); }
        }

        public string FullName => $"{FirstName} {LastName}";

        public Color CategoryColor => Category switch
        {
            "Family" => Color.LightBlue,
            "Friend" => Color.LightGreen,
            "Work" => Color.LightYellow,
            _ => Color.White
        };

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
