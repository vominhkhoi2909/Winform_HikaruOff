﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HikaruOff.Controller;
using HikaruOff.BUS;

namespace HikaruOff
{
    public partial class UC_Dashboard : UserControl
    {
        ItemCtrl item = new ItemCtrl();
        CustomerCtrl customer = new CustomerCtrl();
        SaleCtrl sale = new SaleCtrl();

        public UC_Dashboard()
        {
            InitializeComponent();
            refresh();
        }

        //Hàm hỗ trợ.
        //Hàm làm lại form.
        private void refresh()
        {
            lbl_NumProduct.Text = item.Count().ToString() + " Items";
            lbl_NumCustomer.Text = customer.Count().ToString() + " People";
            lbl_NumSale.Text = sale.Count().ToString() + " Bill";
            lbl_SaleTotal.Text = sale.Sum().ToString() + "đ";
            dtm_From.Value = DateTime.Now;
            dtm_To.Value = DateTime.Now;
            showChart(1, DateTime.Now, DateTime.Now);
        }

        //Xóa các cột dữ liệu của dashboard cũ.
        void clearChart()
        {
            foreach (var series in cht_Dashboard.Series)
            {
                series.Points.Clear();
            }
        }

        //Lấy thông tin truy vấn thêm vào cột dữ liệu dashboard.
        private void showChart(int style, DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            dt = sale.PullListDt(style, from, to);
            List<double> data = new List<double>();
            List<string> label = new List<string>();
            clearChart();
            foreach (DataRow dr in dt.Rows)
            {
                cht_Dashboard.Series["SaleDate"].Points.AddXY(dr["date"].ToString(), dr["total"]);
            }
        }

        //Hàm action.
        //Hiển thị dashboard lọc theo tháng.
        private void btn_Month_Click(object sender, EventArgs e)
        {
            showChart(2, DateTime.Now, DateTime.Now);
        }

        //Hiển thị dashboard lọc theo năm.
        private void btn_Year_Click(object sender, EventArgs e)
        {
            showChart(3, DateTime.Now, DateTime.Now);
        }

        //Hiển thị dashboard lọc theo từ date tới date.
        private void btn_Fill_Click(object sender, EventArgs e)
        {
            showChart(4, dtm_From.Value, dtm_To.Value);
        }

        //Hiển thị dashboard lọc theo ngày.
        private void btn_Day_Click(object sender, EventArgs e)
        {
            showChart(1, DateTime.Now, DateTime.Now);
        }
    }
}
