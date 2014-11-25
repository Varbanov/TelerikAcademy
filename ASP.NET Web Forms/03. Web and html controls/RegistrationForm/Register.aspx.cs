using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            this.RegisterForm.Visible = false;
            var nameMarkup = "<br />" + Server.HtmlEncode(this.TextBoxFirstName.Text) + " " + Server.HtmlEncode(this.TextBoxLastName.Text);
            var facultyMarkup = "<br />" + Server.HtmlEncode(this.TextBoxFacultyNumber.Text);
            var universityMarkup = "<br />" + Server.HtmlEncode(this.DropDownUniversity.SelectedValue);

            var specialtyMarkup = "<br />" + Server.HtmlEncode(this.DropDownSpecialty.SelectedValue);

            var coursesMarkup = new HtmlGenericControl("div");

            foreach (ListItem item  in this.ListBoxCourses.Items)
            {
                if (item.Selected)
                {
                    coursesMarkup.InnerHtml += string.Format("<br /> {0}", Server.HtmlEncode(item.Value));
                }
            }


            this.Response.Write(nameMarkup + facultyMarkup + universityMarkup + specialtyMarkup + coursesMarkup.InnerHtml);

        }
    }
}