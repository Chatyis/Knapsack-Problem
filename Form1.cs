using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemPlecakowy
{
    public partial class Form1 : Form
    {
        private OpenFileDialog uploadFileOFD = new OpenFileDialog();
        private int selectionNumber = 1;
        public bool isSelectionDisplayed = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public void uploadFileButton_Click(object sender, EventArgs e)
        {
            uploadFileOFD.Filter = "Text Files | *.txt";
            if (uploadFileOFD.ShowDialog() == DialogResult.OK)
            {
                uploadFileTextbox.Text = uploadFileOFD.FileName;
                startSelectionButton.Enabled = true;
            }
        }
        private void setViewButton_Click(object sender, EventArgs e)
        {
            foreach(Control item in tabControl1.Controls.OfType<TabPage>().ToArray())
            {
                if (isSelectionDisplayed)
                {
                    item.Controls.OfType<TextBox>().ToArray()[0].Hide();
                    item.Controls.OfType<DataGridView>().ToArray()[0].Show();
                    setViewButton.Text = "Wyświetl Selekcje";
                }
                else
                {
                    item.Controls.OfType<TextBox>().ToArray()[0].Show();
                    item.Controls.OfType<DataGridView>().ToArray()[0].Hide();
                    setViewButton.Text = "Porównaj Generacje";
                }
            }
            
            isSelectionDisplayed = !isSelectionDisplayed;
        }
        private void saveAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveAsSFD = new SaveFileDialog();
            saveAsSFD.Filter = "Text Files | *.txt";
            saveAsSFD.DefaultExt = "txt";
            saveAsSFD.FileName = "result.txt";
            if (saveAsSFD.ShowDialog() == DialogResult.OK) 
            { 
                MessageBox.Show(saveAsSFD.FileName);
                System.IO.File.WriteAllText(saveAsSFD.FileName, ""); 
                foreach(Control item in tabControl1.Controls.OfType<TabPage>().ToList())
                {
                    System.IO.File.AppendAllText(saveAsSFD.FileName, item.Controls.OfType<TextBox>().ToArray()[0].Text+"\r\n");
                }
            }
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            //resultsTextBox.Text = "";
            foreach (Control item in tabControl1.Controls.OfType<TabPage>().ToList())
            {
                tabControl1.Controls.Remove(item);
                selectionNumber = 1;
            }
        }
        private void startSelectionButton_Click(object sender, EventArgs e)
        {
            GeneticAlgorithm();
        }
        private void uploadFileTextbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
