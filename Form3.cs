using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Text.UTF8Encoding;
using static ITCan.Persons;
namespace ITCan
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        OpenFileDialog openFileDialog1 = new OpenFileDialog
        {
            ReadOnlyChecked = true,
            ShowReadOnly = true
        };
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private List<Persons> PersonsList;
        private void button1_Click(object sender, EventArgs e)
        {

            PersonsList = new List<Persons>();


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName, encoding: Encoding.UTF8);

                if (lines.Count() > 0)
                {
                    var person = new Persons();
                    foreach (var cellValues in lines)
                    {
                        if (!string.IsNullOrEmpty(cellValues))
                        {
                            var cellArray = cellValues.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            person.Number = cellArray[0];
                            person.Date = Convert.ToDateTime(cellArray[1]);
                            person.Vid = cellArray[2];
                            person.Model = cellArray[3];
                            person.Problem = cellArray[4];
                            person.FIO = cellArray[5];
                            person.Telephone = cellArray[6];
                            person.Status = cellArray[7];
                            person.Master = cellArray[8];
                            PersonsList.Add(person);
                        }
                    }
                    FillingDGV();
                }
            }

        }
        private void FillingDGV()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in PersonsList)
            {
                dataGridView1.Rows.Add(item.Number, item.Date, item.Vid, item.Model, item.Problem,
                    item.FIO, item.Telephone, item.Status, item.Master);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        break;
                    }

                    if (textBox1.Text == dataGridView1.Rows[i].Cells[j].Value.ToString())
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
        }
    }

}

