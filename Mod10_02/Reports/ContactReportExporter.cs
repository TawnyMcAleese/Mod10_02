using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Mod10_02.Models;

namespace Mod10_02.Reports
{
    public static class ContactReportExporter
    {
        public static void ExportToFile(IEnumerable<Contact> contacts, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Contact Report:");
            foreach (var c in contacts)
            {
                sb.AppendLine($"{c.FullName} | {c.Email} | {c.Phone} | {c.Category}");
            }
            sb.AppendLine($"Total: {contacts.Count()}");
            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
