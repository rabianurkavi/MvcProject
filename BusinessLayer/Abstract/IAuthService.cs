﻿using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        bool AdminLogin(AdminForLoginDto adminForLoginDto);
        Admin AdminExists(string email);
        void AdminRegister(string adminUserName, string adminMail,string password);
        Writer WriterLogin(string writerMail,string writerPassword);
        void WriterRegister(string writerName, string writerSurName, string writerAbout,string writerMail,string Title, string writerPassword, bool writerStatus);

    }
}
