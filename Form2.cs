using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Text.UTF8Encoding;
using static ITCan.Persons;

namespace ITCan
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private List<Persons> PersonsList;
        private void button4_Click(object sender, EventArgs e)
        {
            using (TextWriter tw = new StreamWriter("DR.txt"))
            {
                foreach (var person in PersonsList)
                {
                    string str = $"{person.Number};{person.Date.ToShortDateString()};{person.Vid};{person.Model};" +
                        $"{person.Problem};{person.FIO};{person.Telephone};{person.Status};{person.Master}";
                    tw.WriteLine(str);

                }
                MessageBox.Show("Успешная перезапись списка", "Цех");
            }
        }
        OpenFileDialog openFileDialog1 = new OpenFileDialog
        {
            ReadOnlyChecked = true,
            ShowReadOnly = true
        };
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

        private void button2_Click(object sender, EventArgs e)
        {
            var person = new Persons();

            person.Number = textBox1.Text;
            person.Date = Convert.ToDateTime(textBox2.Text);
            person.Vid = textBox3.Text;
            person.Model = textBox4.Text;
            person.Problem = textBox5.Text;
            person.FIO = textBox6.Text;
            person.Telephone = textBox7.Text;
            person.Status = textBox8.Text;
            person.Master = textBox9.Text;
            PersonsList.Add(person);
            FillingDGV();
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

        private void button3_Click(object sender, EventArgs e)
        {
            int Index = dataGridView1.CurrentRow.Index;
            PersonsList.RemoveAt(Index);
            FillingDGV();
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

