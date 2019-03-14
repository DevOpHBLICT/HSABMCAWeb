using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;

namespace HSABMCAWeb
{
    public partial class _Default : Page
    {
        dsWebTableAdapters.PagesTableAdapter tadPages = new dsWebTableAdapters.PagesTableAdapter();
        dsWeb.PagesDataTable tblPages = new dsWeb.PagesDataTable();

        Button btn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            if (Request.QueryString["PageID"] != null)
            {
                tr01_MCD.Visible = false;
                tr01_BID.Visible = false;
                tr01_IMCA.Visible = false;
                tr01_DOLS.Visible = false;
                pnl99_Footer.Visible = true;
                string page_id = Request.QueryString["PageID"].ToString().ToLower();
                tadPages.Fill(tblPages, Page_ID: page_id);
                page_id = "home";
                foreach (dsWeb.PagesRow prow in tblPages)
                {
                    page_id = prow.Page_ID;
                    switch (prow.HeaderType)
                    {
                        case "MCD":
                            tr01_MCD.Visible = true;
                            break;
                        case "BID":
                            tr01_BID.Visible = true;
                            break;
                        case "IMCA":
                            tr01_IMCA.Visible = true;
                            break;
                        case "DOLS":
                            tr01_DOLS.Visible = true;
                            break;
                        default:
                            page_id = "home";
                            break;
                    }
                }
                Load_Page(page_id: page_id);
                return;
            }
            pnl99_Footer.Visible = false;
            img99_Next.Visible = false;
            pnl02_Page.Visible = false;
        }

        protected void btn01_Click(object sender, EventArgs e)
        {
            btn = (Button)sender;
            if (!btn.ToolTip.Equals(""))
            {
                Load_Page(page_id: btn.ToolTip);
                return;
            }

            tr01_MCD.Visible = false;
            tr01_BID.Visible = false;
            tr01_IMCA.Visible = false;
            tr01_DOLS.Visible = false;
            pnl99_Footer.Visible = true;

            switch (btn.ID)
            {
                case "btn01_MCD":
                    tr01_MCD.Visible = true;
                    btn.ToolTip = "Slide01";
                    Load_Page(page_id: btn.ToolTip);
                    pnl02_Page.Visible = true;
                    break;
                case "btn01_InfoMCD":
                    tr01_MCD.Visible = true;
                    break;
            }

        }
        protected void img02_Yes_Click(object sender, ImageClickEventArgs e)
        {
            Load_Page(page_id: img02_Yes.ToolTip);
        }

        protected void img02_No_Click(object sender, ImageClickEventArgs e)
        {
            Load_Page(page_id: img02_No.ToolTip);
        }

        protected void Load_Page(string page_id)
        {
            if (page_id.ToLower().Equals("home"))
            {
                Load_Home();
                return;
            }
            tadPages.Fill(tblPages, Page_ID: page_id);
            foreach(dsWeb.PagesRow prow in tblPages)
            {
                pnl02_Page.Visible = true;
                lbl02_Prompt.Text = prow.DisplayText;
                if (prow.IsYesPage_IDNull())
                {
                    tr02_Yes.Visible = false;
                    img02_Yes.ToolTip = "Home";
                }
                else
                {
                    tr02_Yes.Visible = true;
                    img02_Yes.ToolTip = prow.YesPage_ID;

                }
                if (prow.IsNoPage_IDNull())
                {
                    tr02_No.Visible = false;
                    img02_No.ToolTip = "Home";
                }
                else
                {
                    tr02_No.Visible = true;
                    img02_No.ToolTip = prow.NoPage_ID;
                }
                pnl02A_Prompt.Visible = tr02_Yes.Visible || tr02_No.Visible;
                if (prow.IsBackPage_IDNull())
                {
                    img99_Back.Visible = false;
                    img99_Back.ToolTip = "Home";
                }
                else
                {
                    img99_Back.Visible = true;
                    img99_Back.ToolTip = prow.BackPage_ID;
                }
                if (prow.IsNextPage_IDNull())
                {
                    img99_Next.Visible = false;
                    img99_Next.ToolTip = "Home";
                }
                else
                {
                    img99_Next.Visible = true;
                    img99_Next.ToolTip = prow.NextPage_ID;
                }
                return;
            }
            img99_Back.Visible = false;
            img99_Next.Visible = false;
            tr02_Yes.Visible = false;
            tr02_No.Visible = false;
            lbl02_Prompt.Text = page_id+ " page not found - please report to support ";
        }

        #region pnl99_Footer

        protected void img99_Home_Click(object sender, ImageClickEventArgs e)
        {
            Load_Home();
        }

        protected void Load_Home()
        { 
            tr01_MCD.Visible = true;
            tr01_BID.Visible = true;
            tr01_IMCA.Visible = true;
            tr01_DOLS.Visible = true;
            pnl99_Footer.Visible = false;
            img99_Next.Visible = false;
            pnl02_Page.Visible = false;

        }

        protected void img99_Next_Click(object sender, ImageClickEventArgs e)
        {
            Load_Page(page_id: img99_Next.ToolTip);
        }


        #endregion

        protected void img99_Back_Click(object sender, ImageClickEventArgs e)
        {
            Load_Page(page_id: img99_Back.ToolTip);

        }


    }
}