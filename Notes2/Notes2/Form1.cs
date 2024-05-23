using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes2
{
    public partial class NoteTaker : Form
    {
        DataTable notes= new DataTable();
        bool editing= false;
        public NoteTaker()
        {
            InitializeComponent();
        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previuosnotes.DataSource = notes;
        }

        

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previuosnotes.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex) { Console.WriteLine("Not a valid note"); }
        }
        private void loadbtn_Click(object sender, EventArgs e)
        {
            titleBox.Text = notes.Rows[previuosnotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previuosnotes.CurrentCell.RowIndex].ItemArray[1].ToString();

            editing = true;
        }

        private void newnotebtn_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                notes.Rows[previuosnotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[previuosnotes.CurrentCell.RowIndex]["Note"] = noteBox.Text;
            }
            else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;
        }

        private void previuosnotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = notes.Rows[previuosnotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previuosnotes.CurrentCell.RowIndex].ItemArray[1].ToString();

            editing = true;
        }
    }
}
