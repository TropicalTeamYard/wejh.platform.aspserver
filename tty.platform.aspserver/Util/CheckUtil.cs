﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tty.Model;
using System.Text.RegularExpressions;

namespace tty.Util
{
    public static class CheckUtil
    {
        public static bool Username(string username,UserType userType) 
        {
            if (userType == UserType.WEJH)
            {
                return true;
            }
            else 
            {
                if (username.Length >= 2 && username.Length <= 10)
                {
                    string except = @"!@#$%^&*()_+-=,./\[]{}:;'<>?`~";
                    bool flag = true;
                    foreach (var item in except)
                    {
                        if (username.Contains(item))
                        {
                            flag = false;
                            break;
                        }
                    }
                    //为防止和其他冲突，不能设置账号为纯数字。
                    if (long.TryParse(username,out long re))
                    {
                        flag = false;
                    }
                    return flag;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool Password(string password)
        {
            if (password.Length == 32)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Nickname(string nickname)
        {
            if (nickname.Length >= 2 && nickname.Length <= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Email(string email)
        {
            return Regex.IsMatch(email, "^[a-z0-9A-Z]+[-|a-z0-9A-Z._]+@([a-z0-9A-Z]+(-[a-z0-9A-Z]+)?\\.)+[a-z]{2,}$");
        }
    }
}
