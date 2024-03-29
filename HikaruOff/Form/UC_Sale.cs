﻿using System;
using HikaruOff.Controller;
using System.Windows.Forms;

namespace HikaruOff
{
    public partial class UC_Sale : UserControl
    {
        //Khởi tạo các biến của form.
        SaleCtrl sale = new SaleCtrl();

        //Hàm khỏi tạo mặc định.
        public UC_Sale()
        {
            InitializeComponent();
            refresh();
        }

        //Hàm hỗ trợ.
        //Refresh form.
        void refresh()
        {
            txt_Search.Text = "";
            sale.ShowDgv(dgv_Sale);
            dgv_Sale.Update();
            dgv_Sale.Refresh();
        }

        //Hàm action.
        //Làm mới lại form.
        private void btn_Renew_Click(object sender, EventArgs e)
        {
            refresh();
        }

        //Search sale.
        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (txt_Search.Text != "")
                sale.Search(dgv_Sale, txt_Search.Text);
            dgv_Sale.Update();
            dgv_Sale.Refresh();
        }
    }
}
