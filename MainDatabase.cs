﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace StockProgram
{
    public partial class MainDatabase : Form
    {
        //global variables
        private SQLiteConnection conn;
        private DataTable table;

        public MainDatabase()
        {
            InitializeComponent();

            //initialising (or setting) the connection variable as well as the table variable
            setConn();
            setTable();

            //open connection to database
            openConnection();

            //show stock
            showStock();

            //close connection to database
            closeConnection();
        }

        //methods for opening and closing database
        public void openConnection() {
            getConn().Open();
        }

        public void closeConnection() {
            getConn().Close();
        }

        //method for showing the database
        protected void showStock() {
            //the command object
            string selectStock = "SELECT* from Products";
            SQLiteCommand selectComm = new SQLiteCommand(selectStock, conn);

            //the adapter
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectComm);
            adapter.Fill(table);

            //actually putting it in the form
            stockView.DataSource = table;
        }

        //method for sorting name by product id
        private void sortBtn_Click(object sender, EventArgs e)
        {
            //the command object
            string sortStock = "SELECT* from Products ORDER BY ProductId";
            SQLiteCommand sortComm = new SQLiteCommand(sortStock, conn);

            //the adapter
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sortComm);
            adapter.Fill(table);

            //actually putting it in the form
            stockView.DataSource = table;
        }

        //method for sorting name alphabetically
        private void sortNameBtn_Click(object sender, EventArgs e)
        {
            //the command object
            string sortStock = "SELECT* from Products ORDER BY Name";
            SQLiteCommand sortNameComm = new SQLiteCommand(sortStock, conn);

            //the adapter
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sortNameComm);
            adapter.Fill(table);

            //actually putting it in the form
            stockView.DataSource = table;
        }

        //methods for initialising the connection and table variables
        public SQLiteConnection getConn() {
            return conn;
        }

        private void setConn() {
            conn = new SQLiteConnection(@"data source=database\StockDatabase.sqlite");
        }

        public DataTable getTable() {
            return table;
        }

        private void setTable() {
            table = new DataTable();
        }

        private void submitStockBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(enterIdTb.Text))
            {
                string enterId;
                enterId = enterIdTb.Text;
                string command = "INSERT into Products(Id) VALUES(enterId)";
                SQLiteCommand enterIdComm = new SQLiteCommand(command);
                SQLiteDataAdapter enterIdAdpt = new SQLiteDataAdapter(enterIdComm);
                enterIdAdpt.Update(table);
            }
            if (!String.IsNullOrEmpty(enterNameTb.Text))
            {
                string enterName;
                enterName = enterNameTb.Text;
                string command = "INSERT into Products(Name) VALUES(enterName)";
                SQLiteCommand enterNameComm = new SQLiteCommand(command);
                SQLiteDataAdapter enterNameAdpt = new SQLiteDataAdapter(enterNameComm);
                enterNameAdpt.Update(table);
            }
            if (!String.IsNullOrEmpty(enterPriceTb.Text))
            {
                string enterPrice;
                enterPrice = enterPriceTb.Text;
                string command = "INSERT into Products(Price) VALUES(enterPrice)";
                SQLiteCommand enterPriceComm = new SQLiteCommand(command);
                SQLiteDataAdapter enterPriceAdpt = new SQLiteDataAdapter(enterPriceComm);
                enterPriceAdpt.Update(table);
            }
            if (!String.IsNullOrEmpty(enterQuantityTb.Text))
            {
                string enterQuant;
                enterQuant = enterQuantityTb.Text;
                string command = "INSERT into Products(Quantity) VALUES(enterQuant)";
                SQLiteCommand enterQuantComm = new SQLiteCommand(command);
                SQLiteDataAdapter enterQuantAdpt = new SQLiteDataAdapter(enterQuantComm);
                enterQuantAdpt.Update(table);
            }
        }
    }
}
