using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSCOMOleDbQueryMonitor
{
    public interface IWizardPage
    {
        UserControl Content { get; }
        void Load();
        void Save();
        void Cancel();
        bool IsBusy { get; }
        bool PageValid { get; }
        string ValidationMessage { get; }
    }
}
