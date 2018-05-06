using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPrices
{
    public partial class StockGUI : Form
    {
        Dictionary<string, int> stocks = new Dictionary<string, int>();
        List<String> stocksAdded = new List<string>();
        private Timer timer1;
        Random rnd = new Random();
        String stockSymbol = "";
        String stockSymbolDrop = "";
        int stockPrice = 0;

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stocks["AAPL"] = rnd.Next(1, 13);
            stocks["ORCL"] = rnd.Next(15, 30);
            stocks["MSFT"] = rnd.Next(10, 50);
            stocks["PRI"] = rnd.Next(12, 40);
            stocks["ULTA"] = rnd.Next(240, 350);
            stocks["T"] = rnd.Next(35, 50);
            stocks["VZ"] = rnd.Next(35, 70);
            stocks["C"] = rnd.Next(90, 120);
            stocks["JPM"] = rnd.Next(290, 340);
            stocks["GS"] = rnd.Next(280, 350);
            if(stockSymbol != "" && !stocks.ContainsKey(stockSymbol))
            {
                stocks.Add(stockSymbol, stockPrice);
                stocksAdded.Add(stockSymbol);
            }
            for (int i = 0; i < stocksAdded.Count; i++)
            {
                stocks[stocksAdded[i]] = rnd.Next(1, 100);
            }
            stockSymbol = "";
            stocks.Remove(stockSymbolDrop);
            stocksAdded.Remove(stockSymbolDrop);
            stockSymbolDrop = "";

            dataGridView1.DataSource = (from d in stocks orderby d.Key select new { d.Key, d.Value }).ToList();
        }

        public StockGUI()
        {
            InitTimer();
            stocks.Add("AAPL", 32);
            stocks.Add("ORCL", 15);
            stocks.Add("MSFT", 10);
            stocks.Add("PRI", 12);
            stocks.Add("ULTA", 250);
            stocks.Add("T", 24);
            stocks.Add("VZ", 40);
            stocks.Add("C", 100);
            stocks.Add("JPM", 300);
            stocks.Add("GS", 300);
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(!comboBox1.SelectedIndex.Equals(0))
            {
                stockSymbol = comboBox1.Text;
                stockPrice = rnd.Next(1, 100);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox2.SelectedIndex.Equals(0))
            {
                stockSymbolDrop = comboBox2.Text;
                comboBox2.SelectedIndex = 0;
            }
        }
    }
}
