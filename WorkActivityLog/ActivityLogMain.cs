using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkActivityLog
{
    public partial class ActivityLogMain : Form
    {
        public ActivityLogMain()
        {
            ToolStripButton lsortButton;

            InitializeComponent();
            txtStartDate.Text = "00/00/0000";
            txtEndDate.Text = "00/00/0000";
            chkStatus.Text = "Emailed For RFC";
            //lsortButton = new ToolStripButton("ALL");
            //tbsSort.DropDownItems.Add(lsortButton);
            foreach (Globals.ProjectStatus prjStatus in Enum.GetValues(typeof(Globals.ProjectStatus)))
            {
                cmbProjectStatus.Items.Add(prjStatus);
                lsortButton = new ToolStripButton(prjStatus.ToString());
                tbsSort.DropDownItems.Add(lsortButton);
            }
            cmbProjectStatus.SelectedIndex = 0;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (cmbProjectTitle.SelectedIndex == 0) return;

            cmbProjectTitle.SelectedIndex--;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cmbProjectTitle.SelectedIndex == cmbProjectTitle.Items.Count - 1) return;

            cmbProjectTitle.SelectedIndex++;
        }

        private void ActivityLogMain_Load(object sender, EventArgs e)
        {
            Boolean lblnCurFileExists;
            String lstrMonth, lstrYear;

            Globals.mInputState = Globals.InputState.Load;
            Globals.mblnDirty = false;

            lstrMonth = DateTime.Today.ToString("MM");
            lstrYear = DateTime.Today.Year.ToString();

            Globals.mstrCurTextFile = lstrMonth + ".txt";
            lblnCurFileExists = Globals.CheckForTextFile(Globals.mstrCurDataFolder + Globals.mstrCurTextFile); //see if latest file is in current

            if (!lblnCurFileExists)
            {
                Globals.CreateNewTextFile(Globals.mstrCurTextFile, lstrMonth, lstrYear);
                Globals.mInputState = Globals.InputState.New;
            }

            LoadLogHeaderRecords(Globals.mstrCurDataFolder + Globals.mstrCurTextFile);//load log
            if (cmbProjectTitle.Items.Count == 0) //nothing in current log
            {
                cmbProjectTitle.Items.Add(Globals.mstrNoRecordsMessage);
            }
            
            cmbProjectTitle.SelectedIndex = 0; //set first record
            lblYearMonth.Text = FormatMonthYear(lstrMonth, lstrYear);
            Globals.mInputState = Globals.InputState.Normal;
        }

        private string FormatMonthYear(string lstrMonth, string lstrYear)
        {
            string lstrReturn;

            switch (lstrMonth)
            {
                case "01":
                    lstrReturn = "Jan ";
                    break;
                case "02":
                    lstrReturn = "Feb ";
                    break;
                case "03":
                    lstrReturn = "Mar ";
                    break;
                case "04":
                    lstrReturn = "Apr ";
                    break;
                case "05":
                    lstrReturn = "May ";
                    break;
                case "06":
                    lstrReturn = "Jun ";
                    break;
                case "07":
                    lstrReturn = "Jul ";
                    break;
                case "08":
                    lstrReturn = "Aug ";
                    break;
                case "09":
                    lstrReturn = "Sep ";
                    break;
                case "10":
                    lstrReturn = "Oct ";
                    break;
                case "11":
                    lstrReturn = "Nov ";
                    break;
                case "12":
                    lstrReturn = "Dec ";
                    break;
                default:
                    lstrReturn = "Def ";
                    break;
            }
            return lstrReturn + lstrYear;
        }

        private void LoadLogHeaderRecords(string lstrFileName, Globals.ProjectStatus statusFilter = Globals.ProjectStatus.None)
        {
            string[] lstrTitleRec;
            
            Globals.mintLastLogFileRec = 0;

            Globals.mstrLogFileLines = File.ReadAllLines(lstrFileName);

            if (Globals.mstrLogFileLines.Length == 0) //for some reason the file exists, but is blank, recreate it with header record
            {
                Globals.CreateNewTextFile(Globals.mstrCurTextFile);
                Globals.mstrLogFileLines = File.ReadAllLines(lstrFileName);
            }

            if (Globals.mstrLogFileLines.Length == 1) //file only has header record, get out
            {
                lblYearMonth.Text = Globals.mstrLogFileLines[0]; //set what month/year we are in currently
                return;
            }

            lblYearMonth.Text = Globals.mstrLogFileLines[0]; //set what month/year we are in currently

            for (int i = 1; i < Globals.mstrLogFileLines.Length; i++) //skip header record
            {
                if (Globals.mstrLogFileLines[i].StartsWith("&&&"))
                {
                    lstrTitleRec = Globals.mstrLogFileLines[i].Split(Globals.DELIM);
                    try
                    {
                        Globals.mintCurrentLogFileRec = Int32.Parse(lstrTitleRec[0].Substring(3));

                        if (Globals.mintCurrentLogFileRec > Globals.mintLastLogFileRec) Globals.mintLastLogFileRec = Globals.mintCurrentLogFileRec;

                        if (lstrTitleRec[2] == Enum.GetName(statusFilter.GetType(), statusFilter) || statusFilter == Globals.ProjectStatus.None)
                        {
                            //Project title will be MM-DD-YYYY | Title | Rec Number
                            cmbProjectTitle.Items.Add(Globals.FormatDateForDisplay(lstrTitleRec[3]) + " " + Globals.DELIM + " " + lstrTitleRec[1]
                                                      + " " + Globals.DELIM + " " + lstrTitleRec[0].Substring(3));
                        }
                    }
                    catch (System.FormatException formatErr)
                    {
                        int lineNum = i+1;
                        MessageBox.Show("Error Loading Document on line " + lineNum.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Environment.Exit(11); //bad format?
                    }
                }
            }
        }

        private void cmbProjectTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] lstrTitleRec;
            int lintRecNumb;

            if (cmbProjectTitle.SelectedIndex < 0 || Globals.mInputState == Globals.InputState.New) return;


            lstrTitleRec = cmbProjectTitle.Text.Split(Globals.DELIM);
            try
            {
                //lintRecNumb = Int32.Parse(lstrTitleRec[2]);
                ResetForm(cmbProjectTitle.SelectedIndex);
                LoadLogRecord(Int32.Parse(lstrTitleRec[2]));
            }

            catch (System.IndexOutOfRangeException err)
            {
                return;
            }
        }

        public void LoadLogRecord(int lintLogRec, Globals.ProjectStatus statusFilter = Globals.ProjectStatus.None)
        {
            string[] lstrTitleRec;

            rtbProjectNotes.Clear();

            //first find the record we are looking for
            for (int i = 1; i < Globals.mstrLogFileLines.Length; i++) //skip header record
            {
                if (Globals.mstrLogFileLines[i].StartsWith("&&&"))
                {
                    lstrTitleRec = Globals.mstrLogFileLines[i].Split(Globals.DELIM);

                    if (lintLogRec == Int32.Parse(lstrTitleRec[0].Substring(3))
                       && (lstrTitleRec[2] == Enum.GetName(statusFilter.GetType(), statusFilter) || statusFilter == Globals.ProjectStatus.None))
                    {
                        Globals.mintCurrentLogFileRec = Int32.Parse(lstrTitleRec[0].Substring(3));
                        
                        cmbProjectStatus.SelectedIndex = cmbProjectStatus.FindString(lstrTitleRec[2]);
                        txtStartDate.Text = Globals.FormatDateForDisplay(lstrTitleRec[3]);
                        txtEndDate.Text = Globals.FormatDateForDisplay(lstrTitleRec[4]);
                        if (lstrTitleRec[5] == "1") chkStatus.Checked = true; 

                        if (lstrTitleRec[6] == "1") chkPriority.Checked = true; 

                        //now load all the text until the next record
                        i++;
                        while (i < Globals.mstrLogFileLines.Length)
                        {
                            if (Globals.mstrLogFileLines[i].StartsWith("&&&") == false)
                            {
                                rtbProjectNotes.AppendText(Globals.mstrLogFileLines[i] + "\n");
                                i++;
                            }
                            else break;
                            
                        }
                    }
                    else
                    {
                        i += Int32.Parse(lstrTitleRec[7]); //go to next title record
                    }
                }
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            Globals.mInputState = Globals.InputState.New;
            Void();
            Array.Resize(ref Globals.mstrLogFileLines, Globals.mstrLogFileLines.Length + 1);
            Globals.mintLastLogFileRec++;
            cmbProjectTitle.DropDownStyle = ComboBoxStyle.DropDown;            
        }

        private void tsbVoid_Click(object sender, EventArgs e)
        {
            Globals.mInputState = Globals.InputState.Void;
            Void();
        }

        private void Void()
        {
            cmbProjectStatus.SelectedIndex = 0;
            cmbProjectTitle.Text = "";
            chkPriority.Checked = false;
            chkStatus.Checked = false;
            txtStartDate.Text = "00/00/0000";
            txtEndDate.Text = "00/00/0000";
            rtbProjectNotes.Clear();
            cmbProjectTitle.Focus();
        }

        private void cmbProjectTitle_Leave(object sender, EventArgs e)
        {
            string lstrcomboText;

            switch (Globals.mInputState)
            {
                case Globals.InputState.New:
                    lstrcomboText = cmbProjectTitle.Text;
                    //set header record for this person and set start date to today
                    cmbProjectTitle.Text = (DateTime.Today.ToString("MM-dd-yyyy") + " " + Globals.DELIM + " " + lstrcomboText
                                               + " " + Globals.DELIM + " " + Globals.mintLastLogFileRec);
                    //cmbProjectTitle.SelectedIndex = cmbProjectTitle.Items.Count - 1;
                    txtStartDate.Text = DateTime.Today.ToString("MM-dd-yyyy");
                    Globals.mblnDirty = true;
                    break;
                case Globals.InputState.Void:
                    break;
                case Globals.InputState.Load:
                    break;
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            string[] lstrTitleRec;
            bool lblnUpdatedExistingRecord;
            int lintComboIndex;

            if (!Globals.mblnDirty) return; //nothing changed

            if (cmbProjectTitle.Text == Globals.mstrNoRecordsMessage) return;

            lintComboIndex = cmbProjectTitle.SelectedIndex;

            if (Globals.mInputState == Globals.InputState.New) //this is a new record just append the info
            {
                //now write info to log file
                Globals.mInputState = Globals.InputState.Save;
                lstrTitleRec = cmbProjectTitle.Text.Split(Globals.DELIM);

                using (StreamWriter sw = File.AppendText(Globals.mstrCurDataFolder + Globals.mstrCurTextFile))
                {
                    WriteEditedRecord(sw, lstrTitleRec);
                }
                cmbProjectTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else //update something that already exists in the file
            {
                Globals.mInputState = Globals.InputState.Save;
                File.WriteAllLines(Globals.mstrCurDataFolder + Globals.mstrCurTextFile + ".TMP", Globals.mstrLogFileLines);
                File.Delete(Globals.mstrCurDataFolder + Globals.mstrCurTextFile);

                try
                {
                    using (StreamWriter sw = File.CreateText(Globals.mstrCurDataFolder + Globals.mstrCurTextFile))
                    {
                        sw.WriteLine(Globals.mstrLogFileLines[0]); //header record

                        for (int i = 1; i < Globals.mstrLogFileLines.Length; i++)
                        {
                            lblnUpdatedExistingRecord = false;
                            if (Globals.mstrLogFileLines[i].StartsWith("&&&"))
                            {
                                lstrTitleRec = Globals.mstrLogFileLines[i].Split(Globals.DELIM);
                                if (lstrTitleRec[0].Substring(3).Trim() == Globals.mintCurrentLogFileRec.ToString().Trim()) //this is the record that exists that we are updating
                                {

                                    WriteEditedRecord(sw, cmbProjectTitle.Text.Split(Globals.DELIM));
                                    lblnUpdatedExistingRecord = true;                                    
                                    try { while (Globals.mstrLogFileLines[i + 1].StartsWith("&&&") == false) i++; }//we updated the edited record now 'skip' to the next one
                                    catch (System.IndexOutOfRangeException err) { }
                                }
                            }
                            if (lblnUpdatedExistingRecord == false) sw.WriteLine(Globals.mstrLogFileLines[i]); //avoid writing line of a record for the one we already updated and wrote
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Save Failed. Restoring Last Copy Of Text File", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Globals.mstrLogFileLines = File.ReadAllLines(Globals.mstrCurDataFolder + Globals.mstrCurTextFile + ".TMP");
                    File.WriteAllLines(Globals.mstrCurDataFolder + Globals.mstrCurTextFile, Globals.mstrLogFileLines);
                    try { File.Delete(Globals.mstrCurDataFolder + Globals.mstrCurTextFile + ".TMP"); }
                    catch (Exception err) { return; }
                }
            }

            lblDirty.Visible = false;
            Globals.mblnDirty = false;

            ResetForm(lintComboIndex);
        }

        private void ResetForm(int lintComboIndex = -1, Globals.ProjectStatus lstatusFilter = Globals.ProjectStatus.None)
        {
            cmbProjectTitle.Items.Clear();
            cmbProjectTitle.SelectedIndex = -1;
            rtbProjectNotes.Clear();
            cmbProjectStatus.SelectedIndex = -1;
            chkPriority.Checked = false;
            chkStatus.Checked = false;
            txtStartDate.Text = "00/00/0000";
            txtEndDate.Text = "00/00/0000";
            FlashAnimation();
            LoadLogHeaderRecords(Globals.mstrCurDataFolder + Globals.mstrCurTextFile, lstatusFilter);
            if (cmbProjectTitle.Items.Count == 0) //nothing in current log
            {
                cmbProjectTitle.Items.Add(Globals.mstrNoRecordsMessage);
            }
            cmbProjectTitle.SelectedIndex = lintComboIndex;
        }

        private void FlashAnimation() //wanted a fancy saving screen, but for now, all this does is refresh the screen by adding a delay
        {
            string message;

            message = "clearing...";
            rtbProjectNotes.SelectionColor = Color.Black;
            rtbProjectNotes.SelectionColor = rtbProjectNotes.ForeColor;

            for (int i = 0; i < 5; i++)
            {
                rtbProjectNotes.AppendText("clearing..." + "\n");
                message = message + message;
                System.Threading.Thread.Sleep(100);
            }
            rtbProjectNotes.Clear();
        }

        private void WriteEditedRecord(StreamWriter lsw, string[] lstrTitleRec)
        {
            lsw.WriteLine("&&&" + lstrTitleRec[2] + Globals.DELIM + lstrTitleRec[1] + Globals.DELIM + cmbProjectStatus.Text + Globals.DELIM +
                        Globals.FormatDateForStorage(txtStartDate.Text) + Globals.DELIM + Globals.FormatDateForStorage(txtEndDate.Text) +
                        Globals.DELIM + (chkStatus.Checked ? "1" : "0") + Globals.DELIM + (chkPriority.Checked ? "1" : "0") + Globals.DELIM +
                        rtbProjectNotes.Lines.Count());
            for (int i = 0; i < rtbProjectNotes.Lines.Count(); i++)
            {
                lsw.WriteLine(rtbProjectNotes.Lines[i]);
            }
        }

        private void rtbProjectNotes_TextChanged(object sender, EventArgs e)
        {
            Globals.mblnDirty = true;
            lblDirty.Visible = true;
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string[] lstrTitleRec;
            DialogResult lDRAnswer;
            int lintComboIndex;

            if (cmbProjectTitle.Text == Globals.mstrNoRecordsMessage || cmbProjectTitle.SelectedIndex == -1) return;

            lDRAnswer = MessageBox.Show("You Are About To Delete Some Data.\n Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (lDRAnswer == System.Windows.Forms.DialogResult.No) return;

            lintComboIndex = cmbProjectTitle.SelectedIndex;

            File.WriteAllLines(Globals.mstrCurDataFolder + Globals.mstrCurTextFile + ".TMP", Globals.mstrLogFileLines);

            File.Delete(Globals.mstrCurDataFolder + Globals.mstrCurTextFile);

            try
            {
                using (StreamWriter sw = File.CreateText(Globals.mstrCurDataFolder + Globals.mstrCurTextFile))
                {
                    sw.WriteLine(Globals.mstrLogFileLines[0]); //header record

                    for (int i = 1; i < Globals.mstrLogFileLines.Length; i++)
                    {

                        if (Globals.mstrLogFileLines[i].StartsWith("&&&"))
                        {
                            lstrTitleRec = Globals.mstrLogFileLines[i].Split(Globals.DELIM);
                            if (lstrTitleRec[0].Substring(3).Trim() == Globals.mintCurrentLogFileRec.ToString().Trim()) //this is the record that exists that we are deleting
                            {
                                i += Int32.Parse(lstrTitleRec[7] + 1);//skip passed this record w/ line count and keep writing
                            }
                        }
                        try { sw.WriteLine(Globals.mstrLogFileLines[i]); } //incase we are erasing the last record of the file, don't write non-existant data
                        catch (System.IndexOutOfRangeException err) { }
                    }
                }
            }

            catch (Exception error)
            {
                MessageBox.Show("Delete Failed. Restoring Last Copy Of Text File", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Globals.mstrLogFileLines = File.ReadAllLines(Globals.mstrCurDataFolder + Globals.mstrCurTextFile + ".TMP");
                File.WriteAllLines(Globals.mstrCurDataFolder + Globals.mstrCurTextFile, Globals.mstrLogFileLines);
                try { File.Delete(Globals.mstrCurDataFolder + Globals.mstrCurTextFile + ".TMP"); }
                catch (Exception err) { return; }
            }
            ResetForm(lintComboIndex-1);
        }

        private void tbsSort_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Globals.ProjectStatus lstatusFilter;
            if (e.ClickedItem.Text == "ALL") lstatusFilter = Globals.ProjectStatus.None;
            else lstatusFilter = (Globals.ProjectStatus) Enum.Parse(typeof(Globals.ProjectStatus), e.ClickedItem.Text);
            ResetForm(cmbProjectTitle.SelectedIndex, lstatusFilter);
            
        }

        private void tbsSort_Click(object sender, EventArgs e)
        {

        }
    }

    public static class Globals
    {
        public static String mstrCurDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"/WorkActivityLog/" + @"current/"; //folder to current text files
        public static String mstrDataPathFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + @"/WorkActivityLog/"; //folder to current text files
        public static String mstrCurTextFile;
        public const char DELIM = '|';
        public static string[] mstrLogFileLines;
        public static int mintCurrentLogFileRec;
        public static int mintLastLogFileRec;
        public const int CONST_RecNumberLength = 3;
        public static InputState mInputState;
        public static Boolean mblnDirty;
        public static string mstrNoRecordsMessage = "No Current Projects In Log";

        /* Current Format of Log Records
         * &&&### (0)| Project Title (String) (1)| Project Status (String) (2)| Start Date (YYYYMMDD) (3)| End Date(YYYYMMDD) (4)| Status Check (0 or 1) (5)| Priority Check (0 or 1) (6)| LineCount (7)
         * the &&& string will be used to identify new records and the # will identify the record's number
         * that way we can check for the first characters on a newline to see if its a different record than current
         * LineCount should allow us to 'point' to the next record based on how many lines of text we have currently
         */

        public enum ProjectStatus
        {
            None, Ongoing, Finished, OnHold, ToDo
        };

        public enum InputState
        {
            Normal, New, Void, Load, Delete, Save
        };

        public static Boolean CheckForTextFile(string lstrFilePath)
        {
            return File.Exists(lstrFilePath) ? true : false;
        }

        public static void CreateNewTextFile(string FileName, string Month = null , string Year = null)
        {
            if (Month == null) Month = DateTime.Today.ToString("MM");
            if (Year == null) Year = DateTime.Today.Year.ToString();

            string Folder = (Year == DateTime.Today.Year.ToString() ? Folder = @"current/" : Folder = Year + @"/"); //test the current folder or diff folder

            System.IO.Directory.CreateDirectory(Globals.mstrDataPathFolder + Folder);

            using (StreamWriter sw = File.CreateText(Globals.mstrDataPathFolder + Folder + FileName))
            {
                //just create a header record that will have month and year
                sw.WriteLine(Month + DELIM + Year);
            }
        }

        public static string FormatDateForDisplay(string lstrDate)
        {
            return lstrDate.Substring(4, 2) + "/" + lstrDate.Substring(6,2) + "/" + lstrDate.Substring(0, 4);
        }

        public static string FormatDateForStorage(string lstrDate)
        {
            return lstrDate.Substring(6, 4) + lstrDate.Substring(0, 2) + lstrDate.Substring(3, 2);
        }
    }
}
