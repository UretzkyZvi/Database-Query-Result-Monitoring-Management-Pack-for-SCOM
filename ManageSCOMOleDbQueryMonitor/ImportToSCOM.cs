using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSCOMOleDbQueryMonitor
{
    public partial class ImportToSCOM : KryptonForm
    {
        private const string VALIDATION_MESSAGE = "Current page is not valid. Please fill in required information";

        #region Properties

        public WizardPageCollection WizardPages { get; set; }


        private bool navigationEnabled = true;
        private SharedData data;

        public bool NavigationEnabled
        {
            get { return navigationEnabled; }
            set
            {
                btnBack.Enabled = value;
                btnNext.Enabled = value;
                navigationEnabled = value;
            }
        }

        #endregion

        #region Delegates & Events

        public delegate void WizardCompletedEventHandler();
        public event WizardCompletedEventHandler WizardCompleted;

        public delegate void WizardCanceledEventHandler();
        public event WizardCanceledEventHandler WizardCanceled;
        #endregion

        #region Constructor & Window Event Handlers

        public ImportToSCOM()
        {
            InitializeComponent();


            //ImportWizardController controller = new ImportWizardController();
            //this.Text = "Import Scenario to System Center Operations Manager";
            //WizardCompleted += ImportToSCOM_WizardCompleted;
            //WizardPages = new WizardPageCollection();
            //WizardPages.WizardPageLocationChanged += new WizardPageCollection.WizardPageLocationChangedEventHanlder(WizardPages_WizardPageLocationChanged);
     
            //WizardPages.Add(1, new ConnectionToSCOM(data));
            //WizardPages.Add(2, new SelectSQLDBEngine(data));
            //WizardPages.Add(3, new SchedulerSettings(controller));
            //WizardPages.Add(4, new MonitorSettings(controller));
            //WizardPages.Add(5, new SelectAgents(controller));
            //LoadWizard();
            //host.ShowDialog();

            
        }

        public ImportToSCOM(SharedData data):this()
        {
            this.data = data;

            WizardCompleted += ImportToSCOM_WizardCompleted;
            WizardPages = new WizardPageCollection();
            WizardPages.WizardPageLocationChanged += new WizardPageCollection.WizardPageLocationChangedEventHanlder(WizardPages_WizardPageLocationChanged);

            if (data.MGConnection!=null)
            {
                WizardPages.Add(1, new SelectSQLDBEngine(data));
                WizardPages.Add(2, new WriteQuery(data));
                WizardPages.Add(3, new DefineMonitor(data));
                WizardPages.Add(4, new Summary(data));
            }

            LoadWizard();
        }

        private void ImportToSCOM_WizardCompleted()
        {
           
           // throw new NotImplementedException();
        }

        void WizardPages_WizardPageLocationChanged(WizardPageLocationChangedEventArgs e)
        {
            LoadNextPage(e.PageIndex, e.PreviousPageIndex, true);
        }

        #endregion

        #region Private Methods

        private void NotifyWizardCompleted()
        {
            if (WizardCompleted != null)
            {
                OnWizardCompleted();
                WizardCompleted();
            }
        }
        private void OnWizardCompleted()
        {
            WizardPages.LastPage.Save();
            WizardPages.Reset();
            this.DialogResult = DialogResult.OK;
        }

        public void UpdateNavigation()
        {
            #region Reset

            btnNext.Enabled = true;
            btnNext.Visible = true;

            #endregion

            bool canMoveNext = WizardPages.CanMoveNext;
            bool canMovePrevious = WizardPages.CanMovePrevious;

            btnBack.Enabled = canMovePrevious;
            //btnFirst.Enabled = canMovePrevious;

            if (canMoveNext)
            {
                btnNext.Text = "&Next >";
                btnNext.Enabled = true;
            }
            else
            {
                btnNext.Text = "Finish";
                btnNext.Visible = true;
            }
        }

        private bool CheckPageIsValid()
        {
            if (!WizardPages.CurrentPage.PageValid)
            {
                MessageBox.Show(
                    string.Concat(VALIDATION_MESSAGE, Environment.NewLine, Environment.NewLine, WizardPages.CurrentPage.ValidationMessage),
                    "Details Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region Public Methods

        public void LoadWizard()
        {
            WizardPages.MovePageFirst();
        }
        public void LoadNextPage(int pageIndex, int previousPageIndex, bool savePreviousPage)
        {
            if (pageIndex != -1)
            {
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(WizardPages[pageIndex].Content);
                if (savePreviousPage && previousPageIndex != -1)
                {
                    WizardPages[previousPageIndex].Save();
                    WizardPages[previousPageIndex].Cancel();
                }
                WizardPages[pageIndex].Load();
                UpdateNavigation();
            }
        }

        #endregion

        #region Event Handlers

        private void btnBack_Click(object sender, EventArgs e)
        {
            //if (!CheckPageIsValid()) //Maybe doesn't matter if move back; only matters if move forward
            //{ return; }

            WizardPages.MovePagePrevious();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!CheckPageIsValid())
            { return; }

            if (WizardPages.CanMoveNext)
            {
                WizardPages.MovePageNext();
            }
            else
            {
                //This is the finish button and it has been clicked
                NotifyWizardCompleted();
            }
        }


        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            WizardPages.Reset();
            Close();
        }
    }
}
