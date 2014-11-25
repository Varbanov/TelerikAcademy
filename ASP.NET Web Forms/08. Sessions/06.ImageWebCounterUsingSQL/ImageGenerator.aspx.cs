using _06.ImageWebCounterUsingSQL.Data;
using _06.ImageWebCounterUsingSQL.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.ImageWebCounterUsingSQL
{
    public partial class ImageGenerator : System.Web.UI.Page
    {
        private VisitDbContext visitorsDbContext = new VisitDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            var visits = this.GetOrSaveVisits();
            this.GenerateBitmap(visits);
        }

        private int GetOrSaveVisits()
        {
            var visits = this.visitorsDbContext.Visits.FirstOrDefault();
            if (visits == null)
            {
                var newVisit = new Visit()
                {
                    VisitCount = 1
                };

                this.visitorsDbContext.Visits.Add(newVisit);
                this.visitorsDbContext.SaveChanges();
                return newVisit.VisitCount;
            }
            else
            {
                visits.VisitCount++;
                this.visitorsDbContext.SaveChanges();
                return visits.VisitCount;
            }
        }

        private void GenerateBitmap(int visits)
        {
            using (Bitmap bitmap = new Bitmap(110, 110))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.FillRectangle(Brushes.Black, 0, 0, 200, 200);
                    graphics.DrawString(visits.ToString(),
                        new Font("Consolas", 40),
                        new SolidBrush(Color.White),
                        new PointF(30, 25));

                    this.Response.ContentType = "image/jpeg";
                    bitmap.Save(this.Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}