using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Text;


namespace gR_window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(GraphStyleCB.Items.Count > 0)
                GraphStyleCB.SelectedIndex = 0;    //The first item has index 0 '
        }

        public void End_Excel_App(DateTime dateStart, DateTime dateEnd)
        {
            Process[] xlp = Process.GetProcessesByName("EXCEL");
            foreach (Process p in xlp)
            {
                if(p.StartTime>=dateStart && p.StartTime<=dateEnd)
                {
                    p.Kill();                
                }
            }
        }

        public static String GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            String columnName = String.Empty;
            int modulo;

            while(dividend>0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = Convert.ToInt32((dividend - modulo) / 26);
            }
            return columnName;
        }

        public static String convertSeq(String Sequence)
        {
            int i, ln;
            String Seq2;
            ln = Sequence.Length;

            Seq2 = "";
            for (i=0;i<ln;i++)
            {
                if(Sequence[i] >= 'A' && Sequence[i] <= 'Z')
                {
                    Seq2 = Seq2 + Sequence[i];
                }
            }
            return Seq2;
        }

        public static double gR_Calc(String Seq)
        {
            int X, Y,N,ln,i,C;              //N=rejected bases
            double SumX, SumY;
            double MuX, MuY, gR;
            //long SumA, SumC, SumG, SumT;

            C = GV.C;
            X = 0;Y = 0;N = 0;
            SumX = 0;SumY = 0;
            MuX = 0;MuY = 0;gR = 0;

            ln = Seq.Length;
            if(C==1)                //Nandy
            {
                for(i=0;i<ln;i++)
                {
                    if (Seq[i]=='G') { X = X + 1; }
                    else if(Seq[i]=='A') { X = X - 1; }
                    else if(Seq[i]=='C') { Y = Y + 1; }
                    else if(Seq[i]=='T') { Y = Y - 1; }
                    else { N = N + 1; continue; }
                    SumX = SumX + X; SumY = SumY + Y;
                }
            }
            else if(C==2)           //Gates
            {
                for (i = 0; i < ln; i++)
                {
                    if (Seq[i] == 'C') { X = X + 1; }
                    else if (Seq[i] == 'G') { X = X - 1; }
                    else if (Seq[i] == 'T') { Y = Y + 1; }
                    else if (Seq[i] == 'A') { Y = Y - 1; }
                    else { N = N + 1; continue; }
                    SumX = SumX + X; SumY = SumY + Y;
                }
            }
            else if (C == 3)           //Leong and Morgenthaler
            {
                for (i = 0; i < ln; i++)
                {
                    if (Seq[i] == 'A') { X = X + 1; }
                    else if (Seq[i] == 'C') { X = X - 1; }
                    else if (Seq[i] == 'T') { Y = Y + 1; }
                    else if (Seq[i] == 'G') { Y = Y - 1; }
                    else { N = N + 1; continue; }
                    SumX = SumX + X; SumY = SumY + Y;
                }
            }
            else if (C == 4)           //Custom01
            {
                for (i = 0; i < ln; i++)
                {
                    if (Seq[i] == 'T') { X = X + 1; }
                    else if (Seq[i] == 'A') { X = X - 1; }
                    else if (Seq[i] == 'G') { Y = Y + 1; }
                    else if (Seq[i] == 'C') { Y = Y - 1; }
                    else { N = N + 1; continue; }
                    SumX = SumX + X; SumY = SumY + Y;
                }
            }
            MuX = SumX / Seq.Length; MuY = SumY / Seq.Length;
            gR = Math.Pow(MuX * MuX + MuY * MuY, 0.5);

            return gR;
        }

        private void GraphStyleCB_SelectedIndexChanged(object sender, EventArgs e) //Handles GraphStyleCB.SelectedIndexChanged
        {
            if (GraphStyleCB.SelectedIndex == 0)
                GraphStylePB.Image = gR_window.Properties.Resources.Nandy;
            else if (GraphStyleCB.SelectedIndex == 1)
                GraphStylePB.Image = gR_window.Properties.Resources.Gates;
            else if (GraphStyleCB.SelectedIndex == 2)
                GraphStylePB.Image = gR_window.Properties.Resources.Leong_and_Morgenthaler;
            else if (GraphStyleCB.SelectedIndex == 3)
                GraphStylePB.Image = gR_window.Properties.Resources.Custom01;
            else
                MessageBox.Show("Wrong Choice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static String getHeaderDetails(String header,String key)
        {
            int StartIndex, EndIndex;

            StartIndex = header.IndexOf(key);

            if (StartIndex == -1)
                return "Not Found";

            StartIndex += key.Length;

            EndIndex = header.IndexOf("|", StartIndex + 1);

            return header.Substring(StartIndex, EndIndex - StartIndex);

        }

        public static int charCount(String s1, char ch)
        {
            return s1.Split(ch).Length - 1;
        }

        //===============================================================================

        public static void processEachFile(String fileName, int count)
        {
            if(count%100==0)
                Console.WriteLine("Working on File ["+ Path.GetFileName(fileName) + "] --- File No.: ["+ count + "]");
            int headerStartIndex, headerEndIndex, SeqStartIndex, SeqEndIndex, RejectsN;
            String fileContent, fastaHeader, Seq, SeqConv;

            fileContent = File.ReadAllText(fileName);
            headerStartIndex = fileContent.IndexOf(">");
            headerEndIndex = fileContent.IndexOf("\n");
            SeqStartIndex = headerEndIndex + 1;
            SeqEndIndex = fileContent.Length - 1;

            fastaHeader = fileContent.Substring(headerStartIndex, headerEndIndex - headerStartIndex);
            fastaHeader = fastaHeader.Replace(",", "&");        //replacing comma(,) with and(&) because csv handles comma(,) differently.
            Seq = fileContent.Substring(SeqStartIndex, SeqEndIndex - SeqStartIndex + 1);
            Seq = Seq.Trim();
            SeqConv = convertSeq(Seq);
            SeqConv = SeqConv.ToUpper();

            String year, country, host;
            year = getHeaderDetails(fastaHeader, "Year=");
            country = getHeaderDetails(fastaHeader, "Country=");
            host = getHeaderDetails(fastaHeader, "Host=");

            RejectsN = SeqConv.Length - (charCount(SeqConv, 'A') + charCount(SeqConv, 'C') + charCount(SeqConv, 'G') + charCount(SeqConv, 'T'));

            String lineData = (count - 1) + "," + Path.GetFileName(fileName) + "," + fastaHeader + "," + SeqConv + "," + SeqConv.Length + "," + RejectsN + "," + year + "," + country + "," + host + ",";
            GV.csvData.Add(count, lineData);
            gR_windower(SeqConv, count);
        }


        public static void gR_windower(String SeqConv, int count)
        {
            //String columnIndex;
            int windowStart, windowEnd, gR_columnStart;
            double gR;

            windowStart = 0;
            windowEnd = windowStart + GV.windowSize;


            gR_columnStart = 9; //change later


            String lineData = "";

            if (SeqConv.Length > GV.maxLength)
                GV.header = "";

            do
            {
                gR = gR_Calc(SeqConv.Substring(windowStart, GV.windowSize));
                gR_columnStart += 1;
                //columnIndex = GetExcelColumnName(gR_columnStart);

                lineData += gR + ",";
                //If(oSheet.Range(ch & "1").Text = "") Then
                //        oSheet.Range(ch & "1").Value = "pR (" & (windowStart + 1) & "-" & (windowStart + windowSize) & ")"
                //    End If
                //if (count == 2)                 //adding heading eg. gR (1-36) etc
                if (SeqConv.Length > GV.maxLength)
                {
                    //Only applicable for first file, since thread, later change

                    GV.header += "gR (" + (windowStart + 1) + "-" + (windowStart + GV.windowSize) + "),";
                    //Console.WriteLine("Added :" + "1" + "~" + gR_columnStart + "~" + "gR (" + (windowStart + 1) + "-" + (windowStart + GV.windowSize) + ")");
                }
                windowStart = windowStart + GV.windowInterval;
                windowEnd = windowStart + GV.windowSize;// -1+GV.windowInterval;
            } while (windowEnd <= SeqConv.Length);
            //GV.maxLength = SeqConv.Length;
            if (SeqConv.Length > GV.maxLength)
                GV.maxLength = SeqConv.Length;

            //if (count == 2)
            if (count == GV.maxCount + 1)
                GV.csvData.Add(1, GV.header);// + "\n");
            lineData = GV.csvData[count] + lineData;// + "\n";
            GV.csvData.Remove(count);
            GV.csvData.Add(count, lineData);
        }

        public static void WriteToCSV(String fileNameWithPath, String fileNameWithPathExcel)
        {
            String headerPart = "Sl. No." + "," + "File Name" + "," + "Fasta Header" + "," + "Sequence" + "," + "Sequence Length 'N'" + "," + "No. of Rejected bases 'X'" + "," + "Year" + "," + "Country" + "," + "Host" + ",";
            headerPart = headerPart + GV.csvData[1];
            //String data = "";
            //StringBuilder data = new StringBuilder();
            

            Console.WriteLine("Consolidating data started at : " + DateTime.Now);

            //for (int i = 2; i <= GV.csvData.Count; i++)
            //    data += GV.csvData[i];

            String[] test = new String[GV.csvData.Count];
            for (int i = 2; i <= GV.csvData.Count; i++)
                test[i-1]= GV.csvData[i];
            test[0] = headerPart;
            Console.WriteLine("Writing to CSV started at : "+DateTime.Now);

            //using (StreamWriter writer = new StreamWriter(fileNameWithPath, false, System.Text.Encoding.UTF8, 65536))
            //writer.Write(headerPart + data);
            File.WriteAllLines(fileNameWithPath, test, Encoding.UTF8);

            Console.WriteLine("Writing to Excel started at : "+DateTime.Now);

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(fileNameWithPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wb.SaveAs(fileNameWithPathExcel, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            wb.Close();
            app.Quit();

            //Console.WriteLine("After Excel : "+DateTime.Now);

            File.Delete(fileNameWithPath);
        }

        //==========================================================================================

        private void TB_KillExcel_Click(object sender, EventArgs e)
        {
            Process[] xlp = Process.GetProcessesByName("EXCEL");
            foreach (Process p in xlp)
                p.Kill();
            MessageBox.Show("All Excel Processes Killed!");
        }

        private void Btn_Inp_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                GV.inputFolderPath = folderBrowserDialog1.SelectedPath;
                TB_Inp.Text = GV.inputFolderPath;
                TB_Inp.ReadOnly = true;
            }
        }

        private void Btn_Outp_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                GV.outputFolderPath = folderBrowserDialog1.SelectedPath;
                TB_Outp.Text = GV.outputFolderPath;
                TB_Outp.ReadOnly = true;
            }
        }

        //==========================main code starts=======================================

        private void Btn_Exec_Click(object sender, EventArgs e)
        {
            DateTime dateStart = DateTime.Now;

            GV.inputFolderPath = TB_Inp.Text;
            GV.outputFolderPath = TB_Outp.Text;

            if (GV.inputFolderPath == "" || GV.outputFolderPath == "")
            {
                MessageBox.Show("Enter the Input Folder Path And/Or the Output folder Path and try again.", "Invalid Entry");
                return;
            }

            if (Directory.Exists(GV.inputFolderPath) == false || Directory.Exists(GV.outputFolderPath) == false)
            {
                MessageBox.Show("Invalid input/output folder entered. Enter valid folder(s) and try again." + "\n" + "Or select folder(s) through the Browse Folder button(s) to prevent such error.", "Invalid Folder");
                return;
            }
            GV.C = GraphStyleCB.SelectedIndex + 1;
            if (int.TryParse(TB_WS.Text, out GV.windowSize) == false)
            {
                MessageBox.Show("Invalid Numerical value in Window Size", "Invalid Entry");
                return;
            }
            if (int.TryParse(TB_WI.Text, out GV.windowInterval) == false)
            {
                MessageBox.Show("Invalid Numerical value in Window Size", "Invalid Entry");
                return;
            }

            String[] fileEntries = Directory.GetFiles(GV.inputFolderPath, "*.fasta");
            //String fileName;
            //int ln,count;
            GV.maxLength = 0;
            GV.maxCount = fileEntries.Length;

            Array.Sort(fileEntries);

            String fileTest = GV.outputFolderPath + "\\gR Sliding Window.xlsx";
            String fileTestCSV = GV.outputFolderPath + "\\gR Sliding Window.csv";
            if (File.Exists(fileTest))
                File.Delete(fileTest);
            if (File.Exists(fileTestCSV))
                File.Delete(fileTestCSV);

            int count = 2;

            //ProgressBar7.Visible = true;
            //ProgressBar7.Value = 50;
            GV.maxLength = -1;
            foreach (String fileName in fileEntries)
            {
                //ProgressBar7.Value = (int)((count - 1) / fileEntries.Length * 100);
                processEachFile(fileName, count++);
            }





            TimeSpan Diff1 = DateTime.Now - dateStart;
            Console.WriteLine("Computation completed in " + Diff1.ToString());

            //WriteToExcelFile(fileTest, ExcelData);
            WriteToCSV(fileTestCSV, fileTest);
            DateTime dateEnd = DateTime.Now;
            TimeSpan Diff2 = dateEnd - dateStart;
            Console.WriteLine("Excel file creation completed in :" + Diff2.ToString());
            GV.csvData.Clear();
            //ProgressBar7.Visible = false;
            MessageBox.Show("Computation completed in : " + Diff1 + "\nExcel file creation completed in :" + Diff2,"Job Complete!");
        }
    }



    public class GV     //Global Variables, other classes to written after Main Class else code wont work
    {
        public static String inputFolderPath, outputFolderPath,header="";
        public static int windowSize, windowInterval,maxLength,maxCount;         //maxLength, maxCount for heading addition
        public static int C;
        public static Dictionary<int,String> csvData = new Dictionary<int, String>();
    }
}
