using System;
using System.Runtime.InteropServices;

namespace COREBASE.COMMAND.PDF
{
    public class PDFView
    {
        // FPDF_UnlockDLL: Unlock the DLL with license key. Not used in evaluation version.
        [DllImport("fpdfview.dll")]
        public static extern void FPDF_UnlockDLL(String license_id, String unlock_code);

        // FPDF_LoadDocument: Load a document
        [DllImport("fpdfview.dll")]
        public static extern int FPDF_LoadDocument(String file_path, String password);

        // FPDF_GetPageCount: Get number of pages in the document
        [DllImport("fpdfview.dll")]
        public static extern int FPDF_GetPageCount();

        // FPDF_LoadPage: Load a page
        [DllImport("fpdfview.dll")]
        public static extern int FPDF_LoadPage(int pdf_doc, int page_index);

        // FPDF_GetPageWidth: Get page width in points
        [DllImport("fpdfview.dll")]
        public static extern double FPDF_GetPageWidth(int pdf_page);

        // FPDF_GetPageHeight: Get page width in points
        [DllImport("fpdfview.dll")]
        public static extern double FPDF_GetPageHeight(int pdf_page);

        // FPDF_RenderPage: Render a page onto specified area of a device
        [DllImport("fpdfview.dll")]
        public static extern void FPDF_RenderPage(System.IntPtr hdc, int pdf_page, int start_x,
        int start_y, int size_x, int size_y, int rotate, int flags);

        // FPDF_ClosePage: Close a loaded page
        [DllImport("fpdfview.dll")]
        public static extern int FPDF_ClosePage(int pdf_page);

        // FPDF_CloseDocument: Close a loaded document
        [DllImport("fpdfview.dll")]
        public static extern int FPDF_CloseDocument(int pdf_doc);

    }
}
