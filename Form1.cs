using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace E14Hockey
{
    public partial class Form1 : Form
    {
        public static Excel.Application? excelApp;
        public static Excel.Workbook? excelBook;
        public static Excel.Worksheet? excelSheet;
        public static Excel.Range? excelRange;

        public string excelPath = AppContext.BaseDirectory + "QuantHockey.xlsx";

        public int playerAction = 1;

        public Form1()
        {
            InitializeComponent();
            excelApp = new Excel.Application();

            if (excelApp is null)
            {
                MessageBox.Show("The logiciel needs Excel to work correctly. Please be sure that your Excel application is installed properly.");
                Application.Exit();
            }
            else
            {
                try
                {
                    InitializePlayers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occured. More information: " + ex.Message);
                    Application.Exit();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializePlayers()
        {
            ListViewItem? playerList = null;

            lvPlayers.View = View.Details;
            lvPlayers.FullRowSelect = true;

            excelBook = excelApp?.Workbooks.Open(excelPath);
            excelSheet = excelBook.Worksheets["QuantHockey"];
            excelRange = excelSheet.Range["A2"];

            int playersRows = excelRange.get_End(Excel.XlDirection.xlDown).Row;

            for (int i = 2; i < playersRows; i++)
            {
                for (int j = 2; j < 8; j++)
                {
                    string? info = excelSheet.Cells[i, j].Value.ToString();

                    if (i == 2)
                    {
                        if (j != 3)
                        {
                            lvPlayers.Columns.Add(info);
                        }
                    }
                    else
                    {
                        if (j == 2)
                        {
                            playerList = new ListViewItem(info);
                        }
                        else
                        {
                            if (j != 3)
                            {
                                playerList?.SubItems.Add(info);
                            }
                        }
                    }
                }
                if (playerList is not null)
                {
                    lvPlayers.Items.Add(playerList);
                }
            }

            lvPlayers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvPlayers.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);

            excelBook.Close(false);

            StartGame();
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            EndGame();
        }

        private void EndGame()
        {
            try
            {
                if (excelBook is not null)
                {
                    string endGame = DateTime.Now.ToString("yyMMddHHmmss");

                    excelBook.SaveAs2(AppContext.BaseDirectory + $"Stats_{endGame}.xlsx");
                    
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("There was no game recorded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The game's stats could not be saved ::" + ex.Message);
            }
        }

        private void StartGame()
        {
            excelBook = excelApp.Workbooks.Add();

            excelSheet = excelBook.Worksheets[1];
            excelSheet.Cells[1, 2] = "Player";
            excelSheet.Cells[1, 3] = "Action";
            excelSheet.Cells[1, 4] = "Time Stamp";

            playerAction = 2;

            excelRange = excelSheet.Range["B1:D1"];
            excelRange.Font.Bold = true;

            excelSheet.Columns[2].ColumnWidth = 25;
            excelSheet.Columns[4].ColumnWidth = 15;

            excelSheet.Cells[2, 4].EntireColumn.NumberFormat = "[$-en-US]hh:mm:ss AM/PM";

        }

        private void RecordAction(Button action)
        {
            if (lvPlayers.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must selec a player, before clicking a button.");
            }
            else
            {
                ListViewItem player = lvPlayers.SelectedItems[0];

                excelSheet.Cells[playerAction, 2].Value = player.SubItems[0].Text;
                excelSheet.Cells[playerAction, 3].Value = action.Text;
                excelSheet.Cells[playerAction, 4].Value = DateTime.Now.ToOADate(); ;

                playerAction++;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            RecordAction(btnCheck);
        }

        private void btnShot_Click(object sender, EventArgs e)
        {
            RecordAction(btnShot);
        }

        private void btnGoal_Click(object sender, EventArgs e)
        {
            RecordAction(btnGoal);
        }

        private void btnAssist_Click(object sender, EventArgs e)
        {
            RecordAction(btnAssist);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            excelApp?.Quit();

            GC.WaitForPendingFinalizers();
            GC.Collect();

            if (excelSheet is not null)
                Marshal.ReleaseComObject(excelSheet);
            if (excelBook is not null)
                Marshal.ReleaseComObject(excelBook);
            if (excelApp is not null)
            {
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}
