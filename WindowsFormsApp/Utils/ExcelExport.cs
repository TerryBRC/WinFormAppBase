using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp.Utils
{
    class ExcelExport
    {
        public ExcelExport() { }

        public void ExportarDataGridViewAExcel(string Titulo1, string Titulo2oFecha, DataGridView gridView)
        {
            if (gridView.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet hoja = (Excel.Worksheet)xlWorkbook.Sheets[1];

            // Titulo1
            hoja.Cells[1, 1] = Titulo1;
            Excel.Range range = hoja.get_Range("A1", "G1");
            range.Merge(true);
            range.Font.Bold = true;
            range.Font.Size = 16;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.Font.Color = ColorTranslator.ToOle(Color.Blue);

            // Titulo2oFecha
            hoja.Cells[3, 1] = Titulo2oFecha;
            Excel.Range range2 = hoja.get_Range("A3", "G3");
            range2.Merge(true);
            range2.Font.Bold = true;
            range2.Font.Size = 14;
            range2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range2.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range2.Font.Color = ColorTranslator.ToOle(Color.Blue);

            // Insertar los encabezados de las columnas
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                if (gridView.Columns[i].Visible)
                {
                    hoja.Cells[5, i + 1] = gridView.Columns[i].HeaderText;
                    hoja.Cells[5, i + 1].Font.Bold = true;
                    hoja.Cells[5, i + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    hoja.Cells[5, i + 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    hoja.Cells[5, i + 1].Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                }
            }

            

            // Insertar los datos de las filas
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                for (int j = 0; j < gridView.Columns.Count; j++)
                {
                    if (gridView.Columns[j].Visible)
                    {
                        string cellValue = gridView.Rows[i].Cells[j].Value?.ToString() ?? "";
                        hoja.Cells[i + 6, j + 1] = cellValue;

                        // Formatear fechas si la celda es de tipo DateTime
                        if (gridView.Rows[i].Cells[j].Value is DateTime)
                        {
                            DateTime dateValue = (DateTime)gridView.Rows[i].Cells[j].Value;
                            hoja.Cells[i + 6, j + 1] = dateValue.ToString("M/d/yyyy");
                        }
                    }
                }
            }
            // Ajustar el ancho de las columnas automáticamente
            hoja.Columns.AutoFit();

            // Hacer visible Excel
            xlApp.Visible = true;
        }


    }
}
