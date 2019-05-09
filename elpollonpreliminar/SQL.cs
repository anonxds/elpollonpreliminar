
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elpollonpreliminar
{
    class SQL
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter db;

        private void setcon()
        {
            con = new SqlConnection("Data Source=SETH\\SQLEXPRESS;Initial Catalog=tiendita; Integrated security=true;");
        }
        public void Exe(String query)
        {
                      setcon();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void ExportDataTableToPdf(string filename, List<string> _nombre, List<int> _cantidad,List<int> _precio,Label lblprecio)
        {

            var saveFilediloge = new SaveFileDialog();
            saveFilediloge.FileName = filename;
            saveFilediloge.DefaultExt = ".pdf";
            if (saveFilediloge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFilediloge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A5, 10f, 10f, 10f, 0f);
                    PdfPTable titulo = new PdfPTable(1);
                    PdfPTable artiulos = new PdfPTable(3);
                    PdfPTable precio = new PdfPTable(1);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    titulo.AddCell(GetCell("EL POLLON " + "\n" + "Hora: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm")  + "\n XXXXXXXXXXXXXXXXXXXXXXXXXXXXX", PdfPCell.ALIGN_CENTER));

                    artiulos.AddCell(GetCell("Nombre \n" + string.Join("\n", _nombre), PdfPCell.ALIGN_LEFT));
                    artiulos.AddCell(GetCell("Cantidad \n" + string.Join("X \n ", _cantidad), PdfPCell.ALIGN_CENTER));
                    artiulos.AddCell(GetCell("Precio \n" + string.Join("\n ", _precio), PdfPCell.ALIGN_RIGHT));
                    precio.AddCell(GetCell("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX \n" + "Total = " + lblprecio.Text, Element.ALIGN_CENTER));
                    pdfdoc.Add(titulo);
                    pdfdoc.Add(artiulos);
                    pdfdoc.Add(precio);

                    pdfdoc.Close();
                    stream.Close();
                }
            }

        }
        //
        public PdfPCell GetCell(string text, int ali)
        {
            Phrase titulo = new Phrase();
            PdfPCell cell = new PdfPCell(new Phrase(text, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
            cell.Padding = 0;
            cell.HorizontalAlignment = ali;
            cell.Border = PdfPCell.NO_BORDER;
            return cell;
        }
        public string getdata(string query, string dato)
        {
            setcon();
            //         con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = query;
            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();

            string userRole = string.Empty;
            while (reader.Read())
            {
                userRole = reader[dato].ToString();

            }
            con.Close();
            return userRole;
        }
        public void populate(ComboBox cb, string query, string type)
        {
            setcon();
            cb.Items.Clear();
            con.Open();


            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cb.Items.Add(dr[type]).ToString();
            }
            con.Close();

        }
        public void descripcion(ComboBox cb, Label lblprecio)
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from inventarioP where nombre = '" + cb.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            //
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblprecio.Text = "Precio " + dr["precio"].ToString();
            }
            con.Close();
        }
    }
}

