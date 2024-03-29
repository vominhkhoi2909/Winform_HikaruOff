﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikaruOff.BUS
{
    public class LoginBUS
    {
        //Khởi tạo các biến giá trị.
        int _userId;
        string _userName, _userEmail, _userOffice;

        //Khởi tạo mặc định.
        public LoginBUS()
        {
            this.UserId = 1003;
            this.UserEmail = "hikaru_shop@gmail.com";
            this.UserName = "Võ Minh Khôi";
            this.UserOffice = "Master";
        }

        public LoginBUS(LoginBUS log)
        {
            this.UserId = log.UserId;
            this.UserEmail = log.UserEmail;
            this.UserName = log.UserName;
            this.UserOffice = log.UserOffice;
        }

        //Hàm xử lý getter, setter.
        public int UserId { get => _userId; set => _userId = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string UserEmail { get => _userEmail; set => _userEmail = value; }
        public string UserOffice { get => _userOffice; set => _userOffice = value; }
    }
}
