using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
  public  class Exportar
    {

        public void ExportarDgv(DataGridView dg)
        {

            try
            {
                SaveFileDialog Fichero = new SaveFileDialog(); // instancio el dialogo
                Fichero.Filter = "Excel (*.xls)|*.xls"; // filtro por esos tipos de extenciones xls=Excel
                Fichero.FileName = "ArchivoExportado"; //filtro por nombre
                if (Fichero.ShowDialog()==DialogResult.OK) // Si el usuario da ok al dialogo
                {
                    Microsoft.Office.Interop.Excel.Application app; //Declaro  la app de excel
                    Microsoft.Office.Interop.Excel.Workbook libro; // declaro el libro
                    Microsoft.Office.Interop.Excel.Worksheet hoja; // declaro la hoja de trabajo de excel
                    app= new Microsoft.Office.Interop.Excel.Application();//  instancio la app como objeto 
                    libro = app.Workbooks.Add(); //instancio el libro como librode trabajo de la app 
                    hoja =
                        (Microsoft.Office.Interop.Excel.Worksheet) libro.Worksheets.get_Item(1);
                    //recorro el DgvDatos rellenando la hoja de excel

                    for (int i = 0; i < dg.Rows.Count -1; i++) //recorro las filas de la grilla
                    {
                        for (int j = 0; j < dg.Columns.Count; j++) //Recorro las columnas de cada fila
                        {
                            if ((dg.Rows[i].Cells[j].Value ==null)==false) // Si en la fila y columna no hay datos 
                            {
                                hoja.Cells[i + 1, j + 1] = dg.Rows[i].Cells[j].Value.ToString(); //agrego lo que hay en la fila [i] y la columna [j] a la hoja de trab
                            }
                        }
                    }
                    libro.SaveAs(Fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libro.Close(true); 
                    app.Quit();
                    //cerramos los proc de excel que se craron
                }

            }
            catch (Exception ex )
            {

                MessageBox.Show("Error al exportar la informacion debido a " + ex.ToString());
            }
        }
    }
}
