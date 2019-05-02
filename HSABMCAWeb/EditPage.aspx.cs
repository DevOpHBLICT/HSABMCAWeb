using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Web;

namespace HSABMCAWeb
{
    public partial class EditPage : System.Web.UI.Page
    {
        dsWebTableAdapters.PagesTableAdapter tadPages = new dsWebTableAdapters.PagesTableAdapter();
        dsWeb.PagesDataTable tblPages = new dsWeb.PagesDataTable();

        dsWebTableAdapters.LoginUserTableAdapter tadLogin = new dsWebTableAdapters.LoginUserTableAdapter();
        dsWeb.LoginUserDataTable tblLogin = new dsWeb.LoginUserDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (IsPostBack)
            {
                if (Session[GString.UserRole] != null)
                {
                    switch (Session[GString.UserRole].ToString())
                    {
                        case "admin":
                            return;

                        case "login":
                            return;

                    }
                }
            }
            pnl02_Select.Visible = false;
            pnl03_HTML.Visible = false;
            pnl01_Login.Visible = true;
            txt01_User.Text = "";
            txt01_Password.Text = "";
            Session[GString.UserRole] = "login";
        }

        protected void btn01_Login_Click(object sender, EventArgs e)
        {
            tadLogin.Fill(tblLogin, Login: txt01_User.Text.Trim(), Password: txt01_Password.Text.Trim());
            if (tblLogin.Rows.Count.Equals(1))
            {
                Session[GString.UserName] = txt01_User.Text;
                Session[GString.UserRole] = "admin";
                pnl01_Login.Visible = false;
                pnl02_Select.Visible = true;
                pnl03_HTML.Visible = false;
                return;
            }
            Session[GString.UserRole] = "login";
            Display_Error(ErrorMessage: "Login Failed");
        }

        //protected void ddl02_Page_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    pnl02_Select.Visible = false;
        //    txt03_Page_ID.Text = ddl02_Page.SelectedValue;
        //    txt03_Page_ID.ToolTip = txt03_Page_ID.Text;
        //    txt03_Page_ID.Enabled = false;
        //    pnl03_HTML.Visible = true;
        //    btn03_AddPage.Visible = false;
        //    btn03_Save.Visible = true;
        //    tadPages.Fill(tblPages, Page_ID: ddl02_Page.SelectedValue);
        //    foreach (dsWeb.PagesRow prow in tblPages)
        //    {
        //        lbl03_HTML.Text = prow.DisplayHTML.Trim();
        //        txt03_Prompt.Text = prow.DisplayHTML.Trim();
        //        txt03_Yes.Text = prow.IsYesPage_IDNull() ? "" : prow.YesPage_ID.Trim();
        //        txt03_No.Text = prow.IsNoPage_IDNull() ? "" : prow.NoPage_ID.Trim();
        //        txt03_Next.Text = prow.IsNextPage_IDNull() ? "" : prow.NextPage_ID.Trim();
        //        txt03_Back.Text = prow.IsBackPage_IDNull() ? "" : prow.BackPage_ID.Trim();
        //        ddl03_Header.SelectedValue = prow.IsHeaderTypeNull() ? "" : prow.HeaderType.Trim();
        //    }
        //    txt03_Yes.ToolTip = txt03_Yes.Text;
        //    txt03_No.ToolTip = txt03_No.Text;
        //    txt03_Next.ToolTip = txt03_Next.Text;
        //    txt03_Back.ToolTip = txt03_Back.Text;
        //    ddl03_Header.ToolTip = ddl03_Header.SelectedValue;
        //}

        protected void btn02_New_Click(object sender, EventArgs e)
        {
            pnl02_Select.Visible = false;
            txt03_Page_ID.Text = "";
            txt03_Page_ID.Enabled = true;
            pnl03_HTML.Visible = true;
            btn03_AddPage.Visible = true;
            btn03_Save.Visible = false;
            lbl03_HTML.Text = "";
            txt03_Prompt.Text = "";
            txt03_Yes.Text = "";
            txt03_No.Text = "";
            txt03_Next.Text = "";
            txt03_Back.Text = "";
            ddl03_Header.Text = "";
            txt03_Yes.ToolTip = txt03_Yes.Text;
            txt03_No.ToolTip = txt03_No.Text;
            txt03_Next.ToolTip = txt03_Next.Text;
            txt03_Back.ToolTip = txt03_Back.Text;
            ddl03_Header.ToolTip = ddl03_Header.SelectedValue;
            
        }

        protected void btn03_AddPage_Click(object sender, EventArgs e)
        {
            txt03_Page_ID.Text = txt03_Page_ID.Text.Trim();
            if (txt03_Page_ID.Text.Trim().Equals(""))
            {
                Display_Error("Page ID cannot be blank");
                return;
            }
            tadPages.Fill(tblPages, Page_ID: txt03_Page_ID.Text);
            if (tblPages.Rows.Count > 0)
            {
                Display_Error("Page ID already exists - duplicates not allowed");
                return;
            }
            if (ddl03_Header.SelectedValue.Trim().Equals(""))
            {
                Display_Error("Please select Header");
                return;
            }
            try
            {
                tadPages.Insert(Page_ID: txt03_Page_ID.Text,
                                DisplayHTML: txt03_Prompt.Text.Trim(),
                                YesPage_ID: txt03_Yes.Text,
                                NoPage_ID: txt03_No.Text,
                                NextPage_ID: txt03_Next.Text,
                                BackPage_ID: txt03_Back.Text,
                                HeaderType: ddl03_Header.SelectedValue);
                dg02_Pages.DataBind();
                pnl03_HTML.Visible = false;
                pnl02_Select.Visible = true;
            }
            catch (Exception ex)
            {
                Report_Exception(process_exception: ex);
            }

        }

        protected void btn03_Save_Click(object sender, EventArgs e)
        {
            txt03_Page_ID.Text = txt03_Page_ID.Text.Trim();
            if (txt03_Page_ID.Text.Trim().Equals(""))
            {
                Display_Error("Page ID cannot be blank");
                return;
            }
            tadPages.Fill(tblPages, Page_ID: txt03_Page_ID.Text);
            if (!txt03_Page_ID.Text.Trim().Equals(txt03_Page_ID.ToolTip))
            {
                if (tblPages.Rows.Count > 0)
                {
                    Display_Error("Page ID already exists - duplicates not allowed");
                    return;
                }
            }
            if (ddl03_Header.SelectedValue.Trim().Equals(""))
            {
                Display_Error("Please select Header");
                return;
            }
            try
            {
                tadPages.UpdateQuery(Page_ID: txt03_Page_ID.Text,
                                     DisplayHTML: txt03_Prompt.Text.Trim(),
                                     YesPage_ID: txt03_Yes.Text,
                                     NoPage_ID: txt03_No.Text,
                                     NextPage_ID: txt03_Next.Text,
                                     BackPage_ID: txt03_Back.Text,
                                     HeaderType: ddl03_Header.Text,
                                     Original_Page_ID: txt03_Page_ID.ToolTip);
                dg02_Pages.DataBind();
                pnl03_HTML.Visible = false;
                pnl02_Select.Visible = true;
            }
            catch (Exception ex)
            {
                Report_Exception(process_exception: ex);
            }
        }

        protected void btn03_Cancel_Click(object sender, EventArgs e)
        {
            pnl02_Select.Visible = true;
            dg02_Pages.DataBind();
            pnl03_HTML.Visible = false;
        }

        protected void Display_Error(string ErrorMessage)
        {
            CustomValidator cval = new CustomValidator();
            cval.ErrorMessage = ErrorMessage;
            cval.IsValid = false;
            this.Validators.Add(cval);
        }

        protected void Report_Exception(Exception process_exception)
        {
            Exception varexception = process_exception;

            string errorMessage = string.Empty;

            while (varexception != null)
            {

                errorMessage += varexception.ToString();

                varexception = varexception.InnerException;
            }
            CustomValidator cvalSend = new CustomValidator();
            cvalSend.ErrorMessage = errorMessage;
            cvalSend.IsValid = false;
            this.Validators.Add(cvalSend);
        }

        protected void dg02_Pages_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnl02_Select.Visible = false;
            txt03_Page_ID.Text = dg02_Pages.SelectedDataKey.Value.ToString();
            txt03_Page_ID.ToolTip = txt03_Page_ID.Text;
            txt03_Page_ID.Enabled = false;
            pnl03_HTML.Visible = true;
            btn03_AddPage.Visible = false;
            btn03_Save.Visible = true;
            tadPages.Fill(tblPages, Page_ID: txt03_Page_ID.Text);
            foreach (dsWeb.PagesRow prow in tblPages)
            {
                lbl03_HTML.Text = prow.DisplayHTML.Trim();
                txt03_Prompt.Text = prow.DisplayHTML.Trim();
                txt03_Yes.Text = prow.IsYesPage_IDNull() ? "" : prow.YesPage_ID.Trim();
                txt03_No.Text = prow.IsNoPage_IDNull() ? "" : prow.NoPage_ID.Trim();
                txt03_Next.Text = prow.IsNextPage_IDNull() ? "" : prow.NextPage_ID.Trim();
                txt03_Back.Text = prow.IsBackPage_IDNull() ? "" : prow.BackPage_ID.Trim();
                ddl03_Header.SelectedValue = prow.IsHeaderTypeNull() ? "" : prow.HeaderType.Trim();
            }
            txt03_Yes.ToolTip = txt03_Yes.Text;
            txt03_No.ToolTip = txt03_No.Text;
            txt03_Next.ToolTip = txt03_Next.Text;
            txt03_Back.ToolTip = txt03_Back.Text;
            ddl03_Header.ToolTip = ddl03_Header.SelectedValue;
        }
    }
}