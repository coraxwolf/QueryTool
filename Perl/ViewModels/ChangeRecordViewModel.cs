using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.ViewModels
{
    public class ChangeRecordViewModel : ViewModelBase
    {
        public string CourseName { get; }
        public string ChangeNote { get; }

        public ChangeRecordViewModel(string coursename, string changeNote)
        {
            CourseName = coursename;
            ChangeNote = changeNote;
        }
    }
}
