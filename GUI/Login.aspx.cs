﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;

using DAL;
using System.Diagnostics;

namespace GUI
{
    public partial class Login : System.Web.UI.Page
    {
        UserController UC = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["AuthToken"] != null)
            {
                string authToken = Request.Cookies["AuthToken"].Value;
                if (UC.getTokenUser(authToken))
                {
                    string script = $"alert(\" Valid Cookie!! \")";

                    ScriptManager.RegisterStartupScript(this, GetType(), "AlertScript", script, true);
                }
            }          
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;



            String authToken = UC.Login(userName, password);

     
            string script = $"alert(\"{authToken} \")";

            ScriptManager.RegisterStartupScript(this, GetType(), "AlertScript", script, true);
            HttpCookie authCookie = new HttpCookie("AuthToken", authToken);

            Response.Cookies.Add(authCookie);
        }
    }
}