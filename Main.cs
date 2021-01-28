using EbooksLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EbooksLib
{
    public partial class Main : Form
    {
        List<Ebooks> ebooksList = new List<Ebooks>();

        public Main()
        {
            InitializeComponent();
            ebooksList = EbooksManager.GetAll().OrderBy(e => e.Title).ToList();
        }

        private void SetupDisplay(List<Ebooks> list)
        {
            ebooksGridView.DataSource = list;
            ebooksGridView.RowHeadersVisible = false;
            ebooksGridView.Columns[0].HeaderText = "Auteurs";
            ebooksGridView.Columns[1].HeaderText = "Série";
            ebooksGridView.Columns[2].HeaderText = "Titre";
            foreach(DataGridViewColumn col in ebooksGridView.Columns)
            {
                col.MinimumWidth = ebooksGridView.Width / 3;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.FillWeight = 1;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SetupDisplay(ebooksList);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            List<Ebooks> list = ebooksList;
            if (!SearchText.Text.Equals(""))
            {
                string search4 = SearchText.Text.ToLower();
                list = list.Where(e => e.Authors.ToLower().Contains(search4) ||
                    e.Series.ToLower().Contains(search4) ||
                    e.Authors.ToLower().Contains(search4))
                    .ToList();
            }
            SetupDisplay(list);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SearchText.Text = "";
            SearchButton_Click(sender, e);
        }
    }
}
